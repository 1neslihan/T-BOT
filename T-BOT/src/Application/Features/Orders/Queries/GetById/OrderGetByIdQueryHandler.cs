using Application.Common.Interfaces;
using Domain.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Orders.Queries.GetAll
{
    public class OrderGetByIdQueryHandler : IRequestHandler<OrderGetByIdQuery, List<OrderGetByIdDto>>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly ICurrentUserService _currentUserService;
        private readonly UserManager<User> _userManager;
        private readonly IEmailService _emailService;

        public OrderGetByIdQueryHandler(IApplicationDbContext applicationDbContext, ICurrentUserService currentUserService, UserManager<User> userManager, IEmailService emailService)
        {
            _applicationDbContext=applicationDbContext;
            _currentUserService=currentUserService;
            _userManager=userManager;
            _emailService=emailService;
        }

        public async Task<List<OrderGetByIdDto>> Handle(OrderGetByIdQuery request, CancellationToken cancellationToken)
        {
            var dbQuery = _applicationDbContext.Orders
                .AsNoTracking()
                .Where(x => x.UserId == _currentUserService.UserId)
                .Where(x => x.Id==request.Id);

            var userQuery = await _userManager.Users
                .Where(x => x.Id ==_currentUserService.UserId)
                .FirstOrDefaultAsync();


            dbQuery = request.IsDeleted.HasValue
                ? dbQuery.Where(x => x.IsDeleted == request.IsDeleted.Value)
                : dbQuery.Where(x => x.IsDeleted == false || x.IsDeleted == true);

            var orderRecords = await dbQuery
                .Select(x => new OrderGetByIdDto(x.Id, x.RequestedAmount, x.UserId, x.Category, x.IsDeleted, x.CreatedOn)).ToListAsync(cancellationToken);

            var productDbQuery = _applicationDbContext.Products.Where(x => x.OrderId == request.Id).ToList();

            var orderEventsDbQuery = _applicationDbContext.OrderEvents.Where(x => x.OrderId == request.Id).ToList();


            return orderRecords;
        }


    }


}
