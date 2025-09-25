using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBookManagmentSystem.classes
{
    public class Member
    {
        public string Name { get; set; }
        public int MemberId  { get; set; }
        public static Book BorrowBook(Book book) {
            Book borrowedBook= Book.Borrow(book);
            return book;
        
        
        }
        public static Book ReturnBook(Book book) {
          Book returnedBook= Book.Return(book);
            return returnedBook;



        }



    }
}
