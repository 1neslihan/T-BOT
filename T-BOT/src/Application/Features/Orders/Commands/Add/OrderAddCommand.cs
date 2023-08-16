using Domain.Common;
using Domain.Enums;
using MediatR;

namespace Application.Features.Orders.Commands.Add
{
    public class OrderAddCommand : IRequest<Response<Guid>>
    {
        public Guid Id { get; set; }
        public int RequestedAmount { get; set; }
        public string UserId { get; set; }
        public Categories Category { get; set; }

    }
}
