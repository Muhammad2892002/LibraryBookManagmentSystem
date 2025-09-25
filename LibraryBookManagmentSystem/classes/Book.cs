using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBookManagmentSystem.classes
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public bool? IsBorrowed { get; set; }
        public int MemberId { get; set; }
 public static Book Borrow(Book book) {
            if (book.IsBorrowed == false)
            {
                book.IsBorrowed = true;


            }
            else {
                Console.WriteLine("This book is already borrowed.");


            }
            
                return book;


        }
        public static Book Return(Book book) {

            if (book.IsBorrowed == true)
            {
                book.IsBorrowed = false;
                book.MemberId = 0;
             return book;


            }
            else
            {
                Console.WriteLine("This book is not borrowed yet.");
                return null;
            }
           


        }
        
    }
   
}
