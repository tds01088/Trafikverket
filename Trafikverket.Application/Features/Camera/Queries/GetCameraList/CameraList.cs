using System;
using System.Collections.Generic;
using System.Text;

namespace Trafikverket.Application.Features.Camera.Queries.GetCameraList
{
   public  class CameraList
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string CameraId { get; set; }
        public string Direction { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public string LastModifiedBy { get; set; }
    }
}
