namespace Design_Patterns.Repositories.Interfaces.Factory
{
    internal interface IRepositoryFactory
    {
        public IBookRepository CreateBookRepository();
        public IMemberRepository CreateMemberRepository();
    }
}
