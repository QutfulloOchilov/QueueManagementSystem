using QueueManagementSystem.Application.WorkerSchedules.QueryModels.Common;
using QueueManagementSystem.Application.WorkerSchedules.ViewModels;
using QueueManagementSystem.Domain.Entities;

namespace QueueManagementSystem.Application.Mapper
{
    public class WorkerScheduleMapper : MappingProfile
    {
        public WorkerScheduleMapper()
        {
            BuildMap<WorkerSchedule, WorkerScheduleViewModel>();
            BuildMap<WorkerScheduleQueryModel, WorkerSchedule>();
        }
    }
}