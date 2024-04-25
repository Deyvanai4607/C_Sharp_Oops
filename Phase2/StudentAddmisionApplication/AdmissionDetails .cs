using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAddmisionApplication
{
    public enum AdmissionStatus{Select, Admitted, Cancelled}
    public class AdmissionDetails 
    {
        //a.	AdmissionID – (Auto Increment ID - AID1001)
        // b.	StudentID
        // c.	DepartmentID
        // d.	AdmissionDate
        // e.	AdmissionStatus – Enum- (Select, Admitted, Cancelled)
        StudentDetails stud=new StudentDetails();
        DepartmentDetails dep=new DepartmentDetails();
        private static int _admissionID=1000;
        public string AdmissionID { get; set; }
        // public string StudentID=stud.StudentID;
        // public string DepartmentID=dep.DepartmentID;
        public DateTime AdmissionDate { get; set; }
        public  AdmissionStatus AdmissionStatus { get; set; }
        public AdmissionDetails(string addmisionDate,string addmissionStatus){
            _admissionID++;
            AdmissionID="AID"+_admissionID;
            //stud.StudentID=studentId;
            //dep.DepartmentID=departId;
            AdmissionDate=DateTime.ParseExact(addmisionDate,"dd/MM/yyyy",null);
            AdmissionStatus=Enum.Parse<AdmissionStatus>(addmissionStatus);
        }
        public AdmissionDetails(){
             _admissionID++;
            AdmissionID="AID"+_admissionID;
        }
        // public static List<AdmissionDetails> GetAddmisionDetails(){
        //     List<AdmissionDetails> addmisionList=new List<AdmissionDetails>{
        //         new AdmissionDetails("SF3001","DID101","11/05/2022","Admitted"),
        //          new AdmissionDetails("SF3002","DID102","12/05/2022","Admitted")
        //     };
            
        //     return addmisionList;
        // }

    }
}