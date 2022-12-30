using System;
using Banking;

namespace HandlerTest
{

    // act like function Pointer
    // delegate signature should match signature with functions 

    public  delegate void AccountOperation ();
    class Program
    {

         // using  Delegate concept it C#
        
        static void Main(string[] args)
        {
            Handler theHandler=new Handler();

            // static (compile time): at the time of building solution (exe ,dll)
            // Compiler resolves function to be called at runitme  (Early binding)
            // runtime : at the time of execution
            // static linking
            // explicitly calling function:
            // early binding
                // faster in execution
                
               //theHandler.BlockAccount();
               //theHandler.PayIncomeTax();
            
            // Dynamic Application
            // loosely coupled logic and at runtime they would behave like
            // loosely coupled : highly cohesive at runtime


            //  Delegate is used for late binding
            //  Delegate is used for :Dynamic linking of function
            //  Delegate is foundation for Event Driven Architecture

            // Register a function to be called dynamically
            AccountOperation operation1=new  AccountOperation(theHandler.SendEmailNotification);
            AccountOperation operation2=new  AccountOperation(theHandler.PayIncomeTax);
            AccountOperation operation3=new  AccountOperation(theHandler.BlockAccount);
            AccountOperation operation=operation1;

            // Multicast Delegate:

            operation+=operation2;   // chain another delegate
            operation+=operation3;   // chain another delegate

            operation();            // Invoking delegate
                                    // broadcasting

            Console.WriteLine("Hello World!");
        }
    }
}
