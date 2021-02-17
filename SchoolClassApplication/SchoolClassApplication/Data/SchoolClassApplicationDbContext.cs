﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SchoolClassApplication.Entities;

#nullable disable

namespace SchoolClassApplication.Data
{
    public partial class SchoolClassApplicationDbContext : DbContext
    {
        public SchoolClassApplicationDbContext()
        {
        }

        public SchoolClassApplicationDbContext(DbContextOptions<SchoolClassApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<SchoolClass> SchoolClasses { get; set; }
        public virtual DbSet<SchoolClassCourse> SchoolClassCourses { get; set; }
        public virtual DbSet<SchoolClassStudent> SchoolClassStudents { get; set; }
        public virtual DbSet<SchoolCourse> SchoolCourses { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<SchoolClass>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ClassName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Created).HasColumnType("date");

                entity.Property(e => e.TeacherId).HasMaxLength(450);
            });

            modelBuilder.Entity<SchoolClassCourse>(entity =>
            {
                entity.HasKey(e => new { e.SchoolClassId, e.SchoolCourseId })
                    .HasName("PK__SchoolCl__EDA3F0A3C42C513C");

                entity.Property(e => e.TeacherId).HasMaxLength(450);

                entity.HasOne(d => d.SchoolClass)
                    .WithMany(p => p.SchoolClassCourses)
                    .HasForeignKey(d => d.SchoolClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SchoolCla__Schoo__2A4B4B5E");

                entity.HasOne(d => d.SchoolCourse)
                    .WithMany(p => p.SchoolClassCourses)
                    .HasForeignKey(d => d.SchoolCourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SchoolCla__Schoo__2B3F6F97");
            });

            modelBuilder.Entity<SchoolClassStudent>(entity =>
            {
                entity.HasKey(e => e.StudentId)
                    .HasName("PK__SchoolCl__32C52B9908530D26");

                entity.HasOne(d => d.SchoolClass)
                    .WithMany(p => p.SchoolClassStudents)
                    .HasForeignKey(d => d.SchoolClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SchoolCla__Schoo__276EDEB3");
            });

            modelBuilder.Entity<SchoolCourse>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CourseName)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
