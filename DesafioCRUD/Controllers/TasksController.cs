using DesafioCRUD.Dominio.Dominio;
using DesafioCRUD.DTO.Tasks;
using DesafioCRUD.Service.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace DesafioCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly TaskItemService _taskService;

        public TasksController(TaskItemService taskService)
        {
            _taskService = taskService;
        }

        // GET: api/tasks
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tasks = await _taskService.ListarTasksAsync();

            var dtos = tasks.Select(t => new TaskDto(
                t.Id,
                t.LeadId,
                t.Title,
                t.DueDate,
                t.Status,
                t.CreatedAt,
                t.UpdatedAt
            ));

            return Ok(dtos);
        }

        // GET: api/tasks/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var task = await _taskService.BuscarTaskPorIdAsync(id);
            if (task == null) return NotFound();

            var dto = new TaskDto(
                task.Id,
                task.LeadId,
                task.Title,
                task.DueDate,
                task.Status,
                task.CreatedAt,
                task.UpdatedAt
            );

            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TaskCreateDto dto)
        {
            var task = new TaskItem
            {
                Title = dto.Title,
                DueDate = dto.DueDate,
                Status =  DesafioCRUD.Dominio.Dominio.TaskStatus.Todo
,                // usa o SEU enum
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            await _taskService.CriarTaskAsync(task);
            return Ok();
        }



        // PUT: api/tasks/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TaskUpdateDto dto)
        {
            var task = await _taskService.BuscarTaskPorIdAsync(id);
            if (task == null) return NotFound();

            task.Title = dto.Title;
            task.DueDate = dto.DueDate;
            task.Status = (DesafioCRUD.Dominio.Dominio.TaskStatus)dto.Status; // usa o SEU enum
            task.UpdatedAt = DateTime.UtcNow;

            await _taskService.AtualizarTaskAsync(task);
            return Ok();
        }


        // DELETE: api/tasks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _taskService.RemoverTaskAsync(id);
            return Ok();
        }


    }
}
