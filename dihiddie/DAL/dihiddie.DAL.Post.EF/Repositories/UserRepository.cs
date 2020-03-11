using dihiddie.DAL.Post.Core.Repositories;
using dihiddie.DAL.Post.EF.Context;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace dihiddie.DAL.Post.EF.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DihiddieContext context;

        public UserRepository(DihiddieContext context)
        {
            this.context = context;
        }

        public async Task<string> GetPasswordAsync(string userName)
        {
            var user = await context.User.FirstOrDefaultAsync(x => x.Name == userName).ConfigureAwait(false);
            if (user == null) return null;
            return user.Password;
        }
    }
}
