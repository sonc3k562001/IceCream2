using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ice_Cream.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ice_Cream.Pages
{
    public class UserModel : PageModel
    {
        private StoreDbContext db;

        [BindProperty]
        public Customer customer { get; set; }



        public UserModel(StoreDbContext _db)
        {
            db = _db;
        }

        public void OnGet()
        {
            customer = new Customer();
        }

        public void OnPost()
        {
            db.Customers.Add(customer);
            db.SaveChanges();

        }
    }
}