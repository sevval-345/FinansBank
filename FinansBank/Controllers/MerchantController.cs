using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Web;
using System.Web.Mvc;
using FinansBank.Models.Entity;
using PagedList;

namespace FinansBank.Controllers
{
    public class MerchantController : Controller
    {
        // GET: Merchant
        mvcfinansEntities2 db = new mvcfinansEntities2();
        public ActionResult Index(int page = 1)
        {
            //var value = db.Merchant.ToList();
            var value = db.Merchant.ToList().ToPagedList(page, 4);
            return View(value);
        }

       

        [HttpGet]
        public ActionResult NewMerchant() 
        {
            List<SelectListItem> values = (from i in db.Customer.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.CustomerName,
                                               Value = i.CustomerID.ToString()       
                                           }).ToList();
            ViewBag.vl= values;
            return View();
        }

        [HttpPost]
        public ActionResult NewMerchant(Merchant p1)
        {
            
            var ct = db.Customer.Where(m => m.CustomerID == p1.Customer.CustomerID).FirstOrDefault();
            p1.Customer = ct;
            db.Merchant.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
        public ActionResult DELETE(int id)
        {
            var merchant = db.Merchant.Find(id);
            db.Merchant.Remove(merchant);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult MerchantImport(int id)
        {
            var mt = db.Merchant.Find(id);
            return View("MerchantImport", mt);
        }

        public ActionResult UPDATE(Merchant p1)
        {
            var mt = db.Merchant.Find(p1.MerchanID);
            mt.MerchantName = p1.MerchantName;
            mt.Adress = p1.Adress;
            mt.Telephone = p1.Telephone;
            mt.VergiNo = p1.VergiNo;
            db.SaveChanges();
            return RedirectToAction("Index");
        }



    }
}