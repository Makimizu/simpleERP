using simpleERP.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace simpleERP.Controllers
{
    public class CompanyController : Controller
    {
        // GET: Company
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult saveCompany(FormCollection form)
        {
            if (string.IsNullOrEmpty(form["CompanyName"]) || string.IsNullOrEmpty(form["CompanyAddress"]) || string.IsNullOrEmpty(form["CompanyCity"]) ||
                string.IsNullOrEmpty(form["CompanyPoscode"]) || string.IsNullOrEmpty(form["CompanyEmail"]) || string.IsNullOrEmpty(form["CompanyPhone"]))
            {
                return Json(new { Message = "Please fill data !", success = false }, JsonRequestBehavior.AllowGet);
            }

            var CompanyName = form["CompanyName"];
            var CompanyAddress = form["CompanyAddress"];
            var CompanyCity = form["CompanyCity"];
            var CompanyPoscode = form["CompanyPoscode"];
            var CompanyEmail = form["CompanyEmail"];
            var CompanyPhone = form["CompanyPhone"];

            simpleERPEntities simpleERP = new simpleERPEntities();

            using (var db = new simpleERPEntities())
            {
                tblCompany company = new tblCompany();
                company.companyName = CompanyName;
                company.address = CompanyAddress;
                company.city = CompanyCity;
                company.poscode = CompanyPoscode;
                company.email = CompanyEmail;
                company.phone = CompanyPhone;

                db.tblCompanys.Add(company);
                db.SaveChanges();
            }

            return Json(new { Message = "Successfully Saved !", success = true }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult updateCompany(FormCollection form)
        {
            var CompanyNo = form["CompanyNo"];
            var CompanyName = form["CompanyName"];
            var CompanyAddress = form["CompanyAddress"];
            var CompanyCity = form["CompanyCity"];
            var CompanyPoscode = form["CompanyPoscode"];
            var CompanyEmail = form["CompanyEmail"];
            var CompanyPhone = form["CompanyPhone"];

            simpleERPEntities simpleERP = new simpleERPEntities();
            tblCompany company = simpleERP.tblCompanys.Where(a => a.companyId.ToString() == CompanyNo).FirstOrDefault();
            company.companyName = CompanyName;
            company.address = CompanyAddress;
            company.city = CompanyCity;
            company.poscode = CompanyPoscode;
            company.email = CompanyEmail;
            company.phone = CompanyPhone;
            simpleERP.SaveChanges();

            return Json(new { message = "Data successfully updated", success = true }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult deleteCompany(FormCollection form)
        {
            tblCompany item = new tblCompany();
            item.companyId = form["CompanyNo"] == null ? 0 : Convert.ToInt32(form["CompanyNo"]);

            simpleERPEntities simpleERP = new simpleERPEntities();
            var data = simpleERP.tblCompanys.Where(a => a.companyId.Equals(item.companyId)).ToList();
            simpleERP.tblCompanys.RemoveRange(data);
            simpleERP.SaveChanges();
            return Json(new { data = data, recordsTotal = data.Count, status = "Data successfully deleted" }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult getDataCompanys(FormCollection form)
        {
            int start = Convert.ToInt32(form["start"]);
            int length = Convert.ToInt32(form["length"]);

            simpleERPEntities simpleERP = new simpleERPEntities();
            var collData = simpleERP.Database.SqlQuery<tblCompany>(@"select * from tblCompanys").ToList();

            int totalData = collData.Count;
            int totalPages = totalData / length;
            collData = collData.Skip(start).Take(length).ToList();
            return Json(new { data = collData, recordsTotal = totalData, recordsFiltered = totalData }, JsonRequestBehavior.AllowGet);
        }
    }
}