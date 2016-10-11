/*
 To model a book library, define classes to hold a book and a library. 
 The library must have a name and a list of books. The books must contain the title, author, publisher, release date, ISBN-number and price. 
Read a list of books, add them to the library and print the total sum of prices by author,
ordered descending by price and then by author’s name lexicographically.
Books in the input will be in format {title} {author} {publisher} {release date} {ISBN} {price}.
 */
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace _05.BookLibrary
{
    class BookLibrary
    {
        static void Main()
        {
            // the library class here is useless, but let's stick with it
            int n = int.Parse(Console.ReadLine());
            Library netherLib = new Library("Nether_Library", ReadBooks(n));
            // Fill up a dictionary holding every author and the sum of his prices
            Dictionary<string, double> authors = new Dictionary<string, double>();
            foreach (Book book in netherLib.Books)
            {
                if (!authors.ContainsKey(book.Author))
                    authors[book.Author] = 0;
                authors[book.Author] += book.Price;
            }

            authors = authors.OrderByDescending(x => x.Value).ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            // print results
            foreach (var author in authors.Keys)
            {
                Console.WriteLine($"{author} -> {authors[author]:F2}");
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
