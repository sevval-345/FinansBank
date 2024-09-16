using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinansBank.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace FinansBank.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Costomer
        mvcfinansEntities2 db = new mvcfinansEntities2(); // tabloları db nesnesinin içine attık
        public ActionResult Index(int page =1)
        {
            //var value = db.Customer.ToList();//costomer değişkeni Costomer tablosundaki verileri listeler.
            var value = db.Customer.ToList().ToPagedList(page, 4);
            return View(value);
        }

        [HttpGet]
        public ActionResult NewCustomer() 
        {
            return View();
        }



        [HttpPost]
        public ActionResult NewCustomer(Customer p1)
        {
            if (!ModelState.IsValid) 
            {
                return View("NewCustomer");
            }
            db.Customer.Add(p1);
            db.SaveChanges();
            return View();
        }
        public ActionResult DELETE(int id)
        {
            var customer = db.Customer.Find(id);
            db.Customer.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CustomerImport(int id)
        {
            var ct = db.Customer.Find(id);
            return View("CustomerImport", ct);
        }

        public ActionResult  UPDATE(Customer p1)
        {
            var ct = db.Customer.Find(p1.CustomerID);
            ct.CustomerName = p1.CustomerName;
            ct.CustomerSurname = p1.CustomerSurname;
            ct.E_mail = p1.E_mail;
            ct.Telephone = p1.Telephone;
            ct.Adress = p1.Adress;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}