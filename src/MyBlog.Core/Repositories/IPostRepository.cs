using MyBlog.Core.Domain.Content;
using MyBlog.Core.Models;
using MyBlog.Core.Models.Content;
using MyBlog.Core.SeeWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Core.Repositories
{
    public interface IPostRepository:IRepository<Post, Guid>
    {
        Task<List<Post>> GetPopularPostAsync(int count);
        Task<PagedResult<PostInListDto>> GetPostPagingAsync(string keyword, Guid? categoryId, int pageIndex = 1,int pageSize= 10);
    }
}
