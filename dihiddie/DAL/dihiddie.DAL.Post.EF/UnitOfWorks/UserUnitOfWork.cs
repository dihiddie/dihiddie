using dihiddie.DAL.Post.Core.Repositories;
using dihiddie.DAL.Post.Core.UnitOfWorks;
using dihiddie.DAL.Post.EF.Context;
using dihiddie.DAL.Post.EF.Repositories;
using System;

namespace dihiddie.DAL.Post.EF.UnitOfWorks
{
    public class UserUnitOfWork : IUserUnitOfWork, IDisposable
    {

        private readonly DihiddieContext context;

        public UserUnitOfWork(DihiddieContext context)
        {
            this.context = context;
            UserRepository = new UserRepository(context);
        }

        public IUserRepository UserRepository { get; set; }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
