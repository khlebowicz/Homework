using Homework.Common.Abstract;
using Homework.Data.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Homework.Data.Repository.Abstract
{
    public interface IReservationRepository : IRepository<Reservation>
    {
        Task<Reservation> GetReservationById(Guid userId, CancellationToken cancellationToken = default);
    }
}
