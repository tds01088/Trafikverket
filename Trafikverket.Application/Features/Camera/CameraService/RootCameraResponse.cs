using System;
using System.Collections.Generic;


namespace Trafikverket.Application.Features.Camera.CameraService
{

  
    public class RootCameraResponse
    {
        public RESPONSE RESPONSE { get; set; }
    }

    public class Geometry
    {
        public string SWEREF99TM { get; set; }
        public string WGS84 { get; set; }
    }

    public class Camera
    {
        public bool Active { get; set; }
        public string ContentType { get; set; }
        public List<int> CountyNo { get; set; }
        public int Direction { get; set; }
        public Geometry Geometry { get; set; }
        public bool HasFullSizePhoto { get; set; }
        public bool HasSketchImage { get; set; }
        public string IconId { get; set; }
        public string Id { get; set; }
        public DateTime ModifiedTime { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public DateTime PhotoTime { get; set; }
        public string PhotoUrl { get; set; }
        public string Status { get; set; }
    }

    public class RESULT
    {
        public List<Camera> Camera { get; set; }
    }

    public class RESPONSE
    {
        public List<RESULT> RESULT { get; set; }
    }
}
