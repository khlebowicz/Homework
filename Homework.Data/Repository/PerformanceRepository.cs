using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Homework.Common;
using Homework.Data.Data;
using Homework.Data.Database;
using Homework.Data.Repository.Abstract;
using Microsoft.EntityFrameworkCore;


namespace Homework.Data.Repository
{
    public class PerformanceRepository : Repository<Performance>, IPerformanceRepository
    {
        public PerformanceRepository(HomeWorkDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Performance> GetPerformanceById(Guid performanceId, CancellationToken cancellationToken = default)
        {
            return await ((HomeWorkDbContext)_dbContext).Performance.FirstOrDefaultAsync(x => x.Id == performanceId, cancellationToken);
        }

        public async Task<List<Performance>> GetPerformances(CancellationToken cancellationToken = default)
        {
            return await ((HomeWorkDbContext)_dbContext).Performance.ToListAsync(cancellationToken);
        }
    }
}