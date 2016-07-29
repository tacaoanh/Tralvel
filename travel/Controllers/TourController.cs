using System.Web.Mvc;
using travel.Common;
using travel.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using travel.Common;

namespace travel.Controllers
{
    public class TourController : Controller
    {
        private const int PageSize = 6;
        // GET: Tour
        public ActionResult Index(int id, int? page)
        {
            var lst = TourManager.Instance.GetTourByCategoryId(id,"");
            ViewBag.CategoryId = id;
            ViewBag.Text = TempData["TourHot"];

            page = (page ?? 1);

            var ViewModels = lst.ToPagedList(page.Value, PageSize);

            return View("Index", ViewModels);
        }
        public ActionResult TourTinh(int id, int? page)
        {
            var lst = TourManager.Instance.GetTourByProvinceId(id, "");
            Setting.ProvinceId = id;           

            ViewBag.Tinh = id;
            page = (page ?? 1);

            var ViewModels = lst.ToPagedList(page.Value, PageSize);

            return View("TourTinh", ViewModels);
        }
    }
}