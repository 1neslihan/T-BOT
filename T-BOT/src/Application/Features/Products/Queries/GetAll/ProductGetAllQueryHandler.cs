using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Products.Queries.GetAll
{
    public class ProductGetAllQueryHandler : IRequestHandler<ProductGetAllQuery, List<ProductGetAllDto>>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public ProductGetAllQueryHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext=applicationDbContext;
        }

        public async Task<List<ProductGetAllDto>> Handle(ProductGetAllQuery request, CancellationToken cancellationToken)
        {
            var dbQuery = _applicationDbContext.Products.AsQueryable();

            dbQuery = request.IsDeleted.HasValue
            ? dbQuery.Where(x => x.IsDeleted == request.IsDeleted.Value)
            : dbQuery.Where(x => x.IsDeleted == false || x.IsDeleted == true);

            var productRecords = await dbQuery
                .Select(x => new ProductGetAllDto(x.Id, x.OrderId, x.Name, x.StoreName, x.Picture, x.Price, x.IsDeleted)).ToListAsync(cancellationToken);

            return productRecords;
        }
    }
}
