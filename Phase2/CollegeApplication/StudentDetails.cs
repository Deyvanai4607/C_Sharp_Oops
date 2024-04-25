using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeApplication
{
    public class StudentDetails
    {
        //field
        private string _studentName; 
        //properties
        public string StudentName{
            get{
                return _studentName;
            } 
            set{
                _studentName=value;
            }
        }
        //Auto
        public string FatherName{get;set;}
        public string Gender{get;set;}
        public DateTime Dob{get;set;}
        public int Math{get;set;}
        public int Science{get;set;}
        public int Chemistry{get;set;}
         
        
        //events
        //indexers
        //Constructor
        public StudentDetails(){
            StudentName="enter your name";
        }
        //parameteraized constructor
        public StudentDetails(string studentName){
            StudentName=studentName;
        }
        //destructor
        ~StudentDetails(){
            Console.WriteLine("Destructor called");
        }
        //Methods
        public bool Eligibility(){ //not denote static
            return true;
        }
    }
}