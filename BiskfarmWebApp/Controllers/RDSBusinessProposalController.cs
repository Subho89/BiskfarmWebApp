using Microsoft.AspNetCore.Mvc;

namespace BiskfarmWebApp.Controllers
{
    public class RDSBusinessProposalController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
