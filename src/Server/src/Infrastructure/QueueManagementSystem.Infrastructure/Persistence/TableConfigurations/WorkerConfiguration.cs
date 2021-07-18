using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QueueManagementSystem.Domain.Entities;

namespace QueueManagementSystem.Infrastructure.Persistence.TableConfigurations
{
	public class WorkerConfiguration : IEntityTypeConfiguration<Worker>
	{
		public void Configure(EntityTypeBuilder<Worker> builder)
		{
			builder.ToTable("Workers");

			builder.HasKey(w => w.Id);

			builder.Property(w => w.Id).ValueGeneratedOnAdd();

			builder.Property(w => w.FirstName)
					.IsRequired();

			builder.Property(w => w.LastName)
					.IsRequired();

			builder.Property(w => w.PhoneNumber)
					.IsRequired();

			builder.Property(w => w.Email)
					.IsRequired();

			builder.HasMany(w => w.Services)
					.WithMany(s => s.Workers)
					.UsingEntity<ServiceDetails>(j => j.HasOne(sd => sd.Service)
													  .WithMany(w => w.ServiceDetails)
													  .HasForeignKey(sd => sd.ServiceId),

												j => j.HasOne(sd => sd.Worker)
														.WithMany(s => s.ServiceDetails)
														.HasForeignKey(sd => sd.WorkerId),

												j =>
												{
													j.ToTable("ServiceDetails");
													j.HasKey(sd => sd.Id);
													j.Property(sd => sd.Id).ValueGeneratedOnAdd();
													j.Ignore(sd => sd.IsActive);
													j.Property(sd => sd.Price).HasColumnType("decimal(18,2)");
												});
		}
	}
}
