using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Organization.Data.Entity
{
	public class OrganizationEntity
	{
		[Key]
		public string Name { get; set; }
		public string Status {  get; set; }
		public string? Division { get; set; }
	}
}
