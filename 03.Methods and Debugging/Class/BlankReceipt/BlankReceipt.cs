using System;
/*
 * Create a method that prints a blank cash receipt. The method should invoke three other methods:
 *  one for printing the header, one for the body and one for the footer of the receipt. 
 */

class BlankReceipt
{
    public const string RECEIPT_HEADER = "CASH RECEIPT\n"
                                + "------------------------------";
    public const string RECEIPT_BODY = "Charged to____________________\n"
                                     + "Received by___________________";
    public const string RECEIPT_FOOTER = "------------------------------\n"
                                        + "© SoftUni";

    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.Unicode;
        PrintReceipt();
    }
    static void PrintReceipt()
    {
        PrintReceiptHeader();
        PrintReceiptBody();
        PrintReceiptFooter();
    }
    
    static void PrintReceiptHeader()
    {
        Console.WriteLine(RECEIPT_HEADER);
    }

    static void PrintReceiptBody()
    {
        Console.WriteLine(RECEIPT_BODY);
    }

    static void PrintReceiptFooter()
    {
        Console.WriteLine(RECEIPT_FOOTER);
    }
}

