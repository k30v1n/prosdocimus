using Microsoft.AspNetCore.Mvc;

namespace prosdocimus.Controllers
{
    [Route("/")]
    public class StatusController : Controller
    {
        [HttpGet()]
        public IActionResult Index()
        {
            return Json(new
            {
                status = "running"
            });
        }
    }
}