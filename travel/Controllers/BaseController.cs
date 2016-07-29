using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using travel.Common;

namespace travel.Controllers
{
    public class BaseController : Controller
    {
        protected override IAsyncResult BeginExecuteCore(AsyncCallback callback, object state)
        {            
            CleanUp();
            SetCulture();
            return base.BeginExecuteCore(callback, state);
        }

        public bool IsActionName(string actionName, string controllerName)
        {
            var currentActionName = ControllerContext.RouteData.Values["action"].ToString();
            var currentControllerName = ControllerContext.RouteData.Values["controller"].ToString();

            return currentActionName.Equals(actionName) && currentControllerName.Equals(controllerName);   
        }

        private void CleanUp()
        {
            if (!IsActionName("Register", "Account") 
                &&!IsActionName("ActivateRegister", "Account"))
            {
               // SessionHelper<ConfirmSmsSession>.Remove(Constants.Session.AccountRegister);
            }

            if (!IsActionName("Login", "Account")
                &&!IsActionName("ActivateForgotPassword", "Account")
                &&!IsActionName("UpdatePassword", "Account"))
            {
                //SessionHelper<ConfirmSmsSession>.Remove(Constants.Session.AccountForgotPassword);   
            }
        }

        private void SetCulture()
        {
            string cultureName;

            var cultureCookie = Request.Cookies["_culture"];
            if (cultureCookie != null)
                cultureName = cultureCookie.Value;
            else
                cultureName = Request.UserLanguages != null && Request.UserLanguages.Length > 0
                    ? Request.UserLanguages[0]
                    : null;

            cultureName = CultureHelper.GetImplementedCulture(cultureName);

            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(cultureName);
            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;
        }
    }
}