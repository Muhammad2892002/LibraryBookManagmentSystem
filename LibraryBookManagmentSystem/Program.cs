using LibraryBookManagmentSystem.classes;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LibraryBookManagmentSystem
{
    public class Program
    { 
        

       public static void Main(string[] args)
        {
            
         
          
             
           
            Member.AddMember( "MohammadHadidi");
             Member.AddMember( "AhmadKH" );
               
               

            
           
            
               
            
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
                MemberId=3201,
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
            Console.WriteLine("press \"1\" to login or \n Press \"2\" to signup");
            var choise=Console.ReadLine();
            switch (choise) {
                case "1": {
                        Login();
                   




                    } break;
                case "2":Signup();break;
                default: {
                        Console.WriteLine("Invalid Input");
                        Intilaizer();
                        break;
                    
                    
                    }
            
            
            }
           






        }
        public static void Signup() {
            Console.WriteLine("Enter your member name");
            string memberName = Console.ReadLine();
            Member.AddMember(memberName);
            Login();





        }
        public static void Login() {
            Console.WriteLine("Welcome To mini library system");
            Console.WriteLine("Please enter your name :");
            string name = Console.ReadLine();

            Console.WriteLine("Please enter your member id :");
            string memberIdAsString = Console.ReadLine();
            int memberAsInt;
            bool isParsed = int.TryParse(memberIdAsString, out memberAsInt);
            var memberExist = Member.FindMember(name, memberAsInt);
            if (memberExist.MemberId <= 3201)
            {
                SignAsLibrarian(memberExist);
                


            }
            if (memberExist != null && memberExist.MemberId>3201)
            {
                SignInAsPatron(memberExist);
         




            }
            else
            {
            retry:

                Console.WriteLine("Member not found.or you dont have an account");
                Console.WriteLine("press \"1\" to create new member or press \"2\" to go back  ");
                var userChoise = Console.ReadLine();
                switch (userChoise)
                {
                    case "1":
                        {
                            Signup();


                            break;




                        }
                    case "2": { Intilaizer(); break; }
                    default:
                        {
                            Console.WriteLine("Invalid input");
                            goto retry;
                            break;


                        }


                }






            }


        }


        public static void BorrowTransaction(Member member) {
        
            Console.WriteLine("Here is the list of available books :");
            Library.ShowAvailableBooks();
            Console.WriteLine("Enter the ISBN of  book that you want to borrow");
            string isbnBookToReturn = Console.ReadLine();
            var returnedBook = Library.FindBookByISBN(isbnBookToReturn);
            if (returnedBook != null && returnedBook.IsBorrowed == false)
            {
                Library.ChangeBookStatus(returnedBook, member.MemberId);
                if (member.MemberId > 3201)
                {
                    SignInAsPatron(member);

                }
                else if (member.MemberId <= 3201) {
                    SignAsLibrarian(member);
                
                }


            }
            else if (returnedBook != null && returnedBook.IsBorrowed == true)
            {
                Console.WriteLine("This book  is bowred ");
                if (member.MemberId > 3201)
                {
                    SignInAsPatron(member);

                }
                else if (member.MemberId <= 3201)
                {
                    SignAsLibrarian(member);

                }



            }
            else if (returnedBook == null)
            {
  Console.WriteLine("There is no book ");
                if (member.MemberId > 3201)
                {
                  
                    SignInAsPatron(member);

                }
                else if (member.MemberId <= 3201)
                {
                    SignAsLibrarian(member);

                }


            }





        }

        public static void ReturnTransaction(Member member) {
            Library.FetchAllBorrowedBooks(member.MemberId);
      
            Console.WriteLine("Please enter the ISBN of the book ?");
            string isbnBookToReturn = Console.ReadLine();
            var returnedBook = Library.FindBookByISBN(isbnBookToReturn);
            if (returnedBook != null && returnedBook.IsBorrowed == true && member.MemberId == returnedBook.MemberId)
            {
                Library.ChangeBookStatus(returnedBook, member.MemberId);
                if (member.MemberId > 3201)
                {
                    SignInAsPatron(member);

                }
                else if (member.MemberId <= 3201)
                {
                    SignAsLibrarian(member);

                }


            }
            else if (returnedBook != null && returnedBook.IsBorrowed == false)
            {
                Console.WriteLine("This book is not bowrred !!");
                if (member.MemberId > 3201)
                {
                    SignInAsPatron(member);

                }
                else if (member.MemberId <= 3201)
                {
                    SignAsLibrarian(member);

                }



            }
            else
            {
                Console.WriteLine("you dont have a book in your account or doesnot exist");
                if (member.MemberId > 3201)
                {
                    SignInAsPatron(member);

                }
                else if (member.MemberId <= 3201)
                {
                    SignAsLibrarian(member);

                }

            }






        }


        public static void SignAsLibrarian(Member member) {
            Console.WriteLine("Welcom Mr/Ms."+member.Name);
            Console.WriteLine("What type of activity you want to do");
            Console.WriteLine("1.Add a book \n"+"2.Borrow a book\n"+"3.Return a book\n 4. Press\"0\" to logout");
            var choise = Console.ReadLine();
            switch (choise) {
                case "0":{ Intilaizer(); break; }
                case "1": {
                        AddBookTransaction(member);
                    
                    
                    
                    } break;
                    case "2":BorrowTransaction(member); break;
                case "3":ReturnTransaction(member); break;
                default: {
                        Console.WriteLine("Invalid input");
                        SignAsLibrarian(member); break;
                    
                    }
            
            }
        
        
        
        }
        public static void SignInAsPatron(Member member) {
        choise:
            Console.WriteLine($"Welcome MR/MS. {member.Name} ");


            Console.WriteLine("What do you want to do today ?");
            Console.WriteLine("1. Borrow a book or \n 2.Return a book or to logout press \"0\"");
            string userChoice = Console.ReadLine();

            switch (userChoice)

            {
                case "1":
                    {
                        BorrowTransaction(member);



                        break;

                    }
                case "2":
                    {
                        ReturnTransaction(member);
                        break;



                    }
                case "0": { Intilaizer(); break; }
                default:
                    {
                        Console.WriteLine("Invalid choice. Please try again.");
                        goto choise;
                        break;
                    }


            }

        }

        public static void AddBookTransaction(Member member) {
            Book newBook = new Book();
          
            Console.WriteLine("Enter the \"ISBN\"");
            string ISBN = Console.ReadLine();
            var bookExistince=Library.FindBookByISBN(ISBN);
            if (bookExistince == null)
            {
                Console.WriteLine("Enter The Title");
                string bookTitle = Console.ReadLine();


                Console.WriteLine("Enter the author");
                string author = Console.ReadLine();
                newBook.Author = author;
                newBook.Title = bookTitle;
                newBook.ISBN = ISBN;
                newBook.IsBorrowed = false;
                newBook.MemberId = 0;
                Library.AddBook(newBook);
                Console.WriteLine("Process Completed");
                SignAsLibrarian(member);
            }
            else {
                Console.WriteLine("There is a book with same ISBN");
                AddBookTransaction(member);
            
            }
        
        
        }
    }
}
