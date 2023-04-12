using HotelManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelManagement.Controllers
{
  
    public class HomeeController : Controller
    {
        // GET: Homee

        public ActionResult Index()
        {
            return View();
        }
        //[Authorize(Roles ="Owner")]
        //public ActionResult getUserList()
        //{ 
        //    HotelManagementDBEntities2 db= new HotelManagementDBEntities2();
        //    var user=db.STAFFs.ToList();
        //    return View(user);
        //    }

        public ActionResult About()
        {
            return View();
        }
        
        public ActionResult Contact()
        {
            return View();
        }
    }
}