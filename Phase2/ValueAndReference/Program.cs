using System;
namespace ValueAndReference;
class Program{
    public static void Main(string[] args)
    {
        
        //value type
        int number1=10;
        
        Console.WriteLine(number1);
        int number2=number1;
        Console.WriteLine(number2);
        number1=20;
        Console.WriteLine(number2);
        //reference type

        Student stu1=new Student();
        Student stu2;
        stu1.Name="devi";
        Console.WriteLine(stu1.Name);
        stu2=stu1;
        Console.WriteLine(stu2.Name);
        stu1.Name="nila";
        Console.WriteLine(stu1.Name);
        Console.WriteLine(stu2.Name);



    }
}