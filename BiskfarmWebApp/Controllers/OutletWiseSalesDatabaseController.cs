using Biskfarm.DAL;
using Biskfarm.DAL.Model;
using Biskfarm.Services;
using Microsoft.AspNetCore.Mvc;

namespace BiskfarmWebApp.Controllers
{
    public class OutletWiseSalesDatabaseController : Controller
    {
        private readonly BiskfarmContext db;
        OutletWiseSalesDatabaseServices services = new OutletWiseSalesDatabaseServices();
        List<OutletWiseSalesDatabase> databases = new List<OutletWiseSalesDatabase>(); 
        public OutletWiseSalesDatabaseController(BiskfarmContext _db)
        {
            db=_db;
        }
        public IActionResult Index()
        {
            databases = services.LoadingOutletList(db);
            return View(databases);
        }

        public JsonResult GetRSMData(SelectionVM selection)
        {
            //databases = services.LoadingOutletList(db);
            //var rsmLst=databases.Where(r=>r.RSM_NAME== rsmName).ToList().Distinct();

            return Json("");
        }

        public IActionResult GetRawData()
        {
            return PartialView();
        }
    }
}
