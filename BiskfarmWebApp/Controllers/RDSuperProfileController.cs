using Biskfarm.DAL;
using Biskfarm.DAL.Model;
using Biskfarm.Services;
using BiskfarmWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BiskfarmWebApp.Controllers
{
    public class RDSuperProfileController : Controller
    {
        private readonly BiskfarmContext db;
        RDSSuperProfileServices rdsServices = new RDSSuperProfileServices();
        public RDSuperProfileController(BiskfarmContext _db)
        {
            db = _db;
        }
        public IActionResult Index()
        {
            return View(rdsServices.GetAll(db));
        }

        public IActionResult RDSuperProfileList()
        {
            return View();
        }

        public IActionResult View(int id)
        {
            var rds= rdsServices.GetProfileById(db,id);
            return View(rds);
        }
        public IActionResult Create()
        {
            var inputServices = rdsServices.GetRDSSuperProfileInputParameters(db);

            return View(inputServices);
        }

        [HttpPost]
        public IActionResult Create(RDSSuperProfileVM profile)
        {
            //foreach(var dst in  distributorData)
            //{

            //}
            var inputServices = rdsServices.GetRDSSuperProfileInputParameters(db);

            return View();
        }

        [HttpPost]
        public JsonResult GetData(RDSSuperProfileVM profileVM)
        {
            bool rel= rdsServices.SaveRDSSuperProfile(db, profileVM);
            if(rel)
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
