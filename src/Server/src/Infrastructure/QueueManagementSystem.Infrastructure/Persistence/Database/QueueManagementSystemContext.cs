using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Infrastructure.Internal;
using Microsoft.Extensions.Configuration;
using QueueManagementSystem.Application.Abstraction;
using QueueManagementSystem.Domain.Entities;
using QueueManagementSystem.Domain.Interfaces;
using QueueManagementSystem.Infrastructure.Persistence.TableConfigurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace QueueManagementSystem.Infrastructure.Persistence.Database
{
	public class QueueManagementSystemContext : DbContext, IContext
	{
		public QueueManagementSystemContext(DbContextOptions<QueueManagementSystemContext> dbContextOptions)
			: base(dbContextOptions)
		{
			OptionBuilder = dbContextOptions;
		}

		public QueueManagementSystemContext() { }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			var extension = optionsBuilder.Options.FindExtension<SqlServerOptionsExtension>();
			IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory).AddJsonFile("appsettings.json").Build();
			string connectionString = configuration["ConnectionStrings:sqlServer"];
			if (extension != null)
				connectionString = extension.ConnectionString;

			optionsBuilder.UseLazyLoadingProxies();
			optionsBuilder.UseSqlServer(connectionString);
		}


		public DbContextOptions OptionBuilder { get; }

		public override int SaveChanges()
		{
			return base.SaveChanges();
		}

		public Guid Id { get; set; }
		public int? CommandTimeout
		{
			get => this.Database.GetCommandTimeout();
			set => this.Database.SetCommandTimeout(value);
		}

		/// <summary>
		/// Add new entity to context
		/// </summary>
		public void AddToContext<T>(T entity) where T : IEntity
		{
			Entry(entity as EntityBase).State = EntityState.Added;
		}

		/// <summary>
		/// Change a state of entity to deleted
		/// </summary>
		public void MarkDelete<T>(T entity) where T : IEntity
		{
			var entityBase = entity as EntityBase;
			if (ChangeTracker.Entries().FirstOrDefault(e =>
			{
				return e.Entity is EntityBase serverEntityBase && serverEntityBase.Id == entityBase.Id;
			})?.State == EntityState.Deleted)
			{
				throw new Exception("BaseStatus of serverEntity already is deleted");
			}
			Entry(entityBase).State = EntityState.Deleted;
		}

		/// <summary>
		/// Get entities from context
		/// </summary>
		public new IQueryable<T> Set<T>() where T : class, IEntity
		{
			return base.Set<T>();
		}

		/// <summary>
		/// Get entity by guid
		/// </summary>
		public T GetById<T>(Guid guid) where T : class, IEntity
		{
			return this.Find<T>(guid);
		}

		/// <summary>
		/// Get entity by guid
		/// </summary>
		public Task<T> GetByIdAsync<T>(Guid id, CancellationToken cancellationToken = default) where T : class, IEntity
		{
			return this.FindAsync<T>(new object[] { id }, cancellationToken).AsTask();
		}

		/// <summary>
		/// Update en entity
		/// </summary>
		public void Update<T>(Guid id, T entity) where T : class, IEntity
		{
			var oldEntity = Find<T>(id);
			Entry(oldEntity).CurrentValues.SetValues(entity);
		}

		/// <summary>
		/// Delete entity from context
		/// </summary>
		public void Delete<T>(T entity) where T : class, IEntity
		{
			this.Remove(entity);
		}

		public bool HasChange()
		{
			return ChangeTracker.HasChanges();
		}

		public void UndoChanges()
		{
			RollBack();
		}

		void RollBack()
		{
			var changedEntries = ChangeTracker.Entries()
				.Where(x => x.State != EntityState.Unchanged).ToList();

			foreach (var entry in changedEntries)
			{
				switch (entry.State)
				{
					case EntityState.Modified:
						entry.CurrentValues.SetValues(entry.OriginalValues);
						entry.State = EntityState.Unchanged;
						break;
					case EntityState.Added:
						entry.State = EntityState.Detached;
						break;
					case EntityState.Deleted:
						entry.State = EntityState.Unchanged;
						break;
				}
			}
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Ignore<EntityBase>();
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserConfiguration).Assembly);
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(WorkerConfiguration).Assembly);
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(BusinessConfiguration).Assembly);
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(WorkerScheduleConfiguration).Assembly);
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(FeedbackConfiguration).Assembly);
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(JobConfiguration).Assembly);

		}

		[Obsolete]
		public int ExecuteSqlCommand(string sql, params object[] parameters)
		{
			//TODO: Shazod should research how use ExecuteSqlCommandAsync into ef core 5
			//return this.Database.ExecuteSqlCommand(sql, parameters);
			return this.Database.ExecuteSqlRaw(sql, parameters);
		}

		[Obsolete]
		public async Task<int> ExecuteSqlCommandAsync(string sql, params object[] parameters)
		{
			//TODO: Shazod should research how use ExecuteSqlCommandAsync into ef core 5
			//return this.Database.ExecuteSqlCommandAsync(sql, parameters);
			return await this.Database.ExecuteSqlRawAsync(sql, parameters);
		}

		public void RemoveRange(IEnumerable<IEntity> entities)
		{
			base.RemoveRange(entities);
		}

		public void UpdateRange(IEnumerable<IEntity> entities)
		{
			base.UpdateRange(entities);
		}

		public Task AddRangeAsync(IEnumerable<IEntity> entities, CancellationToken cancellationToken = default)
		{
			return base.AddRangeAsync(entities, cancellationToken);
		}

		public void AddRange(IEnumerable<IEntity> entities)
		{
			base.AddRange(entities);
		}

		public void Add(IEntity entity)
		{
			base.Add(entity);
		}

		public Task AddAsync(IEntity entity)
		{
			return base.AddAsync(entity).AsTask();
		}

		public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
		{
			return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
		}

		public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
		{
			return base.SaveChangesAsync(cancellationToken);
		}

		public override void Dispose()
		{
			base.Dispose();
		}

		public override ValueTask DisposeAsync()
		{
			return base.DisposeAsync();
		}
	}
}
