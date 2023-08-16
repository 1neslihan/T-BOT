using Domain.Common;
using MediatR;

namespace Application.Features.SendEmail.Commands.OrderDetails
{
    public class SendOrderDetailsAddCommand : IRequest<Response<Guid>>
    {
        //public string Name { get; set; }
        //public string Email { get; set; }
        public Guid OrderId { get; set; }
        //public string GenerateDate { get; set; }
        //public List<Product> Products { get; set; }
        //public List<OrderEvent> OrderEvents { get; set; }
    }
}
