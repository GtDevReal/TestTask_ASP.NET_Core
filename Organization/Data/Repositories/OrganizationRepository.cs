using Microsoft.EntityFrameworkCore;
using Organization.Data.Entity;
using Organization.Data.Interfaces;

namespace Organization.Data.Repositories
{
	public class OrganizationRepository : IRepository<OrganizationEntity>
	{
		private readonly OrganizationDbContext _context;

		public OrganizationRepository(OrganizationDbContext context) 
		{ 
			_context = context;
		}

		public async Task<IEnumerable<OrganizationEntity>> GetAllAsync()
		{
			return await _context.Organization.ToListAsync();
		}

		public async Task<OrganizationEntity> CreateAsync(OrganizationEntity entity)
		{
			_context.Organization.Add(entity);
			await _context.SaveChangesAsync();
			return entity;
		}

		public async Task<OrganizationEntity> SynchronizeAsync(OrganizationEntity entity)
		{
			_context.Organization.Add(entity);
			await _context.SaveChangesAsync();
			return entity;
		}

		public async Task<OrganizationEntity> GetByNameAsync(string name)
		{
			return await _context.Organization.FirstOrDefaultAsync(x => x.Name == name);
		}
	}
}
