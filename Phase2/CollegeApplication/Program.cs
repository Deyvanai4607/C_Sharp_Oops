using System;
using ;
{
    
}
namespace CollegeApplication;
class Program{
    public static void Main(string[] args)
    {
        List<StudentDetails> stud=new  List<StudentDetails>();
        StudentDetails student1=new StudentDetails();
        
        student1.StudentName=Console.ReadLine();
        student1.FatherName=Console.ReadLine();
        student1.Dob=DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy",null);
        student1.Math=int.Parse(Console.ReadLine());
        student1.Science=int.Parse(Console.ReadLine());

    }
}