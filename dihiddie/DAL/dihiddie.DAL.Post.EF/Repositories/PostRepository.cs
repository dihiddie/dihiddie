using dihiddie.DAL.Post.Core.Repositories;
using System;
using System.Collections;
using System.Threading.Tasks;
using AutoMapper;
using dihiddie.DAL.Post.EF.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

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

        public Core.Models.Post GetPost(int id)
        {
            return null;
        }

        public async Task<IEnumerable<Core.Models.Post>> GetPreviewsAsync()
        {
            var posts = await context.Post.ToListAsync();
            return mapper.Map<Core.Models.Post[]>(posts);
        }

        public async Task<bool> SaveAsync(Core.Models.Post post)
        {
            try
            {
                await context.Post.AddAsync(mapper.Map<Context.Post>(post)).ConfigureAwait(false);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}