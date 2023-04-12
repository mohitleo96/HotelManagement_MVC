using HotelManagement.Models;
using HotelManagement.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelManagement.Controllers
{
    public class GUESTController : Controller
    {

        // GET: GUEST
        private _IAllRepository<Guest> interfaceobj;
        public GUESTController()
        {
            this.interfaceobj = new AllRepository<Guest>();

        }
        public ActionResult Index()
        {
            return View(from m in interfaceobj.GetModel() select m);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Guest collection)
        {
            try
            {
                interfaceobj.InsertModel(collection);
                interfaceobj.Save();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Edit(int id)
        {
            Guest g = interfaceobj.GetModelById(id);

            return View(g);
        }
        [HttpPost]
        public ActionResult Edit(int id, Guest collection)
        {
            try
            {
                interfaceobj.UpdateModel(collection);
                interfaceobj.Save();
                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }
        public ActionResult Delete(int id)
        {
            Guest D = interfaceobj.GetModelById(id);
            return View(D);
        }
        [HttpPost]
        public ActionResult Delete(int id, Guest collection)
        {
            try
            {
                interfaceobj.DeleteModel(id);
                interfaceobj.Save();
                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }
    }
}