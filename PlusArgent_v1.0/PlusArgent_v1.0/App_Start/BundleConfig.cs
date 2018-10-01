using System.Web;
using System.Web.Optimization;

namespace PlusArgent_v1._0
{
    public class BundleConfig
    {
        // Para obter mais informações sobre o agrupamento, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                     "~/Scripts/jquery-1.10.2.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                       "~/Content/vendors/jquery/dist/jquery.min.js"));
     
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Content/vendors/bootstrap/dist/js/bootstrap.min.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/custom").Include(
                      "~/Content/build/js/custom.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/custom.min.css"));

            bundles.Add(new StyleBundle("~/Content/bootstrap").Include("~/Content/vendors/bootstrap/dist/css/bootstrap.min.css"));

            bundles.Add(new StyleBundle("~/Content/font").Include("~/Content/vendors/font-awesome/css/font-awesome.min.css"));

            


        }
    }
}
