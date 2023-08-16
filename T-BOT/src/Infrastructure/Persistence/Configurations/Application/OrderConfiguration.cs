using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations.Application
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            //Id
            builder.HasKey(x => x.Id);


            //Requested Amount
            builder.Property(x => x.RequestedAmount)
                .IsRequired();

            //Categories
            builder.Property(x => x.Category)
                .HasConversion<string>();

            //Common Fields

            //CreatedOn
            builder.Property(x => x.CreatedOn)
                .IsRequired()
                .ValueGeneratedOnAdd();

            // CreatedByUserId
            builder.Property(x => x.CreatedByUserId)
                .IsRequired(false)
                .HasMaxLength(100);

            //ModifiedOn
            builder.Property(x => x.ModifiedOn).IsRequired(false);

            // ModifiedByUserId
            builder.Property(x => x.ModifiedByUserId)
                .IsRequired(false)
                .HasMaxLength(100);

            //DeletedOn
            builder.Property(x => x.DeletedOn).IsRequired(false);

            //DeletedByUserId
            builder.Property(x => x.DeletedByUserId)
                .IsRequired(false)
                .HasMaxLength(100);

            //IsDeleted
            builder.Property(x => x.IsDeleted)
                .IsRequired()
                .HasDefaultValueSql("0");
            builder.HasIndex(x => x.IsDeleted);

            //Relationships
            //builder.HasOne<User>(x => x.User)
            //    .WithMany(x => x.Orders)
            //    .HasForeignKey(x => x.UserId)
            //    .IsRequired()
            //    .OnDelete(DeleteBehavior.Cascade);


            builder.HasMany<Product>(x => x.Products)
                .WithOne(x => x.Order)
                .HasForeignKey(x => x.OrderId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade); ;

            builder.HasMany<OrderEvent>(x => x.OrderEvents)
                .WithOne(x => x.Order)
                .HasForeignKey(x => x.OrderId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade); ;

            builder.ToTable("Orders");
        }
    }
}
