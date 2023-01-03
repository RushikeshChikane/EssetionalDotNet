using System;


namespace AnnonymousMethodTest
{


    public delegate void BasicOperation();
    public delegate void DoSomething();

    //delegate function with 1 parameter
    public  delegate int AnnonymousMethod1(int i);
     
     //delegate method with 2 parameter with int type
    public delegate int AnnonymousMethod2(int a, int b);
    class Program
    {
        //callback function

        void PrintReport()
        {
            Console.WriteLine("Printing a Report : graph, table, score card");
        }
        
        static void Main(string[] args)
        {
            //Normally Function Calling
            Program prog=new Program();
            prog.PrintReport();

            //register the function using delegate method
            //registrating callback function
            Program program1=new Program();
            BasicOperation Method1=new BasicOperation(program1.PrintReport);
            //resolving name of function at runtmr
            Method1();


            //Inline function
            //Annonnymouse Method by

            BasicOperation Methos2=delegate(){
                Console.WriteLine("Printing Compeny Annual Report");
            };
            Methos2();

            //Using
            //Lambda symol 
            DoSomething Method3 =()=>{Console.WriteLine("Printing Covid Spread Lockdown Report");};
            Method3();

       
            AnnonymousMethod1 prroxy1= new AnnonymousMethod1(
                                                             delegate (int x)
                                                             {
                                                                 return x * 2;
                                                             }
                                                            );
               Console.WriteLine("{0}",prroxy1(25));     

            //using Lambda   
            AnnonymousMethod1 proxy2=x=>x*2;
            Console.WriteLine(proxy2(30));      


            //(input parameter) => Expression ;
            AnnonymousMethod2 getBigger=(x,y)=>{if(x>y)return x; else return y;};
            Console.WriteLine(getBigger(10,15));

            // Which is the good language
            //Answer the language which transforms itself over period as per
            //the culture society transforms
            Console.WriteLine("Welcome to .NET Programming");                                    



        }
    }
}