using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QueueManagementSystem.Domain.Entities;

namespace QueueManagementSystem.Infrastructure.Persistence.TableConfigurations
{
	public class BusinessConfiguration : IEntityTypeConfiguration<Business>
	{
		public void Configure(EntityTypeBuilder<Business> builder)
		{
			builder.ToTable("Businesses");

			builder.HasKey(b => b.Id);

			builder.Property(b => b.Id).ValueGeneratedOnAdd();

		}
	}
}
