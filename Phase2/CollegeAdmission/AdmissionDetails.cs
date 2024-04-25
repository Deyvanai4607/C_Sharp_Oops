using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeAdmission
{
    //enum declaration
    public enum AdmissionStatus{Select, Admitted, Cancelled}
    public class AdmissionDetails
    {
        /*a.	AdmissionID – (Auto Increment ID - AID1001)
        b.	StudentID
        c.	DepartmentID
        d.	AdmissionDate
        e.	AdmissionStatus – Enum- (Select, Admitted, Cancelled)
        */
        //static field
        private static int s_admissionID=1000;
        //Properties
        public string AdmissionID { get;}//read only
        public string StudentID { get; set; }
        public string DepartmentID { get; set; }
        public DateTime AdmissionDate { get; set; }
        public AdmissionStatus AdmissionStatus { get; set; }
        //Constructor
        public AdmissionDetails(string studentID,string departmentID,DateTime admissionDate,AdmissionStatus admissionStatus){
            //auto increament
            s_admissionID++;
            AdmissionID="AID"+s_admissionID;
            StudentID=studentID;
            DepartmentID=departmentID;
            AdmissionDate=admissionDate;
            AdmissionStatus=admissionStatus;
        }
        public AdmissionDetails(string admission){
            string[] adm=admission.Split(","); 
            AdmissionID=adm[0];
            s_admissionID=int.Parse(adm[0].Remove(0,3));
            StudentID=adm[1];
            DepartmentID=adm[2];
            AdmissionDate=DateTime.ParseExact(adm[3],"dd/MM/yyyy",null);
            AdmissionStatus=Enum.Parse<AdmissionStatus>(adm[4]);
        }
    }
}