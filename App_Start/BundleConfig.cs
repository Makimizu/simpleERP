using System.Web.Optimization;

namespace simpleERP
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Assets/scripts").Include(
                      "~/Assets/plugins/jquery/jquery.min.js",
                      "~/Assets/plugins/bootstrap/js/bootstrap.js",
                      "~/Assets/plugins/bootstrap-select/js/bootstrap-select.js",
                      "~/Assets/plugins/jquery-slimscroll/jquery.slimscroll.js",
                      "~/Assets/plugins/node-waves/waves.js",
                      "~/Assets/plugins/jquery-countto/jquery.countTo.js",
                      "~/Assets/plugins/raphael/raphael.min.js",
                      "~/Assets/plugins/morrisjs/morris.js",
                      "~/Assets/plugins/chartjs/Chart.bundle.js"));

            bundles.Add(new ScriptBundle("~/Assets/js").Include(
                      "~/Assets/js/admin.js",
                      "~/Assets/js/demo.js"));

            bundles.Add(new StyleBundle("~/Assets/css").Include(
                      "~/Assets/css/style.css"));

            bundles.Add(new StyleBundle("~/Assets/css/themes").Include(
                      "~/Assets/css/themes/all-themes.css"));

            bundles.Add(new StyleBundle("~/Assets/plugins").Include(
                      "~/Assets/plugins/bootstrap/css/bootstrap.css",
                      "~/Assets/plugins/node-waves/waves.css",
                      "~/Assets/plugins/animate-css/animate.css",
                      "~/Assets/plugins/jquery-datatable/skin/bootstrap/css/dataTables.bootstrap.css",
                      "~/Assets/plugins/morrisjs/morris.css"));
        }
    }
}
