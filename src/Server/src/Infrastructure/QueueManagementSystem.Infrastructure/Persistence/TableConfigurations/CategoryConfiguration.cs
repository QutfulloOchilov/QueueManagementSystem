using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QueueManagementSystem.Domain.Entities;

namespace QueueManagementSystem.Infrastructure.Persistence.TableConfigurations
{
	public class CategoryConfiguration : IEntityTypeConfiguration<Category>
	{
		public void Configure(EntityTypeBuilder<Category> builder)
		{
			builder.ToTable("Categories");

			builder.HasKey(c => c.Id);

			builder.Property(c => c.Id).ValueGeneratedOnAdd();

			builder.Property(c => c.Name)
					.IsRequired();

			builder.Ignore(c => c.Title);

			builder.HasMany(c => c.Jobs)
					.WithOne(j => j.Category)
					.HasForeignKey(j => j.CategoryId)
					.IsRequired();
		}
	}
}
