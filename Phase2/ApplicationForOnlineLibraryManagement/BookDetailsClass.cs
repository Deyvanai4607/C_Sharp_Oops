using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationForOnlineLibraryManagement
{
    public class BookDetailsClass
    {
        /*1.	BookID (Auto Increment - BID1000)
            2.	BookName
            3.	AuthorName
            4.	BookCount
        */
        //static feild
        private static int s_bookID=1000;
        //properties
        public string BookID { get;  }//read only
        public string BookName { get; set; }
        public string AuthorName { get; set; }
        public int BookCount { get; set; }
        //constructor
        public BookDetailsClass(string bookName,string authorName,int bookCount){
            s_bookID++;
            BookID="BID"+s_bookID;
            BookName=bookName;
            AuthorName=authorName;
            BookCount=bookCount;
        }
    }
}