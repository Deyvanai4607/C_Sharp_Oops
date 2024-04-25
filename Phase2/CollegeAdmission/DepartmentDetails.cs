using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeAdmission
{
    public class DepartmentDetails
    {
        /*a.	DepartmentID – (AutoIncrement - DID101)
            b.	DepartmentName
            c.	NumberOfSeats
        */
        //static field
        private static int s_departmentID=100;
        //properties
        public string DepartmentID { get; }    //read only
        public string DepartmentName { get; set; }
        public int NumberOfSeats { get; set; }
        //constructor
        public DepartmentDetails(string depName,int numberOfSeat){
            //auto increament
            s_departmentID++;
            DepartmentID="DID"+s_departmentID;
            DepartmentName=depName;
            NumberOfSeats=numberOfSeat;
        }
         public DepartmentDetails(string department){
            string[] dep=department.Split(","); 
            DepartmentID=dep[0];
            s_departmentID=int.Parse(dep[0].Remove(0,3));
            DepartmentName=dep[1];
            NumberOfSeats=int.Parse(dep[2]);
        }

    }
}