using instagram.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace instagram.Controllers
{
    public class igController : Controller
    {
        static String SqlCon = ConfigurationManager.ConnectionStrings["SqlConnectionDB"].ConnectionString;
        SqlConnection con = new SqlConnection(SqlCon);
        // GET: ig

        public ActionResult Index(Class1 class1)
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Class1 class1)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    SqlCommand cmd = new SqlCommand("SP_Insta", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("Username", class1.Username);
                    cmd.Parameters.AddWithValue("Password", class1.Password);
                    con.Open();
                    var i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        TempData["Success"] = "";
                        return RedirectToAction("Login", "ig");
                    }
                }

            }
            catch (Exception ex)
            {
                con.Close();
            }
            return View();



        }

    }
}