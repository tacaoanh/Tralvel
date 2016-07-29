using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace travel.Common
{
    public static class CdnUntil
    {
        public static string CdnUrl(this HtmlHelper helper, string contentPath)
        {
            // Check if we are in release mode. If not, then simply return as normal
            if (contentPath.StartsWith("~"))
            {
                contentPath = contentPath.Substring(1);
            } 
            string appSetting = ConfigurationManager.AppSettings["CDNUrl"];	
            Uri combinedUri = new Uri(new Uri(appSetting), contentPath);
            contentPath = combinedUri.ToString();					
            var url = new UrlHelper(helper.ViewContext.RequestContext);
 
            return url.Content(contentPath);
        }
    }
}