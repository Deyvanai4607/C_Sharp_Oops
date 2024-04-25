using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationForOnlineLibraryManagement
{
    //enum
    public enum Status{Default, Borrowed, Returned}
    public class BorrowDetailsClass
    {
        /*•	BorrowID (Auto Increment – LB2000)
        •	BookID 
        •	UserID
        •	BorrowedDate – ( Current Date and Time )
        •	BorrowBookCount 
        •	Status –  ( Enum - Default, Borrowed, Returned )
        •	PaidFineAmount
        */
        //static feild
        private static int s_borrowID=2000;
        //properties
        public string BorrowID { get;  }//read only
        public string BookID { get; set; }
        public string UserID { get; set; }
        public DateTime BorrowedDate { get; set; }
        public int BorrowBookCount { get; set; }
        public Status Status { get; set; }
        public int PaidFineAmount { get; set; }
        //constructor
        public BorrowDetailsClass(string bookID,string userID,DateTime borrowedDate,int borrowBookCount,Status status,int paidFineAmount){
            s_borrowID++;
            BorrowID="LB"+s_borrowID;
            BookID=bookID;
            UserID=userID;
            BorrowedDate=borrowedDate;
            BorrowBookCount=borrowBookCount;
            Status=status;
            PaidFineAmount=paidFineAmount;
        }
    }
}