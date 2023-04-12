using HotelManagement.Models;
using HotelManagement.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelManagement.Controllers
{
    public class DEPARTMENTController : Controller
    {
        // GET: MyCustomer

        private _IAllRepository<DEPARTMENT> interfaceobj;

        public DEPARTMENTController()
        {
            this.interfaceobj = new AllRepository<DEPARTMENT>();
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
        public ActionResult Create(DEPARTMENT collection)
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
            DEPARTMENT c = interfaceobj.GetModelById(id);
            return View(c);
        }
        [HttpPost]
        public ActionResult Edit(int id, DEPARTMENT collection)
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
            DEPARTMENT D = interfaceobj.GetModelById(id);
            return View(D);
        }
        [HttpPost]
        public ActionResult Delete(int id, DEPARTMENT collection)
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