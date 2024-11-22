using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BethanysPieShopHRM2
{
    internal class Employee
    {
        //Fields
        public string firstName;
        public string lastName;
        public string email;

        public int numberOfHoursWorked;
        public double wage;
        public double hourlyRate;

        public DateTime birthDay;

        const int minimalHoursWorkedUnit = 1;

        //Our constructors

        //An exemple of an overloaded constructor
        //we need to add the ": this" keyword to make a call to the "original"
        //and passing it the values
        public Employee(string first, string last, string em, DateTime bd) : this(first,last, em, bd,0)// here a zero is passed since we don't have a value for the rate
        {
        }

        public Employee(string first, string last, string em, DateTime bd, double rate)
        {
            firstName = first;
            lastName = last;
            email = em;
            birthDay = bd;
            hourlyRate = rate;
        }

        //Methods
        public void PerformWork()
        {
            PerformWork(minimalHoursWorkedUnit);
            //numberOfHoursWorked++;
            //Console.WriteLine($"{firstName} {lastName} has worked for{numberOfHoursWorked} hour(s)!");
        }

        public void PerformWork(int numberOfHours)
        {
            numberOfHoursWorked += numberOfHours;
            Console.WriteLine($"{firstName} {lastName} has worked for {numberOfHours} hour(s)!");
        }

        public double ReceiveWage(bool resetHours = true)
        {
            wage = numberOfHoursWorked * hourlyRate;

            Console.WriteLine($"{firstName} {lastName} has received a wafe of {wage} for {numberOfHoursWorked} hour(s) of work.");
            if (resetHours)
                numberOfHoursWorked = 0;
            return wage;
        }

        public void DisplayEmployeeDetails()
        {
            Console.WriteLine($"\nFirst name: \t{firstName}\nLast name: \t{lastName}\nEmail:  \t{email}\nBirthday: \t{birthDay.ToShortDateString()}\n");
        }
    }
}
