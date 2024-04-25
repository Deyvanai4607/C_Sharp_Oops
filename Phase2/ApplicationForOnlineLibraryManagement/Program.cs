using System;
namespace ApplicationForOnlineLibraryManagement;
class Program
{
    public static void Main(string[] args)
    {
        //calling default data
        Operation.DefaultData();
        //calling main menu
        Operation.MainMenu();
    }
}