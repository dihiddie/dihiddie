using dihiddie.DAL.Post.Core.Repositories;

namespace dihiddie.DAL.Post.Core.UnitOfWorks
{
    public interface IUserUnitOfWork
    {
        IUserRepository UserRepository { get; set; }
    }
}
