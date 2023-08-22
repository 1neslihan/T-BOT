using Application.Common.Interfaces;
using Domain.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Orders.Commands.SoftDelete
{

    public class OrderSoftDeleteCommandHandler : IRequestHandler<OrderSoftDeleteCommand, Response<Guid>>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public OrderSoftDeleteCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext=applicationDbContext;
        }

        public async Task<Response<Guid>> Handle(OrderSoftDeleteCommand request, CancellationToken cancellationToken)
        {
            var dbQuery = _applicationDbContext.Orders.AsQueryable();

            var order = await dbQuery
                .Include(x => x.Products)
                .Include(x => x.OrderEvents)
                .Where(x => x.Id == request.Id).FirstOrDefaultAsync();

            if (order != null)
            {
                order.IsDeleted= true;
                order.DeletedOn= DateTime.Now;
                order.ModifiedOn=DateTime.Now;
                //order.DeletedByUserId=request.Id.ToString();

                if (order.Products != null)
                {
                    foreach (var product in order.Products)
                    {
                        product.IsDeleted = true;
                        product.DeletedOn = DateTime.Now;
                        product.ModifiedOn= DateTime.Now;
                        //product.DeletedByUserId = request.Id.ToString();
                    }
                }

                if (order.OrderEvents != null)
                {
                    foreach (var orderEvent in order.OrderEvents)
                    {
                        orderEvent.IsDeleted = true;
                        orderEvent.DeletedOn = DateTime.Now;
                        orderEvent.ModifiedOn= DateTime.Now;
                        //orderEvent.DeletedByUserId = request.Id.ToString();
                    }
                }

                await _applicationDbContext.SaveChangesAsync(cancellationToken);
                return new Response<Guid>("Order moved to the trash");
            }
            return new Response<Guid>("Order was not found");
        }
    }
}
