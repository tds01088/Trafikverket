using AutoMapper;
using Trafikverket.Application.Features.Camera.Commands.CreateCamera;
using Trafikverket.Application.Features.Camera.CameraService;
using Trafikverket.Domain.Entities;
using System.Diagnostics.Tracing;
using Trafikverket.Application.Features.Camera.Queries.GetCameraList;

namespace Trafikverket.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Camera, CameraDto>()
                  .ForMember(dest => dest.CameraId,
                     opts => opts.MapFrom(source => source.Id));
            CreateMap<CameraDto, CreateCameraCommand>();
            CreateMap<CreateCameraCommand, CameraEntity>();
            CreateMap<CameraEntity, CameraList>();            
        }
    }
}
