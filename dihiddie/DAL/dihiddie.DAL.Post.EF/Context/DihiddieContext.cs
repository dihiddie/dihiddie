using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace dihiddie.DAL.Post.EF.Context
{
    public partial class DihiddieContext : DbContext
    {
        public DihiddieContext()
        {
        }

        public DihiddieContext(DbContextOptions<DihiddieContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Post> Post { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Post>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Content).IsRequired();

                entity.Property(e => e.CreateDateTime).HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.PreviewImagePath)
                    .IsRequired()
                    .HasMaxLength(260)
                    .IsUnicode(false);

                entity.Property(e => e.PreviewText)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateDateTime).HasColumnType("datetime");
            });
        }
    }
}
