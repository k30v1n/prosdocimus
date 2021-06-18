using Microsoft.AspNetCore.Mvc;

namespace app.Controllers
{
    [Route("/")]
    public class HomeController: Controller 
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok("Running");
        }
    }
}