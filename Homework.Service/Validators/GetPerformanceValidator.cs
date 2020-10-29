using FluentValidation;
using Homework.Data.Database;
using Homework.Data.Repository.Abstract;
using Homework.Service.Queries;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Homework.Service.Validators
{
    public class GetPerformanceValidator : AbstractValidator<GetPerformanceQuery>
    {
        private readonly IPerformanceRepository _performanceRepository;
        private readonly HomeWorkDbContext _dbContext;

        public GetPerformanceValidator(IPerformanceRepository performanceRepository)
        {
            _performanceRepository = performanceRepository;
            _dbContext = (HomeWorkDbContext)_performanceRepository.GetDbContext();
            RuleFor(u => u)
                .MustAsync(PerformanceMustExists)
                .WithMessage("Błędny identyfikator występu");
        }

        private async Task<bool> PerformanceMustExists(GetPerformanceQuery command, CancellationToken cancellation = new CancellationToken())
        {
            if (command.Id.HasValue)
            {
                return await _dbContext.Performance?.AnyAsync(s => s.Id == command.Id.Value);
            }
            return true; 
        }
    }
}
