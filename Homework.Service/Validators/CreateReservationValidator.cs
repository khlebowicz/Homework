using FluentValidation;
using Homework.Common;
using Homework.Data.Database;
using Homework.Data.Repository.Abstract;
using Homework.Service.Commands;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Homework.Service.Validators
{

    public class CreateReservationValidator : AbstractValidator<CreateReservationCommand>
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly HomeWorkDbContext _dbContext;

        public CreateReservationValidator(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
            _dbContext = (HomeWorkDbContext)_reservationRepository.GetDbContext();

            RuleFor(u => u)
                .MustAsync(PerformanceMustBePlanned)
                .WithMessage(Invariants.Messages.PerformanceMustBePlanned);

            RuleFor(u => u)
                .MustAsync(UserMustExists)
                .WithMessage(Invariants.Messages.UserMustExists);

            RuleFor(u => u)
                .MustAsync(SeatNotBought)
                .WithMessage(Invariants.Messages.BoughtSeat);

            RuleFor(u => u)
                .MustAsync(SeatNotReserved)
                .WithMessage(Invariants.Messages.ReservedSeat);
        }

        private async Task<bool> PerformanceMustBePlanned(CreateReservationCommand command, CancellationToken cancellation = new CancellationToken())
        {
            return await _dbContext.Performance?.AnyAsync(s => s.Id == command.PerformanceId && s.Date > DateTime.Now);
        }

        private async Task<bool> UserMustExists(CreateReservationCommand command, CancellationToken cancellation = new CancellationToken())
        {
            return await _dbContext.User?.AnyAsync(s => s.Id == command.UserId);
        }

        private async Task<bool> SeatNotBought(CreateReservationCommand command, CancellationToken cancellation = new CancellationToken())
        {
            var seat = await _dbContext.Seat?.FirstOrDefaultAsync(s => s.Id == command.SeatId);
            return !seat.Reservations.Any(s => s.UntilWhen == Invariants.DefaultSaleDate);
        }

        private async Task<bool> SeatNotReserved(CreateReservationCommand command, CancellationToken cancellation = new CancellationToken())
        {
            var seat = await _dbContext.Seat?.FirstOrDefaultAsync(s => s.Id == command.SeatId);
            var user = await _dbContext.User?.FirstOrDefaultAsync(s => s.Id == command.UserId);
            if (user.IsVip)
            {
                var vipUsers = await _dbContext.User.Where(w => w.IsVip).Select(s => s.Id).ToListAsync();
                return !seat.Reservations.Any(s => s.UntilWhen < DateTime.Now && vipUsers.Contains(s.UserId));
            }
            else
            {
                return !seat.Reservations.Any(s => s.UntilWhen < DateTime.Now);
            }
        }
    }
}
