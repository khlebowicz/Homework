using Homework.Common;
using Homework.Data.Data;
using Homework.Data.Database;
using Homework.Data.Repository.Abstract;
using Homework.Service.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Homework.Service.Handlers
{

	public class GetFreeSeatByPerformanceQueryHandler : IRequestHandler<GetFreeSeatByPerformanceQuery, SimpleResponse>
	{
		private readonly HomeWorkDbContext _dbContext;
		private readonly IPerformanceRepository _performanceRepository;
		public GetFreeSeatByPerformanceQueryHandler(IPerformanceRepository performanceRepository)
		{
			_performanceRepository = performanceRepository;
			_dbContext = (HomeWorkDbContext)_performanceRepository.GetDbContext();
		}

		public async Task<SimpleResponse> Handle(GetFreeSeatByPerformanceQuery request,
			CancellationToken cancellationToken)
		{
			var performance = await _dbContext.Performance
				.Include(b => b.Seats)
				.Where(x => x.Id == request.PerformanceId)
				.FirstOrDefaultAsync(cancellationToken);

			//var data = await _dbContext.Performance
			//	.Where(x => x.Id == request.PerformanceId)
			//	.Include(b => b.Seats)
			//	.Select(s => s.Seats)
			//	.Select(s=>s.Where(w=>!(w.Reservations.Any())))
			//	.ToListAsync(cancellationToken);

			return new SimpleResponse(performance?.Seats.Where(s => !s.Reservations.Any()));
		}
	}
}
