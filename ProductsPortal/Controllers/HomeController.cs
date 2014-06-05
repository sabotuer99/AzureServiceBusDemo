using Microsoft.ServiceBus;
using ProductsPortal.Models;
using ProductsServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.Web.Mvc;

namespace ProductsPortal.Controllers
{
    public class HomeController : Controller
    {
        //declare the channel factory
        static ChannelFactory<IProductChannel> channelFactory;

        static HomeController()
        {
            //create shared secret token credentials for authentication
            channelFactory = new ChannelFactory<IProductChannel>(new NetTcpRelayBinding(), "sb://[YourAzureNamespace].servicebus.windows.net/products");

            channelFactory.Endpoint.EndpointBehaviors.Add(new TransportClientEndpointBehavior { TokenProvider = TokenProvider.CreateSharedSecretTokenProvider("owner", "[YourIssuerSecret]") });
        }

        
        public ActionResult Index()
        {
            using(IProductChannel channel = channelFactory.CreateChannel())
            {
                //return the view of the products inventory
                return this.View(from prod in channel.GetProducts()
                                 select
                                 new Product { Id = prod.Id, Name = prod.Name, Quantity = prod.Quantity });
            }
        }
    }
}