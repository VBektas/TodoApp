namespace TodoApp.Dtos.ResponseDtos
{
    /// <summary>
    /// Dış dünyaya gönderilen görev bilgilerini temsil eden DTO.
    /// </summary>
    public class TodoResponseDto
    {
        /// <summary>
        /// Görevin benzersiz kimliği.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Görev başlığı.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Görev tamamlandı mı?
        /// </summary>
        public bool IsCompleted { get; set; }

        /// <summary>
        /// Görev oluşturulma tarihi (UTC).
        /// </summary>
        public DateTime CreatedAt { get; set; }
    }
}
