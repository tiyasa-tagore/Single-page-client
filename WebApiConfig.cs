using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Http;
using YourAppNamespace.Models; // Change to your actual namespace and model
public static class WebApiConfig
{
    public static void Register(HttpConfiguration config)
    {
        // Other configuration code...

        // Route for the ProductsController
        config.Routes.MapHttpRoute(
            name: "DefaultApi",
            routeTemplate: "api/{controller}/{id}",
            defaults: new { id = RouteParameter.Optional }
        );
    }
}

public class ProductsController : ApiController
{
    // GET api/products
    [HttpGet]
    public IHttpActionResult GetProductsServices()
    {
        // Assuming you have a class 'ProductService' to represent the data
        List<ProductService> products = new List<ProductService>();
        string connectionString = "YourConnectionString"; // Replace with your actual connection string

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Products_Service_Tbl", conn))
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ProductService product = new ProductService
                        {
                            Id = (int)reader["Id"], // Replace with actual column name
                            Name = reader["Name"].ToString(), // Replace with actual column name
                            // Add other properties as necessary
                        };
                        products.Add(product);
                    }
                }
            }
        }

        return Ok(products); // Serializes the list to JSON automatically
    }
}

