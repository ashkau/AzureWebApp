using AzureWebApp.Model;
using System.Collections.Generic;

namespace AzureWebApp.Service
{
    public interface IProductService
    {
        List<Product> GetProducts();
    }
}