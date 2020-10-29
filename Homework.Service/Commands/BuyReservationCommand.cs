using Homework.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Homework.Service.Commands
{
    public class BuyReservationCommand : IRequest<SimpleResponse>
    {
        public Guid ReservationId { get; set; }
        public Guid UserId { get; set; }
    }
}
