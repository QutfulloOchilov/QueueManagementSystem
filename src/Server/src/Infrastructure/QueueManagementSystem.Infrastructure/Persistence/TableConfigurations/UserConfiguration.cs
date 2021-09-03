using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QueueManagementSystem.Domain.Entities;

namespace QueueManagementSystem.Infrastructure.Persistence.TableConfigurations
{
	public class UserConfiguration : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> builder)
		{
			builder.ToTable("Users");

			builder.HasKey(p => p.Id);

			builder.Property(p => p.Id).ValueGeneratedOnAdd();

			builder.Property(u => u.FirstName)
					.IsRequired();

			builder.Property(u => u.LastName)
					.IsRequired();

			builder.HasMany(u => u.JobDetails)
					.WithMany(w => w.Users)
					.UsingEntity<HaircutReservation>(j => j.HasOne(hr => hr.JobDetail)
														   .WithMany(sd => sd.HaircutReservations)
														   .HasForeignKey(hr => hr.JobDetailId),

													 j => j.HasOne(hr => hr.User)
															.WithMany(u => u.Reservations)
															.HasForeignKey(hr => hr.UserId),
													 j =>
													 {
														 j.ToTable("Reservations");
														 j.HasKey(hr => hr.Id);
														 j.Ignore(hr => hr.IsActive);
														 j.Property(hr => hr.Id).ValueGeneratedOnAdd();
													 });
		}
	}
}
