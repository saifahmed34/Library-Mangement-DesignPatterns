using Design_Patterns.Models;

namespace Design_Patterns.Repositories.Interfaces
{
    internal interface IMemberRepository
    {
        public void AddMember(Member member);
        public Member GetMemberById(int id);
        public List<Member> GetAllMembers();

    }
}
