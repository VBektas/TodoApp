namespace TodoApp.Dtos.RequestDtos
{
    /// <summary>
    /// Yeni bir görev oluşturmak için kullanılan veri transfer nesnesi.
    /// </summary>
    public class TodoCreateRequestDto
    {
        /// <summary>
        /// Görev başlığı.
        /// </summary>
        public string Title { get; set; }
    }
}
