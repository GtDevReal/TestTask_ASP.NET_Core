using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Organization.Data;
using Organization.Data.Entity;
using Organization.Models;
using System.Diagnostics;

namespace Organization.Controllers
{
	public class OrganizationController : Controller
	{
		private readonly ILogger<OrganizationController> _logger;
		private OrganizationDbContext _db = new();

		public OrganizationController(ILogger<OrganizationController> logger)
		{
			_logger = logger;	
		}

		public IActionResult Index()
		{
			var divisionList = _db.Organization.ToList();
			List<OrganizationViewModel> organization = [];
			foreach (var division in divisionList)
			{
				organization.Add(new OrganizationViewModel
				{
					Name = division.Name,
					Status = division.Status,
					Division = division.Division,
				});
			}
			return View(organization);
		}

		public IActionResult Add()
		{
			var divisionList = _db.Organization.ToList();
			ViewBag.Division = new SelectList(divisionList, "Name", "Name");
			return View();
		}

		[HttpPost]
		public IActionResult Add(OrganizationViewModel model)
		{
			if (ModelState.IsValid && !_db.Organization.Where(x => x.Name == model.Name).Any())
			{
				OrganizationEntity entity = new()
				{
					Name = model.Name,
					Status = model.Status,
					Division = model.Division,
				};
				_db.Add(entity);
				_db.SaveChanges();
				return Redirect("Index");
			}
			else
			{
				return View();
			}
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
