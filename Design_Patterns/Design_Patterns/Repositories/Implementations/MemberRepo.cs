using Design_Patterns.Models;
using Design_Patterns.Repositories.Interfaces;

namespace Design_Patterns.Repositories.Implementations
{
    internal class MemberRepo : IMemberRepository
    {
        private List<Member> members = new List<Member>();
        public void AddMember(Member member)
        {
            members.Add(member);
        }

        public List<Member> GetAllMembers()
        {
            return members;
        }

        public Member GetMemberById(int id)
        {
            var member = members.FirstOrDefault(m => m.Id == id);
            if (member == null)
            {
                //  Console.WriteLine("there is no member here");
                // return member;
            }
            return member;

        }
    }
}
