using AzureWebApp.Model;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace AzureWebApp.Service
{
    public class ProductService
    {
        private static string db_source = "azureappdbserver1.database.windows.net";
        private static string db_user = "sqladmin";
        private static string db_password = "Azure@123";
        private static string db_database = "AppServiceDB";

        private IConfiguration _configuration;
        public static IConfiguration Config;

        public ProductService(IConfiguration cofiguration)
        {
            _configuration = cofiguration;
        }

        private SqlConnection GetConnection()
        {
            var _builder = new SqlConnectionStringBuilder();
            _builder.UserID = db_user;
            _builder.Password = db_password;
            _builder.DataSource = db_source;
            _builder.InitialCatalog = db_database;

            string connStr = _configuration.GetConnectionString("ConnectionString");
            connStr = Config.GetConnectionString("ConnectionString");



            //return new SqlConnection(_builder.ConnectionString);
            return new SqlConnection(connStr);
        }

        public List<Product> GetProducts()
        {
            SqlConnection conn = GetConnection();

            List<Product> products = new List<Product>();

            conn.Open();
            SqlCommand comm = new SqlCommand("Select ProductId, ProductName, Quantity from Products", conn);

            SqlDataReader dataReader = comm.ExecuteReader();

            while (dataReader.Read())
            {
                Product product = new Product()
                {
                    ProductId = dataReader.GetInt32(0),
                    ProductName = dataReader.GetString(1),
                    Quantity = dataReader.GetInt32(2)
                };

                products.Add(product);
            }

            conn.Close();

            return products;
        }

    }
}
