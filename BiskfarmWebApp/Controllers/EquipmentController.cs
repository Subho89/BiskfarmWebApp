using Biskfarm.DAL;
using Biskfarm.Services;
using Microsoft.AspNetCore.Mvc;

namespace BiskfarmWebApp.Controllers
{
    public class EquipmentController : Controller
    {
        private readonly BiskfarmContext db;
        RDSDemoServices services=new RDSDemoServices();
        public EquipmentController(BiskfarmContext _db)
        {
            db=_db;
        }
        public IActionResult Index()
        {
            var lst = services.GetList(db);
            return View(lst);
        }

        //[HttpPost]
        //public string Create(List<Customer> cst)
        //{
        //    return "Success";
        //}
    }
}
