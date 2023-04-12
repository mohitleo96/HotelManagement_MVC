using HotelManagement.Models.DAL;
using HotelManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;



namespace HotelManagement.Controllers
{
    public class MANAGERController : Controller
    {
        // GET: Receptionist



        private _IAllRepository<MANAGER> interfaceobj;

        public MANAGERController()
        {
            this.interfaceobj = new AllRepository<MANAGER>();
        }



        public ActionResult Index()
        {
            return View(from m in interfaceobj.GetModel() select m);
        }

        // GET: Receptionist/Create
        public ActionResult Create()
        {
            return View();
        }
        // POST: Receptionist/Create
        [HttpPost]
        public ActionResult Create(MANAGER collection)
        {
            try
            {
                // TODO: Add insert logic here

                interfaceobj.InsertModel(collection);
                interfaceobj.Save();
                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }



        // GET: Receptionist/Edit/5
        public ActionResult Edit(int id)
        {
            MANAGER model = interfaceobj.GetModelById(id);
            return View(model);
        }



        // POST: Receptionist/Edit/5

        [HttpPost]
        public ActionResult Edit(MANAGER collection)
        {
            try
            {
                // TODO: Add update logic here
                interfaceobj.UpdateModel(collection);
                interfaceobj.Save();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }



        // GET: Receptionist/Delete/5
        public ActionResult Delete(int id)
        {
            MANAGER D = interfaceobj.GetModelById(id);
            return View(D);
        }



        // POST: Receptionist/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, MANAGER collection)
        {

            try
            {
                // TODO: Add delete logic here
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