using Microsoft.EntityFrameworkCore;
using TodoApp.Entites;

namespace TodoApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        /// <summary>
        /// Todos tablosuna erişim sağlar
        /// </summary>
        public DbSet<Todo> Todos { get; set; }


        /// <summary>
        /// Veritabanı bağlantı seçeneklerini yapılandırır.
        /// </summary>
        /// <param name="optionsBuilder">DbContext yapılandırma seçeneklerini tutan nesne.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging(true);
        }

        /// <summary>
        /// Veritabanı modeli yapılandırılır. Entity özellikleri ve veri türleri burada tanımlanır.
        /// </summary>
        /// <param name="modelBuilder">Model oluşturucu nesnesi.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Todo>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            });
            base.OnModelCreating(modelBuilder);
        }

        /// <summary>
        /// Değişiklikleri kaydederken, kayıtlı kullanıcı bilgilerini izler.
        /// </summary>
        /// <returns>Kaydedilen değişiklik sayısı.</returns>
        public override int SaveChanges()
        {
            ApplyCreateAtInfo();
            return base.SaveChanges();
        }

        /// <summary>
        /// Değişiklikleri asenkron olarak kaydederken, kayıtlı kullanıcı bilgilerini izler.
        /// </summary>
        /// <param name="cancellationToken">İptal belirteci.</param>
        /// <returns>Kaydedilen değişiklik sayısı.</returns>
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            ApplyCreateAtInfo();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void ApplyCreateAtInfo()
        {
            foreach (var item in ChangeTracker.Entries().Where(x => x.State == EntityState.Added || x.State == EntityState.Modified))
            {
                if (item.Entity is BaseEntity baseEntity && item.State == EntityState.Added)
                {
                    baseEntity.CreatedAt = DateTime.UtcNow;
                }
            }
        }
    }
}
