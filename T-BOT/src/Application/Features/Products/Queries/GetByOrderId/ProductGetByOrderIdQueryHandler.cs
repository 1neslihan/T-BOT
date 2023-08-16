using Application.Common.Interfaces;
using Application.Common.Models.General;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Products.Queries.GetAll
{
    public class ProductGetByOrderIdQueryHandler : IRequestHandler<ProductGetByOrderIdQuery, PaginatedList<ProductGetByOrderIdDto>>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public ProductGetByOrderIdQueryHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext=applicationDbContext;
        }

        public async Task<PaginatedList<ProductGetByOrderIdDto>> Handle(ProductGetByOrderIdQuery request, CancellationToken cancellationToken)
        {
            var dbQuery = _applicationDbContext.Products.AsQueryable();

            dbQuery= request.IsDeleted.HasValue
                ? dbQuery.Where(x => x.IsDeleted == request.IsDeleted.Value && x.OrderId==request.OrderId)
                : dbQuery.Where(x => x.OrderId==request.OrderId);

            var productDtos = await dbQuery.Select(x => new ProductGetByOrderIdDto(x.Id, x.OrderId, x.Name, x.Picture, x.StoreName, x.Price, x.IsDeleted))
                .AsQueryable()
                .ToListAsync(cancellationToken);

            return PaginatedList<ProductGetByOrderIdDto>.Create(productDtos, request.PageNumber, request.PageSize);

        }


    }
}
