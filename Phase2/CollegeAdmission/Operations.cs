using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace CollegeAdmission
{
    //static class
    public static class Operations
    {
        //Local/Global Object creation
        static StudentDetails currentLogedInStudent;

        //static list creation
        public static List<StudentDetails> studentList=new List<StudentDetails>();
        public static List<DepartmentDetails> departmenttList=new List<DepartmentDetails>();
        public static List<AdmissionDetails> admissiontList=new List<AdmissionDetails>();
        //main menu
        public static void MainMenu(){
            Console.WriteLine("*************Welcome to Syncfusion College of Engineering and Technology***********");
            
           string mainChoice="yes";
           do{
                //need to show the main menu option 
                Console.WriteLine("Main menu\n1.Student Registration\n2.Student Login\n3.Department wise seat availability\n4.Exit");
                //need to get an input from user and validate.
                Console.Write("Select an Option : ");
                int mainOption = int.Parse(Console.ReadLine());

                //need to create mainmenu structure
                switch (mainOption)
                {
                    case 1:
                        {
                            Console.WriteLine("************Student Registration*****************");
                            StudentRegistration();
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("************Student Login*****************");
                            StudentLogin();
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("************Department wise seat availability*****************");
                            DepartmentwiseSeatAvailability();
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("************Application Exit Successfully*****************");
                            mainChoice="no";
                            break;
                        }
                }
                //need to iterate until the the option is exit
            } while (mainChoice=="yes");
        }//main menu ends

        //student registration
        public static void StudentRegistration(){
            //need to get required details
            Console.Write("Enter your Name : ");
            string name=Console.ReadLine();
            Console.Write("Enter your father name : ");
            string fatherName=Console.ReadLine();
            Console.Write("Enter your Date Of Birth dd/MM/yyyy : ");
            DateTime dob=DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy",null);
            Console.Write("Enter your genmder (Male/Female) : ");
            Gender gender=Enum.Parse<Gender>(Console.ReadLine(),true);
            Console.Write("Enter your Physics mark : ");
            int physics=int.Parse(Console.ReadLine());
            Console.Write("Enter your chemistry mark : ");
            int chemistry=int.Parse(Console.ReadLine());
            Console.Write("Enter your maths mark : ");
            int maths=int.Parse(Console.ReadLine());
            //need to create an object
            StudentDetails student=new StudentDetails(name,fatherName,dob,gender,physics,chemistry,maths);
            //need to add in list
            studentList.Add(student);
            //need to display confirmation message and id
            Console.WriteLine($"Registration Successfull your ID is {student.StudentID}");

        } //student registration end

        //student Login
        public static void StudentLogin(){
            //need to get ID input
            Console.Write("Enter your ID : ");
            string loginID=Console.ReadLine().ToUpper();
            //validate by its presence in the list
            bool flag=true;
            foreach(StudentDetails student in studentList){
                if(loginID.Equals(student.StudentID)){
                    flag=false;
                    //assigning current user to global variable 
                    currentLogedInStudent=student;
                    Console.WriteLine("Loged in successfully");
                    //need to call sub menu
                    SubMenu();
                    break;
                }
            }
            if(flag){
                Console.WriteLine("Invalid ID or ID is not present");
            }
            //if not - Invalid 
        }//student Login end
        //sub menu
        public static void SubMenu(){
            string subChoice="yes";
            do{
                Console.WriteLine("***********Sub Menu******************");
                //need to show submenu option
                Console.WriteLine("Select an option\n1.check eligibility\n2.show details\n3.take addmission\n4.cancel admission\n5.Show Admission Details\n6.Exit");
                //getting user option
                Console.WriteLine("Enter option ");
                int subOption=int.Parse(Console.ReadLine());
                //need to create submenu structure
                switch(subOption){
                    case 1:{
                        Console.WriteLine("***************Check Eligibility********************");
                        CheckEligibility();
                        break;
                    }case 2:{
                        Console.WriteLine("************show details*******************");
                        ShowDetails();
                        break;
                    }case 3:{
                        Console.WriteLine("************take addmission*******************");
                        TakeAddmission();
                        break;
                    }case 4:{
                        Console.WriteLine("************cancel admission*******************");
                        CancelAdmission();
                        break;
                    }case 5:{
                        Console.WriteLine("************Show Admission Details*******************");
                        ShowAdmissionDetails();
                        break;
                    }case 6:{
                        Console.WriteLine("taking back to main menu ");
                        subChoice="no";
                        break;
                    }
                }
                //iterate till the option is exit
            }while(subChoice=="yes");
        }//end sub menu
        //CheckEligibility
        public static void CheckEligibility(){
            //get cutOff value as input
            Console.Write("Enter cutoff value : ");
            double cutOff=double.Parse(Console.ReadLine());
            //check eligble or not eligible
            if(currentLogedInStudent.CheckEligibility(cutOff)){
                Console.WriteLine("Student is eligible ");
            }else{
                Console.WriteLine("Student is not eligible");
            }
        }//CheckEligibility end
        //show details
        public static void ShowDetails(){
            //need to show current student's details
            Console.WriteLine("|student ID|Student name|student father name|student DOB|student Gender|student physics mark|student chemistry mark|student maths mark");
            Console.WriteLine($"|{currentLogedInStudent.StudentID}|{currentLogedInStudent.StudentName}|{currentLogedInStudent.FatherName}|{currentLogedInStudent.DOB}|{currentLogedInStudent.Gender}|{currentLogedInStudent.Physics}|{currentLogedInStudent.Chemistry}|{currentLogedInStudent.Maths}|");
        } //show details END
        //take addmission
        public static void TakeAddmission(){
            //need to show available department details
            DepartmentwiseSeatAvailability();
            //ask deprtment id from user
            Console.Write("Select an department ID: ");
            string departmentID=Console.ReadLine().ToUpper();
            //check the id present or not
            bool flag=true;
            foreach(DepartmentDetails department in departmenttList ){
                if(departmentID.Equals(department.DepartmentID)){
                    flag=false;
                    //check the student eligible or not
                    if(currentLogedInStudent.CheckEligibility(75.0)){
                        //check the seat availability
                        if(department.NumberOfSeats>0){
                            //check student already take any admission
                            int count=0;
                            foreach(AdmissionDetails admission in admissiontList){
                                if(currentLogedInStudent.StudentID.Equals(admission.StudentID)&& admission.AdmissionStatus.Equals(AdmissionStatus.Admitted)){
                                    count++;
                                }
                            }
                            if(count==0){
                                //create admission object
                                AdmissionDetails takeAdmission=new AdmissionDetails(currentLogedInStudent.StudentID,department.DepartmentID,DateTime.Now,AdmissionStatus.Admitted);

                                //reduce seat count
                                department.NumberOfSeats--;
                                // add to the admission list
                                admissiontList.Add(takeAdmission);
                                //display admission success message
                                Console.WriteLine($"you have take admission sucessfully. Admission ID: {takeAdmission.AdmissionID} ");
                            }
                            else
                            {
                                Console.WriteLine("you have already take a admission");
                            }
                            
                        }
                        else
                        {
                            Console.WriteLine("Seats are not available");
                        }
                        
                    }
                    else
                    {
                        Console.WriteLine("your not eligible due to low cutoff");
                    }
                    
                    break;
                }
            }
            if(flag){
                Console.WriteLine("Invalid ID or ID not found");
            }
            
        }//take addmission end
        //cancel admission
        public static void CancelAdmission(){
            //check the student is taken any admission and display it
            bool flag=true;
            foreach(AdmissionDetails admission in admissiontList){
                if(currentLogedInStudent.StudentID.Equals(admission.StudentID)&& admission.AdmissionStatus.Equals(AdmissionStatus.Admitted)){
                    //cancel the found admission
                    admission.AdmissionStatus=AdmissionStatus.Cancelled;
                    //return the seat to department
                    foreach(DepartmentDetails department in departmenttList){
                        if(admission.DepartmentID.Equals(department.DepartmentID)){
                            department.NumberOfSeats++;
                            break;
                        }
                    }
                    break;
                }
            }
            if(flag){
                Console.WriteLine("you have not admission to cancel");
            }
            
        }//cancel admission end
        //Show Admission Details
        public static void ShowAdmissionDetails(){
            //need to show curerrent loged in student's admission details
            Console.WriteLine("|Admission ID|Student ID|Department ID|Admission Date|Admission Status|");
            foreach(AdmissionDetails admission in admissiontList){
               if(currentLogedInStudent.StudentID.Equals(admission.StudentID)){
                 Console.WriteLine($"|{admission.AdmissionID}|{admission.StudentID}|{admission.DepartmentID}|{admission.AdmissionDate}|{admission.AdmissionStatus}|");
               }
            }
            Console.WriteLine();

        }//Show Admission Details end

        //Department wise seat availability
        public static void DepartmentwiseSeatAvailability(){
            //need to show all department details
            string line="___________________________________________________";
            Console.WriteLine(line);
            Console.WriteLine($"|{"DepartmentID",-12}|{"DepartmentName",-14}|{"NumberOfSeats",-13}");
            Console.WriteLine(line);
            foreach(DepartmentDetails department in departmenttList){
                
                Console.WriteLine($"|{department.DepartmentID,-12}|{department.DepartmentName,-14}|{department.NumberOfSeats,-13}|");
                Console.WriteLine(line);
            }
            Console.WriteLine();
        }//Department wise seat availability END

        //adding default data
        public static void AddDefaultData(){
            StudentDetails student1=new StudentDetails("Ravichandran E","Ettapparajan",new DateTime(1999,11,11),Gender.Male,95,95,95);
            StudentDetails student2=new StudentDetails("Baskaran S","Sethurajan",new DateTime(1999,11,11),Gender.Male,95,95,95);
            // studentList.Add(student1);
            // studentList.Add(student2);
            studentList.AddRange(new List<StudentDetails>(){student1,student2});
            DepartmentDetails department1=new DepartmentDetails("EEE",29);
            DepartmentDetails department2=new DepartmentDetails("CSE",29);
            DepartmentDetails department3=new DepartmentDetails("MECH",30);
            DepartmentDetails department4=new DepartmentDetails("ECE",30);
            departmenttList.AddRange(new List<DepartmentDetails>(){department1,department2,department3,department4});
            AdmissionDetails admission1=new AdmissionDetails(student1.StudentID,department1.DepartmentID,new DateTime(2022,05,11),AdmissionStatus.Admitted);
            AdmissionDetails admission2=new AdmissionDetails(student2.StudentID,department2.DepartmentID,new DateTime(2022,05,12),AdmissionStatus.Admitted);
            admissiontList.AddRange(new List<AdmissionDetails>(){admission1,admission2});

          
            
            
            
        }//default ends
    }
}