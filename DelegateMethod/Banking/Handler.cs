using System;

// Listener
// Hook
// Handler
// Each class should be independently Tested:
// Unit Testing:
// Dynamic Invocation
// .NET Types: Delegate ,Event

//

namespace Banking {

    public class Handler {

        public  void BlockAccount(){          
            Console.WriteLine( " The Account has been blocked....");
        }

        public  void SendEmailNotification(){
             Console.WriteLine( "Email notification has been sent to registered email address");    
        }
        public void PayIncomeTax(){
             Console.WriteLine( " Income tax has been deducted from your Account by Order...");
        }

    }
}