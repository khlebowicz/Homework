using Homework.Common;
using Homework.Data.Data;
using Homework.Data.Database;
using Homework.Data.Repository.Abstract;
using Homework.Service.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Homework.Service.Handlers
{

	public class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommand, SimpleResponse>
	{
		private readonly IReservationRepository _reservationRepository;
		private readonly HomeWorkDbContext _dbContext;

		public CreateReservationCommandHandler(IReservationRepository reservationRepository)
		{
			_dbContext = (HomeWorkDbContext)_reservationRepository.GetDbContext();
			_reservationRepository = reservationRepository;
		}

		public async Task<SimpleResponse> Handle(CreateReservationCommand request,
			CancellationToken cancellationToken)
		{
			var user = await _dbContext.User?.FirstOrDefaultAsync(s => s.Id == request.UserId);
			var untilWhen = user.IsVip ? DateTime.Now.AddMinutes(Invariants.ReservationLengthForVIPUser) : DateTime.Now.AddMinutes(Invariants.ReservationLengthForRegularUser);
			var reservationId = Guid.NewGuid();
			await _reservationRepository.Add(new Reservation() { 
				Id = reservationId,
				UserId = request.UserId, 
				UntilWhen = untilWhen });
			return new SimpleResponse(reservationId);
		}
	}
}
