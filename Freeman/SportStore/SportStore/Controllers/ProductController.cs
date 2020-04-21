using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportStore.Models;

namespace SportStore.Controllers
{
    public class ProductController:Controller
    {
        private IProductRepository repository;
        public Int32 PageSize = 4;

        public ProductController(IProductRepository repo)
        {
            repository = repo;
        }

        public ViewResult List(Int32 productPage = 1)
        {
           return View(repository.Products
               .OrderBy(p => p.ProductID)
               .Skip((productPage-1)*PageSize)
               .Take(PageSize)
               );
        }
    }
}
