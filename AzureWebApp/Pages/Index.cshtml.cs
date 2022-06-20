using AzureWebApp.Model;
using AzureWebApp.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureWebApp.Pages
{
    public class IndexModel : PageModel
    {

        public List<Product> products;

        public void OnGet()
        {
            ProductService productService = new ProductService();
            products = productService.GetProducts();


        }
    }
}
