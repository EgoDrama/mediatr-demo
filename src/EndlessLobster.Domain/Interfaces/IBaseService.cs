namespace EndlessLobster.Domain
{
	public interface IBaseService<T>
	{
		T Get(int id);
		void Save(T entity);
	}
}