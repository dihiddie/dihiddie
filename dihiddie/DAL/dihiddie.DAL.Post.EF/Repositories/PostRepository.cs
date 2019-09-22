using AutoMapper;
using dihiddie.DAL.Post.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using dihiddie.DAL.Post.EF.Context;
using dihiddie.DAL.Post.Core.Models;
using PostContent = dihiddie.DAL.Post.EF.Context.PostContent;

namespace dihiddie.DAL.Post.EF.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly DihiddieContext context;

        private readonly IMapper mapper;

        public PostRepository(DihiddieContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public Core.Models.PostInformation GetPost(int id)
        {
            return null;
        }

        public async Task<IEnumerable<Core.Models.PostInformation>> GetPreviewsAsync()
        {
            var posts = await context.PostInformation.ToListAsync().ConfigureAwait(false);
            return mapper.Map<Core.Models.PostInformation[]>(posts);
        }

        public async Task<int> SaveAsync(Core.Models.PostInformation post)
        {
            var mappedPostInformation = mapper.Map<Context.PostInformation>(post);
            await context.PostInformation.AddAsync(mappedPostInformation).ConfigureAwait(false);
            await context.SaveChangesAsync().ConfigureAwait(false);
            return mappedPostInformation.Id;
        }

        public async Task<int> SaveContentAsync(Core.Models.PostContent post)
        {
            var mappedPostContent = mapper.Map<PostContent>(post);
            await context.PostContent.AddAsync(mappedPostContent).ConfigureAwait(false);
            await context.SaveChangesAsync().ConfigureAwait(false);
            return mappedPostContent.Id;
        }
    }
}