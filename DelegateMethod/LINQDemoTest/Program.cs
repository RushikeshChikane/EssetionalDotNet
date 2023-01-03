using System;
using System.Reflection;


namespace LINQDemoTest
{

    //Every Claa is Bydefault inherited from object class
    //goed in java , C sharp, Javascript, Typescript
    class Program
    {
        static void Main(string [] args)
        {

            //How do you check type of variable at runtime?
            //  C++ ------->   RTTI
            // JAva -------->  Reflection
            //C # ---------->  Reflection

            Program program = new Program();
            Console.WriteLine("Demo for Reflection");
            Type theType1=program.GetType();
            Console.WriteLine("Type of program variable :"+theType1.Name);


            var instance =new {
                            Id="34",
                            FirstName="Rushikesh",
                            LastName="Chikane",
                            ContactNumber="5522336644",
                            Location=new{
                                LandMark="Nanded City",
                                City = "Pune",
                                State="Maharashtra",
                                Country ="India",
                            }
            };

            Type theType2=instance.GetType();
            Console.WriteLine("Type of theType2 :"+theType2.Name);


            Console.WriteLine("Demo of Annoumouse Data Type");
            Console.WriteLine(instance.FirstName+" "+instance.LastName);
            Console.WriteLine(instance.Location.Country);
            Console.WriteLine(instance.Location.State);
            Console.WriteLine(instance.Location.City);
            Console.WriteLine(instance.Location.LandMark);
            Console.WriteLine("Hello World");
                               
        }
    
    }
}