using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QueueManagementSystem.Domain.Entities;

namespace QueueManagementSystem.Infrastructure.Persistence.TableConfigurations
{
	public class WorkerScheduleConfiguration : IEntityTypeConfiguration<WorkerSchedule>
	{
		public void Configure(EntityTypeBuilder<WorkerSchedule> builder)
		{
			builder.ToTable("WorkerSchedules");

			builder.HasKey(ws => ws.Id);

			builder.Property(ws => ws.Id).ValueGeneratedOnAdd();

			builder.Ignore(ws => ws.IsActive);

			builder.HasOne(w => w.Worker)
				.WithMany(w => w.WorkerSchedules)
				.HasForeignKey(w => w.WorkerId)
				.IsRequired()
				.OnDelete(DeleteBehavior.Cascade);
		}
	}
}
