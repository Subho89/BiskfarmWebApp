using Biskfarm.DAL;
using Biskfarm.DAL.Model;
using Biskfarm.Services;
using Microsoft.AspNetCore.Mvc;

namespace BiskfarmWebApp.Controllers
{
    public class HierarchyController : Controller
    {
        private readonly BiskfarmContext db;
        HierarchyServices services=new HierarchyServices();

        public HierarchyController(BiskfarmContext context)
        {
            db= context;
        }
        public IActionResult Index()
        {
            var hierarchies = services.GetAllHierarchy(db);
            return View(hierarchies);
        }


        public IActionResult Create()
        {
            return View();   
        }

        [HttpPost]
        public IActionResult Create(RDS_Hierarchy hierarchy)
        {
            services.AddHierarchy(hierarchy,db);

            return Json("Success");
        }
    }
}
