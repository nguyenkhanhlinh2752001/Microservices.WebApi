using MassTransit;
using Shared.Model.Models;

namespace OrderProcessor_Microservice.Consumers
{
    public class OrderConsumer : IConsumer<Order>
    {
        public async Task Consume(ConsumeContext<Order> context)
        {
            var data = context.Message;
        }
    }
}