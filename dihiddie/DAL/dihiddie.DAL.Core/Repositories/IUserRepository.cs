using System.Threading.Tasks;

namespace dihiddie.DAL.Post.Core.Repositories
{
    public interface IUserRepository
    {
        Task<string> GetPasswordAsync(string userName);
    }
}
