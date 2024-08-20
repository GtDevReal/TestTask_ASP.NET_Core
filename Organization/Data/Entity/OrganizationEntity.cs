using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Organization.Data.Entity
{
	public class OrganizationEntity
	{
		[Key]
		public string Name { get; set; }

		public string Status {  get; set; }

		public string? ParentId { get; set; }

        [ForeignKey("ParentId")]
		public OrganizationEntity? Parent { get; set; }

		public IEnumerable<OrganizationEntity>? Children { get; set; }
    }
}
