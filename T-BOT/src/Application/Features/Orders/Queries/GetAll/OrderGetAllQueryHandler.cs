using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Orders.Queries.GetByDate
{
    public class OrderGetAllQueryHandler : IRequestHandler<OrderGetAllQuery, List<OrderGetAllDto>>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly ICurrentUserService _currentUserService;

        public OrderGetAllQueryHandler(IApplicationDbContext applicationDbContext, ICurrentUserService currentUserService)
        {
            _applicationDbContext=applicationDbContext;
            _currentUserService=currentUserService;
        }

        public async Task<List<OrderGetAllDto>> Handle(OrderGetAllQuery request, CancellationToken cancellationToken)
        {
            var dbQuery = _applicationDbContext.Orders
                .AsNoTracking()
                .Where(x => x.UserId == _currentUserService.UserId);

            dbQuery = request.IsDeleted.HasValue
                ? dbQuery.Where(x => x.IsDeleted == request.IsDeleted.Value)
                : dbQuery.Where(x => x.IsDeleted == false || x.IsDeleted == true);

            dbQuery=dbQuery.OrderByDescending(x => x.CreatedOn);


            var orderRecords = await dbQuery
                .Select(x => new OrderGetAllDto(x.Id, x.RequestedAmount, x.UserId, x.Category, x.IsDeleted, x.CreatedOn)).ToListAsync(cancellationToken);

            return orderRecords;

        }
    }
}

