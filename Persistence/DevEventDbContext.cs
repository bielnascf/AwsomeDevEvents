using AwsomeDevEvents.Entity;
using Microsoft.EntityFrameworkCore;

namespace AwsomeDevEvents.Persistance
{
    public class DevEventDbContext : DbContext
    {
        public DevEventDbContext(DbContextOptions<DevEventDbContext> options) : base(options)
        {

        }

        public DbSet<DevEvent> DevEvents { get; set; }
        public DbSet<DevEventSpeaker> DevEventsSpeaker { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<DevEvent>(e =>
            {
                e.HasKey(de => de.Id);

                e.Property(de => de.Title).IsRequired(false);
                e.Property(de => de.Description).HasMaxLength(200).HasColumnType("varchar(200)");
                e.Property(de => de.StartDate).HasColumnName("Start_Date");
                e.Property(de => de.EndDate).HasColumnName("End_Date");
                e.HasMany(de => de.Speakers).WithOne().HasForeignKey(s => s.DevEventId);
            });

            builder.Entity<DevEventSpeaker>(e =>
            {
                e.HasKey(de => de.Id);
            });
        }
    }
}
