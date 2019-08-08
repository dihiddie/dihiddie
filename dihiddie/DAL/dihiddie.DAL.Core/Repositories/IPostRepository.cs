using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dihiddie.DAL.Post.Core.Repositories
{
    public interface IPostRepository
    {
        Task<bool> SaveAsync(Models.Post post);

        Task<IEnumerable<Models.Post>> GetPreviewsAsync();

        Models.Post GetPost(int id);
    }
}
