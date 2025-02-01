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
        private IConfiguration configuration;

        public RDSuperProfileController(BiskfarmContext _db, IConfiguration _con)
        {
            db = _db;
            configuration = _con;   

        }
        public IActionResult Index()
        {
			if (HttpContext.Session.GetString("UserName") != null)
			{
                ViewBag.UserName = HttpContext.Session.GetString("UserName");
                ViewBag.SO_ID = HttpContext.Session.GetString("SO_ID");
                return View(rdsServices.GetAll(db, ViewBag.SO_ID));
			}
            else
            {
                return RedirectToAction("Index", "Account");
            }
        }

        public IActionResult RDSuperProfileList()
        {
            return View();
        }

        public IActionResult View(int id)
        {
            var rds= rdsServices.GetProfileById(db,id,GetConnectionString());
            return View(rds);
        }
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("UserName") != null)
            {
                
                ViewBag.UserName = HttpContext.Session.GetString("UserName");
                ViewBag.SO_ID = HttpContext.Session.GetString("SO_ID");
                var inputServices = rdsServices.GetRDSSuperProfileInputParameters(db, ViewBag.SO_ID,GetConnectionString());

                return View(inputServices);
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }
        }

        private string GetConnectionString()
        {
            return this.configuration.GetConnectionString("dbBiskfarm");
        }

        [HttpPost]
        public IActionResult Create(RDSSuperProfileVM profile)
        {
            //foreach(var dst in  distributorData)
            //{

            //}
            //var inputServices = rdsServices.GetRDSSuperProfileInputParameters(db);

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
