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

            builder.HasOne(w => w.Business)
                .WithMany(b => b.Workers)
                .HasForeignKey(w => w.BusinessId);

            builder.HasMany(w => w.Jobs)
                .WithMany(s => s.Workers)
                .UsingEntity<JobDetail>(j => j.HasOne(sd => sd.Job)
                        .WithMany(w => w.JobDetails)
                        .HasForeignKey(sd => sd.JobId),
                    j => j.HasOne(sd => sd.Worker)
                        .WithMany(s => s.JobDetails)
                        .HasForeignKey(sd => sd.WorkerId),
                    j =>
                    {
                        j.ToTable("JobDetails");
                        j.HasKey(sd => sd.Id);
                        j.Property(sd => sd.Id).ValueGeneratedOnAdd();
                        j.Ignore(sd => sd.IsActive);
                        j.Property(sd => sd.Price).HasColumnType("decimal(18,2)");
                    });
        }
    }
}