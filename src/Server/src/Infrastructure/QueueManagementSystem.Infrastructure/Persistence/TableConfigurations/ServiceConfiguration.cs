using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QueueManagementSystem.Domain.Entities;

namespace QueueManagementSystem.Infrastructure.Persistence.TableConfigurations
{
	public class ServiceConfiguration : IEntityTypeConfiguration<Service>
	{
		public void Configure(EntityTypeBuilder<Service> builder)
		{
			builder.ToTable("Services");

			builder.HasKey(s => s.Id);

			builder.Property(s => s.Id).ValueGeneratedOnAdd();

			builder.Property(s => s.Name)
					.IsRequired();

			builder.Ignore(s => s.IsActive);
		}
	}
}
