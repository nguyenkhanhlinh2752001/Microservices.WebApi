using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Shared.Model.Models;

namespace Order_Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IBus _bus;

        public OrderController(IBus bus)
        {
            _bus = bus;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTicket(Order model)
        {
            if (model != null)
            {
                model.CreatedOn = DateTime.Now;
                Uri uri = new Uri("rabbitmq://localhost/order");
                var endPoint = await _bus.GetSendEndpoint(uri);
                await endPoint.Send(model);
                return Ok();
            }
            return BadRequest();
        }
    }
}