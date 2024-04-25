using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAddmisionApplication
{
    
    public class DepartmentDetails 
    {
       
        /// <summary>
        /// static field  s_departmentID used to autoincreament Department of the instance of the<see cref="DepartmentDetails"/>
        /// </summary>
        private static int s_departmentID=100;
        // public static int EEENumberOfSeats;
        // public static int CSENumberOfSeats;
        // public static int MECHNumberOfSeats;
        // public static int ECENumberOfSeats;
        /// <summary>
        /// DepartmentID property is used to hold Department's ID of instance of <see cref="DepartmentDetails"/> 
        /// </summary>
         
        public string DepartmentID { get; set; }
        /// <summary>
        /// DepartmentName property is used to hold Department's name of instance of <see cref="DepartmentDetails"/> 
        /// </summary>
         
        public string DepartmentName { get; set; }
        /// <summary>
        /// NumberOfSeats property is used to hold Department's NumberOfSeats of instance of <see cref="DepartmentDetails"/> 
        /// </summary>
        /// <value></value>
        public int NumberOfSeats { get; set; }
        /// <summary>
        /// NumberOfSeats property is used to hold Department's NumberOfSeats of instance of <see cref="DepartmentDetails"/>
        /// </summary>
        /// <param name="departname"></param>
        /// <param name="noOfSeats"></param>
        public DepartmentDetails(string departname,int noOfSeats){
            s_departmentID++;
            DepartmentID="DID"+s_departmentID;
            DepartmentName=departname;
            NumberOfSeats=noOfSeats;
            
        }
       public DepartmentDetails(){
            DepartmentName="Enter your name";
            
        }
        // public static List<DepartmentDetails> GetDepartmentList(){
        //     List<DepartmentDetails> departmentList=new List<DepartmentDetails>{
        //         new DepartmentDetails("EEE",29),
        //         new DepartmentDetails("CSE",29),
        //         new DepartmentDetails("MECH",30),
        //         new DepartmentDetails("ECE",30)

        //     };
        //     return departmentList;
        // }

        
        
 //Default Department Details
// DepartmentID	Department Name	NumberOfSeat
// DID101	EEE	29
// DID102	CSE	29
// DID103	MECH	30
// DID104	ECE	30

    }
}