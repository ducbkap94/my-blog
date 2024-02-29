using MyBlog.Core.Repositories;

namespace MyBlog.Core.SeeWorks
{
    public interface IUnitOfWork
    {
        IPostRepository Posts { get; }
        Task<int> CompleteAsync();
    }
}
