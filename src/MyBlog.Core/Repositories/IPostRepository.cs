﻿using MyBlog.Core.Domain.Content;
using MyBlog.Core.Models;
using MyBlog.Core.Models.Content;
using MyBlog.Core.SeeWorks;

namespace MyBlog.Core.Repositories
{
    public interface IPostRepository:IRepository<Post, Guid>
    {
        Task<PagedResult<PostInListDto>> GetAllPaging(string? keyword, Guid currentUserId, Guid? categoryId, int pageIndex = 1, int pageSize = 10);
        Task<bool> IsSlugAlreadyExisted(string slug, Guid? currentId = null);
        Task<List<SeriesInListDto>> GetAllSeries(Guid postId);
        Task Approve(Guid id, Guid currentUserId);
        Task SendToApprove(Guid id, Guid currentUserId);
        Task ReturnBack(Guid id, Guid currentUserId, string note);
        Task<string> GetReturnReason(Guid id);
        Task<bool> HasPublishInLast(Guid id);
        Task<List<PostActivityLogDto>> GetActivityLogs(Guid id);
    }
}
