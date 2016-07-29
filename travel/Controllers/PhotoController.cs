using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using travel.Manager;

namespace travel.Controllers
{
    [OutputCache(Duration = int.MaxValue, VaryByParam = "*")]
    public class PhotoController : Controller
    {
        // GET: Photo
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ShowPhotoNguoiDungByReviewId(string tenIMG)
        {
            var imageData = PhotoManager.Instance.GetPhotoNguoiDungByReviewId(tenIMG);

            return File(imageData, "image/jpg");
        }
        [Route("anh-tour-category/{tenIMG}")]
        public ActionResult ShowPhotoTourCategory(string tenIMG)
        {
            var imageData = PhotoManager.Instance.GethotoTourCategory(tenIMG);

            return File(imageData, "image/jpg");
        }
        public ActionResult ShowAnhById(string tenIMG)
        {
            var imageData = AnhManager.Instance.GetAnhById(tenIMG);
            return File(imageData, "image/jpg");
        }
    }
}