using Biskfarm.DAL;
using Biskfarm.DAL.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace BiskfarmWebApp.Controllers
{
    public class AccountController : Controller
    {
		private IConfiguration configuration;
		private readonly BiskfarmContext db;
		private const string SessionFirstName = "USP_FIRST_NAME";
		private const string SessionUserID = "USP_USER_ID";
		public AccountController(BiskfarmContext _db, IConfiguration _con)
		{
			db = _db;
			configuration = _con;
		}
		public IActionResult Index()
        {
            ViewBag.Year = DateTime.Now.Year;

            return View();
        }
		private string GetConnectionString()
		{
			return this.configuration.GetConnectionString("dbBiskfarm");
		}

		[HttpPost]
        public IActionResult Login(string userId,string password)
        {
			using (SqlConnection con = new SqlConnection(GetConnectionString()))
			{
				//using (SqlCommand cmd = new SqlCommand())
				{
					con.Open();
					string qry = "SELECT USP_USER_ID, USP_FIRST_NAME, USP_PSWD, USP_GROUP_CODE, USERGROUPID, ISNULL(USP_MAILID, '') USP_MAILID,USP_USER_IDN FROM dbo.VW_USER_LOGIN where usp_user_id = '" + userId + "' and usp_pswd = '" + password + "' and ISNULL(ACTIVE,'N')= 'Y'";
					



					SqlCommand cmd1 = new SqlCommand(qry, con);
					cmd1.CommandType = CommandType.Text;
					
					using (SqlDataReader reader = cmd1.ExecuteReader())
					{
						if (reader.Read())
						{
							string USP_USER_ID = reader["USP_USER_ID"].ToString();
							string USP_FIRST_NAME = reader["USP_FIRST_NAME"].ToString();
							HttpContext.Session.SetString("UserName", USP_FIRST_NAME);
							HttpContext.Session.SetString("SO_ID",(USP_USER_ID));

							return Json("Success");
						}
						else
						{
							return Json("UserName and Password incorrect");
						}

					}
				}
			}
				

			
        }
    }
}
