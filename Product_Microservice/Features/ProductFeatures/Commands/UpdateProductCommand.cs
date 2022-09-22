﻿using MediatR;
using Product_Microservice.Context;

namespace Product_Microservice.Features.ProductFeatures.Commands
{
    public class UpdateProductCommand:  IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Barcode { get; set; }
        public string Description { get; set; }
        public decimal BuyingPrice { get; set; }
        public decimal Rate { get; set; }
        public string ConfidentialData { get; set; }
        public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, int>
        {
            private readonly IApplicationContext _context;
            public UpdateProductCommandHandler(IApplicationContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
            {
                var product = _context.Products.Where(a => a.Id == command.Id).FirstOrDefault();
                if (product == null)
                {
                    return default;
                }
                else
                {
                    product.Barcode = command.Barcode;
                    product.Name = command.Name;
                    product.BuyingPrice = command.BuyingPrice;
                    product.Rate = command.Rate;
                    product.Description = command.Description;
                    product.ConfidentialData = command.ConfidentialData;
                    await _context.SaveChanges();
                    return product.Id;
                }
            }
        }
    }
}
