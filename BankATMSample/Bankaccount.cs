using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankATMSample
{
    abstract class Bankaccount 
    {
        public long accountnumber { get; set; } //Account number type is long.
        public int banknumber { get; set; }
        public string IBAN { get; set; }
        public  decimal balance { get; set; }

        //In an abstract method, we are required to make changes (implement the method) later,
        //whereas in a virtual method, we can either override it to make changes or use it as it is.

        public virtual string Withdraw(decimal amount)
        {
            balance -= amount; //balance = balance - amount;
            return "You withdraw " + amount + " euro. Current balance = " + balance;

        }

        public virtual string Deposit(decimal amount)
        {
            balance += amount; //balance = balance + amount;
            return "You deposit " + amount + " euro. Current balance = " + balance;
        }

    }

    class Current_Account : Bankaccount //We used inheritance here, and I inherited an abstract class in the class.
                                        //Now, if I want to use a method from the abstract class, I can override it. This way, I can make changes to the function.
    {
        public override string Withdraw(decimal amount)
        {
            if (balance < amount)
            {
                return "Balance is not enough.(Low balance)";
            }
            if (amount % 5==0 ) 
            {
                return base.Withdraw(amount); //This means that since the requested amount is a multiple of 5,
                                              //we can return to the main class and continue with the process.
            }
            else
            {
                return "Coins cannot be dispensed. Please request a withdrawal in multiples of 5.";
            }
        }

        internal string Deposit(object value)
        {
            throw new NotImplementedException();
        }
    }
    class Saving_Account : Bankaccount 
    {
        public  DateTime saveaccountstarttime { get; set; }
        public int saveaccounttime { get; set; }
        public DateTime saveaccountfinishtime 
        {
            get
            {
                return saveaccountstarttime.AddDays(saveaccounttime);
            }
           
        }

        public override string Withdraw(decimal amount)
        {
            //You cannot withdraw funds before the saving account due date. 
            if (DateTime.Today.Date != saveaccountfinishtime)
            {
                return "Please wait for due date";
            }
            else if (balance < amount)
            {
                return "Balance is not enough.(Low balance)";
            }
            else if (amount % 5 != 0)
            {
                return "Coins cannot be dispensed. Wrong request.";
            }
            else
            {
                return base.Withdraw(amount);
            }

        }

        public override string Deposit(decimal amount)
        {
            if (DateTime.Today.Date == saveaccountfinishtime)
            {
                return base.Deposit(amount);
            }
            else 
            {
                return "Wait for due date!";
            }


        }

    }


}
