// EmployeeClass
// Alias
using System;
using System.Collections.Generic;

using con = System.Console;

namespace EmployeeClass
{
    class EmployeeClass
    {
        static void Main(string[] args)
        {
            List<Employee> empList = new List<Employee>();

            con
                .WriteLine(@"
 _____                 _                       
| ____|_ __ ___  _ __ | | ___  _   _  ___  ___ 
|  _| | '_ ` _ \| '_ \| |/ _ \| | | |/ _ \/ _ \
| |___| | | | | | |_) | | (_) | |_| |  __/  __/
|_____|_| |_| |_| .__/|_|\___/ \__, |\___|\___|
                |_|            |___/
                
Welcome to the workforce.");

            try
            {
                con
                    .Write($"\nYou are making a new employee, enter a first and last name, and a monthly salary.\nWhen you're finished. Press ENTER.\n");
                while (true)
                {
                    con.Write("First name                    : ");
                    string _fn = con.ReadLine();
                    con.Write("Last name                     : ");
                    string _ln = con.ReadLine();
                    con.Write("Monthly Salary (enter to stop): ");
                    decimal _sl = decimal.Parse(con.ReadLine());

                    empList.Add(new Employee(_fn, _ln, _sl));
                    con.WriteLine($"Added {_fn} {_ln}.\n");
                }
            }
            catch (System.FormatException)
            {
                /* We end up here when exception is caught */
            }
            catch (ArgumentException)
            {
                con.WriteLine("Salary cannot be less than 0!");
            }

            con.Write("\n");
            for (int i = 0; i < empList.Count; i++)
            {
                con
                    .WriteLine($"Employee {i + 1}, {empList[i].givenName} {
                        empList[i].familyName}. Yearly salary is {
                        empList[i].YearlySalary():C}");
            }
        }
    }

    class Employee
    {
        // Intrinsics
        public string givenName { get; set; }

        public string familyName { get; set; }

        private decimal mSalary;

        /*
         * Constructor
         */
        public Employee(string _gName, string _fName, decimal _mSalary)
        {
            givenName = _gName;
            familyName = _fName;
            MSalary = _mSalary;
        }

        /* 
         * Returns the yearly salary
         */
        public decimal YearlySalary()
        {
            return mSalary * 12;
        }

        /*
         * Methods for the monthly salary
         */
        public decimal MSalary
        {
            get
            {
                return mSalary;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException();
                }
                mSalary = value;
            }
        }
    }
}
