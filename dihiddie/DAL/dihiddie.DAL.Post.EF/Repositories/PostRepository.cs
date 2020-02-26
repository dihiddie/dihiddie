using AutoMapper;
using dihiddie.DAL.Post.Core.Models;
using dihiddie.DAL.Post.Core.Repositories;
using dihiddie.DAL.Post.EF.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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
            var postContent = await context.PostContent.AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == postContentId)
                .ConfigureAwait(false);
            return mapper.Map<Core.Models.PostContent>(postContent);
        }

        public async Task<Core.Models.PostInformation> GetPostInformationByPostId(int postId)
        {
            var postInformation = await context
                .PostInformation.FirstOrDefaultAsync(x => x.PostId == postId)
                .ConfigureAwait(false);
            return mapper.Map<Context.PostInformation, Core.Models.PostInformation>(postInformation);
        }

        public async Task<byte[]> GetPreviewImage(int postId)
        {
            var postInformation = await context.PostInformation.FirstOrDefaultAsync(x => x.PostId == postId)
                .ConfigureAwait(false);
            return postInformation?.PreviewImage;
        }

        public async Task<IEnumerable<Core.Models.PostInformation>> GetPreviewsAsync()
        {
            var posts = await context.PostInformation.OrderByDescending(x => x.CreateDateTime).ToListAsync()
                .ConfigureAwait(false);
            return mapper.Map<Core.Models.PostInformation[]>(posts);
        }

        public async Task<int> SaveAsync(Core.Models.PostInformation post)
        {
            var mappedPostInformation = mapper.Map<Context.PostInformation>(post);
            var postInfoInDb = await context.PostInformation.AsNoTracking().FirstOrDefaultAsync(x => x.Id == post.Id)
                .ConfigureAwait(false);
            if (postInfoInDb == null)
                await context.PostInformation.AddAsync(mappedPostInformation).ConfigureAwait(false);
            else
            {
                postInfoInDb.IsBlogPost = mappedPostInformation.IsBlogPost;
                postInfoInDb.IsDraft = mappedPostInformation.IsDraft;
                postInfoInDb.PreviewImage = mappedPostInformation.PreviewImage;
                postInfoInDb.PreviewText = mappedPostInformation.PreviewText;
                postInfoInDb.Title = mappedPostInformation.Title;
                context.PostInformation.Update(postInfoInDb);
            }
            await context.SaveChangesAsync().ConfigureAwait(false);
            return mappedPostInformation.Id;
        }

        public async Task<int> SaveContentAsync(Core.Models.PostContent post)
        {
            var mappedPostContent = mapper.Map<PostContent>(post);
            var postInDb = await context.PostContent.AsNoTracking().FirstOrDefaultAsync(x => x.Id == post.Id)
                .ConfigureAwait(false);
            if (postInDb == null)
                await context.PostContent.AddAsync(mappedPostContent).ConfigureAwait(false);
            else context.PostContent.Update(mappedPostContent);
            await context.SaveChangesAsync().ConfigureAwait(false);
            return mappedPostContent.Id;
        }
    }
}