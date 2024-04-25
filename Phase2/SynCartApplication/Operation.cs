using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SynCartApplication
{
    public static class Operation
    {
        static CustomerDetails currentCustomer;
        //lists
        static List<CustomerDetails> customerDetailsList=new List<CustomerDetails>();
        static List<ProductDetails> productDetailsList=new List<ProductDetails>();
        static List<OrderDetails> orderDetailsList=new List<OrderDetails>();
        //main menu
        /*1.	Customer Registration
        2.	Login
        3.	Exit
        */
        public static void MainMenu(){
            Console.WriteLine("********************Welcome to SynCart *************************");
            string mainChoice="yes";
            do{
                Console.WriteLine("Select option\n1.Customer Registration\n2.Login\n3.Exit ");
                int option=int.Parse(Console.ReadLine());
                switch(option){
                    case 1:{
                        Console.WriteLine("************Customer Registration***********");
                        CustomerRegistration();
                        break;
                    }case 2:{
                        Console.WriteLine("************Login***********");
                        Login();
                        break;
                    }case 3:{
                        Console.WriteLine("************Exit successfully***********");
                        mainChoice="no";
                        break;
                    }
                }               
            }while(mainChoice=="yes");         
        } //main menu end
        //customer registration
        public static void CustomerRegistration(){
            //get customer details from user
            Console.Write("Enter customer name : ");
            string name=Console.ReadLine();
            Console.Write("Enter customer city : ");
            string city=Console.ReadLine();
            Console.Write("Enter customer Phone Number : ");
            long phoneNumber=long.Parse(Console.ReadLine());
            Console.Write("Enter customer Mail ID : ");
            string mailID=Console.ReadLine();
            Console.Write("Enter customer Wallet Balance : ");
            int walletBalance=int.Parse(Console.ReadLine());
            //object creation
            CustomerDetails customer=new CustomerDetails(name,city,phoneNumber,walletBalance,mailID);
            //add to list
            customerDetailsList.Add(customer);
            //display customer id
            Console.WriteLine($"Customer registration is successfully done and customer ID is {customer.CustomerID}");
        }//customer registration end
        //Login
        public static void Login(){
            //get customer id
            Console.WriteLine("Enter your customer ID");
            String customerId=Console.ReadLine().ToUpper();
            //validate the customer id
            bool flag=true;
            foreach(CustomerDetails customer in customerDetailsList){
                if(customerId.Equals(customer.CustomerID)){
                    flag=false;
                    currentCustomer=customer;
                    //create sub menu
                    SubMenu();
                    break;
                }
            }
            if(flag){
                Console.WriteLine("Invalid customerID");
            }
            
        }//Login end
        //sub menu
        /*a.	Purchase
        b.	Order History
        c.	Cancel Order
        d.	Wallet Balance
        e.	WalletRecharge
        f.	Exit
        */
        public static void SubMenu(){
            string subChoice="yes";
            do{
                Console.WriteLine("Select option\n1.Purchase\n2.Order History\n3.Cancel Order\n4.Wallet Balance\n5.WalletRecharge\n6.Exit");
                int subOption=int.Parse(Console.ReadLine());
                switch(subOption){
                    case 1:{
                        Console.WriteLine("************Purchase*************");
                        Purchase();
                        break;
                    }case 2:{
                        Console.WriteLine("************Order History*************");
                        OrderHistory();
                        break;
                    }case 3:{
                        Console.WriteLine("************Cancel Order*************");
                        CancelOrder();
                        break;
                    }case 4:{
                        Console.WriteLine("************Wallet Balance*************");
                        WalletBalance();
                        break;
                    }case 5:{
                            Console.WriteLine("************WalletRecharge*************");
                            Console.WriteLine("Do you want to recharge your wallet ? yes/no");
                            string answer = Console.ReadLine();
                            if(answer=="yes"){
                                WalletRecharge();
                            }else{
                                subChoice="no";                                
                            }
                            
                            break;
                        }
                    case 6:{
                        Console.WriteLine("************Exit sucessfully*************");
                        subChoice="no";
                        break;
                    }
                }
            }while(subChoice=="yes");
        }//sub menu end
        //Purchase
        public static void Purchase(){
            Console.WriteLine($"|{"ProductID",-14}|{"Product Name",-18}|{"Available Stock Quantity",-25}|{"Price Per Quantity",-20}|{"Shipping Duration",-20}|");
            foreach(ProductDetails product in productDetailsList){
                Console.WriteLine($"|{product.ProductID,-14}|{product.ProductName,-18}|{product.Stock,-25}|{product.Price,-20}|{product.ShippingDuration,-20}|");            
            }
            Console.Write("Select product id which you want : ");
            string productId=Console.ReadLine();
            //validate product id
            bool flag=true;
            foreach(ProductDetails product in productDetailsList){
                if(productId.Equals(product.ProductID)){
                    flag=false;
                    Console.Write("Enter a count you wish to purchase : ");
                    int requireCount=int.Parse(Console.ReadLine());
                    if(requireCount<=product.Stock){
                        int deliverycharge=50;
                        int totalAmount = (requireCount*product.Price) + deliverycharge;
                        if(currentCustomer.WalletBalance>=totalAmount){
                            currentCustomer.DeductBalance(totalAmount);
                            product.Stock=product.Stock-requireCount;
                            OrderDetails order=new OrderDetails(currentCustomer.CustomerID,product.ProductID,totalAmount,DateTime.Now,requireCount,OrderStatus.Ordered);
                            orderDetailsList.Add(order);
                            Console.WriteLine($"Order Placed Successfully. Order ID: {order.OrderID}");
                            Console.WriteLine($"Order placed successfully. Your order will be delivered on {order.PurchaseDate.AddDays(product.ShippingDuration)}");
                        }else{
                            Console.WriteLine("Insufficient Wallet Balance. Please recharge your wallet and do purchase again");
                        }
                    }else{
                        Console.WriteLine($"Required count not available. Current availability is {product.Stock}");
                    }
                    break;
                }

            }
            if(flag){
                Console.WriteLine("Invalid ProductID");
            }

        }//Purchase end
        //Order History
        public static void OrderHistory(){
            Console.WriteLine($"|{"Order ID",-10}|{"customerID",-10}|{"productID",-10}|{"totalPrice",-10}|{"purchaseDate",-10}|{"quantity",-10}|{"orderStatus",-10}");
            foreach(OrderDetails order in orderDetailsList){
                if(currentCustomer.CustomerID.Equals(order.CustomerID)){
                    Console.WriteLine($"|{order.OrderID,-10}|{order.CustomerID,-10}|{order.ProductID,-10}|{order.TotalPrice,-10}|{order.PurchaseDate,-10}|{order.Quantity,-10}|{order.OrderStatus,-10}");
                }
            }
        }//Order History end
        //Cancel Order
        public static void CancelOrder(){
            Console.WriteLine($"|{"Order ID",-10}|{"customerID",-10}|{"productID",-10}|{"totalPrice",-10}|{"purchaseDate",-10}|{"quantity",-10}|{"orderStatus",-10}");
            foreach(OrderDetails order in orderDetailsList){
                if(currentCustomer.CustomerID.Equals(order.CustomerID)&& order.OrderStatus.Equals(OrderStatus.Ordered)){
                    Console.WriteLine($"|{order.OrderID,-10}|{order.CustomerID,-10}|{order.ProductID,-10}|{order.TotalPrice,-10}|{order.PurchaseDate,-10}|{order.Quantity,-10}|{order.OrderStatus,-10}");
                    Console.WriteLine("Enter order id which you want to cancel");
                    string cancelOrderID=Console.ReadLine();
                    if(cancelOrderID.Equals(order.OrderID)){
                        order.Quantity++;
                        order.OrderStatus=OrderStatus.Cancelled;
                        currentCustomer.WalletBalance=currentCustomer.WalletBalance+order.TotalPrice;
                        Console.WriteLine($"Order :{order.OrderID} cancelled successfully");
                        break;
                    }else{
                        Console.WriteLine("Invalid OrderID");
                    }
                }
            }
        }//Cancel Order end
        //Wallet Balance
        public static void WalletBalance(){
            //display wallet balance
           Console.WriteLine($"{currentCustomer.Name} wallet balance is {currentCustomer.WalletBalance}") ;
        }//Wallet Balance end
        //WalletRecharge
        public static void WalletRecharge(){
            
            //get amount from user
            
                Console.Write("Enter recharge amount : ");
                int rechargeAmount=int.Parse(Console.ReadLine());
                currentCustomer.WalletRecharge(rechargeAmount);
                Console.WriteLine($"your updated wallet balance is : {currentCustomer.WalletBalance}");
            
        }//WalletRecharge end

        //add default values
        public static void DefaultValues(){
            CustomerDetails customer1=new CustomerDetails("Ravi","Chennai",9885858588,50000,"ravi@mail.com");
            CustomerDetails customer2=new CustomerDetails("Baskaran","Chennai",9888475757,60000,"baskaran@mail.com");
            customerDetailsList.AddRange(new List<CustomerDetails>(){customer1,customer2});
            OrderDetails order1=new OrderDetails("CID1001","PID101",20000,DateTime.Now,2,OrderStatus.Ordered);
            OrderDetails order2=new OrderDetails("CID1002","PID102",40000,DateTime.Now,2,OrderStatus.Ordered);
            orderDetailsList.AddRange(new List<OrderDetails>(){order1,order2});  
            ProductDetails product1=new ProductDetails("Mobile (Samsung)",10,10000,3);
            ProductDetails product2=new ProductDetails("Tablet (Lenovo)",5,15000,2);
            ProductDetails product3=new ProductDetails("Camara (Sony)",3,20000,4);
            ProductDetails product4=new ProductDetails("iPhone",5,50000,6);
            ProductDetails product5=new ProductDetails("Laptop (Lenovo I3)",3,40000,3);
            ProductDetails product6=new ProductDetails("HeadPhone (Boat)",5,1000,2);
            ProductDetails product7=new ProductDetails("Speakers (Boat)",4,500,2);
            productDetailsList.AddRange(new List<ProductDetails>(){product1,product2,product3,product4,product5,product6,product7});
   
        } //add default values end             				

    }
}