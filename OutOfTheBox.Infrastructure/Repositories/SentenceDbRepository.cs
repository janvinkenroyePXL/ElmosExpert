using OutOfTheBox.Domain;
using OutOfTheBox.Logic.IRepositories;

namespace OutOfTheBox.Infrastructure.Repositories
{
    public class SentenceDbRepository : BaseDbRepository<Sentence>, ISentenceRepository
    {
        public SentenceDbRepository(OutOfTheBoxContext context) : base(context)
        {
        }
    }
}
