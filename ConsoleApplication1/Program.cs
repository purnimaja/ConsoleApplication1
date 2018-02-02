using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//hsbc and icici
namespace ConsoleApplication1
{

    interface IBankAccount
    {
        //class could have string property called Name
        string Name { get; set; }

        //declaring functions inside interface
        void Deposit(double amt);
        bool Withdraw(double amt);
        double GetBal();
    }

    //created abstract class  so that we can use the same behaviour in both class
    //interface always talks about how public class behave
    //refrence is always of base and instance(object) is of derived
    //constructor is called after the allocation of memory 
    abstract class BankAccount : IBankAccount
    {
        private string name;
        public string Name
        {

            get
            {
                return this.Name;
            }
            set
            {
                this.Name = value;
            }

        }
        protected double bal;
        public void Deposit(double amt)
        {
        this.bal +=amt;
        }
          public abstract bool Withdraw(double amt);
         public double GetBal()
          {
            return this.bal;
         }
    }


    class HSBC : BankAccount
    {
        public HSBC(string , int)
        {

        }
        public override bool Withdraw(double amt)
        {
            if(this.GetBal() - amt >= 5000)
            {
                this.bal -= amt;
                return true; 
            }
            return false;
        }
    }
    
    //you can assign any derived instance to a base reference

    class Program
    {

        static void Main(string[] args)
        {
            BankAccount a1;

            a1 = new HSBC();
            a1.Name = "Bill Gates";
            a1.Deposit(15000);
            a1.Withdraw(3000);
            a1.Withdraw(4000);

            Console.WriteLine("{0} your account bal: {1}", a1.Name, a1.GetBal());
          
        }
    }
}
