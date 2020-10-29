using Homework.Common;
using Homework.Data.Data;
using Homework.Data.Database;
using Homework.Data.Repository.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Homework.Data.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(HomeWorkDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<User> GetUserById(Guid userId, CancellationToken cancellationToken = default)
        {
            return await ((HomeWorkDbContext)_dbContext).User.FirstOrDefaultAsync(x => x.Id == userId, cancellationToken);
        }
    }
}
