using Microsoft.AspNetCore.Mvc;

namespace OrganizationStatusUpdate.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class StatusUpdateController : ControllerBase
	{
		private OrganizationTestCreateContext _db = new();

		[HttpGet]
		public Dictionary<string, string> GetStatuses ()
		{
			var organization = _db.Organizations.ToList();
			Dictionary<string, string> statuses = [];

			foreach (var org in organization) 
			{
				statuses.Add(org.Name, org.Status);
			}
			return statuses;
		}
	}
}
