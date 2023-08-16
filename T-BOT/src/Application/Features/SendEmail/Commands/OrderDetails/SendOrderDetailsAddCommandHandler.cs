using Application.Common.Interfaces;
using Application.Common.Models.Email;
using Domain.Common;
using Domain.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.SendEmail.Commands.OrderDetails
{
    public class SendOrderDetailsAddCommandHandler : IRequestHandler<SendOrderDetailsAddCommand, Response<Guid>>
    {
        private readonly IEmailService _emailService;
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly ICurrentUserService _currentUserService;
        private readonly UserManager<User> _userManager;

        public SendOrderDetailsAddCommandHandler(IEmailService emailService, IApplicationDbContext applicationDbContext, ICurrentUserService currentUserService, UserManager<User> userManager)
        {
            _emailService=emailService;
            _applicationDbContext=applicationDbContext;
            _currentUserService=currentUserService;
            _userManager=userManager;

        }

        public async Task<Response<Guid>> Handle(SendOrderDetailsAddCommand request, CancellationToken cancellationToken)
        {
            var userQuery = await _userManager.Users
                .Where(x => x.Id ==_currentUserService.UserId)
                .FirstOrDefaultAsync();

            var productDbQuery = _applicationDbContext.Products.Where(x => x.OrderId == request.OrderId).ToList();

            var orderEventDbQuery = _applicationDbContext.OrderEvents.Where(x => x.OrderId == request.OrderId).ToList();

            var orderDbQuery = _applicationDbContext.Orders.Where(x => x.Id == request.OrderId).ToList();

            if (userQuery.EmailNotification == true)
            {
                _emailService.SendOrderDetails(new SendOrderDetailsDto()
                {
                    Name = userQuery.FirstName,
                    Email = userQuery.Email,
                    OrderId = request.OrderId,
                    GenerateDate= orderDbQuery.Select(order => order.CreatedOn).FirstOrDefault().ToString(),
                    Products = productDbQuery,
                    OrderEvents=orderEventDbQuery,
                });

                return new Response<Guid>("Email successfully send.");
            }

            return new Response<Guid>("Email notification not enabled.");
        }
    }
}
