using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using travel.Manager;

namespace travel.Controllers
{
    public class DetailController : Controller
    {
        // GET: Detail
        public ActionResult Index(int tourId)
        {
            var detail = TourDetailManager.Instance.TourGetDetail(tourId);
            if (detail == null) 
                return RedirectToAction("NotFound", "Error"); //---Trường hợp dữ liệu bị null.
            return View(detail);
        }
    }
}