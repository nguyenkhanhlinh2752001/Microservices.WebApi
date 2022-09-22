using Customer_Microservice.Context;
using MediatR;

namespace Customer_Microservice.Features.CustomerFeatures.Commands
{
    public class UpdateCustomerCommand: IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public class UpdateProductCommandHandler : IRequestHandler<UpdateCustomerCommand, int>
        {
            private readonly IApplicationContext _context;
            public UpdateProductCommandHandler(IApplicationContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(UpdateCustomerCommand command, CancellationToken cancellationToken)
            {
                var customer = _context.Customers.Where(a => a.Id == command.Id).FirstOrDefault();
                if (customer == null)
                {
                    return default;
                }
                else
                {
                    customer.Name = command.Name;
                    customer.Email = command.Email;
                    await _context.SaveChanges();
                    return customer.Id;
                }
            }
        }
    }
}
