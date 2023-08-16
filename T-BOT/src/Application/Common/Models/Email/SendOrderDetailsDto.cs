using Domain.Entities;

namespace Application.Common.Models.Email
{
    public class SendOrderDetailsDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public Guid OrderId { get; set; }
        public string GenerateDate { get; set; }
        public List<Product> Products { get; set; }
        public List<OrderEvent> OrderEvents { get; set; }
    }
}
