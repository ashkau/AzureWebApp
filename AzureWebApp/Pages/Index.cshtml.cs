using AzureWebApp.Model;
using AzureWebApp.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
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

        private IProductService _productService;
        public IndexModel(IProductService productService)
        {
            _productService = productService;
        }

        public void OnGet()
        {
            //IConfiguration Configuration;

            //var builder = new ConfigurationBuilder()
            //.AddJsonFile("appSettings.json");

            //Configuration = builder.Build();

            //ProductService productService = new ProductService(Configuration);
            //products = productService.GetProducts();

            products = _productService.GetProducts();
        }
    }
}
