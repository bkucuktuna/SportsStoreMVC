using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Concrete;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Models;

namespace SportsStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        IProductRepository productRepository;
        public ProductController(IProductRepository _productRepository) { this.productRepository = _productRepository; }
        
        // GET: Product
        public ActionResult List(string category, int page=1)
        {
            ProductsListViewModel model = new ProductsListViewModel();
            int pageSize = 2;
            int count;
            if (category != null)
            {
                model.Products = productRepository.Products.Where(p => p.Category == category).Skip((page - 1) * pageSize).Take(pageSize);
                ViewBag.PageCount = Math.Ceiling((double)productRepository.Products.Where(p => p.Category == category).Count() / pageSize);
                count = productRepository.Products.Where(p => p.Category == category).Count();
            }
            else
            {
                model.Products = productRepository.Products.Skip((page - 1) * pageSize).Take(pageSize);
                ViewBag.PageCount = Math.Ceiling((double)productRepository.Products.Count() / pageSize);
                count = productRepository.Products.Count();
            }


            //return View(rep.Products);


            //model.Products = productRepository.Products.Skip((page - 1) * pageSize).Take(pageSize);

            model.Category = category;
            model.pageInfo = new HTMLHelpers.PageInfo() { PageSize = 2, NumProducts = count, CurrentPage=page };
            return View(model);
        }
        public ActionResult ShoppingCart()
        {
            return View();
        }

    }
}