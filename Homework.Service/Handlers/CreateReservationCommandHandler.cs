using Homework.Common;
using Homework.Data.Database;
using Homework.Data.Repository.Abstract;
using Homework.Service.Commands;
using MediatR;
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

		public CreateReservationCommandHandler(IReservationRepository reservationRepository)
		{
			_reservationRepository = reservationRepository;
		}

		public async Task<SimpleResponse> Handle(CreateReservationCommand request,
			CancellationToken cancellationToken)
		{
			var guid = Guid.NewGuid();
			return new SimpleResponse(guid);
		}
	}
}
