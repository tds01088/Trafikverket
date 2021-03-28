using MediatR;
using System;

namespace Trafikverket.Application.Features.Camera.Commands.CreateCamera
{
    public class CreateCameraCommand : IRequest<Guid>
    {
        public bool Active { get; set; }
        public string ContentType { get; set; }
        public int Direction { get; set; }
        public bool HasFullSizePhoto { get; set; }
        public bool HasSketchImage { get; set; }
        public string IconId { get; set; }
        public string CameraId { get; set; }
        public DateTime ModifiedTime { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public DateTime PhotoTime { get; set; }
        public string PhotoUrl { get; set; }
        public string Status { get; set; }
    }
}

