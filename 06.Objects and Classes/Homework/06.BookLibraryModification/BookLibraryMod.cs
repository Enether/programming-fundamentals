/*
 Use the classes from the previous problem and make a program that read a list of books
 and print all titles released after given date ordered by date and then by title lexicographically. 
 The date is given if format “day-month-year” at the last line in the input
 */
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace _06.BookLibraryModification
{
    class BookLibraryMod
    {
        static void Main()
        {
            // the library class here is useless, but let's stick with it
            int n = int.Parse(Console.ReadLine());
            Library netherLib = new Library("Nether_Library", ReadBooks(n));
            DateTime givenDate = DateTime.ParseExact(Console.ReadLine(), "d.M.yyyy", CultureInfo.InvariantCulture);
            // Fill up a dictionary holding every author and the sum of his prices
            Dictionary<string, DateTime> titles = netherLib.Books.Where(x => DateTime.Compare(givenDate, x.ReleaseDate) < 0).ToDictionary(x => x.Title, x => x.ReleaseDate);

            titles = titles.OrderBy(x => x.Value).ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            // print results
            foreach (var title in titles.Keys)
            {
                Console.WriteLine($"{title} -> {titles[title].ToString("dd.MM.yyyy")}");
            }
        }

        static List<Book> ReadBooks(int n)
        {
            List<Book> books = new List<Book>();
            // Read the input and fill up the list of books
            for (int i = 0; i < n; i++)
            {
                string[] bookInfo = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string bookTitle = bookInfo[0];
                string bookAuthor = bookInfo[1];
                string bookPublisher = bookInfo[2];
                DateTime releaseDate = DateTime.ParseExact(bookInfo[3], "d.M.yyyy", CultureInfo.InvariantCulture);
                long isbn = long.Parse(bookInfo[4]);
                double price = double.Parse(bookInfo[5]);

                books.Add(new Book(bookTitle, bookAuthor, bookPublisher, releaseDate, isbn, price));  // fill up the list of books
            }

            return books;
        }
    }
    class Library
    {
        public string Name { get; }
        public List<Book> Books { get; }

        public Library(string name, List<Book> books)
        {
            this.Name = name;
            this.Books = books;
        }
    }

    class Book
    {
        public string Title { get; }
        public string Author { get; }
        public string Publisher { get; }
        public DateTime ReleaseDate { get; }
        public long ISBN { get; }
        public double Price { get; }

        public Book(string title, string author, string publisher, DateTime releaseDate, long isbn, double price)
        {
            this.Title = title;
            this.Author = author;
            this.Publisher = publisher;
            this.ReleaseDate = releaseDate;
            this.ISBN = isbn;
            this.Price = price;
        }
    }
}
