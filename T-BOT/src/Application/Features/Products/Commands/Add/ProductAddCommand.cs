using Domain.Common;
using MediatR;

namespace Application.Features.Products.Commands.Add
{
    public class ProductAddCommand : IRequest<Response<Guid>>
    {
        public Guid OrderId { get; set; }
        public string Name { get; set; }
        public string StoreName { get; set; }
        public string Picture { get; set; }
        public decimal Price { get; set; }

    }
}
