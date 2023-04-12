using HotelManagement.Models;
using HotelManagement.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelManagement.Controllers
{
    public class ROOMController : Controller
    {

        // GET: GUEST
        private _IAllRepository<ROOM> interfaceobj;
        public ROOMController()
        {
            this.interfaceobj = new AllRepository<ROOM>();

        }
        public ActionResult Index()
        {
            return View(from m in interfaceobj.GetModel() select m);
        }
        public ActionResult Index1()
        {
            return View(from m in interfaceobj.GetModel() select m);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(ROOM collection)
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
            ROOM g = interfaceobj.GetModelById(id);

            return View(g);
        }
        [HttpPost]
        public ActionResult Edit(int id, ROOM collection)
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
            ROOM D = interfaceobj.GetModelById(id);
            return View(D);
        }
        [HttpPost]
        public ActionResult Delete(int id, ROOM collection)
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