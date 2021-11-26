using QueueManagementSystem.Application.Persons;
using QueueManagementSystem.Application.Persons.ViewModels;
using QueueManagementSystem.Application.Services;
using QueueManagementSystem.Domain.Entities;

namespace QueueManagementSystem.Application.ViewModels.Persons.Services
{
    public interface IPersonService : IService<Person, PersonViewModel, PersonBaseQueryModel>
    {
    }
}