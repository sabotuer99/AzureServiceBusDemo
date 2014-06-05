using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ProductsServer
{
    //Implement the IProducts interface
    class ProductsService : IProducts
    {
        // Populate array of products for display on Web site
        ProductData[] products =
            new[] 
            {
                new ProductData{Id = "1", Name = "Rock", Quantity = "1" },
                new ProductData{Id = "2", Name = "Paper", Quantity = "3" },
                new ProductData{Id = "3", Name = "Scissors", Quantity = "5" },
                new ProductData{Id = "4", Name = "Well", Quantity = "2500" }
            };

        public IList<ProductData> GetProducts()
        {
            Console.WriteLine("GetProducts called.");
            return products;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var sh = new ServiceHost(typeof(ProductsService));
            sh.Open();

            Console.WriteLine("Press ENTER to close");
            Console.ReadLine();

            sh.Close();
        }
    }
}
