using QueueManagementSystem.Application.ViewModel;
using System.Collections.Generic;

namespace QueueManagementSystem.Application.ViewModels
{
    public class PagedListViewModel<TViewModel> where TViewModel : BaseViewModel
    {
        public int IndexFrom { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
        public IEnumerable<TViewModel> Items { get; set; }
        public bool HasPreviousPage { get; set; }
        public bool HasNextPage { get; set; }
    }
}
