using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeAdmission
{
    public static class FilesHandling
    {
        public static void Create()
        {
            if(!Directory.Exists("CollegeAdmission")){
                Directory.CreateDirectory("CollegeAdmission");
                System.Console.WriteLine("CollegeAdmission folder created....");
            }
            if(!File.Exists("CollegeAdmission/StudentInfo")){
                File.Create("CollegeAdmission/StudentInfo").Close();
                System.Console.WriteLine("StudentInfo file created....");
            }
            if(!File.Exists("CollegeAdmission/DepartmentInfo")){
                File.Create("CollegeAdmission/DepartmentInfo").Close();
                System.Console.WriteLine("DepartmentInfo file created....");
            }
            if(!File.Exists("CollegeAdmission/AddmisiontInfo")){
                File.Create("CollegeAdmission/AddmisiontInfo").Close();
                System.Console.WriteLine("AddmisiontInfo file created....");
            }
        }
        //write data in csv file

        public static void WriteCSV(){
            string[] students=new string[Operations.studentList.Count];
            for(int i=0;i<Operations.studentList.Count;i++) {
                students[i]=Operations.studentList[i].StudentID+","+Operations.studentList[i].StudentName+","+Operations.studentList[i].FatherName+","+Operations.studentList[i].DOB.ToString("dd/MM/yyyy")+","+Operations.studentList[i].Gender+","+Operations.studentList[i].Physics+","+Operations.studentList[i].Chemistry+","+Operations.studentList[i].Maths;
                 
            }    
            File.WriteAllLines("CollegeAdmission/StudentInfo",students); 

            string[] department=new string[Operations.departmenttList.Count];
            for(int i=0;i<Operations.departmenttList.Count;i++){
                department[i]=Operations.departmenttList[i].DepartmentID+","+Operations.departmenttList[i].DepartmentName+","+Operations.departmenttList[i].NumberOfSeats;

            }
            File.WriteAllLines("CollegeAdmission/DepartmentInfo",department);

            string[] admission=new string[Operations.admissiontList.Count];
            //string studentID,string departmentID,DateTime admissionDate,AdmissionStatus admissionStatus
            for(int i=0;i<Operations.admissiontList.Count;i++){
                admission[i]=Operations.admissiontList[i].AdmissionID+","+Operations.admissiontList[i].StudentID+","+Operations.admissiontList[i].DepartmentID+","+Operations.admissiontList[i].AdmissionDate.ToString("dd/MM/yyyy")+","+Operations.admissiontList[i].AdmissionStatus;
            }    
            File.WriteAllLines("CollegeAdmission/AddmisiontInfo",admission);
        }
        //read data from csv file
        public static void ReadFromCSV(){
               string[] students=File.ReadAllLines("CollegeAdmission/StudentInfo");
               foreach(string stud in students){
                    StudentDetails student=new StudentDetails(stud);
                    Operations.studentList.Add(student);
               }

               string[] departments=File.ReadAllLines("CollegeAdmission/DepartmentInfo");
               foreach(String dep in departments){
                    DepartmentDetails department=new DepartmentDetails(dep);
                    Operations.departmenttList.Add(department);
               }

               string[] admissions=File.ReadAllLines("CollegeAdmission/AddmisiontInfo");
               foreach(string adm in admissions){
                    AdmissionDetails admission=new AdmissionDetails(adm);
                    Operations.admissiontList.Add(admission);
               }
        }
    }
}