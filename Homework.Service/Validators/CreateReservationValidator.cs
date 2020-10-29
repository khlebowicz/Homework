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
                .MustAsync(SeatNotBought)
                .WithMessage(Invariants.Messages.SeatNotBought);
        }

        private async Task<bool> PerformanceMustBePlanned(CreateReservationCommand command, CancellationToken cancellation = new CancellationToken())
        {
            return await _dbContext.Performance?.AnyAsync(s => s.Id == command.PerformanceId && s.Date > DateTime.Now);
        }

        private async Task<bool> SeatNotBought(CreateReservationCommand command, CancellationToken cancellation = new CancellationToken())
        {
            var seat = await _dbContext.Seat?.FirstOrDefaultAsync(s => s.Id == command.SeatId);
            return !seat.Reservations.Any(s => s.UntilWhen == Invariants.DefaultLastDate);
        }

    }
}
