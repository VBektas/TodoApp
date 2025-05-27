using Microsoft.EntityFrameworkCore;
using TodoApp.Data;
using TodoApp.Dtos.RequestDtos;
using TodoApp.Dtos.ResponseDtos;
using TodoApp.Entites;
using TodoApp.Interfaces;

namespace TodoApp.Services
{
    public class TodoService : ITodoService
    {
        private readonly AppDbContext _appDbContext;

        public TodoService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        /// <summary>
        /// Yeni görev oluşturur.
        /// </summary>
        public async Task<bool> CreateAsync(TodoCreateRequestDto todoCreateRequestDto)
        {
            await _appDbContext.Todos.AddAsync(new Todo
            {
                Title = todoCreateRequestDto.Title,
            });
            await _appDbContext.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Belirtilen ID'ye göre görevi siler.
        /// </summary>
        public async Task<bool> DeleteAsync(int id)
        {
            if (!await _appDbContext.Todos.AnyAsync(x => x.Id == id))
                return false;

            var todo = await _appDbContext.Todos.Where(x => x.Id == id).FirstOrDefaultAsync();

            _appDbContext.Todos.Remove(todo);
            await _appDbContext.SaveChangesAsync();

            return true;
        }

        /// <summary>
        /// Tüm görevleri getirir.
        /// </summary>
        public async Task<List<TodoResponseDto>> GetAllAsync()
        {
            return await _appDbContext.Todos
                .Select(x => new TodoResponseDto
                {
                    Id = x.Id,
                    Title = x.Title,
                    IsCompleted = x.IsCompleted,
                    CreatedAt = x.CreatedAt,
                })
                .ToListAsync();
        }

        /// <summary>
        /// Belirtilen ID'ye göre görevi getirir.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TodoResponseDto> GetByIdAsync(int id)
        {
            if (!await _appDbContext.Todos.AnyAsync(x => x.Id == id))
                return new TodoResponseDto();

            return await _appDbContext.Todos
                .Select(x => new TodoResponseDto
                {
                    Id = x.Id,
                    Title = x.Title,
                    IsCompleted = x.IsCompleted,
                    CreatedAt = x.CreatedAt,
                })
                .FirstOrDefaultAsync();
        }

        /// <summary>
        /// Belirtilen ID'ye göre görevi Completed olarak işaretler.
        /// </summary>
        public async Task<bool> SetCompletedAsync(int id)
        {
            if (!await _appDbContext.Todos.AnyAsync(x => x.Id == id))
                return false;

            var todo = await _appDbContext.Todos.Where(x => x.Id == id).FirstOrDefaultAsync();
            todo.IsCompleted = true;

            await _appDbContext.SaveChangesAsync();
            return true;
        }
    }
}
