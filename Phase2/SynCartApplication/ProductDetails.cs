using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SynCartApplication
{
    public class ProductDetails
    {
        //static field 
        private static int s_productID=100;
        //properties
        public string ProductID { get;  }//read only
        public string ProductName { get; set; }
        public int Price { get; set; }
        public int Stock { get; set; }
        public int ShippingDuration { get; set; }
        //Constructor
        public ProductDetails(string productName,int price,int stock,int shippingDuration){
            s_productID++;
            ProductID="PID"+s_productID;
            ProductName=productName;
            Price=price;
            Stock=stock;
            ShippingDuration=shippingDuration;
        }
    }
}