using simpleERP.Models;
using System.Web.Mvc;

namespace simpleERP.Controllers
{
    public class HomeController : Controller
    {
        simpleERPEntities simpleERP = new simpleERPEntities();

        public ActionResult Index()
        {
            return View();
        }
    }
}