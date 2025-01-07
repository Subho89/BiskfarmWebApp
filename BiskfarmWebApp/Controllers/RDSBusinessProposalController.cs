using Biskfarm.DAL;
using Biskfarm.DAL.Model;
using Biskfarm.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace BiskfarmWebApp.Controllers
{
    public class RDSBusinessProposalController : Controller
    {
        private readonly BiskfarmContext db;
        RDSBusinessProposalServices rdsServices = new RDSBusinessProposalServices();

        public RDSBusinessProposalController(BiskfarmContext _context)
        {
            db=_context;    
        }
        public IActionResult Index()
        {
            var lst = rdsServices.GetAll(db);
            return View(lst);
        }

        public IActionResult Create()
        {
            var inputServices =  rdsServices.HeirarchyList(db);
            return View(inputServices);
        }

        public IActionResult View(int id)
        {
            var rds= rdsServices.GetRDSBusinessProposal(db,id);
            return View(rds);
        }

        [HttpPost]
        public JsonResult GetData(RDS_BUSINESS_PROPOSAL profileVM)
        {
            bool rel = rdsServices.SaveRDSBusinessProposal(db,profileVM);
            if (rel)
            {
                return Json("Data Saved");
            }
            else
            {
                return Json("Error");
            }

        }
    }
}
