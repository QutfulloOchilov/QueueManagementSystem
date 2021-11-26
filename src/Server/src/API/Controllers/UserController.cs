using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QueueManagementSystem.Application.Users.QueryModels;
using QueueManagementSystem.Application.Users.QueryModels.Common;
using QueueManagementSystem.Application.Users.QueryModels.Insert;
using QueueManagementSystem.Application.Users.Services;
using QueueManagementSystem.Application.Users.ViewModels;
using QueueManagementSystem.Application.Workers.ViewModels;
using QueueManagementSystem.Domain.Entities;

namespace QueueManagementSystem.API.Controllers
{
    public class UserController : BaseController<User, UserViewModel, UserBaseQueryModel, IUserService>
    {
        public UserController(IUserService service) : base(service)
        {
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserViewModel>> GetById(Guid id)
        {
            return Ok(await GetEntityById(id));
        }

        [HttpGet("[action]/{userId}")]
        public async Task<ActionResult<IEnumerable<UserReservationViewModel>>> GetReservations(Guid userId)
        {
            return Ok(await Service.GetReservations(userId));
        }

        [HttpPost]
        public async Task<ActionResult<UserViewModel>> Create([FromBody] InsertUserQueryModel model)
        {
            return Ok(await base.Create(model));
        }

        [HttpPut]
        public async Task<ActionResult<UserViewModel>> Update([FromBody] UserQueryModel model)
        {
            return Ok(await base.Update(model));
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<UserReservationViewModel>> ReserveHaircut(
            [FromBody] ReserveHaircutQueryModel model)
        {
            return Ok(await Service.ReserveHaircut(model));
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> CancelReservation([FromBody] CancelReservationQueryModel model)
        {
            await Service.CancelReservation(model);
            return Ok();
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<FreeTimeViewModel>> GetFreeTime([FromBody] GetFreeTimeQueryModel model)
        {
            return Ok(await Service.GetFreeTime(model));
        }
    }
}