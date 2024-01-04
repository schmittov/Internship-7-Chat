using Chat.Data.Entities.Models;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Chat.Data.Seeds;

namespace Chat.Data.Entities
{
    public class InternshipChatDbContext : DbContext
    {
        
        public InternshipChatDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<GroupChat> GroupChats => Set<GroupChat>();
        public DbSet<User> Users => Set<User>();
        public DbSet<UserGroup> UserGroups => Set<UserGroup>();
        public DbSet<GroupMessage> GroupMessages => Set<GroupMessage>();
        public DbSet<PrivateMessage> PrivateMessages => Set<PrivateMessage>();


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserGroup>()
            .HasKey(ug => new { ug.UserId, ug.GroupChatId });

            modelBuilder.Entity<UserGroup>()
                .HasOne(ug => ug.User)
                .WithMany(u => u.UserGroups)
                .HasForeignKey(ug => ug.UserId);

            modelBuilder.Entity<UserGroup>()
                .HasOne(ug => ug.GroupChat)
                .WithMany(gc => gc.UserGroups)
                .HasForeignKey(ug => ug.GroupChatId);

            modelBuilder.Entity<PrivateMessage>()
                .HasOne(pm => pm.User)
                .WithMany(u => u.PrivateMessages)
                .HasForeignKey(pm => pm.IdSender);

            modelBuilder.Entity<GroupMessage>()
                .HasOne(gm => gm.GroupChat)
                .WithMany(gc => gc.GroupMessages)
                .HasForeignKey(gm => gm.GroupChatId);

            DatabaseSeeder.Seed(modelBuilder);
            base.OnModelCreating(modelBuilder);

        }
    }

    public class InternshipChatDbContextFactory : IDesignTimeDbContextFactory<InternshipChatDbContext>
    {
        public InternshipChatDbContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddXmlFile("Chat.config")
                .Build();

            config.Providers
                .First()
                .TryGet("connectionStrings:add:\"Server=localhost;Port=5432;Database=InternshipChatDB;User Id=postgres;Password=5283;\":connectionString", out var connectionString);

            var options = new DbContextOptionsBuilder<InternshipChatDbContext>()
                .UseNpgsql(connectionString)
                .Options;

            return new InternshipChatDbContext(options);
        }
    }

}
