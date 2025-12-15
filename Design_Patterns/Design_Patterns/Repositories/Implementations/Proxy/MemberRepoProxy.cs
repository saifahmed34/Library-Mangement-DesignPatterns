using Design_Patterns.Models;
using Design_Patterns.Repositories.Interfaces;

namespace Design_Patterns.Repositories.Implementations.Proxy
{
    internal class MemberRepoProxy : IMemberRepository
    {
        private readonly IMemberRepository _realRepo;
        private readonly Member _currentUser;

        public MemberRepoProxy(IMemberRepository realRepo, Member currentUser)
        {
            _realRepo = realRepo;
            _currentUser = currentUser;
        }

        public void AddMember(Member member)
        {
            if (_currentUser.IsAdmin)
            {
                _realRepo.AddMember(member);
            }
            else
            {
                Console.WriteLine("Access Denied");
            }
        }

        public List<Member> GetAllMembers()
        {
            return _realRepo.GetAllMembers();
        }

        public Member GetMemberById(int id)
        {
            return _realRepo.GetMemberById(id);
        }
    }
}
