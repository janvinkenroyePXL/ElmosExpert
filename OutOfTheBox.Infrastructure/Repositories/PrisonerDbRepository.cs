using OutOfTheBox.Domain;
using OutOfTheBox.Logic.IRepositories;

namespace OutOfTheBox.Infrastructure.Repositories
{
    public class PrisonerDbRepository : BaseDbRepository<Prisoner>, IPrisonerRepository
    {
        public PrisonerDbRepository(OutOfTheBoxContext context) : base(context)
        {
        }
    }
}
