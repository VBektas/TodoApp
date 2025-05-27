using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace TodoApp.Entites
{
    /// <summary>
    /// Bir yapılacak görevini temsil eder.
    /// </summary>
    public class Todo : BaseEntity
    {
        /// <summary>
        /// Görevin başlığı
        /// </summary>
        [MaxLength(255)]
        public string Title { get; set; }
        /// <summary>
        /// Görevin tamamlanıp tamamlanmadığını belirtir.
        /// </summary>
        public bool IsCompleted { get; set; }
    }
}
