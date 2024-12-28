using Biskfarm.DAL;
using Biskfarm.Services;
using Microsoft.AspNetCore.Mvc;

namespace BiskfarmWebApp.Controllers
{
    public class RouteWiseSalesDatabaseController : Controller
    {
        private readonly BiskfarmContext db;
        OutletWiseSalesDatabaseServices services = new OutletWiseSalesDatabaseServices();
        public RouteWiseSalesDatabaseController(BiskfarmContext _db)
        {
            db= _db;
        }
        public IActionResult Index()
        {
            var outlet = services.LoadingOutletList(db);
            return View(outlet);
        }
    }
}
