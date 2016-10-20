/*
 We are placing N orders at a time. You need to calculate the price after the discount based on the following formula:
((daysInMonth * capsulesCount) * pricePerCapsule)
*Hint – The DateTime class may come in handy to calculate the days in month.
* 
Input / Constraints
•	On the first line you will receive integer N – the count of orders the shop will receive.
•	For each order you will receive the following information:
o	Price per capsule - floating-point number in range [0…79,228,162,514,264,337,593,543,950,335].
o	Order date - in the following format {d/M/yyyy}, e.g. 25/11/2016, 7/03/2016, 1/1/2020.
o	Capsules count - integer in range [0…2,147,483,647].
The input will be in the described format, there is no need to check it explicitly.

Output
The output should consist of N + 1 lines. For each order you must print a single line in the following format:
•	“The price for the coffee is: ${price}”
On the last line you need to print the total price in the following format:
•	 “Total: ${totalPrice}”
The price must be rounded to 2 decimal places

 */
using System;
using System.Globalization;

class CoffeeOrders
{
    static void Main()
    {
        int orderCount = int.Parse(Console.ReadLine());
        decimal totalPrice = 0M;
        // read orders
        for (int i = 0; i < orderCount; i++)
        {
            decimal capsulePrice = decimal.Parse(Console.ReadLine());
            DateTime orderDate = DateTime.ParseExact(Console.ReadLine(), "d/M/yyyy", CultureInfo.InvariantCulture);
            uint capsulesCount = uint.Parse(Console.ReadLine());

            decimal orderPrice = ((DateTime.DaysInMonth(orderDate.Year, orderDate.Month) * capsulesCount) * capsulePrice);
            totalPrice += orderPrice;
            Console.WriteLine($"The price for the coffee is: ${orderPrice:F2}");
        }
        Console.WriteLine($"Total: ${totalPrice:F2}");
    }
}
