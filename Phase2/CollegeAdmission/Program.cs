using System;
using System.IO;
namespace CollegeAdmission;
public class Program{
    public static void Main(string[] args)
    {
        FilesHandling.Create();
        //default calling
        //Operations.AddDefaultData();
        FilesHandling.ReadFromCSV();
        //calling main menu
        Operations.MainMenu();
        FilesHandling.WriteCSV();
    }
}
