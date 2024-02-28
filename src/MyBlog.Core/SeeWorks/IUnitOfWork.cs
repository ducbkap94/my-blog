namespace MyBlog.Core.SeeWorks
{
    public interface IUnitOfWork
    {
        Task<int> CompleteAsync();
    }
}
