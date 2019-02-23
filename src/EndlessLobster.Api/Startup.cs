using System.Linq;
using EndlessLobster.Domain;
using EndlessLobster.Domain.Models;
using EndlessLobster.Domain.Services;
using EndlessLobster.Repository;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimpleInjector;
using SimpleInjector.Integration.AspNetCore.Mvc;
using SimpleInjector.Lifestyles;

namespace EndlessLobster.Api
{
	public class Startup
	{
		private readonly Container _container = new Container();

		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
			IntegrateSimpleInjector(services);
			services.AddMediatR();
		}

		private void IntegrateSimpleInjector(IServiceCollection services)
		{
			_container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

			services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

			services.AddSingleton<IControllerActivator>(
				new SimpleInjectorControllerActivator(_container));
			services.AddSingleton<IViewComponentActivator>(
				new SimpleInjectorViewComponentActivator(_container));

			services.EnableSimpleInjectorCrossWiring(_container);
			services.UseSimpleInjectorAspNetRequestScoping(_container);
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			InitializeContainer(app);

			app.UseMvc();
		}

		private void InitializeContainer(IApplicationBuilder app)
		{
			// Add application presentation components:
			_container.RegisterMvcControllers(app);
			_container.RegisterMvcViewComponents(app);

			// Add application services. For instance:
			_container.RegisterSimilarTo<CustomerRepository>("EndlessLobster.Repository", "Repository");
			_container.RegisterSimilarTo<OrderService>("EndlessLobster.Domain.Services", "Service");
			_container.Register<ILog, Log>();

			// Allow Simple Injector to resolve services from ASP.NET Core.
			_container.AutoCrossWireAspNetComponents(app);
		}
	}

	public static class ContainerExtension
	{
		public static void RegisterSimilarTo<T>(this Container container, string theNamespace, string matchEnd)
		{
			var repositoryAssembly = typeof(T).Assembly;

			var registrations = repositoryAssembly
				.GetExportedTypes()
				.Where(x => x.Namespace.Contains(theNamespace))
				.Where(x => x.GetInterfaces().Any() && x.Name.EndsWith(matchEnd))
				.Select(x => new { Service = x.GetInterfaces().Single(), Implementation = x });

			foreach (var reg in registrations)
			{
				container.Register(reg.Service, reg.Implementation);
			}
		}
	}
}
