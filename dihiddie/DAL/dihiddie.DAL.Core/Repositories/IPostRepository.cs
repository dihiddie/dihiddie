using System.Collections.Generic;
using System.Threading.Tasks;
using dihiddie.DAL.Post.Core.Models;

namespace dihiddie.DAL.Post.Core.Repositories
{
    public interface IPostRepository
    {
        Task<IEnumerable<Models.PostInformation>> GetPreviewsAsync();

        Task<Models.PostContent> GetPostContentAsync(int postContentId);

        Task<byte[]> GetPreviewImage(int postId);

        Task<PostInformation> GetPostInformationByPostId(int postId);

        Task<IEnumerable<Tag>> GetTagsAsync();

        Task<int> SaveAsync(Models.PostInformation post);

        Task<int> SaveContentAsync(Models.PostContent post);
    }
}
