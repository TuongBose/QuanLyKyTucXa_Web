﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnDBMS.Controllers
{
    public class HoaDonDienNuocController : Controller
    {
        // GET: HoaDonDienNuoc
        Models.QLKTXDataContext db = new Models.QLKTXDataContext();

        public ActionResult HoaDonDienNuoc()
        {
            return View(db.VIEW_HOADONDIENNUOCs);
        }
    }
}