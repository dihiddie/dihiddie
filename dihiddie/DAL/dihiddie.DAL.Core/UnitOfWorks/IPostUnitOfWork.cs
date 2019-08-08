using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using dihiddie.DAL.Post.Core.Repositories;

namespace dihiddie.DAL.Post.Core.UnitOfWorks
{
    public interface IPostUnitOfWork
    {
        IPostRepository PostRepository { get; set; }

        Task SaveChangesAsync();
    }
}
