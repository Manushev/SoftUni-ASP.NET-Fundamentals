﻿using ForumApp.Core.Models;
using ForumApp.Infrastructure.Data.Models;

namespace ForumApp.Core.Contracts
{
    public interface IPostService
    {
        Task AddAsync(PostFormViewModel model);
        Task<IEnumerable<PostViewModel>> GetAllAsync();
    }
}