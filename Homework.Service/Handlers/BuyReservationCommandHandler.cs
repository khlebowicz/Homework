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
	public class BuyReservationCommandHandler : IRequestHandler<BuyReservationCommand, SimpleResponse>
	{
		private readonly IReservationRepository _reservationRepository;
		public BuyReservationCommandHandler(IReservationRepository reservationRepository)
		{
			_reservationRepository = reservationRepository;
		}

		public async Task<SimpleResponse> Handle(BuyReservationCommand request,
			CancellationToken cancellationToken)
		{
			var reservation = await _reservationRepository.GetReservationById(request.ReservationId);
			reservation.UntilWhen = Invariants.DefaultSaleDate;
			await _reservationRepository.Update(reservation);
			return new SimpleResponse(reservation);
		}
	}
}
