using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using travel.Manager;
using travel.Common;

namespace travel.Controllers
{
    public class SearchTourController : Controller
    {
        // GET: SearchTour
        private const int pageSize = 10;
       
        /// <summary>
        /// Tìm  kiếm tour theo tỉnh thành
        /// </summary>
        /// <param name="textSearch"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index(string textSearch, int? page)
        {
            var lisitem = TourManager.Instance.GetTourByProvinceId(Setting.ProvinceId, textSearch).ToList();
            ViewBag.searchText = textSearch;
            ViewBag.CountTour = lisitem.Count();
            page = (page ?? 1);

            var ViewModels = lisitem.ToPagedList(page.Value, pageSize);

            return View("Index", ViewModels);
        }
    }
}