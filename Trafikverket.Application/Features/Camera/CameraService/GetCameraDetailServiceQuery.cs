using MediatR;
using System;
using System.Collections.Generic;

namespace Trafikverket.Application.Features.Camera.CameraService
{
    public class GetCameraDetailServiceQuery : IRequest<List<CameraDto>>
    {
        public string PayloadName { get; set; }
    }
}
