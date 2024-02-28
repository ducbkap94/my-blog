using Microsoft.EntityFrameworkCore;
using MyBlog.Data;

namespace MyBlog.Api
{
    public static class MigrationManager
    {
        public static WebApplication MigrationDatabase(this WebApplication app)
        {
            using(var scope = app.Services.CreateScope())
            {
                using (var context=scope.ServiceProvider.GetRequiredService<MyBlogContext>())
                {
                    context.Database.Migrate();
                    new DataSeeder().SeedAsync(context).Wait();
                }
            }
            return app;
        }
    }
}
