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
    public class ReservationRepository : Repository<Reservation>, IReservationRepository
    {
        public ReservationRepository(HomeWorkDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Reservation> GetReservationById(Guid reservationId, CancellationToken cancellationToken = default)
        {
            return await ((HomeWorkDbContext)_dbContext).Reservation.FirstOrDefaultAsync(x => x.Id == reservationId, cancellationToken);
        }
    }
}
