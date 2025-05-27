using TodoApp.Dtos.RequestDtos;
using TodoApp.Dtos.ResponseDtos;
using TodoApp.Entites;

namespace TodoApp.Interfaces
{
    /// <summary>
    /// Todo işlemleri için servis arayüzü.
    /// </summary>
    public interface ITodoService
    {
        /// <summary>
        /// Tüm görevleri getirir.
        /// </summary>
        Task<List<TodoResponseDto>> GetAllAsync();
        /// <summary>
        /// Belirtilen ID'ye göre görevi getirir.
        /// </summary>
        Task<TodoResponseDto> GetByIdAsync(int id);
        /// <summary>
        /// Yeni görev oluşturur.
        /// </summary>
        Task<bool> CreateAsync(TodoCreateRequestDto todoCreateRequestDto);
        /// <summary>
        /// Belirtilen ID'ye göre görevi siler.
        /// </summary>
        Task<bool> DeleteAsync(int id);
        /// <summary>
        /// Belirtilen ID'ye göre görevi Completed olarak işaretler.
        /// </summary>
        Task<bool> SetCompletedAsync(int id);
    }
}
