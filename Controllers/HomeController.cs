using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.Models;

namespace Project.Controllers
{
    public class HomeController : Controller
    {
        private Model1 Shop = new Model1();
        public ActionResult Index()
        {
            ViewBag.proList = Shop.Products.ToList();
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult FAQs()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public PartialViewResult _SideBar()
        {
            ViewBag.catList = Shop.Categories.ToList();
            return PartialView();
        }

        public PartialViewResult _subMenu()
        {   
            ViewBag.catList = Shop.Categories.ToList();
            return PartialView();
        }
        public PartialViewResult _Slider()
        {
            ViewBag.proList = Shop.Products.ToList();
            return PartialView();
        }
    }
}