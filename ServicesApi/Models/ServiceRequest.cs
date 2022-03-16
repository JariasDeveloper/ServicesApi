using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ServicesApi.Models
{
    public class ServiceRequest
    {
        public Guid Id { get; set; }
        public string BuildingCode { get; set; }
        public string Description { get; set; }
        public CurrentStatus CurrentStatus { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime LastModifiedDate { get; set; }

    }

    public enum CurrentStatus
    {
        NotApplicable   = 0,
        Created         = 1,
        InProgress      = 2,
        Complete        = 3,
        Canceled        = 4
    }
}
