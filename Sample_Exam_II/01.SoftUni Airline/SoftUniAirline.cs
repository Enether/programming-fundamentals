/*
Mary has finally become a junior developer and has received her first task. It’s about managing flights and you need to help her.
Your income is calculated based on how many tickets you sell. There are two types of tickets. The first is for adult and the second is for youth. Income is calculated by the formula: 
(adult passengers count * adult ticket price) + (youth passengers count * youth ticket price)
You also have expenses. They are calculated based on the fuel you are burning during a flight. You will receive the fuel consumption per hour, the fuel price for 1-hour flight and the flight duration. To calculate the expenses, use the following formula:
flight duration * fuel consumption * fuel price
For each flight you need to calculate your profit, subtracting the expense from the income, and you need to print the result. After all flights, you need to calculate your overall and average profit.

Input
On the first line you will receive an integer N, the number of flights you need to manage. For each flight you will receive exactly 7 lines of input:
adult passengers count
adult ticket price 
youth passengers count  
youth ticket price 
fuel price per hour
fuel consumption per hour
flight duration

Output
For each flight you need to calculate the profit and print the result in the following format:
If the income is greater or equal than the expense:
You are ahead with {profit}$.
If the expenses are greater:
We’ve got to sell more tickets! We’ve lost {profit}$. 
After all of the flights you need to print the overall profit in the following format:
Overall profit -> {overallProfit}$.
Average profit -> {averageProfit}$. 
The output must be rounded to three decimal places after the decimal point.
     
Constraints
The adult and youth passengers count will be integers in range [0…1,000,000,000].
The adult and youth ticket price will be floating-point numbers in range [1…1,000,000,000.00].
The fuel price will be floating-point number in range [1…1,000,000.00].
The fuel consumption will be floating-point number in range [1…1,000,000.00].
The flight duration will be integer in range [0…72].
*/
using System;
using System.Collections.Generic;
using System.Linq;

class SoftUniAirline
{
    static void Main()
    {
        int flightsCount = int.Parse(Console.ReadLine());
        List<decimal> flightProfits = new List<decimal>();
        // read the flights
        for (int i = 0; i < flightsCount; i++)
        {
            int adultPassengers = int.Parse(Console.ReadLine());
            decimal adultTicketPrice = decimal.Parse(Console.ReadLine());
            int youngPassengers = int.Parse(Console.ReadLine());
            decimal youngTicketPrice = decimal.Parse(Console.ReadLine());
            decimal fuelPricePerHour = decimal.Parse(Console.ReadLine());
            decimal fuelConsumptionPerHour = decimal.Parse(Console.ReadLine());
            int flightDuration = int.Parse(Console.ReadLine());

            decimal flightProfit = (
                (adultPassengers * adultTicketPrice) + (youngPassengers * youngTicketPrice)  // revenue
                - (flightDuration * fuelConsumptionPerHour * fuelPricePerHour)  // expenses
                );

            if (flightProfit >= 0)
                Console.WriteLine($"You are ahead with {flightProfit:F3}$.");
            else
                Console.WriteLine($"We've got to sell more tickets! We've lost {flightProfit:F3}$.");

            flightProfits.Add(flightProfit);
        }

        Console.WriteLine($"Overall profit -> {flightProfits.Sum():F3}$.");
        Console.WriteLine($"Average profit -> {flightProfits.Average():F3}$.");
    }
}
