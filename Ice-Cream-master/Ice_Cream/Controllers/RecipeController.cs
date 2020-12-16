using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ice_Cream.Models;
using Ice_Cream.Models.ViewModels;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Ice_Cream.Controllers
{
    public class RecipeController : Controller
    {

        //return view
        public IActionResult Index()
        {
            return View();
        }

        // phân trang
        private IStoreRepository repository;
        public RecipeController(IStoreRepository repo)
        {
            repository = repo;
        }
        public int PageSize = 3;
        public ViewResult CateRecipe(string category, int productPage = 1)
            => View(new ProductsListViewModel
            {
                Products = repository.Products
                .Where(p => category == null || p.Category == category)
                .OrderBy(p => p.ProductID)
                .Skip((productPage - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = productPage,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ?
                    repository.Products.Count() :
                    repository.Products.Where(
                        e => e.Category == category).Count()
                }
            });
        // page detail
        public IActionResult Detail(int id)
        {
            return View(
                new Detail
                {
                    Products = repository.Products.Where(p => p.ProductID == id)
                }
                );
        }


        // xử lí ngoại lệ
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

       
    }
}
