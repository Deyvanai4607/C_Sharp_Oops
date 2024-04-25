using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection.Metadata;
namespace EmployeePayrollManagement;
class Program{
    public static void Main(string[] args)
    {
        List<EmployeeDetails> employeeList=new List<EmployeeDetails>();
        string userAns="no";
        do{
            Console.WriteLine("Select option - 1 for registration 2 for login 3 for exit");
            int option=int.Parse(Console.ReadLine());
            EmployeeDetails employee=new EmployeeDetails();
            
            
            switch(option){
                case 1:
                {
                    
                    Console.WriteLine("Your Id : "+employee.EmployeeId);
                    Console.WriteLine("Enter your Name : ");
                    employee.EmployeeName=Console.ReadLine();
                    Console.WriteLine("Enter your Role : ");
                    employee.EmployeeRole=Console.ReadLine();
                    Console.WriteLine("Enter your Work location : chennai/US");
                    employee.WorkLocation=Enum.Parse<WorkLocation>(Console.ReadLine());
                    Console.WriteLine("Enter your Team Name : ");
                    employee.TeamName= Console.ReadLine();
                    Console.WriteLine("Enter your Date of joining : ");
                    employee.Doj=DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy",null);
                    Console.WriteLine("Enter your  Number of Working Days in Month : ");
                    employee.NoOfWorkingInMonth=int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter Number of Leave Taken");
                    employee.LeaveTaken=int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter your gender : female/male");
                    employee.Gender=Enum.Parse<Gender>(Console.ReadLine());
                    employeeList.Add(employee);
                    break;
                }
                case 3:{
                    break;
                }
                case 2:{
                    Console.WriteLine("Enter your Employee Id ");
                    string empId=Console.ReadLine();
                    foreach(EmployeeDetails empInfo in employeeList){

                        if(empId.Equals(empInfo.EmployeeId)){
                            string subAns="no";
                            do{
                            Console.WriteLine("Select the Option - 1. Calculate salary 2. display details 3. exit");
                            int subOption=int.Parse(Console.ReadLine());
                            switch(subOption){
                                case 1:{
                                    int salary=employee.SalaryCalculation(empInfo.NoOfWorkingInMonth,empInfo.LeaveTaken);
                                    Console.WriteLine($"Salary amount is : {salary}");
                                    break;
                                }
                                case 2:{
                                    Console.WriteLine("************Employee Details *********** ");
                                    Console.WriteLine($"Employee Id : {empInfo.EmployeeId}");
                                    Console.WriteLine($"Employee Name : {empInfo.EmployeeName}");
                                    Console.WriteLine($"Employee Role : {empInfo.EmployeeRole}");
                                    Console.WriteLine($"Employee Work location : {empInfo.WorkLocation}");
                                    Console.WriteLine($"Employee Team Name : {empInfo.TeamName}");
                                    Console.WriteLine($"Employee Date of joining : {empInfo.Doj}");
                                    Console.WriteLine($"Employee total Number of Working Days in Month : {empInfo.NoOfWorkingInMonth}");
                                    Console.WriteLine($"Employee Number of Leave Taken : {empInfo.LeaveTaken}");
                                    Console.WriteLine($"Employee gender : {empInfo.Gender}");
                                    

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
