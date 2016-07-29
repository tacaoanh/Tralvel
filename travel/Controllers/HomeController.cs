using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Web;
using System.Web.Mvc;
using travel.Manager;
using travel.Common;
using System.IO;
using System.Net.Http.Headers;
using PagedList;
using travel.Models;

namespace travel.Controllers
{
    
    public class HomeController : Controller
    {
        private static int pageSize = 20;
        public ActionResult Index()
        {  
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "";

            return View();
        }

        public ActionResult Tour()
        {
            ViewBag.Message = "Tour";

            return View();
        }
        public ActionResult TourHot()
        {
            ViewBag.Message = "Tour";

            return View();
        }
        public ActionResult Blog()
        {
            ViewBag.Message = "Tour";

            return View();
        }
        public ActionResult BlogDetail()
        {
            ViewBag.Message = "Tour";

            return View();
        }
        public ActionResult BookingTour()
        {
            ViewBag.Message = "Tour";

            return View();
        }
        public ActionResult News()
        {
            ViewBag.Message = "Tour";

            return View();
        }
        /// <summary>
        /// lấy danh sách các AboutUS
        /// </summary>
        /// <returns></returns>
        public ActionResult AboutUs()
        {
            try
            {
                var listItem = InformationManager.Instance.ListInformationGetByCode("about").ToList();
                return PartialView("_AboutsUs", listItem);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }      
           
        }
        public ActionResult ChonTinh(int provinceId)
        {
            Setting.ProvinceId = provinceId;
            switch(Setting.ProvinceId)
            {
                case 0: Setting.ProvinceName = "- Chọn tỉnh -"; break;
                case 1: Setting.ProvinceName = "Hà Nội"; break;
                case 2: Setting.ProvinceName = "TP. HCM"; break;
                case 3: Setting.ProvinceName = "Nam Định";break;
            }           

            return RedirectToAction("Index", new { provinceId = Setting.ProvinceId });
        }
        
        public ActionResult SlideBanner()
        {
            var lisitem= AnhManager.Instance.GetAnhByType(1).Take(4).ToList();
            ViewBag.Count = lisitem.FirstOrDefault();
            return PartialView("_SlideBanner", lisitem);
        }
        /// <summary>
        /// gửi thông tin liên hệ về  mail
        /// </summary>
        /// <param name="txthoten"></param>
        /// <param name="txtEmail"></param>
        /// <param name="txtDiaChi"></param>
        /// <param name="txtNoiDung"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult SenToMail(string txthoten, string txtEmail, string txtTieude, string txtNoiDung)
        {
            if (ModelState.IsValid)
            {
                string smtpUserName = "laptrinhvienwebsite@gmail.com";
                string smtpPassword = "vhqmmenuuexesogf";
                string smtpHost = "smtp.gmail.com";
                int smtpPort = 25;

                string emailTo = "khaivdop@gmail.com,'" + txtEmail + "'"; //vhqmmenuuexesogf Khi có liên hệ sẽ gửi về thư của mình
                string subject = txtTieude;
                string body = string.Format("Bạn vừa nhận được Thư mới: <b>{0}</b><br/>Email: {1}<br/>Địa chỉ: </br>{2} <br/> Nội dung : {3}", txthoten, txtEmail, txtTieude, txtNoiDung);

                service service = new service();

                bool kq = service.Send(smtpUserName, smtpPassword, smtpHost, smtpPort,
                    emailTo, subject, body);

                if (kq == true)
                {
                    ModelState.AddModelError("CustomError", "Gửi thư thành công!");
                    HttpContext.Response.Write("<script>alert('Gửi thư thành công.');</script>");
                }
                else
                {
                    ModelState.AddModelError("CustomError", "Gửi tin nhắn thất bại, vui lòng thử lại.");
                    HttpContext.Response.Write("<script>alert('Gửi thư thất bại.');</script>");
                }
            }
            return RedirectToAction("Contact", "Home");
        }
    }
}