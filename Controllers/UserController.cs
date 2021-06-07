using simpleERP.Models;
using simpleERP.Models.ViewModel;
using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace simpleERP.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult saveUser(FormCollection form)
        {
            if (string.IsNullOrEmpty(form["username"]) || string.IsNullOrEmpty(form["password"]) || string.IsNullOrEmpty(form["fullname"]) || string.IsNullOrEmpty(form["email"]) || string.IsNullOrEmpty(form["phone"]))
            {
                return Json(new { Message = "Please fill data !", success = false }, JsonRequestBehavior.AllowGet);
            }

            var username = form["username"];
            var password = form["password"];
            var fullname = form["fullname"];
            var email = form["email"];
            var phone = form["phone"];

            simpleERPEntities simpleERP = new simpleERPEntities();

            var checkUsername = simpleERP.tblUsers.Where(a => a.username == username).FirstOrDefault();
            var checkEmail = simpleERP.tblUsers.Where(a => a.email == email).FirstOrDefault();

            if (checkUsername != null)
            {
                return Json(new { Message = "Username already taken", success = false }, JsonRequestBehavior.AllowGet);
            }
            else if (checkEmail != null)
            {
                return Json(new { Message = "Email already taken", success = false }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                using (var db = new simpleERPEntities())
                {
                    tblUser user = new tblUser();
                    user.fullname = fullname;
                    user.username = username;
                    user.email = email;
                    user.password = password;
                    user.phone = phone;

                    db.tblUsers.Add(user);
                    db.SaveChanges();
                }
            }

            return Json(new { Message = "Successfully Saved !", success = true }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult updateUser(FormCollection form)
        {
            var username = form["username"];
            var password = form["password"];
            var email = form["email"];
            var fullname = form["fullname"];
            var phone = form["phone"];

            simpleERPEntities simpleERP = new simpleERPEntities();
            tblUser user = simpleERP.tblUsers.Where(a => a.username == username).FirstOrDefault();
            user.fullname = fullname;
            user.password = password;
            user.phone = phone;
            simpleERP.SaveChanges();

            return Json(new { message = "Data successfully updated", success = true }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult deleteUser(FormCollection form)
        {
            tblUser user = new tblUser();
            user.username = form["username"] == null ? "" : form["username"];

            simpleERPEntities simpleERP = new simpleERPEntities();
            var data = simpleERP.tblUsers.Where(a => a.username.Equals(user.username)).ToList();
            simpleERP.tblUsers.RemoveRange(data);
            simpleERP.SaveChanges();
            return Json(new { data = data, recordsTotal = data.Count, status = "Data successfully deleted" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Login(AccountViewModel model)
        {
            var isValidUser = IsValidUser(model);
            if (isValidUser != null)
            {
                FormsAuthentication.SetAuthCookie(model.UserName, false);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("Failure", "Username dan password Anda salah");
                return View();
            }
        }

        public tblUser IsValidUser(AccountViewModel model)
        {
            using (var dataContext = new simpleERPEntities())
            {
                tblUser user = dataContext.tblUsers.Where(query => query.username.Equals(model.UserName) && query.password.Equals(model.Password)).SingleOrDefault();
                if (user == null)
                    return null;
                else
                    return user;
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Login", "User");
        }

        public JsonResult getDataUsers(FormCollection form)
        {
            int start = Convert.ToInt32(form["start"]);
            int length = Convert.ToInt32(form["length"]);

            simpleERPEntities simpleERP = new simpleERPEntities();
            var collData = simpleERP.Database.SqlQuery<tblUser>(@"select * from tblUsers").ToList();

            int totalData = collData.Count;
            int totalPages = totalData / length;
            collData = collData.Skip(start).Take(length).ToList();
            return Json(new { data = collData, recordsTotal = totalData, recordsFiltered = totalData }, JsonRequestBehavior.AllowGet);
        }
    }
}