using simpleERP.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace simpleERP.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult saveProduct(FormCollection form)
        {
            if (string.IsNullOrEmpty(form["productNo"]) || string.IsNullOrEmpty(form["productName"]) || string.IsNullOrEmpty(form["productUom"]) || string.IsNullOrEmpty(form["minStock"]))
            {
                return Json(new { Message = "Please fill data !", success = false }, JsonRequestBehavior.AllowGet);
            }

            var productNo = form["productNo"];
            var productName = form["productName"];
            var productUom = form["productUom"];
            var minStock = form["minStock"];

            simpleERPEntities simpleERP = new simpleERPEntities();

            var checkUsername = simpleERP.tblItems.Where(a => a.itemno == productNo).FirstOrDefault();

            if (checkUsername != null)
            {
                return Json(new { Message = "Product no already taken", success = false }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                using (var db = new simpleERPEntities())
                {
                    tblItem item = new tblItem();
                    item.itemno = productNo;
                    item.itemname = productName;
                    item.uom = productUom;
                    item.minstock = Convert.ToInt32(minStock);

                    db.tblItems.Add(item);
                    db.SaveChanges();
                }
            }

            return Json(new { Message = "Successfully Saved !", success = true }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult updateProduct(FormCollection form)
        {
            var productNo = form["productNo"];
            var productName = form["productName"];
            var productUom = form["productUom"];
            var minStock = form["minStock"];

            simpleERPEntities simpleERP = new simpleERPEntities();
            tblItem item = simpleERP.tblItems.Where(a => a.itemno == productNo).FirstOrDefault();
            item.itemname = productName;
            item.uom = productUom;
            item.minstock = Convert.ToInt32(minStock);
            simpleERP.SaveChanges();

            return Json(new { message = "Data successfully updated", success = true }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult deleteProduct(FormCollection form)
        {
            tblItem item = new tblItem();
            item.itemno = form["productNo"] == null ? "" : form["productNo"];

            simpleERPEntities simpleERP = new simpleERPEntities();
            var data = simpleERP.tblItems.Where(a => a.itemno.Equals(item.itemno)).ToList();
            simpleERP.tblItems.RemoveRange(data);
            simpleERP.SaveChanges();
            return Json(new { data = data, recordsTotal = data.Count, status = "Data successfully deleted" }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult getDataProducts(FormCollection form)
        {
            int start = Convert.ToInt32(form["start"]);
            int length = Convert.ToInt32(form["length"]);

            simpleERPEntities simpleERP = new simpleERPEntities();
            var collData = simpleERP.Database.SqlQuery<tblItem>(@"select * from tblItems").ToList();

            int totalData = collData.Count;
            int totalPages = totalData / length;
            collData = collData.Skip(start).Take(length).ToList();
            return Json(new { data = collData, recordsTotal = totalData, recordsFiltered = totalData }, JsonRequestBehavior.AllowGet);
        }
    }
}