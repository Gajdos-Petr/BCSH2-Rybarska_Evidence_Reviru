using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rybarska_Evidence.Model
{
    public enum MemberType
    {
        Regular,
        Chairman,
        Leader

    }
    internal class Member
    {
    public int MemberId { get; set; }
    public string FistName { get; set; }

    public string LastName {  get; set; }
   
    public DateTime dateOfBirth { get; set; }

    public MemberType MemberType { get; set;}

    public Document  Document { get; set; }



    public void InsterMemberIntoDatabase(Member memberToInsert)
        {

        }



    public Member? LoadMemberFromDatabase(string FistName, string LastName)
        {
            return null;
        }


    public List<Member> LoadMembersFromDatabase()
        {
            return new List<Member>();
        }
    }
}
