using System.Threading.Tasks;
using Trafikverket.Application.Features.Camera.CameraService;

namespace Trafikverket.Application.Contracts.Infrastructure
{
    public interface IRelayCameraService
    {
        Task<RootCameraResponse> GetListCameraDetailAsync(string payload);    
    }
}
