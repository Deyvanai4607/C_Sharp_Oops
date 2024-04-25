using System;
using System.Collections.Generic;
namespace StudentAddmisionApplication;
class Program
{
   
    public static void Main(string[] args)
    {
        //1.	Student Registration
        // 2.	Student Login
        // 3.	Department wise seat availability
        // 4.	Exit
        List<StudentDetails> StudentList=new List<StudentDetails>();
        List<DepartmentDetails> departmentList=new List<DepartmentDetails>();
        List<AdmissionDetails> admissionList=new List<AdmissionDetails>();
        StudentDetails student1=new StudentDetails("Ravichandran E","Ettapparajan","11/11/1999","Male",95,95,95);
        StudentDetails student2=new StudentDetails("Baskaran S","Sethurajan","11/11/1999","Male",95,95,95);
        StudentList.Add(student1);
        StudentList.Add(student2);
        AdmissionDetails admi1=new AdmissionDetails("11/05/2022","Admitted");
        admissionList.Add(admi1);
        AdmissionDetails admi2=new AdmissionDetails("12/05/2022","Admitted");
        admissionList.Add(admi2);
        string userAns="no";
        do{
            Console.WriteLine("Select option 1.Student Registration 2.	Student Login 3.Department wise seat availability 4.Exit");
            int option=int.Parse(Console.ReadLine());
            
            //a.	StudentName
            // b.	FatherName
            // c.	DOB
            // d.	Gender – Enum (Select, Male, Female, Transgender)
            // e.	Physics
            // f.	Chemistry
            // g.	Maths

            switch(option){
                case 1:{
                    Console.WriteLine("Enter student name : ");
                    string studName=Console.ReadLine();
                    Console.WriteLine("Enter student father name : ");
                    string fatName=Console.ReadLine();
                    Console.WriteLine("Enter student Date of Birth : ");
                    string dob=Console.ReadLine();
                    Console.WriteLine("Enter student gender : ");
                    string gender=Console.ReadLine();
                    Console.WriteLine("Enter student physics mark : ");
                    int physics=int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter student Chemistry mark : ");
                    int chemistry=int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter student Maths mark : ");
                    int maths=int.Parse(Console.ReadLine());                  
                    StudentDetails student=new StudentDetails(studName, fatName, dob, gender, physics, chemistry, maths);
                    StudentList.Add(student);                  
                    Console.WriteLine($"Student Registered Successfully and StudentID is { student.StudentID}");                    
                    break;

                }case 2:{
                    Console.WriteLine("Enter student Id : ");
                    string studId=Console.ReadLine();
                    string depId;
                    foreach (StudentDetails studentInfo in StudentList)
                    {
                        if(studentInfo.StudentID==studId){
                            //a.	Check Eligibility
                            // b.	Show Details
                            // c.	Take Admission
                            // d.	Cancel Admission
                            // e.	Show Admission Details
                            // f.	Exit
                            string userSubAns="no";
                            do{
                                Console.WriteLine("Select option a.Check Eligibility b.Show Details c.Take Admission d.Cancel Admission e.Show Admission Details f.Exit ");
                                string subOption=Console.ReadLine();
                                switch(subOption){
                                    case "a":{
                                        StudentDetails student=new StudentDetails(studentInfo.StudentName, studentInfo.FatherName, studentInfo.DOB.ToString(), studentInfo.Gender.ToString(), studentInfo.Physics, studentInfo.Chemistry, studentInfo.Maths);
                                        bool result=student.CheckEligibility(studentInfo.Physics,studentInfo.Chemistry,studentInfo.Maths);
                                        if(result){
                                            Console.WriteLine("Student is eligible ");
                                        }else{
                                            Console.WriteLine("Student is not eligible");
                                        }
                                        break;
                                    }case "b":{
                                        Console.WriteLine("************Students details information***************");
                                        Console.WriteLine($"Student Name :{studentInfo.StudentID}");
                                        Console.WriteLine($"Student Name :{studentInfo.StudentName}");
                                        Console.WriteLine($"Student Father Name :{studentInfo.FatherName}");
                                        Console.WriteLine($"Student Date of Birth :{studentInfo.DOB}");
                                        Console.WriteLine($"Student Gender :{studentInfo.Gender}");        
                                        Console.WriteLine($"Student Physics mark :{studentInfo.Physics}");
                                        Console.WriteLine($"Student Chemistry mark :{studentInfo.Chemistry}");
                                        Console.WriteLine($"Student Maths mark :{studentInfo.Maths}");
                                        break;
                                    }case "c":{
                                        DepartmentDetails dep1=new DepartmentDetails("EEE",29);
                                        departmentList.Add(dep1);
                                        DepartmentDetails dep2=new DepartmentDetails("CSE",29);
                                        departmentList.Add(dep2);
                                        DepartmentDetails dep3=new DepartmentDetails("MECH",30);
                                        departmentList.Add(dep3);
                                        DepartmentDetails dep4=new DepartmentDetails("ECE",30);
                                        departmentList.Add(dep4);

                                        Console.WriteLine("Department ID   Department Name  Number of seat available");
                                        foreach(DepartmentDetails depInfo in departmentList ){
                                            Console.WriteLine(depInfo.DepartmentID+" "+depInfo.DepartmentName+" "+depInfo.NumberOfSeats);
                                        }
                                        Console.WriteLine("Select one department Id");
                                        depId=Console.ReadLine();
                                        foreach(DepartmentDetails departInfo in departmentList){
                                            if(depId==departInfo.DepartmentID){
                                                StudentDetails student=new StudentDetails(studentInfo.StudentName, studentInfo.FatherName, studentInfo.DOB.ToString(), studentInfo.Gender.ToString(), studentInfo.Physics, studentInfo.Chemistry, studentInfo.Maths);
                                                if(student.CheckEligibility(studentInfo.Physics,studentInfo.Chemistry,studentInfo.Maths)==true){
                                                    if(departInfo.NumberOfSeats>0){
                                                        bool addStatus=false;
                                                        foreach(AdmissionDetails admisInfo in admissionList){
                                                            
                                                            if(admisInfo.AdmissionStatus==Enum.Parse<AdmissionStatus>("Admitted")){
                                                                addStatus=true;
                                                                break;
                                                            }
                                                        }
                                                        if(!addStatus){
                                                            //and create admission details object by using StudentID, DepartmentID, AdmissionDate as Now, AdmissionStatus and Booked and add it to list.
                                                            departInfo.NumberOfSeats=departInfo.NumberOfSeats-1;
                                                            Console.WriteLine("Enter today date : dd/MM/yyyy");
                                                            string date=Console.ReadLine();
                                                            AdmissionDetails admisObj=new AdmissionDetails(date,"Admitted");
                                                            admissionList.Add(admisObj);
                                                            Console.WriteLine($"Admission took successfully. Your admission ID – {admisObj.AdmissionID}");

                                                        }
                                                        
                                                    }
                                                }
                                            }
                                        }
                                        
                                        break;
                                    }case "d":{
                                        AdmissionDetails adm=new AdmissionDetails();
                                        Console.WriteLine("Enter your Admision Id");
                                        string adId=Console.ReadLine(); 
                                        foreach(AdmissionDetails admiList in admissionList){
                                            if(adId==admiList.AdmissionID){
                                                Console.WriteLine($"Addmision ID is {admiList.AdmissionID}");
                                                Console.WriteLine($"Addmision date is {admiList.AdmissionDate}");
                                                Console.WriteLine($"Addmision status is {admiList.AdmissionStatus}");
                                                if(admiList.AdmissionStatus==Enum.Parse<AdmissionStatus>("Admitted")){
                                                   Console.WriteLine("Enter your department Id");
                                                   string depaId=Console.ReadLine(); 
                                                   admiList.AdmissionStatus=Enum.Parse<AdmissionStatus>("Cancelled");
                                                   foreach(DepartmentDetails departInfo in  departmentList){
                                                    if(depaId==departInfo.DepartmentID)
                                                        departInfo.NumberOfSeats=departInfo.NumberOfSeats+1;
                                                        Console.WriteLine("admission cancelled successfully");
                                                    }                                              

                                                }
                                            }
                                        }
                                        break;
                                    }case "e":{
                                        Console.WriteLine("*************Admission information************ ");
                                        Console.WriteLine("Enter your Admision Id");
                                        string adId=Console.ReadLine(); 
                                        foreach(AdmissionDetails admiList in admissionList){
                                            if(adId==admiList.AdmissionID){
                                            Console.WriteLine($"Addmision ID is {admiList.AdmissionID}");
                                            Console.WriteLine($"Addmision date is {admiList.AdmissionDate}");
                                            Console.WriteLine($"Addmision status is {admiList.AdmissionStatus}");
                                            }

                                        }
                                        break;
                                    }case "f":{
                                        break;
                                    }
                                }
                                Console.WriteLine("Do you want to continue ? yes/no");
                                userSubAns=Console.ReadLine();
                            }while(userSubAns=="yes");



                        }else{
                            Console.WriteLine("Invalid Student ID");
                        }
                        
                    }
                    break;

                }case 3:{
                    Console.WriteLine("Department wise seats are available ");
                    foreach(DepartmentDetails depInfo in  departmentList ){
                        Console.WriteLine($"{depInfo.DepartmentName} : {depInfo.NumberOfSeats}");
                    }
                    break;
                }case 4:{
                    break;
                }
            }
            Console.WriteLine("Do you want to Continue ? yes/no");
            userAns=Console.ReadLine();
        }while(userAns=="yes");

    }
}