using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.Models;

namespace Project.Controllers
{
    public class UserController : Controller
    {
        private Model1 Shop = new Model1();
        public ActionResult Register()
        {
            return View();
        }

        public ActionResult Success()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Register user)
        {
            var checkExist_email = Shop.Users.Any(x => x.Email == user.Email);

            if (checkExist_email)
            {
                ModelState.AddModelError("Email", "Email đã tồn tại!!");
            }

            if (ModelState.IsValid)
            {
                var new_User = new User();

                new_User.Name = user.Name;
                new_User.Password = Encrypt.ConvertToEncrypt(user.Password);
                new_User.Address = user.Address;
                new_User.Phone = user.Phone;
                new_User.Email = user.Email;

                Shop.Users.Add(new_User);
                Shop.SaveChanges();

                return RedirectToAction("Success");
            }
            
            return View(user);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Login user)
        {

            if (ModelState.IsValid)
            {
                var checkExist_email = Shop.Users.Any(x => x.Email == user.Email);

                if (!checkExist_email)
                {
                    ModelState.AddModelError("Email", "Email không tồn tại");
                }
                else
                {
                    var check_pass = (from check in Shop.Users
                                      where (check.Email == user.Email)
                                      select check.Password).Single();

                    if (String.Compare(Encrypt.ConvertToEncrypt(user.Password), check_pass) != 0)
                    {
                        ModelState.AddModelError("Pass", "Password không hợp lệ");
                    }
                    else
                    {
                        //var username = (from name in Shop.Users
                        //                where (name.Email == user.Email)
                        //                select name.Name).Single();

                        Session["User"] = user.Email;
                        return RedirectToAction("Index", "Home");
                    }
                }
  
            }
            return View(user);
        }

        public ActionResult Logout()
        {
            Session["User"] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}