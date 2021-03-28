using Trafikverket.Domain.Entities;

namespace Trafikverket.Application.Contracts.Persistence
{
    public interface ITrafikverketCameraRepository  : IAsyncRepository<CameraEntity>
    {
    }
}
