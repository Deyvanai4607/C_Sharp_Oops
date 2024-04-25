using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SynCartApplication
{
    //enum creation
    public enum OrderStatus{Default, Ordered, Cancelled}
    public class OrderDetails
    {
        //static field creation
        private static int s_orderID=1000;
        //properties creation
        public string OrderID { get; }//read only
        public string CustomerID { get; set; }
        public string ProductID { get; set; }
        public int TotalPrice { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int Quantity { get; set; }
        public OrderStatus OrderStatus { get; set; }        
        //Contructor creation
        public OrderDetails(string customerID,string productID,int totalPrice,DateTime purchaseDate,int quantity,OrderStatus orderStatus){
            s_orderID++;
            OrderID="OID"+s_orderID;
            CustomerID=customerID;
            ProductID=productID;
            TotalPrice=totalPrice;
            PurchaseDate=purchaseDate;
            Quantity=quantity;
            OrderStatus=orderStatus;
        }

    }
}