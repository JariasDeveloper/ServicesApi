using Microsoft.EntityFrameworkCore;
using ServicesApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicesApi.Repositories
{
    public class ServiceRequestRepository : IServiceRequestRepository
    {
        private readonly ServiceRequestContext _context;

        public ServiceRequestRepository(ServiceRequestContext context)
        {
            _context = context;
        }

        public async Task<ServiceRequest> Create(ServiceRequest serviceRequest)
        {
            if(serviceRequest.Id == Guid.Empty)
            {
                serviceRequest.Id = Guid.NewGuid();
            }

            _context.ServiceRequests.Add(serviceRequest);
            await _context.SaveChangesAsync();

            return serviceRequest;
        }

        public async Task Delete(int id)
        {
            var serviceToDelete = await _context.ServiceRequests.FindAsync(id);
            _context.ServiceRequests.Remove(serviceToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ServiceRequest>> Get()
        {
            return await _context.ServiceRequests.ToListAsync();
        }

        public async Task<ServiceRequest> Get(Guid id)
        {
            return await _context.ServiceRequests.FindAsync(id);
        }

        public async Task Update(ServiceRequest serviceRequest)
        {
            _context.Entry(serviceRequest).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
