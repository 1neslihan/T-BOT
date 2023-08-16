using Application.Common.Interfaces;
using Domain.Common;
using Domain.Entities;
using MediatR;

namespace Application.Features.Products.Commands.Add
{
    public class ProductAddCommandHandler : IRequestHandler<ProductAddCommand, Response<Guid>>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        //private readonly HttpClient _httpClient;

        public ProductAddCommandHandler(IApplicationDbContext applicationDbContext, HttpClient httpClient)
        {
            _applicationDbContext=applicationDbContext;
            //_httpClient = httpClient;
        }

        public async Task<Response<Guid>> Handle(ProductAddCommand request, CancellationToken cancellationToken)
        {
            var product = new Product()
            {
                OrderId = request.OrderId,
                Name = request.Name,
                StoreName=request.StoreName,
                Picture=request.Picture,
                Price=request.Price,

            };

            await _applicationDbContext.Products.AddAsync(product, cancellationToken);
            await _applicationDbContext.SaveChangesAsync(cancellationToken);


            return new Response<Guid>($"The new product {product.Name} was successfully added to the db.", product.Id);
        }
    }
}
