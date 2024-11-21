
using BethanysPieShopHRM;

int amount = 1234;
int months = 12;
int bonus = 1000;
Utilities.CalculateYearlyWage(amount,months,bonus);   
int yearlyWage = Utilities.CalculateYearlyWage(amount, months);

Console.WriteLine($"Yealy wage: {yearlyWage}");

Console.ReadLine();

