using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Organization.Data;
using Organization.Data.Entity;
using Organization.Data.Interfaces;
using Organization.Data.Repositories;
using Organization.Models;
using System.Diagnostics;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Organization.Controllers
{
	public class OrganizationController(ILogger<OrganizationController> logger, IOrganizationService organizationService) : Controller
	{
		private readonly ILogger<OrganizationController> _logger = logger;
		private readonly IOrganizationService _organizationService = organizationService;

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
					ParentId = division.ParentId,
                });
            }
            return View(organization);
		}

        public async Task<IActionResult> Add()
		{
			var divisionList = await _organizationService.GetAllAsync();
			ViewBag.ParentId = new SelectList(divisionList, "Name", "Name");
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Add(OrganizationViewModel model)
		{
			if (ModelState.IsValid)
			{
				if (!String.IsNullOrEmpty(model.ParentId))
				{
					var parent = await _organizationService.GetByNameAsync(model.ParentId);
                    OrganizationEntity entity = new()
                    {
                        Name = model.Name,
                        Status = model.Status,
                        ParentId = model.ParentId,
						Parent = parent
                    };
                    await _organizationService.CreateAsync(entity);
                }
				else
				{
                    OrganizationEntity entity = new()
                    {
                        Name = model.Name,
                        Status = model.Status,
                        ParentId = model.ParentId,
                    };
                    await _organizationService.CreateAsync(entity);
                }
				

				return Redirect("Index");
			}
			else
			{
				return View();
			}
		}

		public async Task<IActionResult> Synchronize()
		{
			string jsonString = await System.IO.File.ReadAllTextAsync("filePath.json");
			var divisionEntity = JsonSerializer.Deserialize<List<OrganizationEntity>>(jsonString, new JsonSerializerOptions { ReferenceHandler = ReferenceHandler.Preserve });

			if (divisionEntity != null)
				await _organizationService.SynchronizeAsync(divisionEntity);

			return RedirectToAction("Index");
		}
	}
}
