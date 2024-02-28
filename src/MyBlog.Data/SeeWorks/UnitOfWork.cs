using MyBlog.Core.SeeWorks;
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

        public UnitOfWork(MyBlogContext context)
        {
            _context = context;
        }
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
