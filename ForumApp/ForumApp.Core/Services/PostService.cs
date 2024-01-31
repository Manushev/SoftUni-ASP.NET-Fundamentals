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

        public async Task AddAsync(PostFormViewModel model)
        {
            var postModel = new Post
            {
                Title = model.Title,
                Content = model.Content
            };

            dbContext.Posts.Add(postModel);
            await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<PostViewModel>> GetAllAsync()
        {
            var posts = await dbContext.Posts
                .Select(p => new PostViewModel
                {
                    Id = p.Id,
                    Title = p.Title,
                    Content = p.Content,
                })
                .ToListAsync();

            return posts;
        }

        public async Task<PostFormViewModel> GetByIdAsync(int id)
        {
            var entity = await dbContext.Posts
                .FirstOrDefaultAsync(p => p.Id == id);

            return new PostFormViewModel
            {
                Title = entity.Title,
                Content = entity.Content
            };
        }

        public async Task UpdateAsync(PostFormViewModel model)
        {
            var entity = new Post
            {
                Id = model.Id,
                Title = model.Title,
                Content = model.Content
            };
            
            dbContext.Posts.Update(entity);
            await dbContext.SaveChangesAsync();
        }
    }
}
