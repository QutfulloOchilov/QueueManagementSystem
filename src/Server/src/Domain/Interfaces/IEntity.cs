using System;

namespace QueueManagementSystem.Domain.Interfaces
{
    public interface IEntity
    {
        Guid Id { get; }
        string Title { get; }
    }
}