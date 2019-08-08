using dihiddie.DAL.Post.Core.Repositories;
using dihiddie.DAL.Post.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using dihiddie.DAL.Post.EF.Context;
using dihiddie.DAL.Post.EF.Repositories;
using AutoMapper;

namespace dihiddie.DAL.Post.EF.UnitOfWorks
{
    public class PostUnitOfWork : IPostUnitOfWork, IDisposable
    {
        private readonly DihiddieContext context;

        public PostUnitOfWork(DihiddieContext context, IMapper mapper)
        {
            this.context = context;
            PostRepository = new PostRepository(context, mapper);
        }
        public IPostRepository PostRepository { get; set ; }

        public void Dispose()
        {
            context.Dispose();
        }

        public async Task SaveChangesAsync() => await context.SaveChangesAsync().ConfigureAwait(false);
    }
}
