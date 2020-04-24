using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Entities
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options) { }

        public DbSet<Player> Player { get; set; }
        public DbSet<SessionData> sessionData { get; set; }
        public DbSet<TopicData> TopicData { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SessionData>(table => {
                table.HasOne(s => s.topicData)
                    .WithOne(t => t.sessionData)
                    .HasForeignKey<SessionData>(s => s.session_code)
                    .HasPrincipalKey<TopicData>(t => t.sessionCode);
            });
        }
    }
}
