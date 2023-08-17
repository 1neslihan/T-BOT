using Domain.Enums;

namespace Application.Features.Orders.Queries.GetAll
{
    public class OrderGetAllDto
    {
        public OrderGetAllDto(Guid id, int requestedAmount, string userId, Categories category, bool isDeleted, DateTimeOffset orderCreatedOn)
        {
            Id=id;
            RequestedAmount=requestedAmount;
            UserId=userId;
            Category=category;
            IsDeleted=isDeleted;
            OrderCreatedOn=orderCreatedOn;
        }

        public Guid Id { get; set; } //order id
        public int RequestedAmount { get; set; } //order
        public string UserId { get; set; } //order
        public Categories Category { get; set; } //order
        public bool IsDeleted { get; set; } //order
        public DateTimeOffset OrderCreatedOn { get; set; }

    }


}
