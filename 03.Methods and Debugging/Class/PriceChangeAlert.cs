/*
You are assigned to rework a given piece of code which is working without bugs but is not properly formatted. 
The given program tracks stock prices and gives updates about the significance in each price change. Based on the significance, there are four kind of changes: no change at all (price is equal to the previous), minor (difference is below the significance threshold), price up and price down. 
You can find the broken code here: Broken Code for Refactoring.
*/

using System;

class PriceChangeAlert
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        double significanceTreshold = double. Parse(Console.ReadLine());
        double lastStock = double.Parse(Console.ReadLine());

        for (int i = 0; i < n - 1; i++)
        {
            double stock = double.Parse(Console.ReadLine());
            double difference = GetPercentageDifference(lastStock, stock);
            bool isSignificantDifference = IsSignificantDifference(difference, significanceTreshold);

            string message = GetMessage(stock, lastStock, difference, isSignificantDifference);
            Console.WriteLine(message);

            lastStock = stock;
        }
    }

    private static string GetMessage(double stock, double lastStock, double difference, bool isSignificantDiff)
    {
        string msg = "";
        difference *= 100;
        if (!isSignificantDiff)
            msg = string.Format("MINOR CHANGE: {0} to {1} ({2:F2}%)", lastStock, stock, difference);

        else if (isSignificantDiff && (difference > 0))
            msg = string.Format("PRICE UP: {0} to {1} ({2:F2}%)", lastStock, stock, difference);

        else if (isSignificantDiff && (difference < 0))
            msg = string.Format("PRICE DOWN: {0} to {1} ({2:F2}%)", lastStock, stock, difference);

        else if (difference == 0)
            msg = string.Format("NO CHANGE: {0}", stock);

        return msg;
    }

    private static bool IsSignificantDifference(double significantDifference, double difference)
    {
        if (Math.Abs(significantDifference) >= difference)
            return true;

        return false;
    }

    private static double GetPercentageDifference(double stockOne, double stockTwo)
    {
        return (stockTwo - stockOne) / stockOne;
    }
}
