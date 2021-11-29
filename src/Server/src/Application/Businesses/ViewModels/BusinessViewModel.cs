using QueueManagementSystem.Application.ViewModel;

namespace QueueManagementSystem.Application.Businesses.ViewModels
{
    public class BusinessViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public bool IsFeedbackAllowed { get; set; }
    }
}