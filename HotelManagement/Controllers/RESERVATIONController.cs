using HotelManagement.Models;
using HotelManagement.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelManagement.Controllers
{
  
    public class RESERVATIONController : Controller
    {
        // GET: MyCustomer
        //private HotelManagementDBEntities2 ObjHotelDbEntities;
        //public RESERVATIONController()
        //{
        //    ObjHotelDbEntities = new HotelManagementDBEntities2();
        //}


        //private _iallrepository<reservation> interfaceobj;

        //public RESERVATIONController()
        //{
        //    this.interfaceobj = new AllRepository<Reservation>();
        //}
        private _IAllRepository<Reservation> interfaceobj;
        public RESERVATIONController()
        {
            this.interfaceobj = new AllRepository<Reservation>();

        }
        public ActionResult Index()
        {
            return View(from m in interfaceobj.GetModel() select m);
        }


        
        public ActionResult Create()
        {

            HotelManagementDBEntities2 db = new HotelManagementDBEntities2();
            //var list = new List<string>();
            //list.Add("Double_Bed DULEX");
            //list.Add("Single_Bed DULEX");
            //list.Add("Double_Bed Non-AC");
            //list.Add("Single_Bed Non-AC");
            //ViewData["Room_Type"] = new SelectList(list, "Room_ID");

            var roomtype = db.ROOMs.ToList();
            ViewBag.room_type = new SelectList(roomtype, "room_id", "room_type"); 

            var staffname  = db.RECEPTIONISTs.ToList();
            ViewBag.Staff_Name = new SelectList(staffname, "Recp_ID", "Employee_Name");

            var Guestname = db.Guests.ToList();
            ViewBag.Guest_Name = new SelectList(Guestname, "Guest_ID", "Guest_name");

            return View();
        }
        [HttpPost]
        public ActionResult Create(Reservation collection)
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
            var RoomType = db.ROOMs.ToList();
            ViewBag.Room_Type = new SelectList(RoomType, "Room_ID", "Room_Type");

            var staffname = db.RECEPTIONISTs.ToList();
            ViewBag.Staff_Name = new SelectList(staffname, "Recep_ID", " Employee_Name");

            var Guestname = db.Guests.ToList();
            ViewBag.Guest_Name = new SelectList(Guestname, "Guest_ID", "Guest_name");

            Reservation c = interfaceobj.GetModelById(id);
            return View(c);
        }
        [HttpPost]
        public ActionResult Edit(int id, Reservation collection)
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
            Reservation D = interfaceobj.GetModelById(id);
            return View(D);
        }
        [HttpPost]
        public ActionResult Delete(int id, Reservation collection)
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