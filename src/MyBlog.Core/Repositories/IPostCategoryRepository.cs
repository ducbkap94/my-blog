using MyBlog.Core.Domain.Content;
using MyBlog.Core.Models;
using MyBlog.Core.Models.Content;
using MyBlog.Core.SeeWorks;

namespace MyBlog.Core.Repositories
{
    public interface IPostCategoryRepository: IRepository<PostCategory, Guid>
    {
        Task<PagedResult<PostCategoryDto>> GetAllPaging(string? keyword, int pageIndex = 1, int pageSize = 10);
    }
}
