using Homework.Common;
using Homework.Data.Data;
using MediatR;
using System;
using System.Collections.Generic;

namespace Homework.Service.Queries
{
    public class GetPerformanceQuery : IRequest<SimpleResponse>
    {
        public Guid? Id { get; set; }
    }
}
