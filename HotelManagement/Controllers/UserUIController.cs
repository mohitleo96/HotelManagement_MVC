using HotelManagement.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelManagement.Controllers
{
    public class UserUIController : Controller
    {
        // GET: UserUI
        

        private readonly HotelManagementDBEntities2 _context;
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult SearchResult(SearchRoomViewModel vm)
        {
            if(vm.DateFrom==null || vm.DateTo==null)
            { 
            return View(vm);
            }
            var roomsBooked = from b in _context.Reservations
                              where
                              ((vm.DateFrom >= b.CheckIN_Date) && (vm.DateFrom <= b.CheckOUT_Date)) ||
                               ((vm.DateTo >= b.CheckIN_Date) && (vm.DateTo <= b.CheckOUT_Date)) ||
                                ((vm.DateFrom <= b.CheckIN_Date) && (vm.DateTo >= b.CheckIN_Date) && (vm.DateTo <= b.CheckOUT_Date)) ||
                                  ((vm.DateFrom >= b.CheckIN_Date) && (vm.DateFrom <= b.CheckOUT_Date) && (vm.DateTo >= b.CheckOUT_Date)) ||
                                  ((vm.DateFrom <= b.CheckIN_Date) && (vm.DateTo >= b.CheckOUT_Date))
                              select b;
            var availableRooms = _context.ROOMs.Where(r => roomsBooked.Any(b => b.Room_ID == r.Room_ID))
            .Include(x => x.Room_Type)
            .ToList();
            return View(vm);
        }

        public ActionResult Resevation(int Id,DateTime DateFrom,DateTime DateTo)
        {
            Reservation reservation=new Reservation();
            reservation.CheckIN_Date = DateFrom;
            reservation.CheckOUT_Date = DateTo;
            reservation.Room_ID = Id;
            _context.Reservations.Add(reservation);
            _context.SaveChanges();
            return RedirectToAction("Index", "UserUI");
        }
        
    }
}