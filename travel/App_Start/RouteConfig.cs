using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace travel
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");          
            routes.MapRoute("tour-chi-tiet", "tour/{tourName}-{tourId}", new{controller = "Detail",action = "Index", tourName = UrlParameter.Optional, tourId = UrlParameter.Optional});
            routes.MapRoute("danh-muc-tour", "category/{name}-{id}", new { controller = "Tour", action = "Index", name = string.Empty, id = UrlParameter.Optional});
            routes.MapRoute("tinh-tour", "danh-sach/tour/{name}-{id}", new { controller = "Tour", action = "TourTinh", name = string.Empty, id = UrlParameter.Optional });
            routes.MapRoute("tim-kiem-tour", "danh-sach/tim-kiem", new { controller = "SearchTour", action = "Index"});
            



            routes.MapRoute("AnhSlide", "anh-slide/{tenIMG}", new { controller = "Photo", action = "ShowAnhById" });
            routes.MapRoute("AnhNguoiDung", "anh-nguoi-dung/{tenIMG}", new { controller = "Photo", action = "ShowPhotoNguoiDungByReviewId" });
            routes.MapRoute("AnhTourCategory", "anh-tour-category/{tenIMG}", new { controller = "Photo", action = "ShowPhotoTourCategory" });
            routes.MapRoute("ContactUs", "lien-he-cozitravel/{id}", new { controller = "Home", action = "Contact", id = UrlParameter.Optional });   
            routes.MapRoute("Liên hệ", "lien-he-cozitravel/{name}-{id}", new { controller = "Home", action = "Contact",name=string.Empty, id = UrlParameter.Optional });            

            routes.MapRoute("Giới thiệu", "gioi-thieu/{name}-{id}", new { controller = "Introduce", action = "Index", name = string.Empty, id = UrlParameter.Optional });

            routes.MapRoute(
               name: "Default",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
           );
        }
    }
}
