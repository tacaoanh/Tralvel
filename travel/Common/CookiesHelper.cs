using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace travel.Common
{
    public static class CookiesHelper
    {
        public static void SetValue(string key, string value)
        {
            var httpCookie = HttpContext.Current.Request.Cookies[key] ?? new HttpCookie(key);
            httpCookie.Value = value;
            httpCookie.Expires = DateTime.Now.AddDays(365);

            HttpContext.Current.Response.Cookies.Add(httpCookie);
        }

        public static string GetValue(string key)
        {
            var value = string.Empty;

            if (HttpContext.Current.Request.Cookies.AllKeys.Contains(key))
            {
                var httpCookie = HttpContext.Current.Request.Cookies[key];
                if (httpCookie != null)
                    value = httpCookie.Value;
            }

            return value;
        }

        public static bool HasKey(string key)
        {
            var hasKey = HttpContext.Current.Request.Cookies.AllKeys.Contains(key);
            return hasKey;
        }

        public static void Remove(string key)
        {
            if (HasKey(key))
            {
                var cookie = HttpContext.Current.Request.Cookies[key];
                if (cookie != null)
                {
                    cookie.Expires = DateTime.Now.AddDays(-1);
                    HttpContext.Current.Request.Cookies.Add(cookie);
                }
            }
        }
    }
}