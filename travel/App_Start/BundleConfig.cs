using System.Web;
using System.Web.Optimization;

namespace travel
{
    public class BundleConfig
    {
      
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.UseCdn = true;
            BundleTable.EnableOptimizations = true; //force optimization while debugging
            BundleTable.EnableOptimizations.ToString();
            //var jquery = new ScriptBundle("~/bundles/jquery", "//ajax.aspnetcdn.com/ajax/jquery/jquery-2.0.0.min.js").Include(
            //        "~/Scripts/jquery-{version}.js");
            //jquery.CdnFallbackExpression = "window.jQuery";
            //bundles.Add(jquery);

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));
            
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));
            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                     "~/js/wow.min.js",
                     "~/js/js-common.js",
                    "~/js/jquery.prettyPhoto.min.js",
                    "~/js/jquery.prettyPhoto.init.min.js",
                    "~/js/jquery.themepunch.revolution.min.js",
                    "~/js/blazy.min.js",
                    "~/js/facebook_chatbot.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/menujs").Include(
                  "~/js/jquery.mmenu.all.min.js"                
             ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/css/menu.css",
                      "~/css/animate.css",
                      "~/css/style.css",
                      "~/css/style.css",
                      "~/css/main-custom.css",
                      "~/css/js_composer.min.css",
                      "~/css/theme-addons.min.css",
                      "~/css/adventure-tours-icons.css",
                      "~/css/star-rating.css"

                      ));
            bundles.Add(new StyleBundle("~/css/menucss").Include(
                      "~/css/jquery.mmenu.all.css"                     
                      ));
        }
    }
}
