using Microsoft.EntityFrameworkCore;

namespace FiveMessanger.Models
{
    public class FiveMessangerContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<File> Files { get; set; }
        public FiveMessangerContext(DbContextOptions<FiveMessangerContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(user => user.Created)
                .HasDefaultValueSql("now()");
            modelBuilder.Entity<User>()
                .Property(user => user.Role)
                .HasDefaultValue(User.Roles.Student);
            modelBuilder.Entity<User>()
                .HasIndex(User => User.Username)
                .IsUnique();

            modelBuilder.Entity<Message>()
                .Property(msg => msg.Created)
                .HasDefaultValueSql("now()");
        }
    }
}
