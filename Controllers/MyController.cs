using Microsoft.AspNetCore.Mvc;
using MyApp.Services;

namespace MyApp.Controllers
{
	[ApiController]
	[Route("/")]
	public class MyController : ControllerBase
	{
		private readonly IMyService _myService;

		public MyController(IMyService myService)
		{
			_myService = myService;
		}

		[HttpGet]
		public IActionResult GetMessage()
		{
			return Ok(_myService.GetMessage());
		}
	}
}
