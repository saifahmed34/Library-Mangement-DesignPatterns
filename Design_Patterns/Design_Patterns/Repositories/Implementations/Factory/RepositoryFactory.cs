using Design_Patterns.Repositories.Interfaces;
using Design_Patterns.Repositories.Interfaces.Factory;

namespace Design_Patterns.Repositories.Implementations.Factory
{
    internal class RepositoryFactory : IRepositoryFactory
    {
        public IBookRepository CreateBookRepository()
        {
            return new BookImplement();
        }

        public IMemberRepository CreateMemberRepository()
        {
            return new MemberRepo();
        }

    }
}
