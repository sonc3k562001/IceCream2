using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ice_Cream.Infrastructure;
using Ice_Cream.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ice_Cream.Pages
{
    public class CheckoutModel : PageModel
    {
        //create method
        private StoreDbContext db;
        public Cart Cart { get; set; }
        [BindProperty]
        public Bill bill { get; set; }
        public string ReturnUrl { get; set; }


        //method
        public void OnGet(string returnUrl)//get info cart
        {
            bill = new Bill();

            ReturnUrl = returnUrl ?? "/";
            Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        }

        public CheckoutModel(StoreDbContext _db)
        {
            db = _db;
        }



        public void OnPost()
        {

            db.Bills.Add(bill);
            db.SaveChanges();
        }
    }
}
