using Customer_Microservice.Context;
using Customer_Microservice.Models;
using MediatR;

namespace Customer_Microservice.Features.CustomerFeatures.Commands
{
    public class CreateCustomerCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public class CreateProductCommandHandler : IRequestHandler<CreateCustomerCommand, int>
        {
            private readonly IApplicationContext _context;
            public CreateProductCommandHandler(IApplicationContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(CreateCustomerCommand command, CancellationToken cancellationToken)
            {
                var customer = new Customer();
                customer.Name = command.Name;
                customer.Email = command.Email;
                _context.Customers.Add(customer);
                await _context.SaveChanges();
                return customer.Id;
            }
        }
    }
}
