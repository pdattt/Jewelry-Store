using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.Models;

namespace Project.Controllers
{
    public class OrderController : Controller
    {
        Model1 Shop = new Model1();

        public ActionResult ShoppingCart() 
        {
            var order = Session["ShoppingCart"];
            var list = new List<OrderDetail>();

            if(order != null)
            {
                list = (List<OrderDetail>)order;
            }

            return View(list);
        }


        public ActionResult AddOrder(int productID)
        {
            var cart = Session["ShoppingCart"];
            var quantity = 1;

            if (cart != null)
            {
                var list = (List<OrderDetail>)cart;
                
                // Nếu sản phẩm thêm vào đã có trong giỏ hàng thì 
                //tăng số lượng dựa trên số lượng nhập vào
                if(list.Exists(x => x.ProductID == productID))
                {
                    foreach(var order in list)
                    {
                        if(order.ProductID == productID)
                        {
                            order.Amount += quantity;
                        }
                    }
                }
                else
                {
                    var order = new OrderDetail();

                    var product = Shop.Products.Where(x => x.ID == productID).Single();
                    order.ProductID = product.ID;
                    order.Name = product.Name;
                    order.Price = product.Price;
                    order.Image = product.Image;
                    order.Amount = quantity;

                    list.Add(order);

                    Session["ShoppingCart"] = list;
                }
            }
            else
            {
                var order = new OrderDetail();

                var product = Shop.Products.Where(x => x.ID == productID).Single();
                order.ProductID = product.ID;
                order.Name = product.Name;
                order.Price = product.Price;
                order.Image = product.Image;
                order.Amount = quantity;
                var list = new List<OrderDetail>();
                list.Add(order);

                Session["ShoppingCart"] = list;
            }

            return RedirectToAction("ShoppingCart");
        }

        public ActionResult Checkout()
        {
            var user_sess = Session["User"];
            var list_sess = Session["ShoppingCart"];

            var list = new List<OrderDetail>();
            list = (List<OrderDetail>)list_sess;

            if (user_sess == null)
                return RedirectToAction("Login", "User");

            var user = Shop.Users.Where(x => x.Email == user_sess.ToString()).Single();
            ViewBag.user = user;

            return View(list);
        }

        public ActionResult Finish(int payment, int total)
        {
            var user_sess = Session["User"];
            var list_sess = Session["ShoppingCart"];
            DateTime date = DateTime.Today;

            var user = Shop.Users.Where(x => x.Name == user_sess.ToString()).Single();

            var list = new List<OrderDetail>();
            list = (List<OrderDetail>)list_sess;

            var order = new Order();

            //order.Order_ID = 1;
            //var check_orderID = Shop.Orders.Any(x => x.Order_ID == order.Order_ID);

            //do
            //{
            //    order.Order_ID++;
            //} while (check_orderID);

            order.UserID = user.ID;
            order.CreateDate = date;
            order.Address = user.Address;
            order.Payment = payment;
            order.Total = total;
            order.Status = 1;

            Shop.Orders.Add(order);
            Shop.SaveChanges();

            foreach(var product_order in list)
            {
                var order_detail = new OrderDetail();

                order_detail.Order_ID = order.Order_ID;
                order_detail.ProductID = product_order.ProductID;
                order_detail.Amount = product_order.Amount;
                order_detail.Price = product_order.Price;
                order_detail.Name = product_order.Name;
                order_detail.Image = product_order.Image;

                Shop.OrderDetails.Add(order_detail);
                Shop.SaveChanges();
            }

            Session["ShoppingCart"] = null;
            return RedirectToAction("Index", "Home");
        }

        public ActionResult RemoveOrder(int ID, string currentpage, List<OrderDetail> list)
        {
            foreach(var order in list)
            {
                if (order.Detail_ID == ID)
                {
                    list.Remove(order);
                    break;
                }
            }

            Session["ShoppingCart"] = list;

            return RedirectToAction(currentpage, "Order");
        }

    }
}