using Organization.Data.Entity;
using Organization.Data.Interfaces;

namespace Organization.Data.Services
{
	public class OrganizationService : IOrganizationService
	{
		private readonly IRepository<OrganizationEntity> _repository;

		public OrganizationService(IRepository<OrganizationEntity> repository)
		{
			_repository = repository;
		}

		public async Task<IEnumerable<OrganizationEntity>> GetAllAsync() 
		{
			return await _repository.GetAllAsync();
		}

		public async Task<OrganizationEntity> CreateAsync(OrganizationEntity entity)
		{
			return await _repository.CreateAsync(entity);
		}

		public async Task<OrganizationEntity> SynchronizeAsync(OrganizationEntity entity)
		{
			return await _repository.SynchronizeAsync(entity);
		}

		public async Task<OrganizationEntity> GetByNameAsync(string name)
		{
			return await _repository.GetByNameAsync(name);
		}
	}
}
