using AutoMapper;
using dihiddie.DAL.Post.Core.Repositories;
using dihiddie.DAL.Post.EF.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        public async Task<Core.Models.PostContent> GetPostContentAsync(int postContentId)
        {
            var postContent = await context.PostContent
                .FirstOrDefaultAsync(x => x.Id == postContentId)
                .ConfigureAwait(false);
            return mapper.Map<Core.Models.PostContent>(postContent);
        }

        public async Task<byte[]> GetPreviewImage(int postId)
        {
            var postInformation = await context.PostInformation.FirstOrDefaultAsync(x => x.PostId == postId)
                .ConfigureAwait(false);
            return postInformation.PreviewImage;
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