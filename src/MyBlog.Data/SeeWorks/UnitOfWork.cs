using AutoMapper;
using Microsoft.AspNetCore.Identity;
using MyBlog.Core.Domain.Content;
using MyBlog.Core.Domain.Identity;
using MyBlog.Core.Repositories;
using MyBlog.Core.SeeWorks;
using MyBlog.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Data.SeeWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyBlogContext _context;
        public UnitOfWork(MyBlogContext context, IMapper mapper, UserManager<AppUser> userManager)
        {
            _context = context;
            Posts = new PostRepository(context, mapper, userManager);
            PostCategories = new PostCategoryRepository(context, mapper);
            Series = new SeriesRepository(context, mapper);

        }
        public IPostRepository Posts { get; private set; }
        public IPostCategoryRepository PostCategories { get; private set; }
        public ISeriesRepository Series { get; private set; }


        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
