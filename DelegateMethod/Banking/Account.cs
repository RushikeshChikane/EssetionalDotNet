using System;

namespace Banking
{

    // used as blueprint for creating number of instances
    //c sharp provides keywords
    //cons , types
    //Value Types
    //int,float,char,boolean
    //Referance Type
    //class,delegate,event   

    public delegate void Operation(); 
    public class Account
    {
        //Auto Property
        public double Balance{get;set;}
        public Account(double amount){
            this.Balance=amount;
        }

        //user defined events
        //if you want to define event, first you need to define delegate
        //Account class in Publisher
        // it publish events

        public event Operation underBalance;
        public event Operation overBalance;


        // don't repeat your self:

        public  void Monitor()
        {
            if( this.Balance < 5000){
                // static linking of behaviour
                // applying Dynamic linking
                //Handler.BlockAccount();
                underBalance();
            }
            else if(this.Balance>=250000){
                // static linking of behaviour
                // appylying Dynamic Linking
                //Handler.PayIncomeTax();
                overBalance();
            }
        }
        public void Deposit(double amount){
            this.Balance+=amount;
            Monitor();
          
        }

        public void Withdraw(double amount){
            this.Balance-=amount;
            Monitor();
        }

        public static Account Create(double initialAmount){
            Account account=new Account(initialAmount);
            return account;
        }
        
    }
}
