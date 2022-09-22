using Customer_Microservice.Context;
using Customer_Microservice.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Customer_Microservice.Features.CustomerFeatures.Queries
{
    public class GetAllCustomersQuery : IRequest<IEnumerable<Customer>>
    {
        public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQuery, IEnumerable<Customer>>
        {
            private readonly IApplicationContext _context;
            public GetAllCustomersQueryHandler(IApplicationContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Customer>> Handle(GetAllCustomersQuery query, CancellationToken cancellationToken)
            {
                var customerList = await _context.Customers.ToListAsync();
                if (customerList == null)
                {
                    return null;
                }
                return customerList.AsReadOnly();
            }
        }
    }
}
