﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace dihiddie.DAL.Post.Core.Repositories
{
    public interface IPostRepository
    {
        Task<int> SaveAsync(Models.PostInformation post);

        Task<int> SaveContentAsync(Models.PostContent post);

        Task<IEnumerable<Models.PostInformation>> GetPreviewsAsync();

        Models.PostInformation GetPost(int id);
    }
}
