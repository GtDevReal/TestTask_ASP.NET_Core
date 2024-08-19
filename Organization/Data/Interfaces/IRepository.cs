namespace Organization.Data.Interfaces
{
	public interface IRepository<T> where T	: class
	{
		Task<IEnumerable<T>> GetAllAsync();
		Task<T> GetByNameAsync(string name);
		Task<T> CreateAsync(T entity);
		Task<T> SynchronizeAsync(T entity);
	}
}
