using LibraryBookManagmentSystem.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LibraryBookManagmentSystem
{
    public class Program
    { private static List<Member> allMembers = new List<Member>();

       public static void Main(string[] args)
        {
            
         
          
             
           
            allMembers.Add(new Member
            {
                Name = "MohammadHadidi",
                MemberId = 1

            });
            allMembers.Add(new Member
            {
                Name="AhmadKH",
                MemberId=2

            });
            Library.AddBook(new Book
            {
                Title= "Harry Potter and the Philosopher's Stone",
                Author= "J.K. Rowling",
                ISBN= "978-0747532699",
                IsBorrowed= false



            });
            Library.AddBook(new Book {
                Title="Why We Sleep",
                Author="Matthew Walker",
                ISBN="978-1501144318",
                IsBorrowed= true

            });
            Library.AddBook(new Book {
                Title= "Atomic Hobbit",
                Author= "Joshua Foer",
                ISBN= "978-0143120537",
                IsBorrowed= false


            });
            Intilaizer();




        }


        public static void Intilaizer() {
            Console.WriteLine("Welcome To mini library system");
            Console.WriteLine("Please enter your name :");
            string name = Console.ReadLine();
        
            Console.WriteLine("Please enter your member id :");
            string memberIdAsString = Console.ReadLine();
            int memberAsInt;
            bool isParsed= int.TryParse(memberIdAsString, out memberAsInt);
            var memberExist = allMembers.FirstOrDefault(memeber => memeber.MemberId == memberAsInt && memeber.Name == name);
            if (memberExist != null) {
            choise:
                Console.WriteLine($"Welcome MR/MS. {memberExist.Name} ");


                Console.WriteLine("What do you want to do today ?");
                Console.WriteLine("1. Borrow a book or \n 2.Return a book");
                string userChoice = Console.ReadLine();

                switch (userChoice) {
                    case "1": {
                            Console.WriteLine("Here is the list of available books :");
                            Library.ShowAvailableBooks();
                            Console.WriteLine("Enter the ISBN of  book that you want to borrow");
                            string isbnBookToReturn = Console.ReadLine();
                            var returnedBook = Library.FindBookByISBN(isbnBookToReturn);
                            if (returnedBook != null && returnedBook.IsBorrowed == false)
                            {
                                Library.ChangeBookStatus(returnedBook);
                                goto choise;


                            }
                            else
                            {
                                Console.WriteLine("This book does not exist in our library or it is bowred ");
                                goto choise;



                            }
                           

                            break;

                        }
                    case "2": {
                            Console.WriteLine("Please enter the ISBN of the book ?");
                                string isbnBookToReturn = Console.ReadLine(); 
                            var returnedBook= Library.FindBookByISBN(isbnBookToReturn);
                            if (returnedBook != null && returnedBook.IsBorrowed==true) {
                                Library.ChangeBookStatus(returnedBook);
                                goto choise;


                            }
                            else {
                                Console.WriteLine("This book does not exist in our library or it is not bowred yet");
                                goto choise;
                               
                              

                            } break;



                        }
                    default:
                        {
                            Console.WriteLine("Invalid choice. Please try again.");
                            goto choise;
                            break;
                        }
                  
                
                }
                



            }






        }
    }
}
