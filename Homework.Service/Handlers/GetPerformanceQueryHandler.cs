using Homework.Common;
using Homework.Data.Repository.Abstract;
using Homework.Service.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Homework.Service.Handlers
{

	public class GetPerformanceQueryHandler : IRequestHandler<GetPerformanceQuery, SimpleResponse>
	{
		private readonly IPerformanceRepository _performanceRepository;

		public GetPerformanceQueryHandler(IPerformanceRepository performanceRepository)
		{
			_performanceRepository = performanceRepository;
		}

		public async Task<SimpleResponse> Handle(GetPerformanceQuery request,
			CancellationToken cancellationToken)
		{
			if (request.Id.HasValue)
			{
				return new SimpleResponse(await _performanceRepository.GetPerformanceById(request.Id.Value));
			}
			else
			{
				return new SimpleResponse((await _performanceRepository.GetPerformances()).Select(x => new { x.Name, x.Date }));
			}
		}
	}

}
