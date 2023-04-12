using HotelManagement.Models;
using HotelManagement.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelManagement.Controllers
{
    public class INVENTORYController : Controller
    {
        // GET: MyCustomer

        private _IAllRepository<INVENTORY> interfaceobj;

        public INVENTORYController()
        {
            this.interfaceobj = new AllRepository<INVENTORY>();
        }
        public ActionResult Index()
        {
            return View(from m in interfaceobj.GetModel() select m);
        }
        public ActionResult Create()
        {
            HotelManagementDBEntities2 db = new HotelManagementDBEntities2();

            var staffname = db.MANAGERs.ToList();
            ViewBag.Staff_Name = new SelectList(staffname, "Mana_ID", "Employee_name");
            return View();
        }
        [HttpPost]
        public ActionResult Create(INVENTORY collection)
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

            HotelManagementDBEntities2 db = new HotelManagementDBEntities2();

            var staffname = db.MANAGERs.ToList();
            ViewBag.Staff_Name = new SelectList(staffname, "Mana_ID", "Employee_name");
            INVENTORY c = interfaceobj.GetModelById(id);
            return View(c);
        }
        [HttpPost]
        public ActionResult Edit(int id, INVENTORY collection)
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
            INVENTORY D = interfaceobj.GetModelById(id);
            return View(D);
        }
        [HttpPost]
        public ActionResult Delete(int id, INVENTORY collection)
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