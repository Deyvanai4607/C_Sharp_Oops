using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection.Metadata;
namespace EBBillCalculation;
class Program{
    public static void Main(string[] args)
    {
        List<EBBillDetails> EBList=new List<EBBillDetails>();
        string userAns="no";
        do{
            Console.WriteLine("Select option - 1 for registration 2 for login 3 for exit");
            int option=int.Parse(Console.ReadLine());
            EBBillDetails eb=new EBBillDetails();
            
            
            switch(option){
                case 1:
                {                    
                    Console.WriteLine("Your EB Id : "+eb.MeterId);
                    Console.WriteLine("Enter your Username : ");
                    eb.UserName=Console.ReadLine();
                    Console.WriteLine("Enter your Phone Number : ");
                    eb.PhoneNumber=long.Parse(Console.ReadLine());
                    Console.WriteLine("Enter your Mail Id :");
                    eb.MailId=Console.ReadLine();
                    EBList.Add(eb);
                    break;
                }
                case 3:{
                    break;
                }
                case 2:{
                    Console.WriteLine("Enter your Meter Id ");
                    string meterId=Console.ReadLine();
                    foreach(EBBillDetails ebInfo in EBList){

                        if(meterId.Equals(ebInfo.MeterId)){
                            string subAns="no";
                            do{
                            Console.WriteLine("Select the Option - 1. Calculate Amount 2. Display user Details 3. Exit");
                            int subOption=int.Parse(Console.ReadLine());
                            switch(subOption){
                                case 1:{
                                    Console.WriteLine("Enter Units : ");
                                    int unit=int.Parse(Console.ReadLine());
                                    int totalAmount=eb.CalculateAmount(unit);
                                    Console.WriteLine("*************Bill Details**********");
                                    Console.WriteLine($"EB Bill Id : {ebInfo.MeterId}");
                                    Console.WriteLine($"User Name : {ebInfo.UserName}");
                                    Console.WriteLine($"Unit : {unit}");
                                    Console.WriteLine($"Total Amount: {totalAmount}");
                                    break;//Meter ID -(EB1001), Username, Phone number, Mail id
                                }
                                case 2:{
                                    Console.WriteLine("************ User details *********** ");
                                    Console.WriteLine($"Meter ID : {ebInfo.MeterId}");
                                    Console.WriteLine($"Username : {ebInfo.UserName}");
                                    Console.WriteLine($"Phone number : {ebInfo.PhoneNumber}");
                                    Console.WriteLine($"Mail id : {ebInfo.MailId}");
                                    break;
                                }
                                
                                case 3:{
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
