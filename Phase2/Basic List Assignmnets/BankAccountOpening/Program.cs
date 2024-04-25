using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection.Metadata;
namespace BankAccountOpening;
class Program{
    public static void Main(string[] args)
    {
        List<CustomerDetails> customerList=new List<CustomerDetails>();
        string userAns="no";
        do{
            Console.WriteLine("Select option - 1 for registration 2 for login 3 for exit");
            int option=int.Parse(Console.ReadLine());
            CustomerDetails customer1=new CustomerDetails();
            
            
            switch(option){
                case 1:
                {
                    
                    Console.WriteLine("Your Id : "+customer1.CustomerId);
                    
                    Console.WriteLine("Enter your Name : ");
                    customer1.CustomerName=Console.ReadLine();
                    Console.WriteLine("Enter your Balance : ");
                    customer1.Balance=int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter your Gender : female/male");
                    customer1.Gender=Enum.Parse<Gender>(Console.ReadLine());
                    Console.WriteLine("Enter your Phone Number : ");
                    customer1.Phone=long.Parse(Console.ReadLine());
                    Console.WriteLine("Enter your Mail Id : ");
                    customer1.MailId=Console.ReadLine();
                    Console.WriteLine("Enter your Date of birth : ");
                    customer1.Dob=DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy",null);
                    customerList.Add(customer1);
                     
                     
                    
                    break;
                }
                case 3:{
                    break;
                }
                case 2:{
                    Console.WriteLine("Enter your Customer Id ");
                    string customerid=Console.ReadLine();
                    foreach(CustomerDetails customerInfo in customerList){

                        if(customerid.Equals(customerInfo.CustomerId)){
                            string subAns="no";
                            do{
                            Console.WriteLine("Select the Option - 1. Deposit, 2. withdraw, 3.balance check 4. exit");
                            int subOption=int.Parse(Console.ReadLine());
                            switch(subOption){
                                case 1:{
                                    Console.WriteLine("Enter your deposit amount : ");
                                    int deposit=int.Parse(Console.ReadLine());
                                    customerInfo.Balance=customer1.DepositeAmount(customerInfo.Balance,deposit);
                                    Console.WriteLine($"Your Current Balance is : {customerInfo.Balance}");
                                    break;
                                }
                                case 2:{
                                    Console.WriteLine("Enter your withdraw amount : ");
                                    int withdraw=int.Parse(Console.ReadLine());
                                    customerInfo.Balance=customer1.Withdraw(customerInfo.Balance,withdraw);
                                    Console.WriteLine($"Your Current Balance is : {customerInfo.Balance}");

                                    break;
                                }
                                case 3:{
                                    Console.WriteLine($"Current Balance : {customerInfo.Balance}");
                                    break;
                                }
                                case 4:{
                                    subAns="no";
                                    break;
                                }
                            }
                            Console.WriteLine("Do you want to continue ? yes/no");
                            subAns=Console.ReadLine();
                            }while(subAns=="yes");

                        }else{
                            Console.WriteLine( "Invalid user ID");
                         }
                    }
                    break;
                }
            }
            Console.WriteLine("Do you want to continue ? yes/no");
            userAns=Console.ReadLine();
        }while(userAns=="yes");
        
        
     
        
    }
    
    
}
