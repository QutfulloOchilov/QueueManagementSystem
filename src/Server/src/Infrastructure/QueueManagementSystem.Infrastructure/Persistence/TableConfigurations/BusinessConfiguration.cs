using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QueueManagementSystem.Domain.Entities;
using System;

namespace QueueManagementSystem.Infrastructure.Persistence.TableConfigurations
{
	public class BusinessConfiguration : IEntityTypeConfiguration<Business>
	{
		public void Configure(EntityTypeBuilder<Business> builder)
		{
			builder.ToTable("Businesses");

			builder.HasKey(b => b.Id);

			builder.Property(b => b.Id).ValueGeneratedOnAdd();

			builder.HasMany(b => b.Workers)
					.WithOne(w => w.Business)
					.HasForeignKey(b => b.BusinessId);
		}
	}
}
