using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Homework.Common.Abstract;
using Homework.Data.Data;

namespace Homework.Data.Repository.Abstract
{
    public interface IPerformanceRepository: IRepository<Performance>
    {
        Task<Performance> GetPerformanceById(Guid performanceId, CancellationToken cancellationToken = default);

        Task<List<Performance>> GetPerformances(CancellationToken cancellationToken = default);
    }
}