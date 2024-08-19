using Organization.Data.Entity;

namespace Organization.Data.Interfaces
{
	public interface IOrganizationService
	{

		Task<IEnumerable<OrganizationEntity>> GetAllAsync();
		Task<OrganizationEntity> GetByNameAsync(string name);
		Task<OrganizationEntity> CreateAsync(OrganizationEntity entity);
		Task<OrganizationEntity> SynchronizeAsync(OrganizationEntity entity);
	}
}
