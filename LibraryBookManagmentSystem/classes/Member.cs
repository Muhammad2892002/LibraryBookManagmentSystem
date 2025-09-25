using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBookManagmentSystem.classes
{
  
    public class Member
    {  
        private static int Id=3200;
        private static List<Member> allMembers = new List<Member>();

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
        public static void AddMember(string memberName) {
            Member member= new Member();
            member.MemberId = Id;
            member.Name = memberName;
            Id++;
            if (member.MemberId > 3201)
            {
                Console.WriteLine("Your member name is :" + member.Name);
                Console.WriteLine("Your member Id is :" + member.MemberId);
            }
            allMembers.Add(member);
        
        

        }

        public static Member FindMember(string name,int Id) {
            Member findMember = allMembers.FirstOrDefault(x=>x.MemberId==Id && x.Name==name);
            return findMember;
        
        
        
        }



    }
}
