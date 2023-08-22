using Domain.Common;
using MediatR;

namespace Application.Features.Orders.Commands.SoftDelete
{
    public class OrderSoftDeleteCommand : IRequest<Response<Guid>>
    {
        public Guid Id { get; set; }

    }
}
