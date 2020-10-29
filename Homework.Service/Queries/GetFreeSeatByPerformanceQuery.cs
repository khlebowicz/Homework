using Homework.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Homework.Service.Queries
{
    public class GetFreeSeatByPerformanceQuery : IRequest<SimpleResponse>
    {
        public Guid PerformanceId { get; set; }
    }
}
