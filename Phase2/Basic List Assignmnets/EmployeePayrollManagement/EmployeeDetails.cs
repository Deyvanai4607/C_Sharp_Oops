using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePayrollManagement
{
    public enum WorkLocation{chennai,US}
    public enum Gender{female,male}
    public class EmployeeDetails
    {
        private static int _employeeId=1000;
        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeRole { get; set; }
        public WorkLocation WorkLocation { get; set; }
        public string TeamName { get; set; }
        public DateTime Doj { get; set; }
        public int NoOfWorkingInMonth { get; set; }
        public int LeaveTaken { get; set; }
        public Gender Gender { get; set; }
        public EmployeeDetails(){
            _employeeId++;
            EmployeeId="SF"+_employeeId;

        }
        public int SalaryCalculation(int workingDays,int leaveTaken){
            int days=workingDays-leaveTaken;
            int salaryAmount=days*500;
            return salaryAmount;
        }

        
    }

}