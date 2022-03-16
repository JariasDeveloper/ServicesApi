using ServicesApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicesApi.Repositories
{
    public interface IServiceRequestRepository
    {
        Task<IEnumerable<ServiceRequest>> Get();
        Task<ServiceRequest> Get(Guid id);
        Task<ServiceRequest> Create(ServiceRequest serviceRequest);
        Task Update(ServiceRequest serviceRequest);
        Task Delete(int id);
    }
}
