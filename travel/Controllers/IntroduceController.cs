using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using travel.Manager;
using travel.Common;


namespace travel.Controllers
{
    public class IntroduceController : Controller
    {
        // GET: Introduce
        /// <summary>
        /// lấy chi tiết bài giới thiệu
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Index(int id)
        {
            try
            {
                if (id==5)
                {
                    return RedirectToAction("Contact", "Home");
                }
                var list = InformationManager.Instance.InformationGetDetail(id);
                return View(list);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
       
    }
}