using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationForOnlineLibraryManagement
{
    //enum
    public enum Department{ECE, EEE, CSE}
    public enum Gender{Female,Male,Transgender}
    public class UserDetailsClass
    {
                /*a.	UserID (Auto Increment – SF3000)
        b.	UserName
        c.	Gender
        d.	Department – (Enum – ECE, EEE, CSE)
        e.	MobileNumber
        f.	MailID
        g.	WalletBalance
        */
        //static feild
        private static int s_userID=3000;
        //properties
        public string UserID { get;  }// read only
        public string UserName { get; set; }
        public Gender Gender { get; set; }
        public Department Department { get; set; }
        public long MobileNumber { get; set; }
        public string MailID { get; set; }
        public int WalletBalance { get; set; }
        //constructor
        public UserDetailsClass(string userName,Gender gender,Department department,long mobileNumber,string mailID,int walletBalance){
            s_userID++;
            UserID="SF"+s_userID;
            UserName=userName;
            Gender=gender;
            Department=department;
            MobileNumber=mobileNumber;
            MailID=mailID;
            WalletBalance=walletBalance;
        }
        //methods
        public void WalletRecharge(int rechargeAmount){
            WalletBalance=WalletBalance+rechargeAmount;
        }
        public void DeductBalance(int deductedAmount ){
            WalletBalance=WalletBalance-deductedAmount;
        }
    }
}