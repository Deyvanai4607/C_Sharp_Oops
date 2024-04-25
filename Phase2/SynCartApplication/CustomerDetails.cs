using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SynCartApplication
{
    public class CustomerDetails
    {
        //static field
        private static int s_customerID=1000;
        //properties
        public string CustomerID { get;  }//read only
        public string Name { get; set; }
        public string City { get; set; }
        public long MobileNumber { get; set; }
        public int WalletBalance { get; set; }
        public string EmailID { get; set; }
        //constructor
        public CustomerDetails(string name,string city,long mobileNumber,int walletBalance,string emailID){
            s_customerID++;
            CustomerID="CID"+s_customerID;
            Name=name;
            City=city;
            MobileNumber=mobileNumber;
            WalletBalance=walletBalance;
            EmailID=emailID;
        }
        //methods
        public void WalletRecharge(int rechargeAmount){
            WalletBalance=WalletBalance+rechargeAmount;
        }
        public void DeductBalance(int deductAmount){
            WalletBalance=WalletBalance-deductAmount;
        }
    }
}