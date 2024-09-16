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
    public class TerminalController : Controller
    {
        // GET: Terminal
        mvcfinansEntities2 db = new mvcfinansEntities2();
        public ActionResult Index(int page=1)
        {
            //var value = db.Terminal.ToList();
            var value = db.Terminal.ToList().ToPagedList(page, 4);
            return View(value);
        }

        [HttpGet]
        public ActionResult NewTerminal() 
        {
            List<SelectListItem> values = (from i in db.Merchant.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.MerchantName,
                                               Value = i.MerchanID.ToString()
                                           }).ToList();
            ViewBag.vl = values;
            return View();

        }

        [HttpPost]
        public ActionResult NewTerminal(Terminal p1)
        {

            var mh = db.Merchant.Where(m => m.MerchanID == p1.Merchant.MerchanID).FirstOrDefault();
            p1.Merchant = mh;
            db.Terminal.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DELETE(int id)
        {
            var terminal = db.Terminal.Find(id);
            db.Terminal.Remove(terminal);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult TerminalImport(int id)
        {
            var tm = db.Terminal.Find(id);
            return View("TerminalImport", tm);
        }


        public ActionResult UPDATE(Terminal p1)
        {
            var tm = db.Terminal.Find(p1.TerminalID);
            tm.TerminalName = p1.TerminalName;
            tm.TerminalTypes = p1.TerminalTypes;
            tm.SeriouslyNo = p1.SeriouslyNo;
            tm.Situation = p1.Situation;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}