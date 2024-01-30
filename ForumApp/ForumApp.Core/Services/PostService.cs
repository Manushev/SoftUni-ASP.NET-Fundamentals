using ForumApp.Core.Contracts;
using ForumApp.Core.Models;
using ForumApp.Infrastructure.Data;
using ForumApp.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ForumApp.Core.Services
{
    public class PostService : IPostService
    {
        private readonly ForumAppDbContext dbContext;

        public PostService(ForumAppDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public async Task<IEnumerable<PostViewModel>> GetAllAsync()
        {
            var posts =  await dbContext.Posts
                .Select(p => new PostViewModel 
                {
                   Id = p.Id,
                   Title = p.Title,
                   Content = p.Content,
                })
                .ToListAsync();

            return posts;
        }
    }
}
