using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Organization.Data.Entity;
using Organization.Data.Interfaces;

namespace Organization.Data.Repositories
{
	public class OrganizationRepository(OrganizationDbContext context) : IRepository<OrganizationEntity>
	{
		private readonly OrganizationDbContext _context = context;

        public IEnumerable<OrganizationEntity> GetAllChildrenByParentName(string name)
		{
			return _context.Organization.Where(x => x.ParentId == name);
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

		public async Task<OrganizationEntity> SynchronizeAsync(IEnumerable<OrganizationEntity> entity)
		{
			foreach (var item in entity)
			{
				var existDivision = await _context.Organization.FirstOrDefaultAsync(o => o.Name == item.Name);
				if (existDivision != null)
				{
					existDivision.Status = item.Status;
					if (existDivision.ParentId != item.ParentId)
					{
						var newParent = await _context.Organization.FirstOrDefaultAsync(x => x.ParentId == item.ParentId);
						existDivision.ParentId = item.ParentId;
						existDivision.Parent = newParent;
						_context.Organization.Update(existDivision);
					}
					_context.Organization.Update(existDivision);
				}
				else
				{
					var newDivision = new OrganizationEntity
					{
						Name = item.Name,
						ParentId = item.ParentId,
						Status = item.Status,
					};
					_context.Organization.Add(newDivision);
				}
				if (item.Children != null)
				{
					await SynchronizeAsync(item.Children);
				}

			}
			await _context.SaveChangesAsync();
			return entity.First();
		}

		public async Task<OrganizationEntity> GetByNameAsync(string name)
		{
			return await _context.Organization.FirstOrDefaultAsync(x => x.Name == name);
		}
	}
}
