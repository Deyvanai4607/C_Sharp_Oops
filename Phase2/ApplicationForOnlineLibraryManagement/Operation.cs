using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ApplicationForOnlineLibraryManagement
{
    public static class Operation
    {
       static UserDetailsClass currentUserDetails;
        //lists
       static List<UserDetailsClass> userDetailsList=new List<UserDetailsClass>();
       static List<BookDetailsClass> bookDetailsList=new List<BookDetailsClass>();
       static List<BorrowDetailsClass> borrowDetailsList=new List<BorrowDetailsClass>();
       //main menu
       public static void MainMenu(){
        Console.WriteLine("*****************Welcome to SYNCFUSION LIBRARY**************");
        /*1.	UserRegistration
        2.	UserLogin
        3.	Exit
        */
        string mainChoice="yes";
        do{
            Console.WriteLine("Select option\n1.UserRegistration\n2.UserLogin\n3.Exit");
            int mainOption=int.Parse(Console.ReadLine());
            switch(mainOption){
                case 1:{
                    Console.WriteLine("*******************UserRegistration**************");
                    UserRegistration();
                    break;
                }case 2:{
                    Console.WriteLine("*******************UserLogin**************");
                    UserLogin();
                    break;
                } case 3:{
                    Console.WriteLine("*******************Exit Successfully done**************");
                    mainChoice="no";
                    break;
                } 
            }

        }while(mainChoice=="yes");
       } //main menu end
       //user registration
       public static void UserRegistration(){
        /*a.	Username
b.	Gender (Enum – Select, Male, Female, Transgender)
c.	Department  
d.	MobileNumber
e.	MailID
f.	WalletBalance
*/
        //get user details
        Console.Write("Enter user name : ");
        string userName=Console.ReadLine();
        Console.Write("Enter user Gender : ");
        Gender gender=Enum.Parse<Gender>(Console.ReadLine(),true);
        Console.Write("Enter user Department : ");
        Department department=Enum.Parse<Department>(Console.ReadLine(),true);
        Console.Write("Enter user MobileNumber : ");
        long mobileNumber=long.Parse(Console.ReadLine());
        Console.Write("Enter user MailID : ");
        string mailID=Console.ReadLine();
        Console.Write("Enter user walletBalance : ");
        int walletBalance=int.Parse(Console.ReadLine());
        UserDetailsClass user=new UserDetailsClass( userName, gender, department ,mobileNumber, mailID, walletBalance);
        userDetailsList.Add(user);
        //display user id
        Console.WriteLine($"User Registration successfully done. Your user ID is {user.UserID}");

       }  //user registration end
       //UserLogin
        public static void UserLogin(){
            //get user id
            Console.Write ("Enter user Id : ");
            string userID=Console.ReadLine().ToUpper();
            //check user id and else part
            bool flag=true;
            foreach(UserDetailsClass user in userDetailsList){
                if(userID.Equals(user.UserID)){
                    flag = false;
                    currentUserDetails = user;
                    //sub menu
                    SubMenu();
                    break;
                }
            }
            if(flag){
                Console.WriteLine("Invalid User ID. Please enter a valid one");
            }         
        
       }//UserLogin end
       //sub menu
       public static void SubMenu(){
        /*1.	Borrowbook.
        2.	ShowBorrowedhistory.
        3.	ReturnBooks
        4.	WalletRecharge 
        5.	Exit
        */
        string subChoice="yes";
        do{
            Console.WriteLine("Select sub option\n1.Borrowbook\n2.ShowBorrowedhistory\n3.ReturnBooks\n4.WalletRecharge\n5.Exit");
            int subOption=int.Parse(Console.ReadLine());
            switch(subOption){
                case 1:{
                    Console.WriteLine("*************Borrowbook***************");
                    Borrowbook();
                    break;
                }case 2:{
                    Console.WriteLine("*************ShowBorrowedhistory***************");
                    ShowBorrowedhistory();
                    break;
                }case 3:{
                    Console.WriteLine("*************ReturnBooks***************");
                    ReturnBooks();
                    break;
                }case 4:{
                    Console.WriteLine("*************WalletRecharge***************");
                    WalletRecharge();
                    break;
                }case 5:{
                    Console.WriteLine("*************Exit successfully done***************");
                    subChoice="no";
                    break;
                }
            }

        }while(subChoice=="yes");
       } //sub menu end
       //Borrowbook
       public static void Borrowbook(){
        //SHOW details
        Console.WriteLine("BookID, BookName, AuthorName, BookCount");
        foreach(BookDetailsClass book in bookDetailsList){
              Console.WriteLine($"|{book.BookID}|{book.BookName}|{book.AuthorName}|{book.BookCount}");
        }
        Console.WriteLine("Enter Book ID to borrow :");
        string bookId=Console.ReadLine();
        bool flag=true;
         foreach(BookDetailsClass book in bookDetailsList){
            if(bookId.Equals(book.BookID)){
                flag=false;
                Console.Write("Enter the count of the book : ");
                int bookCount=int.Parse(Console.ReadLine());
                if(book.BookCount>=bookCount){
                    int count=0;
                    foreach(BorrowDetailsClass borrow in borrowDetailsList){
                        if(currentUserDetails.UserID.Equals(borrow.UserID)){
                            count=count+borrow.BorrowBookCount;                      
                        }
                    }
                    if(count<3){

                            BorrowDetailsClass borrowf = new BorrowDetailsClass(bookId, currentUserDetails.UserID, DateTime.Now, bookCount, Status.Borrowed, 0);
                            borrowDetailsList.Add(borrowf);
                            Console.WriteLine("Book Borrowed successfully");

                        }
                        else
                        {
                        Console.WriteLine("You have borrowed 3 books already");
                        Console.WriteLine($"You can have maximum of 3 borrowed books. Your already borrowed books count is {count} and requested count is {bookCount}, which exceeds 3 ”.");
                    }

                }else{
                    Console.WriteLine("Books are not available for the selected count");
                    //next available date 
                    DateTime returnDate=new DateTime();
                    foreach(BorrowDetailsClass borrow in borrowDetailsList){
                        if(bookId.Equals(borrow.BookID)){
                            returnDate=borrow.BorrowedDate.AddDays(15);
                            break;
                        }
                    }
                    Console.WriteLine($"The book will be available on {returnDate}");
                }
                break;
            }
         }
         if(flag){
            Console.WriteLine("Invalid Book ID, Please enter valid ID");
         }
       }//Borrowbook end
       //ShowBorrowedhistory
       public static void ShowBorrowedhistory(){
        Console.WriteLine($"|{"BorrowID",-20}|{"BookID",-20}|{"UserID",-20}|{"BorrowedDate",-30}|{"BorrowBookCount",-20}|{"Status",-20}|{"PaidFineAmount",-20}|");
        foreach(BorrowDetailsClass borrow in borrowDetailsList){
                //check user id
                if(currentUserDetails.UserID.Equals(borrow.UserID)){
                     //show details
                    Console.WriteLine($"|{borrow.BorrowID,-20}|{borrow.BookID,-20}|{borrow.UserID,-20}|{borrow.BorrowedDate,-30}|{borrow.BorrowBookCount,-20}|{borrow.Status,-20}|{borrow.PaidFineAmount,-20}|");
                }
               
            }

        }//ShowBorrowedhistory end
       //ReturnBooks
       public static void ReturnBooks(){
        //Show the borrowed book details of current user whose status is “borrowed” 
        Console.WriteLine($"|{"BorrowID",-15}|{"BookID",-15}|{"UserID",-15}|{"BorrowedDate",-30}|{"BorrowBookCount",-15}|{"Status",-15}|{"PaidFineAmount",-15}|{"Return date",-20}|");
            foreach (BorrowDetailsClass borrow in borrowDetailsList)
            {
                //check user id
                if (currentUserDetails.UserID.Equals(borrow.UserID) && borrow.Status.Equals(Status.Borrowed))
                {
                    //show details
                    Console.WriteLine($"|{borrow.BorrowID,-15}|{borrow.BookID,-15}|{borrow.UserID,-15}|{borrow.BorrowedDate,-30}|{borrow.BorrowBookCount,-15}|{borrow.Status,-15}|{borrow.PaidFineAmount,-15}|{borrow.BorrowedDate.AddDays(15),-20}|");

                }

            }
            foreach (BorrowDetailsClass borrow in borrowDetailsList)
            {
                if (currentUserDetails.UserID.Equals(borrow.UserID) && borrow.Status.Equals(Status.Borrowed))
                {
                    Console.WriteLine("select the BorrowedID to return book");
                    string returnBorroweId=Console.ReadLine();
                    if(returnBorroweId.Equals(borrow.BorrowID)){
                        
                        DateTime returnDate = DateTime.Now;
                        TimeSpan span= returnDate.Subtract(borrow.BorrowedDate);
                        int count = span.Days;
                        if (count > 15)
                        {
                            borrow.PaidFineAmount = count - 15;
                            if(currentUserDetails.WalletBalance>=borrow.PaidFineAmount){
                                //deduct the fine amount from his Wallet balance
                                currentUserDetails.DeductBalance(borrow.PaidFineAmount);
                                //change the Status in Booking History to “Returned”
                                borrow.Status=Status.Returned;
                                foreach (BookDetailsClass book in bookDetailsList)
                                {
                                    if (borrow.BookID.Equals(book.BookID))
                                    {
                                        book.BookCount++;
                                        break;
                                    }
                                }

                                Console.WriteLine("Book returned successfully");
                            }else{
                                Console.WriteLine("Insufficient balance. Please rechange and proceed");
                            }
                        }else{
                            borrow.Status=Status.Returned;
                            foreach(BookDetailsClass book in bookDetailsList){
                                if(borrow.BookID.Equals(book.BookID)){
                                    book.BookCount++;
                                    break;
                                }
                            }
                           
                            Console.WriteLine("Book returned successfully");
                        }
                    }
                    break;

                }
            }
            //also Print the return date of each book (Return date will be 15 days after borrowing a book).  

        }//ReturnBooks end
       //WalletRecharge
       public static void WalletRecharge(){
        //ask user wish
        Console.Write("Do you want to recharge Wallet? yes/no");
        string answer=Console.ReadLine();
        if(answer.Equals("yes")){
             //get amount to recharge
             Console.WriteLine($"your current Walletbalance is : {currentUserDetails.WalletBalance} ");
             Console.Write("Enter recharge amount : ");
             int rechargeAmount=int.Parse(Console.ReadLine());
             currentUserDetails.WalletRecharge(rechargeAmount);
             Console.WriteLine($"After recharge your current Walletbalance is : {currentUserDetails.WalletBalance} ");

        }
       

       }//WalletRecharge end
       //adding default data
       public static void DefaultData(){
        UserDetailsClass user1=new UserDetailsClass("Ravichandran",Gender.Male,Department.EEE,9938388333,"ravi@gmail.com",100);
        UserDetailsClass user2=new UserDetailsClass("Priyadharshini",Gender.Female,Department.CSE,9944444455,"priya@gmail.com",150);
        userDetailsList.AddRange(new List<UserDetailsClass>(){user1,user2});

        BookDetailsClass book1=new BookDetailsClass("C#","Author1",3);
        BookDetailsClass book2=new BookDetailsClass("HTML","Author2",5);
        BookDetailsClass book3=new BookDetailsClass("CSS","Author1",3);
        BookDetailsClass book4=new BookDetailsClass("JS","Author1",3);
        BookDetailsClass book5=new BookDetailsClass("TS","Author2",2);
        bookDetailsList.AddRange(new List<BookDetailsClass>(){book1,book2,book3,book4,book5});

        BorrowDetailsClass borrow1=new BorrowDetailsClass("BID1001","SF3001",new DateTime(2023,09,10),2,Status.Borrowed,0);
        BorrowDetailsClass borrow2=new BorrowDetailsClass("BID1003","SF3001",new DateTime(2023,09,12),1,Status.Borrowed,0);
        BorrowDetailsClass borrow3=new BorrowDetailsClass("BID1004","SF3001",new DateTime(2023,09,14),1,Status.Returned,16);
        BorrowDetailsClass borrow4=new BorrowDetailsClass("BID1002","SF3002",new DateTime(2023,09,11),2,Status.Borrowed,0);
        BorrowDetailsClass borrow5=new BorrowDetailsClass("BID1005","SF3002",new DateTime(2023,09,09),1,Status.Returned,20);
        borrowDetailsList.AddRange(new List<BorrowDetailsClass>(){borrow1,borrow2,borrow3,borrow4,borrow5});

        
       }//adding default data end
    }
}