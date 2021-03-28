using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Trafikverket.Application.Features.Camera.Queries.GetCameraList
{
    public class GetCameraListWithDirection90Query : IRequest<List<CameraList>>
    {
    }
}
