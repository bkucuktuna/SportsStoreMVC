﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.Domain.Concrete;
using SportsStore.Domain.Abstract;

namespace SportsStore.WebUI.Controllers
{
    public class NavController : Controller
    {
        IProductRepository repository;
        public NavController(IProductRepository repo)
        {
            repository = repo;
        }

         //GET: Nav
        public PartialViewResult Menu()
        {
            IEnumerable<string> categories = repository.Products.Select(p => p.Category).Distinct();
            return PartialView(categories);
        }
        //public string Menu()
        //{
        //    return "Nav Controller";
        //}
    }
}