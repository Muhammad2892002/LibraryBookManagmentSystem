using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBookManagmentSystem.classes
{
    public class Library
    {
        private static List<Book> allBooks = new List<Book>();
        public static void  AddBook(Book book)
        {
           
            

                allBooks.Add(book);
               
            
          
               



            

          


        }
        public static void ShowAvailableBooks()
        {
            foreach (var book in allBooks)
            {
                if (book.IsBorrowed == false)
                {
                    Console.WriteLine($" ISBN: {book.ISBN}");
                    Console.WriteLine($" Title: {book.Title}");
                    Console.WriteLine($" Author: {book.Author}");
                }
            }

        }
        public static Book FindBookByISBN(string isbn)
        {
            var book = allBooks.FirstOrDefault(b => b.ISBN == isbn);
            return book;



        }

        public static void ChangeBookStatus(Book book)
        {  
            var targetBook = allBooks.Find(target => target.ISBN == book.ISBN);
                allBooks.Remove(targetBook);

            if (book.IsBorrowed == true)
            {
              
              
                Book returnedBook = Member.ReturnBook(book);
                allBooks.Add(returnedBook);
                Console.WriteLine("Book returned successfully.");
            }
            else if (book.IsBorrowed == false)
            {
              
               
                Book borrowedBook = Member.BorrowBook(book);
                allBooks.Add(borrowedBook);
                Console.WriteLine("Book borrowed successfully.");
            }
            else
            {
                Console.WriteLine("Invalid book status.");




            }
        }
    }
}
