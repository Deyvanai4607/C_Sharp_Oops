using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAddmisionApplication
{
    /// <summary>
    /// data type gender is used to select a instance of <see cref="StudentDetails"/> gender information
    /// </summary>
    public enum Gender{Select,Male, Female, Transgender}
    /// <summary>
    /// StudentDetails class use to create instance for student <see cref="StudentDetails"/>
    /// Refer documentation on <see href="www.syncfusion.com"/>
    /// </summary>
    public class StudentDetails
    {
        /// <summary>
        /// static field s_studentID used to autoincreament StudentId of the instance of the<see cref="StudentDetails"/>
        /// </summary>
        private static int s_studentID=3000;
        /// <summary>
        /// StudentID property is used to hold student's ID of instance of <see cref="StudentDetails"/> 
        /// </summary>
      
        public string StudentID { get; set; }
        /// <summary>
        /// StudentName property is used to hold student's name of instance of <see cref="StudentDetails"/>
        /// </summary>
       
        public string StudentName { get; set; }
        /// <summary>
        /// FatherName property is used to hold student's father name of instance of <see cref="StudentDetails"/>
        /// </summary>
       
        public string FatherName { get; set; }
        /// <summary>
        /// DOB property is used to hold student's date of birth of instance of <see cref="StudentDetails"/>
        /// </summary>
      
        public DateTime DOB { get; set; }
        /// <summary>
        /// Gender property is used to hold student's gender of instance of <see cref="StudentDetails"/>
        /// </summary>
       
        public Gender Gender { get; set; }
        /// <summary>
        /// Physics property is used to hold student's physics
        /// </summary>
        /// <value></value>
        public int Physics { get; set; }
        public int Chemistry { get; set; }
        public int Maths { get; set; }
        /// <summary>
        /// Constructor StudentDetails is used to initialize parameter value to it's property
        /// </summary>
        /// <param name="studName">studName parameter used to assign its value to associated property</param>
        /// <param name="fatName">fatName parameter used to assign its value to associated property</param>
        /// <param name="dob">dob parameter used to assign its value to associated property</param>
        /// <param name="gender">gender parameter used to assign its value to associated property</param>
        /// <param name="physics">physics parameter used to assign its value to associated property</param>
        /// <param name="chemistry">chemistry parameter used to assign its value to associated property</param>
        /// <param name="maths">maths parameter used to assign its value to associated property</param>
        public StudentDetails(string studName,string fatName,string dob,string gender,int physics,int chemistry,int maths){
            s_studentID++;
            StudentID="SF"+s_studentID;
           
            StudentName=studName;
            FatherName=fatName;
            DOB = DateTime.ParseExact(dob,"dd/MM/yyyy",null);
            Gender=Enum.Parse<Gender>(gender,true);
            Physics=physics;
            Chemistry=chemistry;
            Maths=maths;

        }
        /// <summary>
        /// Constructor StudentDetails is used to initialize default value to it's property
        /// </summary>
        public StudentDetails(){
            StudentName="Enter your name";
            FatherName="Enter your Father Name";
            Gender=Gender.Select;
            
        }
        //StudentID	StudentName
        // 	FatherName
        // 	DOB
        // 	Gender	Physics
        // 	Chemistry
        // 	Maths
        // SF3001	Ravichandran E	Ettapparajan	11/11/1999	Male 	95	95	95
        // SF3002	Baskaran S	Sethurajan	11/11/1999	Male	95	95	95

        // public static List<StudentDetails> GetStudentDetails(){
        //     List<StudentDetails> studentList=new List<StudentDetails>{
        //         new StudentDetails("SF3001","Ravichandran E","Ettapparajan","11/11/1999","Male",95,95,95),
        //         new StudentDetails("SF3002","Baskaran S","Sethurajan","11/11/1999","Male",95,95,95)
        //     };
        //     return studentList;
        // }
        /// <summary>
        /// Method CheckEligibility is used to check whether the instance of <see cref="StudentDetails"/>
        /// is eligible for admission based on cutoff
        /// </summary>
        /// <param name="physics">physics is a student physics mark</param>
        /// <param name="chemistry">chemistry is a student chemistry mark</param>
        /// <param name="maths">maths is a student maths mark</param>
        /// <returns>Return true if eligible, else false</returns>
        public bool CheckEligibility(double physics,double chemistry,double maths){
            double cutOff =75.0;
            double average =physics+chemistry+maths/3;
            if(average >= cutOff ){
                return true;
            }else
            {
                return false;
            }
        }
    }
}