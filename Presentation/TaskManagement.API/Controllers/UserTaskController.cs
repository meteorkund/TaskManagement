using Microsoft.AspNetCore.Mvc;
using System.Net;
using TaskManagement.Application.Repositories.UserTaskRepositories;
using TaskManagement.Domain.Entities;

namespace TaskManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserTaskController : Controller
    {
        readonly IUserTaskReadRepository _userTaskReadRepository;
        readonly IUserTaskWriteRepository _userTaskWriteRepository;

        public UserTaskController(IUserTaskReadRepository userTaskReadRepository, IUserTaskWriteRepository userTaskWriteRepository)
        {
            _userTaskReadRepository = userTaskReadRepository;
            _userTaskWriteRepository = userTaskWriteRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            IQueryable<UserTask> userTask =  _userTaskReadRepository.GetAll(false);
            return Ok(userTask);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            UserTask userTask = await _userTaskReadRepository.GetByIdAsync(id, false);
            return Ok(userTask);
        }

        [HttpPost]
        public async Task<IActionResult> Post(UserTask model)
        {
            if (ModelState.IsValid)
            {
                await _userTaskWriteRepository.AddAsync(new()
                {
                    Description = model.Description,
                });
                await _userTaskWriteRepository.SaveAsync();
                return StatusCode((int)HttpStatusCode.Created);
            }
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put(UserTask model)
        {

            UserTask userTask = await _userTaskReadRepository.GetByIdAsync(model.Id.ToString());
            userTask.Description = model.Description;
            await _userTaskWriteRepository.SaveAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _userTaskWriteRepository.RemoveAsync(id);
            await _userTaskWriteRepository.SaveAsync();
            return Ok();
        }
    }
}
