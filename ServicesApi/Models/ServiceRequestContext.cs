using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicesApi.Models
{
    public class ServiceRequestContext : DbContext
    {
        public ServiceRequestContext(DbContextOptions<ServiceRequestContext> options)
            :base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<ServiceRequest> ServiceRequests { get; set; }
    }
}
