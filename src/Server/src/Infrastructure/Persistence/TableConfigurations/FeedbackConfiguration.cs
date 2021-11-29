using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QueueManagementSystem.Domain.Entities;

namespace QueueManagementSystem.Infrastructure.Persistence.TableConfigurations
{
    public class FeedbackConfiguration : IEntityTypeConfiguration<Feedback>
    {
        public void Configure(EntityTypeBuilder<Feedback> builder)
        {
            builder.ToTable("Feedbacks");

            builder.HasKey(f => f.Id);

            builder.Property(f => f.Id).ValueGeneratedOnAdd();

            builder.Property(f => f.Comment);

            builder.Property(f => f.Star)
                .IsRequired();

            builder.Ignore(f => f.IsActive);

            builder.HasOne(f => f.Business)
                .WithMany(b => b.Feedbacks)
                .HasForeignKey(f => f.BusinessId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.HasOne(f => f.Worker)
                .WithMany(w => w.Feedbacks)
                .HasForeignKey(f => f.WorkerId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.HasOne(f => f.User)
                .WithMany(u => u.Feedbacks)
                .IsRequired()
                .HasForeignKey(f => f.UserId);
        }
    }
}