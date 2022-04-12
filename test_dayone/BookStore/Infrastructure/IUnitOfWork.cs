namespace BookStore.Infrastructure
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
