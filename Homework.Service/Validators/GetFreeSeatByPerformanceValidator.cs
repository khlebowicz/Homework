using FluentValidation;
using Homework.Common;
using Homework.Data.Database;
using Homework.Data.Repository.Abstract;
using Homework.Service.Queries;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Homework.Service.Validators
{
    public class GetFreeSeatByPerformanceValidator : AbstractValidator<GetFreeSeatByPerformanceQuery>
    {
        private readonly IPerformanceRepository _performanceRepository;
        private readonly HomeWorkDbContext _dbContext;

        public GetFreeSeatByPerformanceValidator(IPerformanceRepository performanceRepository)
        {
            _performanceRepository = performanceRepository;
            _dbContext = (HomeWorkDbContext)_performanceRepository.GetDbContext();

            RuleFor(u => u.PerformanceId)
                .NotEmpty()
                .WithMessage(Invariants.Messages.PerformanceIdNotEmpty);

            RuleFor(u => u)
                .MustAsync(PerformanceMustExists)
                .WithMessage(Invariants.Messages.PerformanceMustExists);
        }

        private async Task<bool> PerformanceMustExists(GetFreeSeatByPerformanceQuery command, CancellationToken cancellation = new CancellationToken())
        {
            return await _dbContext.Performance?.AnyAsync(s => s.Id == command.PerformanceId);
        }
    }
}
