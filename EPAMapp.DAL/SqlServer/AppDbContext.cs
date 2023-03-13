using EPAMapp.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace EPAMapp.DAL.SqlServer
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Note> Notes { get; set; }

        public AppDbContext()
        {
            Database.EnsureCreated();
        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(client => client.Notes)
                .WithOne(order => order.User)
                .HasForeignKey(order => order.Id);

            modelBuilder.Entity<Admin>(builder =>
            {
                builder.HasData(new Admin
                {
                    Id = 1,
                    Name = "Admin",
                    Surname = "Admin",
                    NickName = "Daddy",
                    Email = "admin@admin.com",
                    Password = "1111"
                });
            });


            modelBuilder.Entity<Note>()
                .HasOne(order => order.User)
                .WithMany(client => client.Notes)
                .HasForeignKey(order => order.UserId)
                /*.OnDelete(DeleteBehavior.Cascade)*/;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configPath = Path.Combine("..", "EPAMapp.API", "appsettings.Development.json");
            dynamic config = JsonConvert.DeserializeObject(File.ReadAllText(configPath));

            JsonHolder.ConnectionString = config.ConnectionStrings.ConnectionString;

            optionsBuilder.UseSqlServer(JsonHolder.ConnectionString);
        }
    }
}
