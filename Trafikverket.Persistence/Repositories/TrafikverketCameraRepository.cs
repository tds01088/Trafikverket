using Trafikverket.Application.Contracts.Persistence;
using Trafikverket.Domain.Entities;
using Trafikverket_ConsoleApp.Infrastructure;

namespace Trafikverket.Persistence.Repositories
{
    public class TrafikverketCameraRepository : BaseRepository<CameraEntity>, ITrafikverketCameraRepository
    {
        public TrafikverketCameraRepository(TrafikverketContext dbContext) : base(dbContext)
        {
        }
    }
}
