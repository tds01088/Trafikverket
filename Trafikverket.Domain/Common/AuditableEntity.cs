using System;
using System.Collections.Generic;
using System.Text;

namespace Trafikverket.Domain.Common
{
    public class AuditableEntity
    {
      
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public string LastModifiedBy { get; set; }
    }
}
