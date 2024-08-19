using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Organization.Data;
using Organization.Data.Entity;
using Organization.Data.Interfaces;
using Organization.Models;
using System.Diagnostics;
using System.Net.Http;

namespace Organization.Controllers
{
	public class OrganizationController : Controller
	{
		private readonly ILogger<OrganizationController> _logger;
		private readonly IOrganizationService _organizationService;

		public OrganizationController(ILogger<OrganizationController> logger, IOrganizationService organizationService)
		{
			_organizationService = organizationService;
			_logger = logger;	
		}

		public async Task<IActionResult> Index()
		{
			var divisionList = await _organizationService.GetAllAsync();
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

		public async Task<IActionResult> Add()
		{
			var divisionList = await _organizationService.GetAllAsync();
			ViewBag.Division = new SelectList(divisionList, "Name", "Name");
			return View();
		}

		[HttpPost]
		public IActionResult Add(OrganizationViewModel model)
		{
			if (ModelState.IsValid)
			{
				OrganizationEntity entity = new()
				{
					Name = model.Name,
					Status = model.Status,
					Division = model.Division,
				};
				_organizationService.CreateAsync(entity);

				return Redirect("Index");
			}
			else
			{
				return View();
			}
		}
	}
}
