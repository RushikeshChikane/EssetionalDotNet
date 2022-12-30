using System;
using Banking;
using CentralGovtAdministration;

namespace EventTest
{

    class Program
    {
        static void Main(string []args)
        {
            UPAGovtHandler handler =new UPAGovtHandler();
            Account account1 =Account.Create(10000);

            //at runtime register event handlers with event associated with Account
            //attach event handlers with events associated with Account object


            //associate at runtime with event receiver --------handler
            //associated at runtime with event handler---------handler
            //associated with runtime with Controller ---------handler

            //Event Mapping
            //Event Registration
            //Add Hook to Event
            //Subscribe callback function to event of account   

            account1.overBalance+=new Operation(handler.PayIncomeTax);
            account1.underBalance+=new Operation(handler.PayServiceTax); 

            //Banking Transcation
            account1.Balance=56000;   

            //Highly Cohesive execution happening
            Console.WriteLine("Before first deposit");
            account1.Deposit(200000);
            Console.WriteLine("After First Deposit");
            account1.overBalance+=new Operation(handler.PayServiceTax);
            account1.Deposit(12000);



            Console.WriteLine("For Another Accountv Instance");
            Console.WriteLine("NDA");

            NDAGovtHandler  handler2 =new NDAGovtHandler();
            Account  account2  = Account.Create(37000);
            account2.overBalance+=new Operation(handler2.PayServiceTax);
            account2.Deposit(230000);



            
        }
    }
}
