using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoApp.Dtos.RequestDtos;
using TodoApp.Entites;
using TodoApp.Interfaces;

namespace TodoApp.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class TodosController : ControllerBase
    {
        private readonly ITodoService _todoService;

        public TodosController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        /// <summary>
        /// Tüm görevleri listeler.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var todos = await _todoService.GetAllAsync();
            return Ok(todos);
        }

        /// <summary>
        /// Yeni görev oluşturur.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TodoCreateRequestDto todoCreateRequestDto)
        {
            var created = await _todoService.CreateAsync(todoCreateRequestDto);
            return Ok(created);
        }

        /// <summary>
        /// ID’ye göre görevi siler.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _todoService.DeleteAsync(id);
            return Ok(result);
        }

        /// <summary>
        /// ID’ye göre görevi getirir.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _todoService.GetByIdAsync(id);
            return Ok(result);
        }
        /// <summary>
        /// ID’ye göre görevi getirir.
        /// </summary>
        [HttpGet("completed/{id}")]
        public async Task<IActionResult> SetCompleted(int id)
        {
            var result = await _todoService.SetCompletedAsync(id);
            return Ok(result);
        }
    }
}
