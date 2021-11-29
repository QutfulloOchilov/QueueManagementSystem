using System.Collections.Generic;
using QueueManagementSystem.Domain.Interfaces;

namespace QueueManagementSystem.Application.Abstraction
{
    public interface IPagedList<T> where T : IEntity
    {
        int IndexFrom { get; }
        int PageIndex { get; }
        int PageSize { get; }
        int TotalCount { get; }
        int TotalPages { get; }
        IList<T> Items { get; }
        bool HasPreviousPage { get; }
        bool HasNextPage { get; }
    }
}