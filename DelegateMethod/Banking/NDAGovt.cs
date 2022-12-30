using System;

namespace CentralGovtAdministration
{

    public class NDAGovtHandler
    {
        
        public void PayIncomeTax()
        {
            Console.WriteLine("Income Tax deducted 10%");
        }

        public void PayServiceTax()
        {
            Console.WriteLine("Service Tax deducted 14%");
        }

        public void PayProfessionalTax()
        {
           Console.WriteLine("Professional Tax deducted  8%");
        }
    }
}