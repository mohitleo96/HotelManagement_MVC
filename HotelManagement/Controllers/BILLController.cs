using HotelManagement.Models;
using HotelManagement.Models.DAL;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web.Mvc;

namespace HotelManagement.Controllers
{
    public class BILLController : Controller
    {
        // GET: MyCustomer

        private _IAllRepository<BILL> interfaceobj;

        public BILLController()
        {
            this.interfaceobj = new AllRepository<BILL>();
        }
        public ActionResult Index()
        {
            return View(from m in interfaceobj.GetModel() select m);
            HotelManagementDBEntities2 db = new HotelManagementDBEntities2();

            Reservation res = new Reservation();
            BILL bill = new BILL();
            if (res.Reservation_ID == bill.Reservation_ID)
            {

                if (EntityFunctions.DiffDays(res.CheckOUT_Date, res.CheckIN_Date) == 1)
                {
                    ViewBag.Total = 2000;
                }
                else if (EntityFunctions.DiffDays(res.CheckOUT_Date, res.CheckIN_Date) == 2)
                {
                    ViewBag.Total = 4000;
                }
                else if (EntityFunctions.DiffDays(res.CheckOUT_Date, res.CheckIN_Date) == 3)
                {
                    ViewBag.Total = 6000;
                }

            }

        }
        public ActionResult Create()
        {

            HotelManagementDBEntities2 db = new HotelManagementDBEntities2();

            var list = new List<string>();
            list.Add("Cash");
            list.Add("Online");
            ViewBag.payment = new SelectList(list, "Transaction_Type");
           ;



            var ReservationID = db.Reservations.ToList();
            ViewBag.ResevationID = new SelectList(ReservationID, "Reservation_ID", "Reservation_ID");

            return View();
        }
        [HttpPost]
        public ActionResult Create(BILL collection)
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
            var list = new List<string>();
            list.Add("Cash");
            list.Add("Online");
            ViewBag.payment = new SelectList(list, "Transaction_Type");

            var ReservationID = db.Reservations.ToList();
            ViewBag.ResevationID = new SelectList(ReservationID, "Reservation_ID", "Reservation_ID");

            BILL c = interfaceobj.GetModelById(id);
            return View(c);
        }
        [HttpPost]
        public ActionResult Edit(int id, BILL collection)
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
            BILL D = interfaceobj.GetModelById(id);
            return View(D);
        }
        [HttpPost]
        public ActionResult Delete(int id, BILL collection)
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