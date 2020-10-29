using FluentValidation;
using Homework.Common;
using Homework.Data.Database;
using Homework.Data.Repository.Abstract;
using Homework.Service.Commands;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Homework.Service.Validators
{

    public class BuyReservationValidator : AbstractValidator<BuyReservationCommand>
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly HomeWorkDbContext _dbContext;

        public BuyReservationValidator(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
            _dbContext = (HomeWorkDbContext)_reservationRepository.GetDbContext();

            RuleFor(u => u)
                .MustAsync(ReservationMustBeActive)
                .WithMessage(Invariants.Messages.ReservationMustBeActive);
        }

        private async Task<bool> ReservationMustBeActive(BuyReservationCommand command, CancellationToken cancellation = new CancellationToken())
        {
            return await _dbContext.Reservation?.AnyAsync(s => s.Id == command.ReservationId && s.UntilWhen > DateTime.Now && s.UserId == command.UserId);
        }
    }
}