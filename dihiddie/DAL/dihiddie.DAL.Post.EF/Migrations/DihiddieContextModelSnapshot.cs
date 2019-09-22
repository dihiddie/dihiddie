﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using dihiddie.DAL.Post.EF.Context;

namespace dihiddie.DAL.Post.EF.Migrations
{
    [DbContext(typeof(DihiddieContext))]
    partial class DihiddieContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("dihiddie.DAL.Post.EF.Context.PostContent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("Content")
                        .IsRequired();

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("PostContent");
                });

            modelBuilder.Entity("dihiddie.DAL.Post.EF.Context.PostInformation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreateDateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<bool?>("IsBlogPost");

                    b.Property<bool>("IsDraft");

                    b.Property<int>("PostId");

                    b.Property<string>("PreviewImagePath")
                        .IsRequired()
                        .HasMaxLength(260)
                        .IsUnicode(false);

                    b.Property<string>("PreviewText")
                        .HasMaxLength(500)
                        .IsUnicode(false);

                    b.Property<DateTime?>("UpdateDateTime")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("PostId")
                        .IsUnique()
                        .HasName("UQ__PostInfo__AA126019461B8588");

                    b.ToTable("PostInformation");
                });

            modelBuilder.Entity("dihiddie.DAL.Post.EF.Context.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(155)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("Tag");
                });

            modelBuilder.Entity("dihiddie.DAL.Post.EF.Context.TagPostLink", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PostInformationId");

                    b.Property<int>("TagId");

                    b.HasKey("Id");

                    b.HasIndex("PostInformationId");

                    b.HasIndex("TagId");

                    b.ToTable("TagPostLink");
                });

            modelBuilder.Entity("dihiddie.DAL.Post.EF.Context.PostInformation", b =>
                {
                    b.HasOne("dihiddie.DAL.Post.EF.Context.PostContent", "Post")
                        .WithOne("PostInformation")
                        .HasForeignKey("dihiddie.DAL.Post.EF.Context.PostInformation", "PostId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("dihiddie.DAL.Post.EF.Context.TagPostLink", b =>
                {
                    b.HasOne("dihiddie.DAL.Post.EF.Context.PostInformation", "PostInformation")
                        .WithMany("TagPostLink")
                        .HasForeignKey("PostInformationId")
                        .HasConstraintName("FK__TagPostLi__PostI__6B24EA82");

                    b.HasOne("dihiddie.DAL.Post.EF.Context.Tag", "Tag")
                        .WithMany("TagPostLink")
                        .HasForeignKey("TagId")
                        .HasConstraintName("FK__TagPostLi__TagId__6A30C649");
                });
#pragma warning restore 612, 618
        }
    }
}
