using Organization.Data.Entity;
using Organization.Data.Interfaces;

namespace Organization.Data.Services
{
	public class OrganizationService(IRepository<OrganizationEntity> repository) : IOrganizationService
	{
		private readonly IRepository<OrganizationEntity> _repository = repository;

        public async Task<IEnumerable<OrganizationEntity>> GetAllAsync() 
		{
			return await _repository.GetAllAsync();
		}

        public IEnumerable<OrganizationEntity> GetAllChildrenByParentName(string name)
        {
            return _repository.GetAllChildrenByParentName(name);
        }

        public async Task<OrganizationEntity> CreateAsync(OrganizationEntity entity)
		{
			return await _repository.CreateAsync(entity);
		}

		public async Task<OrganizationEntity> SynchronizeAsync(IEnumerable<OrganizationEntity> entity)
		{
			return await _repository.SynchronizeAsync(entity);
		}

		public async Task<OrganizationEntity> GetByNameAsync(string name)
		{
			return await _repository.GetByNameAsync(name);
		}
	}
}
