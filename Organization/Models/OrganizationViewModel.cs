using System.ComponentModel.DataAnnotations;

namespace Organization.Models
{
	public class OrganizationViewModel
	{
		[Display(Name = "Наименование")]
		[Required(ErrorMessage = "Вы не ввели наименование")]
		public string Name { get; set; }

		[Display(Name = "Статус")]
		public string Status { get; set; }

		[Display(Name = "Подразделение")]
		public string? ParentId { get; set; }

		public OrganizationViewModel? Parent { get; set; }

		public IEnumerable<OrganizationViewModel>? Children { get; set; }

	}
}
