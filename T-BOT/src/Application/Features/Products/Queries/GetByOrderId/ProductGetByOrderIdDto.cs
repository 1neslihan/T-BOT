namespace Application.Features.Products.Queries.GetAll
{
    public class ProductGetByOrderIdDto
    {
        public ProductGetByOrderIdDto(Guid id, Guid orderId, string name, string picture, string storeName, decimal price, bool isDeleted)
        {
            Id=id;
            OrderId=orderId;
            Name=name;
            StoreName=storeName;
            Picture=picture;
            Price=price;
            IsDeleted=isDeleted;
        }

        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public string Name { get; set; }
        public string StoreName { get; set; }
        public string Picture { get; set; }
        public decimal Price { get; set; }
        public bool IsDeleted { get; set; }
    }
}
