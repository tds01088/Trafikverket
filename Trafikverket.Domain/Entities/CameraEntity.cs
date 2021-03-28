using System;
using Trafikverket.Domain.Common;

namespace Trafikverket.Domain.Entities
{
    public class CameraEntity: AuditableEntity {

        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Direction { get; set; }
    }
}
