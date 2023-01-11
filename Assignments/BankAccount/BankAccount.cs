// BankAccount
// Alias
using System;

using con = System.Console;

namespace BankAccount
{
    class BankAccount
    {
        static void Main(string[] args)
        {
            con
                .WriteLine(@"Welcome to
 ____        _   ____              _    
|  _ \  __ _( ) | __ )  __ _ _ __ | | __
| | | |/ _` |/  |  _ \ / _` | '_ \| |/ /
| |_| | (_| |   | |_) | (_| | | | |   < 
|____/ \__,_|   |____/ \__,_|_| |_|_|\_\");

            Account myAccount = new Account();

            con.WriteLine($"\nThe default name is \"{myAccount.Name}\".");
            con.Write("Enter a new name: ");
            myAccount.Name = con.ReadLine();
            con.WriteLine($"The name is now \"{myAccount.Name}\".");
        }
    }

    public class Account
    {
        // Internal memory
        public string Name { get; set; } // Why is this public?

        public Account(string _Name = "Default")
        {
            Name = _Name;
        }
    }
}
