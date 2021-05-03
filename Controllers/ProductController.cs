using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.Models;

namespace Project.Controllers
{
    public class ProductController : Controller
    {
        private Model1 Shop = new Model1();

        public ActionResult proByCat(int ID)
        {
            List<Category> catData = Shop.Categories.ToList();
            List<Product> proData = Shop.Products.ToList();

            var category = catData.Where(x => ID == x.ID).SingleOrDefault();
            ViewBag.proList = Shop.Products.ToList();

            return View(category);
        }

        public ActionResult ProductDetail(int ID = 1)
        {
            List<Product> proData = Shop.Products.ToList();
            var product = proData.Where(x => x.ID == ID).SingleOrDefault();
            //Product product = from pro in proData
            //                  where pro.ID == ID
            //                  select pro.SingleOrDefault();
            ViewBag.proList = Shop.Products.ToList();
            return View(product);
        }
        public ActionResult Products()
        {
            ViewBag.proList = Shop.Products.ToList();
            ViewBag.catList = Shop.Categories.ToList();

            return View();
        }
    }
}