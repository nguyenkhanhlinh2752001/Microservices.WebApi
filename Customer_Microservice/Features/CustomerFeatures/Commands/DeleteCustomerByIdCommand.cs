using Customer_Microservice.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Customer_Microservice.Features.CustomerFeatures.Commands
{
    public class DeleteCustomerByIdCommand: IRequest<int>
    {
        public int Id { get; set; }
        public class DeleteCustomerByIdCommandHandler : IRequestHandler<DeleteCustomerByIdCommand, int>
        {
            private readonly IApplicationContext _context;
            public DeleteCustomerByIdCommandHandler(IApplicationContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(DeleteCustomerByIdCommand command, CancellationToken cancellationToken)
            {
                var customer = await _context.Customers.Where(a => a.Id == command.Id).FirstOrDefaultAsync();
                if (customer == null) return default;
                _context.Customers.Remove(customer);
                await _context.SaveChanges();
                return customer.Id;
            }
        }
    }
}
