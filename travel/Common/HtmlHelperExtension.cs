using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using travel.Manager;
using log4net;
using System.Globalization;
using System.IO;
using System.Web.Optimization;

using travel.ViewModels;

namespace travel.Common
{
    public static class HtmlHelperExtension
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof (HtmlHelperExtension));

        public static string MenuItemActive(this HtmlHelper html, string actions = "", string controllers = "", string cssClass = "active")
        {
            try
            {
                ViewContext viewContext = html.ViewContext;
                bool isChildAction = viewContext.Controller.ControllerContext.IsChildAction;

                if (isChildAction)
                    viewContext = html.ViewContext.ParentActionViewContext;

                RouteValueDictionary routeValues = viewContext.RouteData.Values;
                string currentAction = routeValues["action"].ToString();
                string currentController = routeValues["controller"].ToString();

                if (String.IsNullOrEmpty(actions))
                    actions = currentAction;

                if (String.IsNullOrEmpty(controllers))
                    controllers = currentController;

                string[] acceptedActions = actions.Trim().Split(',').Distinct().ToArray();
                string[] acceptedControllers = controllers.Trim().Split(',').Distinct().ToArray();

                return acceptedActions.Contains(currentAction) && acceptedControllers.Contains(currentController)
                    ? cssClass
                    : String.Empty;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                throw;
            }
        }
        
        /// <summary>
        /// Is current action
        /// </summary>
        /// <param name="html"></param>
        /// <param name="actions"></param>
        /// <param name="controllers"></param>
        /// <returns></returns>
        public static bool IsCurrentAction(this HtmlHelper html, string actions = "", string controllers = "")
        {
            try
            {
                ViewContext viewContext = html.ViewContext;
                bool isChildAction = viewContext.Controller.ControllerContext.IsChildAction;

                if (isChildAction)
                    viewContext = html.ViewContext.ParentActionViewContext;

                RouteValueDictionary routeValues = viewContext.RouteData.Values;
                string currentAction = routeValues["action"].ToString();
                string currentController = routeValues["controller"].ToString();

                if (String.IsNullOrEmpty(actions))
                    actions = currentAction;

                if (String.IsNullOrEmpty(controllers))
                    controllers = currentController;

                string[] acceptedActions = actions.Trim().Split(',').Distinct().ToArray();
                string[] acceptedControllers = controllers.Trim().Split(',').Distinct().ToArray();

                return acceptedActions.Contains(currentAction) && acceptedControllers.Contains(currentController);
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                throw;
            }
        }

        public static string CategoryItemActive(this HtmlHelper html, string actions = "", string controllers = "",
            string categorys = "", string cssClass = "active")
        {
            try
            {
                var num = 0;
                ViewContext viewContext = html.ViewContext;
                bool isChildAction = viewContext.Controller.ControllerContext.IsChildAction;

                if (isChildAction)
                    viewContext = html.ViewContext.ParentActionViewContext;


                RouteValueDictionary routeValues = viewContext.RouteData.Values;
                string currentAction = routeValues["action"].ToString();
                string currentController = routeValues["controller"].ToString();

                string currentCategory = "";
                if (routeValues.ContainsKey("category"))
                {
                    currentCategory = routeValues["category"].ToString();
                }
                else if (int.TryParse(categorys, out num) && routeValues.ContainsKey("parentId"))
                {
                    currentCategory = routeValues["parentId"].ToString();
                }
                else if (routeValues.ContainsKey("tenLoaiBlog"))
                {
                    currentCategory = routeValues["tenLoaiBlog"].ToString();
                }
                else if (int.TryParse(categorys, out num) && routeValues.ContainsKey("loaiTinTucId"))
                {
                    currentCategory = routeValues["loaiTinTucId"].ToString();
                }
                else if (int.TryParse(categorys, out num) && routeValues.ContainsKey("tagId"))
                {
                    currentCategory = routeValues["tagId"].ToString();
                }
                
                if (String.IsNullOrEmpty(actions))
                    actions = currentAction;

                if (String.IsNullOrEmpty(controllers))
                    controllers = currentController;

                if (String.IsNullOrEmpty(categorys))
                    categorys = currentCategory;

                string[] acceptedActions = actions.Trim().Split(',').Distinct().ToArray();
                string[] acceptedControllers = controllers.Trim().Split(',').Distinct().ToArray();
                string[] acceptedCategorys = categorys.Trim().Split(',').Distinct().ToArray();

                string str = acceptedActions.Contains(currentAction) && acceptedControllers.Contains(currentController) &&
                             acceptedCategorys.Contains(currentCategory)
                    ? cssClass
                    : String.Empty;

                return acceptedActions.Contains(currentAction) && acceptedControllers.Contains(currentController) &&
                       acceptedCategorys.Contains(currentCategory)
                    ? cssClass
                    : String.Empty;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                throw;
            }
        }

       
        public static string PopItemActive(this HtmlHelper html, string actions = "", string controllers = "",
            string cssClass = "active-item")
        {
            try
            {
                ViewContext viewContext = html.ViewContext;
                bool isChildAction = viewContext.Controller.ControllerContext.IsChildAction;

                if (isChildAction)
                    viewContext = html.ViewContext.ParentActionViewContext;

                RouteValueDictionary routeValues = viewContext.RouteData.Values;
                string currentAction = routeValues["action"].ToString();
                string currentController = routeValues["controller"].ToString();

                if (String.IsNullOrEmpty(actions))
                    actions = currentAction;

                if (String.IsNullOrEmpty(controllers))
                    controllers = currentController;

                string[] acceptedActions = actions.Trim().Split(',').Distinct().ToArray();
                string[] acceptedControllers = controllers.Trim().Split(',').Distinct().ToArray();

                string str = acceptedActions.Contains(currentAction) && acceptedControllers.Contains(currentController)
                    ? cssClass
                    : String.Empty;

                return acceptedActions.Contains(currentAction) && acceptedControllers.Contains(currentController)
                    ? cssClass
                    : String.Empty;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                throw;
            }
        }

       
        public static string TagItemActive(this HtmlHelper html, int tag = 0, int tagSelected = 0, string cssClass = "active")
        {
            try
            {
                /*
                ViewContext viewContext = html.ViewContext;
                bool isChildAction = viewContext.Controller.ControllerContext.IsChildAction;

                if (isChildAction)
                    viewContext = html.ViewContext.ParentActionViewContext;


                RouteValueDictionary routeValues = viewContext.RouteData.Values;
                string currentAction = routeValues["action"].ToString();
                string currentController = routeValues["controller"].ToString();

                if (String.IsNullOrEmpty(actions))
                    actions = currentAction;

                if (String.IsNullOrEmpty(controllers))
                    controllers = currentController;

                string[] acceptedActions = actions.Trim().Split(',').Distinct().ToArray();
                string[] acceptedControllers = controllers.Trim().Split(',').Distinct().ToArray();
                */
                string str = (tag == tagSelected) ? cssClass : String.Empty;
                return str;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                throw;
            }
        }

        public static string ReturnUrl(this HttpRequestBase request)
        {
            var returnUrl = request.RawUrl;
            if (!string.IsNullOrEmpty(request.QueryString["returnUrl"]))
            {
                returnUrl = request.QueryString["returnUrl"];
            }

            return returnUrl;
        }

        public static string CanonicalArticleUrl(this HttpRequestBase request, string tenNhomKhuyenMai, string tieuDe, int articleId )
        {
            if (request.Url != null)
            {
                var urlComment = string.Concat(Utilities.GetUrlHost(), string.Concat("/", tenNhomKhuyenMai.ToSeoUrl(), "/", tieuDe.ToSeoUrl(), "-", articleId));

                return urlComment;
            }

            return string.Empty;
        }


        public static string CommentTourUrl(this HttpRequestBase request, HttpContextBase context, int articleId, string tieuDe)
        {
            if (request.Url != null)
            {
                var urlComment = string.Concat(Utilities.GetUrlHost(), UrlHelper.GenerateContentUrl(string.Concat("~/tour/", articleId,"/", tieuDe), context));
                    
                return urlComment;
            }

            return string.Empty;
        }

        public static bool IsTVDevice(this HttpRequestBase request)
        {
            bool result = false;
            string userAgent = request.UserAgent;

            if (!string.IsNullOrEmpty(userAgent))
            {
                // Check if user agent is a smart TV - http://goo.gl/FocDk
                if (Regex.IsMatch(userAgent,
                    @"GoogleTV|SmartTV|Internet.TV|NetCast|NETTV|AppleTV|boxee|Kylo|Roku|DLNADOC|CE\-HTML",
                    RegexOptions.IgnoreCase))
                {
                    result = true;
                }
                    // Check if user agent is a TV Based Gaming Console
                else if (Regex.IsMatch(userAgent, "Xbox|PLAYSTATION.3|Wii", RegexOptions.IgnoreCase))
                {
                    result = true;
                }
            }

            return result;
        }

        public static bool IsTabletDevice(this HttpRequestBase request)
        {
            bool result = false;
            string userAgent = request.UserAgent;
            if (!string.IsNullOrEmpty(userAgent))
            {
                // Check if user agent is a Tablet
                if ((Regex.IsMatch(userAgent, "iP(a|ro)d", RegexOptions.IgnoreCase) ||
                     (Regex.IsMatch(userAgent, "tablet", RegexOptions.IgnoreCase)) &&
                     (!Regex.IsMatch(userAgent, "RX-34", RegexOptions.IgnoreCase)) ||
                     (Regex.IsMatch(userAgent, "FOLIO", RegexOptions.IgnoreCase))))
                {
                    result = true;
                }
                    // Check if user agent is an Android Tablet
                else if ((Regex.IsMatch(userAgent, "Linux", RegexOptions.IgnoreCase)) &&
                         (Regex.IsMatch(userAgent, "Android", RegexOptions.IgnoreCase)) &&
                         (!Regex.IsMatch(userAgent, "Fennec|mobi|HTC.Magic|HTCX06HT|Nexus.One|SC-02B|fone.945",
                             RegexOptions.IgnoreCase)))
                {
                    result = true;
                }
                    // Check if user agent is a Kindle or Kindle Fire
                else if ((Regex.IsMatch(userAgent, "Kindle", RegexOptions.IgnoreCase)) ||
                         (Regex.IsMatch(userAgent, "Mac.OS", RegexOptions.IgnoreCase)) &&
                         (Regex.IsMatch(userAgent, "Silk", RegexOptions.IgnoreCase)))
                {
                    result = true;
                }
                    // Check if user agent is a pre Android 3.0 Tablet
                else if (
                    (Regex.IsMatch(userAgent,
                        @"GT-P10|SC-01C|SHW-M180S|SGH-T849|SCH-I800|SHW-M180L|SPH-P100|SGH-I987|zt180|HTC(.Flyer|\\_Flyer)|Sprint.ATP51|ViewPad7|pandigital(sprnova|nova)|Ideos.S7|Dell.Streak.7|Advent.Vega|A101IT|A70BHT|MID7015|Next2|nook",
                        RegexOptions.IgnoreCase)) ||
                    (Regex.IsMatch(userAgent, "MB511", RegexOptions.IgnoreCase)) &&
                    (Regex.IsMatch(userAgent, "RUTEM", RegexOptions.IgnoreCase)))
                {
                    result = true;
                }
            }

            return result;
        }

        public static bool IsMobileDevice(this HttpRequestBase request)
        {
            bool result = false;
            string userAgent = request.UserAgent;

            if (!string.IsNullOrEmpty(userAgent))
            {
                // Check if user agent is unique Mobile User Agent
                if (
                    (Regex.IsMatch(userAgent,
                        "BOLT|Fennec|Iris|Maemo|Minimo|Mobi|mowser|NetFront|Novarra|Prism|RX-34|Skyfire|Tear|XV6875|XV6975|Google.Wireless.Transcoder",
                        RegexOptions.IgnoreCase)))
                {
                    result = true;
                }
                    // Check if user agent is an odd Opera User Agent - http://goo.gl/nK90K
                else if ((Regex.IsMatch(userAgent, "Opera", RegexOptions.IgnoreCase)) &&
                         (Regex.IsMatch(userAgent, "Windows.NT.5", RegexOptions.IgnoreCase)) &&
                         (Regex.IsMatch(userAgent, @"HTC|Xda|Mini|Vario|SAMSUNG\-GT\-i8000|SAMSUNG\-SGH\-i9",
                             RegexOptions.IgnoreCase)))
                {
                    result = true;
                }
            }

            return result;
        }

        public static bool IsDesktopDevice(this HttpRequestBase request)
        {
            bool result = false;
            string userAgent = request.UserAgent;

            if (!string.IsNullOrEmpty(userAgent))
            {
                // Check if user agent is Windows Desktop
                if ((Regex.IsMatch(userAgent, "Windows.(NT|XP|ME|9)")) &&
                    (!Regex.IsMatch(userAgent, "Phone", RegexOptions.IgnoreCase)) ||
                    (Regex.IsMatch(userAgent, "Win(9|.9|NT)", RegexOptions.IgnoreCase)))
                {
                    result = true;
                }
                    // Check if agent is Mac Desktop
                else if ((Regex.IsMatch(userAgent, "Macintosh|PowerPC", RegexOptions.IgnoreCase)) &&
                         (!Regex.IsMatch(userAgent, "Silk", RegexOptions.IgnoreCase)))
                {
                    result = true;
                }
                    // Check if user agent is a Linux Desktop
                else if ((Regex.IsMatch(userAgent, "Linux", RegexOptions.IgnoreCase)) &&
                         (Regex.IsMatch(userAgent, "X11", RegexOptions.IgnoreCase)))
                {
                    result = true;
                }
                    // Check if user agent is a Solaris, SunOS, BSD Desktop
                else if ((Regex.IsMatch(userAgent, "Solaris|SunOS|BSD", RegexOptions.IgnoreCase)))
                {
                    result = true;
                }
                    // Check if user agent is a Desktop BOT/Crawler/Spider
                else if (
                    (Regex.IsMatch(userAgent,
                        "Bot|Crawler|Spider|Yahoo|ia_archiver|Covario-IDS|findlinks|DataparkSearch|larbin|Mediapartners-Google|NG-Search|Snappy|Teoma|Jeeves|TinEye",
                        RegexOptions.IgnoreCase)) &&
                    (!Regex.IsMatch(userAgent, "Mobile", RegexOptions.IgnoreCase)))
                {
                    result = true;
                }
            }

            return result;
        }

        public static MvcHtmlString MetaTags(this HtmlHelper html)
        {
//            try
//            {
//                //---Nếu có page thì lấy page thêm vào sau nội dung của thẻ Tiêu đề, Mô tả.
//                string urlCurrent = HttpContext.Current.Request.Url.AbsoluteUri;
//                Uri myUri = new Uri(urlCurrent);
//                string pageValues = HttpUtility.ParseQueryString(myUri.Query).Get("page");

//                var result = string.Empty;
//                var url = HttpContext.Current.Request.Url.AbsolutePath;
//                var metaTag = SeoManager.Instance.GetMetaTags(url);
                
//                if (metaTag == null)
//                {
//                    /* Gán giá trị mặc định ở mục TAG  */
//                    ViewContext viewContext = html.ViewContext;
//                    bool isChildAction = viewContext.Controller.ControllerContext.IsChildAction;
//                    if (isChildAction) viewContext = html.ViewContext.ParentActionViewContext;
//                    RouteValueDictionary routeValues = viewContext.RouteData.Values;
//                    string controller = routeValues["controller"].ToString();
//                    string action = routeValues["action"].ToString();

//                    if (controller == "Tag" && action == "Index")
//                    {
//                        metaTag = new MetaTagViewModel();
//                        var cityName = "Hà Nội";
//                        if ((routeValues["provinceId"] != null) && (routeValues["provinceId"].ToString() == "2")) cityName = "Hồ Chí Minh";

//                        if (routeValues["quanId"] != null && routeValues["tagId"] != null)
//                        {
//                            var quanId = routeValues["quanId"].ToString();
//                            var tagId = routeValues["tagId"].ToString();
//                            var tagModel = TagManager.Instance.GetTagWithId(Convert.ToInt32(tagId));
//                            var tenDanhMuc = tagModel.TenDanhMuc;
//                            var tenTag = tagModel.Ten;
//                            var tenDanhMucKhongDau = tenDanhMuc.ToSeoUrl().Replace("-", " ");
//                            var tenTagKhongDau = tenTag.ToSeoUrl().Replace("-", " ");

//                            if (quanId != "0")
//                            {
//                                var lstHuyen = HomeManager.Instance.GetQuanWithId(Int32.Parse(quanId));
//                                var tenQuan = lstHuyen.Ten;
//                                var tenQuanKhongDau = tenQuan.ToSeoUrl().Replace("-", " ");

//                                metaTag.Title = tenDanhMuc + " " + tenTag + " ngon tại quận " + tenQuan + " giảm giá qua PASGO";
//                                metaTag.Description = "Địa chỉ " + tenDanhMuc + " " + tenTag + " ngon tại " + tenQuan + ", đặt chỗ ăn buffet qua PASGO nhận nhiều ưu đãi hấp dẫn, giá hợp lý các điểm đến uy tín chất lượng, " + tenTag + " ngon " + tenQuan;
//                                metaTag.Keyword = tenDanhMuc + " " + tenTag + " tại " + tenQuan + ", " + tenDanhMucKhongDau + " " + tenTagKhongDau + " tại " + tenQuanKhongDau;
//                            }
//                            else
//                            {
//                                metaTag.Title = tenDanhMuc + " " + tenTag + " ngon tại " + cityName + " giảm giá qua PASGO";
//                                metaTag.Description = "Địa chỉ " + tenDanhMuc + " " + tenTag + " ngon tại " + cityName + ", đặt chỗ ăn buffet qua PASGO nhận nhiều ưu đãi hấp dẫn, giá hợp lý các điểm đến uy tín chất lượng, " + tenTag + " ngon";
//                                metaTag.Keyword = tenDanhMuc + " " + tenTag + ", " + tenDanhMucKhongDau + " " + tenTagKhongDau;
//                            }
//                        }
//                    }
//                }
//                if (!string.IsNullOrEmpty(pageValues) && (metaTag != null))
//                {
//                    metaTag.Title = metaTag.Title + ' ' + pageValues;
//                    metaTag.Description = metaTag.Description + ' ' + pageValues;
//                }
//                if (metaTag != null)
//                {
//                    result = string.Format(@"<title>{0}</title>
//    <meta name=""description"" content=""{1}"" />
//    <meta name=""keywords"" content=""{2}"" />", html.Raw(HttpUtility.HtmlDecode(metaTag.Title)), html.Raw(HttpUtility.HtmlDecode(metaTag.Description)), html.Raw(HttpUtility.HtmlDecode(metaTag.Keyword)));
//                }
//                return MvcHtmlString.Create(result);
//            }
//            catch (Exception ex)
//            {
//                Logger.Error(ex);
//                throw;
//            }
            return MvcHtmlString.Create("");
        }

        public static string ContentCdn(this UrlHelper helper, string url)
        {
            if (string.IsNullOrEmpty(url)) return url;
            
            if (!url.Contains("~"))
            {
                url = Path.Combine("~", url);
            }

            url = helper.Content(url);

            if (url.Contains("'") 
                && HttpContext.Current.Request.Browser.IsMobileDevice)
            {
                url = url.Replace("'", "\\'");
            }

            if (!Utilities.IsServerDeveloper() &&
                !HttpContext.Current.Request.IsLocal)
            {
                var requestUrl = HttpContext.Current.Request.Url;

                url = string.Concat(requestUrl.Scheme, Uri.SchemeDelimiter, "cdn.", requestUrl.Host, url);
            }

            return url;
        }

        private static string LoadBundleContent(HttpContextBase httpContext, string bundleVirtualPath)
        {
            var bundleContext = new BundleContext(httpContext, BundleTable.Bundles, bundleVirtualPath);
            var bundle = BundleTable.Bundles.Single(b => b.Path == bundleVirtualPath);
            var bundleResponse = bundle.GenerateBundleResponse(bundleContext);

            return bundleResponse.Content;
        }

        private static IHtmlString InlineBundle(this HtmlHelper htmlHelper, string bundleVirtualPath, string htmlTagName)
        {
            string bundleContent = LoadBundleContent(htmlHelper.ViewContext.HttpContext, bundleVirtualPath);
            string htmlTag = string.Format("<{0}>{1}</{0}>", htmlTagName, bundleContent);

            return new HtmlString(htmlTag);
        }

        public static IHtmlString InlineScripts(this HtmlHelper htmlHelper, string bundleVirtualPath)
        {
            return htmlHelper.InlineBundle(bundleVirtualPath, "script");
        }

        public static IHtmlString InlineStyles(this HtmlHelper htmlHelper, string bundleVirtualPath)
        {
            return htmlHelper.InlineBundle(bundleVirtualPath, "style");
        }
        
        public static IHtmlString RenderFormatCssCdn(string url)
        {
            var templateCss = "<link href='[domain]{0}' type='text/css' rel='stylesheet'/>";

            var domain = string.Empty;

            if (!Utilities.IsServerDeveloper()
                && !HttpContext.Current.Request.IsLocal)
            {
                var requestUrl = HttpContext.Current.Request.Url;

                domain = string.Concat(requestUrl.Scheme, Uri.SchemeDelimiter, "cdn.", requestUrl.Host);
            }

            templateCss = templateCss.Replace("[domain]", domain);
          
            var css = Styles.RenderFormat(templateCss, url);

            return css;
        }

        public static IHtmlString RenderFormatJsCdn(string url)
        {
            var templateJs = "<script type='text/javascript' src='[domain]{0}'></script>";

            var domain = string.Empty;

            if (!Utilities.IsServerDeveloper()
                && !HttpContext.Current.Request.IsLocal)
            {
                var requestUrl = HttpContext.Current.Request.Url;

                domain = string.Concat(requestUrl.Scheme, Uri.SchemeDelimiter, "cdn.", requestUrl.Host);
            }

            templateJs = templateJs.Replace("[domain]", domain);

            var css = Scripts.RenderFormat(templateJs, url);

            return css;
        } 

        public static MvcHtmlString CanonicalLink(this HtmlHelper html)
        {
            try
            {
                if (Utilities.IsServerDeveloper())
                {
                    return MvcHtmlString.Create(string.Empty);
                }

                ViewContext viewContext = html.ViewContext;
                bool isChildAction = viewContext.Controller.ControllerContext.IsChildAction;

                if (isChildAction)
                    viewContext = html.ViewContext.ParentActionViewContext;

                RouteValueDictionary routeValues = viewContext.RouteData.Values;
                #region blog
                //var parentId = string.Empty;
                #endregion

                var result = string.Empty;
                var url = string.Empty;
                var cityId = string.Empty;
                var cityName = string.Empty;
                var hosting = "http://pasgo.vn/";

                string controller = routeValues["controller"].ToString();
                string action = routeValues["action"].ToString();
                
                if (routeValues["provinceId"] != null)
                {
                    cityId = routeValues["provinceId"].ToString();
                    if (cityId == "1")
                    {
                        cityName = "ha-noi";
                    }
                    else if (cityId == "2")
                    {
                        cityName = "ho-chi-minh";
                    }
                }

                if (routeValues["tinhId"] != null)
                {
                    cityId = routeValues["tinhId"].ToString();
                    if (cityId == "1")
                    {
                        cityName = "ha-noi";
                    }
                    else if (cityId == "2")
                    {
                        cityName = "ho-chi-minh";
                    }
                }
                #region canonical tin tức
                    //canonical cho page Tin tức Index
                else if ((controller == "TinTuc") && (action == "Index"))
                {
                      url = hosting + "tin-tuc";
                }
                    //canonical cho danh mục tin tức
                else if ((controller == "TinTuc") && (action == "TinTucTheoLoaiTinTuc"))
                {
                    var loaiTinTucId = routeValues["loaiTinTucId"].ToString();
                    if (loaiTinTucId=="1")
                    {
                        url = hosting + "tin-tuc" + "/" + "tin-cap-nhat";
                    }
                    else if (loaiTinTucId == "2")
                    {
                        url = hosting + "tin-tuc" + "/" + "su-kien";
                    }
                    else if (loaiTinTucId == "3")
                    {
                        url = hosting + "tin-tuc" + "/" + "khuyen-mai";
                    }
                    else if (loaiTinTucId == "4")
                    {
                        url = hosting + "tin-tuc" + "/" + "trai-nghiem";
                    }  
                }
                    //canonical cho page tag tin tức
                else if ((controller == "TinTuc") && (action == "TinTucTag"))
                {
                    var title=routeValues["title"].ToString();
                    var id=routeValues["id"].ToString();
                    url = hosting + "the-tin-tuc" + "/" + title+"-"+id;
                }
                    // canonical cho page  tin tức  chi tiết
                //else if ((controller == "TinTuc") && (action == "TinTucDetail"))
                //{
                //    var tenLoaiTin = routeValues["tenLoaiTin"].ToString();
                //    var title = routeValues["title"].ToString();
                //    var id = routeValues["id"].ToString();
                //    url = hosting + "tin-tuc" + "/" + tenLoaiTin + "/" + title + "-" + id;
                //}
                #endregion
                #region canonical blog
                    // canonical cho page Blog index
                else if ((controller=="Blog") && (action=="Index"))
                {
                    url = hosting + "blog";
                }
                    //canonical cho page  danh mục blog
                else if ((controller=="Blog") && (action=="BlogByBlogCategory"))
                {
                    var parentId = routeValues["parentId"].ToString();
                    var tenLoaiBlog = routeValues["tenLoaiBlog"].ToString();
                    var blogCategoryId=routeValues["blogCategoryId"].ToString();                    
                    if (parentId=="1")
                    {
                        url = hosting + "blog" + "/" + "am-thuc" +"/"+ tenLoaiBlog+"-"+parentId+"-"+blogCategoryId;
                    }
                    else if (parentId=="2")
                    {
                        url = hosting + "blog" + "/" + "lam-dep" + "/" + tenLoaiBlog + "-" + parentId + "-" + blogCategoryId;
                    }
                    else if (parentId == "4")
                    {
                        url = hosting + "blog" + "/" + "chia-se" + "/" + tenLoaiBlog + "-" + parentId + "-" + blogCategoryId;
                    }
                }
                    //canonical cho page  chi tiết  bài viết
                //else if ((controller=="Blog") && (action=="BlogDetail"))
                //{
                //    var parentName = routeValues["parentName"].ToString();
                //    var tenLoaiBlog = routeValues["tenLoaiBlog"].ToString();
                //    var title = routeValues["title"].ToString();
                //    var id = routeValues["id"].ToString();

                //    url = hosting + "blog" + "/" + parentName + "/" + tenLoaiBlog + "/" + title + "-" + id;
                   
                //}
                    //canonical cho page tag blog
                else if ((controller == "Blog") && (action == "BlogTag"))
                {
                    var tagName = routeValues["tagName"].ToString();                    
                    var tagId = routeValues["tagId"].ToString();

                    url = hosting + "the-blog" + "/" + tagName + "-" + tagId;

                }
                    // canonical cho page search blog
                else if ((controller == "Blog") && (action == "BlogSearch"))
                {
                    url = hosting + "blog" + "/" +"tim-kiem";

                }
                #endregion               
                if ((controller == "Home") && (action == "Index")) //---Trang chủ.
                {
                    if (cityName == "ha-noi") url = hosting;
                    else url = hosting + cityName;
                }
                else if ((controller == "Home") && (action == "mPasgo"))
                {
                    if (cityName == "ha-noi") url = hosting;
                    else url = hosting + cityName;
                }
                else if ((controller == "Category") && (action == "Index")) //--- Danh mục 
                {
                    var quanId = routeValues["quanId"].ToString();
                    var danhMuc = routeValues["category"].ToString();

                    if (quanId == "0")
                    {
                        url = hosting + cityName + "/" + danhMuc;
                    }
                    else
                    {
                        var tenQuan = routeValues["tenQuan"].ToString();
                        url = hosting + cityName +"/"+ tenQuan +"/" + danhMuc+"-"+quanId;
                    }
                }
                else if ((controller == "Tag") && (action == "Index")) //--- Chi tiết TAG.
                {
                    var quanId = routeValues["quanId"].ToString();
                    var danhMuc = routeValues["danhMuc"].ToString();
                    var tagId = routeValues["tagId"].ToString();
                    var tagTitle = routeValues["tagTitle"].ToString();

                    if (quanId == "0")
                    {
                        url = hosting + cityName + "/" + danhMuc + "/" + tagTitle + "-" + tagId;
                    }
                    else
                    {
                        var tenQuan = routeValues["tenQuan"].ToString();
                        url = hosting + cityName + "/" + tenQuan + "/" + danhMuc + "/" + tagTitle + "-" + tagId + "-" + quanId;
                    }

                }
                else if ((controller == "SponsorCode") && (action == "Index"))
                {
                    url = hosting + "the-pasgo";
                }
                else if ((controller == "SponsorPlace") && (action == "PlaceAndCode"))
                {
                    var quanId = routeValues["quanId"].ToString();
                    var nhomId = routeValues["nhomKhuyenMaiId"].ToString();
                    if ((quanId == "0") && (nhomId == "0"))
                    {
                        var codeId = routeValues["codeId"].ToString();
                        url = hosting + cityName + "/the-pasgo/danh-sach-diem-den-" + codeId;
                    }
                    else if (nhomId == "0")
                    {
                        var codeId = routeValues["codeId"].ToString();
                        var tenQuan = routeValues["tenQuan"].ToString();

                        url = hosting + cityName + "/" + tenQuan + "/the-pasgo/danh-sach-diem-den-" + codeId + "-" + quanId;
                    }
                    else if (quanId == "0")
                    {
                        var codeId = routeValues["codeId"].ToString();
                        var tenNhom = routeValues["tenNhom"].ToString();

                        url = hosting + cityName + "/" + tenNhom + "/the-pasgo/danh-sach-diem-den-" + codeId + "-" + nhomId;

                    }
                    else if ((quanId != "0") && (nhomId != "0"))
                    {
                        var codeId = routeValues["codeId"].ToString();
                        var tenQuan = routeValues["tenQuan"].ToString();
                        var tenNhom = routeValues["tenNhom"].ToString();

                        url = hosting + cityName + "/" + tenQuan + "/" + tenNhom + "/the-pasgo/danh-sach-diem-den-" + codeId + "-" + quanId + "-" + nhomId;

                    }
                }
                else if ((controller == "BenefitCheckIn") && (action == "SearchAllCheckin"))
                {
                    url = hosting + "tim-kiem-dat-cho";
                }
                else if ((controller == "BenefitCheckIn") && (action == "Index"))
                {
                    url = hosting + "lich-su-dat-cho/4-4";
                }
                else if ((controller == "Define") && (action == "ChecinDefine"))
                {
                    url = hosting + "quy-dinh-ve-dat-cho";
                }
                else if ((controller == "Search") && (action == "Index"))
                {
                    url = hosting + "tim-kiem";
                }
                else if ((controller == "Account") && (action == "Login"))
                {
                    url = hosting + "dang-nhap";
                }
                else if ((controller == "Account") && (action == "Logout"))
                {
                    url = hosting + "dang-xuat";
                }
                else if ((controller == "Account") && (action == "Register"))
                {
                    url = hosting + "dang-ky";
                }
                else if ((controller == "Profile") && (action == "Index"))
                {
                    url = hosting + "thong-tin-tai-khoan";
                }
                else if ((controller == "PasswordManager") && (action == "Index"))
                {
                    url = hosting + "quan-ly-mat-khau";
                }
                else if ((controller == "Account") && (action == "ActivateForgotPassword"))
                {
                    url = hosting + "kich-hoat-quen-mat-khau";
                }
                else if ((controller == "Account") && (action == "ActivateRegister"))
                {
                    url = hosting + "kich-hoat-dang-ky";
                }

                else if ((controller == "HuongDan") && (action == "Index")) //---Trang hướng dẫn.
                {
                    url = hosting + "huong-dan-su-dung-dich-vu-pasgo";
                }
                else if ((controller == "HuongDan") && (action == "DetailInstruction")) //--- Chi tiết hướng dẫn.
                {
                    string huongDanId = routeValues["huongDanId"].ToString();
                    url = hosting + "chi-tiet-huong-dan-su-dung-dich-vu-pasgo/" + huongDanId;
                }
                else if ((controller == "Common") && (action == "Introduce")) //---- Gioi-thieu
                {
                    url = hosting + "gioi-thieu";
                }
                else if ((controller == "Common") && (action == "Regulation")) //---- Quy-dinh
                {
                    url = hosting + "quy-dinh";
                }
                else if ((controller == "Common") && (action == "Conflict")) //---- Co-che-giai-quyet-tranh-chap
                {
                    url = hosting + "co-che-giai-quyet-tranh-chap";
                }
                else if ((controller == "Common") && (action == "Security")) //---- Chinh-sach-bao-mat-thong-tin
                {
                    url = hosting + "chinh-sach-bao-mat-thong-tin";
                }
                else if ((controller == "Common") && (action == "DownloadApp")) //---- DownloadApp
                {
                    url = hosting + "app";
                }
                else if ((controller == "Common") && (action == "SponsorCode")) //---- ma-tai-tro
                {
                    url = hosting + "ma-tai-tro";
                }
                else if ((controller == "Common") && (action == "Checkin")) //---- check-in
                {
                    url = hosting + "check-in";
                }
                else if ((controller == "Common") && (action == "Partner")) //---- doi-tac
                {
                    url = hosting + "doi-tac";
                }
                else if ((controller == "Common") && (action == "PolicyTermEn")) //---- e-chinh-sach-va-dieu-khoan
                {
                    url = hosting + "e-chinh-sach-va-dieu-khoan";
                }
                else if ((controller == "Common") && (action == "PolicyTermVn")) //---- chinh-sach-va-dieu-khoan
                {
                    url = hosting + "chinh-sach-va-dieu-khoan";
                }
                else if ((controller == "Common") && (action == "PolicySponsorCodeEn")) //---- e-dieu-khoan-ma-tai-tro
                {
                    url = hosting + "e-dieu-khoan-ma-tai-tro";
                }
                else if ((controller == "Common") && (action == "PolicySponsorCodeVn")) //---- dieu-khoan-ma-tai-tro
                {
                    url = hosting + "dieu-khoan-ma-tai-tro";
                }
                else if ((controller == "Common") && (action == "PolicyCheckinEn")) //---- e-dieu-khoan-check-in
                {
                    url = hosting + "e-dieu-khoan-check-in";
                }
                else if ((controller == "Common") && (action == "PolicyCheckinVn")) //---- dieu-khoan-check-in
                {
                    url = hosting + "dieu-khoan-check-in";
                }
                else if ((controller == "Common") && (action == "GuideCheckinEn")) //---- e-huong-dan-check-in
                {
                    url = hosting + "e-huong-dan-check-in";
                }
                else if ((controller == "Common") && (action == "GuideCheckinVn")) //---- huong-dan-check-in
                {
                    url = hosting + "huong-dan-check-in";
                }
                else if ((controller == "Common") && (action == "GuideShareEn")) //---- huong-dan-check-in
                {
                    url = hosting + "e-chia-se";
                }
                else if ((controller == "Common") && (action == "GuideShareVn")) //---- huong-dan-check-in
                {
                    url = hosting + "chia-se";
                }
                else if ((controller == "Common") && (action == "GuideSponsorCodeEn")) //---- e-huong-dan-ma-tai-tro
                {
                    url = hosting + "e-huong-dan-ma-tai-tro";
                }
                else if ((controller == "Common") && (action == "GuideSponsorCodeVn")) //---- e-huong-dan-ma-tai-tro
                {
                    url = hosting + "huong-dan-ma-tai-tro";
                }

                if (!string.IsNullOrEmpty(url))
                {
                    result = string.Format(@"<link rel=""canonical"" href=""{0}"" />", url);
                }
                return MvcHtmlString.Create(result);
            }
            catch (Exception ex)
            {
                return MvcHtmlString.Create(string.Empty);
                //Logger.Error(ex);
                throw;
            }
        }
        public static MvcHtmlString FormatLinkAnh(this HtmlHelper html, string urlAnh)
        {
            try
            {
                String strPathAndQuery = HttpContext.Current.Request.Url.PathAndQuery;
                String strUrl = HttpContext.Current.Request.Url.AbsoluteUri.Replace(strPathAndQuery, "/");
                strUrl = strUrl + urlAnh;
                return MvcHtmlString.Create(strUrl);
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                throw;
            }
        }

        /* Bread crum */
        public static string Titleize(this string text)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text).ToSentenceCase();
        }

        public static string ToSentenceCase(this string str)
        {
            return Regex.Replace(str, "[a-z][A-Z]", m => m.Value[0] + " " + char.ToLower(m.Value[1]));
        } 
    }
}
