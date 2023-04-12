
using HotelManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;



namespace Hotel_Management_Project.Controllers
{
    public class LOGINController : Controller
    {
        // GET: Login
        HotelManagementDBEntities2 db = new HotelManagementDBEntities2();
        public ActionResult IndexReceptionist()
        {
            return View();
        }
        [HttpPost]

        public ActionResult IndexReceptionist(RECEPTIONIST st)
        {

            {
                
                var recep = db.RECEPTIONISTs.Where(model => model.Mail_ID == st.Mail_ID && model.Password == st.Password).FirstOrDefault();
                if (recep != null)
                {
                    //   We will show this on dashboard if successfully run
                    Session["UserId"] = st.Recp_ID.ToString();
                    Session["Staff_name"] = st.Mail_ID.ToString();
                    TempData["LoginSuccessMessage"] = "<script>alert('Login Successfullly')</script>";
                    

                  return RedirectToAction("IndexReceptionist", "DASHBOARD");

                }
            }

            ViewBag.ErrorMessage = "<script>alert('Username and password is invalid')</script>";
            return View();
       }
        public ActionResult IndexManager()
        {
            return View();
        }

        [HttpPost]

        public ActionResult IndexManager(MANAGER ma)
        {

            var recep = db.MANAGERs.Where(model => model.Mail_ID == ma.Mail_ID && model.Password == ma.Password).FirstOrDefault();
            if (recep != null)
            {
                //   We will show this on dashboard if successfully run

                Session["UserId"] = ma.Mana_ID.ToString();
                Session["Staff_name"] = ma.Mail_ID.ToString();
                TempData["LoginSuccessMessage"] = "<script>alert('Login Successfullly')</script>";
                return RedirectToAction("IndexManager", "DashBoard");
            }
           ViewBag.ErrorMessage = "<script>alert('Username and password is invalid')</script>";
            return View();
        }



        public ActionResult IndexOwner()
        {
            return View();
        } 
        [HttpPost]

        public ActionResult IndexOwner(OWNER owa)
        {
            var recep = db.OWNERs.Where(model => model.Mail_ID == owa.Mail_ID && model.Password == owa.Password).FirstOrDefault();
            if (recep != null)
           {
                //   We will show this on dashboard if successfully run
               Session["UserId"] = owa.Own_ID.ToString();
                Session["owner_Email"] = owa.Mail_ID.ToString();
                TempData["LoginSuccessMessage"] = "<script>alert('Login Successfullly')</script>";
                return RedirectToAction("IndexOwner", "DashBoard");
            }
            ViewBag.ErrorMessage = "<script>alert('Username and password is invalid')</script>";
            return View();
        }
    }
}