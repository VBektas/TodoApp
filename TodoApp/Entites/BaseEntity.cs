using System.ComponentModel.DataAnnotations;

namespace TodoApp.Entites
{
    public class BaseEntity
    {
        /// <summary>
        /// Benzersiz kimlik (Primary Key).
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Oluşturulma tarihi. Varsayılan olarak SaveChanges esnasında şu anki UTC zamanı atanır.
        /// </summary>
        public DateTime CreatedAt { get; set; }
    }
}
