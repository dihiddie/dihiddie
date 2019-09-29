using System;
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

        public virtual DbSet<PostContent> PostContent { get; set; }
        public virtual DbSet<PostInformation> PostInformation { get; set; }
        public virtual DbSet<Tag> Tag { get; set; }
        public virtual DbSet<TagPostLink> TagPostLink { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<PostContent>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Content).IsRequired();
            });

            modelBuilder.Entity<PostInformation>(entity =>
            {
                entity.HasIndex(e => e.PostId)
                    .HasName("UQ__PostInfo__AA126019461B8588")
                    .IsUnique();

                entity.Property(e => e.CreateDateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PreviewText)
                    .HasMaxLength(500)
                    .IsUnicode(false);
                entity.Property(e => e.UpdateDateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(155)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TagPostLink>(entity =>
            {
                entity.HasOne(d => d.PostInformation)
                    .WithMany(p => p.TagPostLink)
                    .HasForeignKey(d => d.PostInformationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TagPostLi__PostI__6B24EA82");

                entity.HasOne(d => d.Tag)
                    .WithMany(p => p.TagPostLink)
                    .HasForeignKey(d => d.TagId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TagPostLi__TagId__6A30C649");
            });
        }
    }
}
