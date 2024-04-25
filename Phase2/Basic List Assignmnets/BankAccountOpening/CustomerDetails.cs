using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BankAccountOpening
{
    public enum Gender{female,male}
    
    public class CustomerDetails
    {
        private static int _customerId=1000;
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int Balance { get; set; }
        public Gender Gender { get; set; }
        public long Phone { get; set; }
        public string MailId { get; set; }
        public DateTime Dob { get; set; }
        public CustomerDetails(){
            _customerId++;
            CustomerId="HDFC"+_customerId;

        }

        public int DepositeAmount(int bal,int dep){
            
            int cb=bal+dep;
            return cb;
        }
        public int Withdraw(int bal,int wed){
            
            int cb=bal-wed;
            return cb;
        }
    }
   
}