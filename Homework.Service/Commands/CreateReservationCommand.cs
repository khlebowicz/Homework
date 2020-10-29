using Homework.Common;
using Homework.Common.Abstract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Homework.Service.Commands
{
    public class CreateReservationCommand : IRequest<SimpleResponse>
    {
        public Guid PerformanceId { get; set; }
        public Guid SeatId { get; set; }
        public Guid UserId { get; set; }
        public DateTime UntilWhen { get; set; }
    }
}
