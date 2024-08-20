namespace Organization.Data.Interfaces
{
	public interface IRepository<T> where T	: class
	{
		Task<IEnumerable<T>> GetAllAsync();
		IEnumerable<T> GetAllChildrenByParentName(string name);
		Task<T> GetByNameAsync(string name);
		Task<T> CreateAsync(T entity);
		Task<T> SynchronizeAsync(IEnumerable<T> entity);
	}
}
