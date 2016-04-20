using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.Domain.Abstract;
using SportsStore.WebUI.Models;
using SportsStore.Domain.Entities;

namespace SportsStore.WebUI.Controllers
{
    public class CartController : Controller
    {
        IProductRepository repositoryCart;
        public CartController(IProductRepository rep) { repositoryCart = rep; }

        // GET: ShoppingCart
        public ActionResult AddToCart(CartItems cartItems, int productId)
        {
            //cartItems.AddToCart( repositoryCart.Products.Where(p => p.ProductID == productId).First());
            
            Product product = repositoryCart.Products.Where(p => p.ProductID == productId).First();
            cartItems.AddToCart(product);
            cartItems.ReturnURL = Request.UrlReferrer.ToString();
            return View(cartItems);
        }
        public ActionResult RemoveFromCart(CartItems cartItems, int productId)
        {
            //cartItems.AddToCart( repositoryCart.Products.Where(p => p.ProductID == productId).First());
            Product product = repositoryCart.Products.Where(p => p.ProductID == productId).First();
            cartItems.RemoveFromCart(product);
            return View("AddToCart",cartItems);
        }
        public PartialViewResult Summary(CartItems cartItems)
        {
            return PartialView(cartItems);
        }

    }
}