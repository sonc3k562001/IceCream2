using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Ice_Cream.Infrastructure;
using Ice_Cream.Models;

namespace Ice_Cream.Pages
{
    public class CartModel : PageModel
    {

        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }



        private IStoreRepository repository;


        public CartModel(IStoreRepository repo)
        {
            repository = repo;
        }



        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        }

        public IActionResult OnPost(long productId, string returnUrl)
        {
            Product product = repository.Products
                .FirstOrDefault(p => p.ProductID == productId);
            Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
            Cart.AddItem(product, 1);
            HttpContext.Session.SetJson("cart", Cart);
            return RedirectToPage(new { returnUrl = returnUrl });
        }
        public IActionResult OnPostRemove(long productId, string returnUrl)
        {
            Product product = repository.Products
           .FirstOrDefault(p => p.ProductID == productId);
            Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
            Cart.RemoveById(productId);
            HttpContext.Session.SetJson("cart", Cart);
            return RedirectToPage(new { returnUrl = returnUrl });
        }


        public IActionResult OnPostClear(string returnUrl)
        {

            Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
            Cart.Clear();
            return RedirectToPage(new { returnUrl = returnUrl });
        }
    }
}