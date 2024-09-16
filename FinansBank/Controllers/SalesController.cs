using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinansBank.Models.Entity;
using PagedList;

namespace FinansBank.Controllers
{
    public class SalesController : Controller
    {
        // GET: Sales
        mvcfinansEntities2 db = new mvcfinansEntities2();

        public ActionResult Index(int page = 1)
        {
            //var value = db.Sales.ToList();
            var value = db.Sales.ToList().ToPagedList(page, 4);
            return View(value);
        }
    }
}