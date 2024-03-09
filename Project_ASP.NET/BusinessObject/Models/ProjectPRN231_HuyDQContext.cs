using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BusinessObject.Models
{
    public partial class ProjectPRN231_HuyDQContext : DbContext
    {
        public ProjectPRN231_HuyDQContext()
        {
        }

        public ProjectPRN231_HuyDQContext(DbContextOptions<ProjectPRN231_HuyDQContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<Feedback> Feedbacks { get; set; } = null!;
        public virtual DbSet<Question> Questions { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Subject> Subjects { get; set; } = null!;
        public virtual DbSet<SubjectAccount> SubjectAccounts { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server = MSI\\MAYAO; database = ProjectPRN231_HuyDQ;uid=sa;pwd=123456; TrustServerCertificate=True ");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("Account");

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.Avatar).HasMaxLength(50);

                entity.Property(e => e.FullName).HasMaxLength(50);

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .HasColumnName("password");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.StudentCode).HasMaxLength(50);

                entity.Property(e => e.TeacherCode).HasMaxLength(50);

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .HasColumnName("username");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_Account_Role");
            });

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.ToTable("Feedback");

                entity.Property(e => e.FeedbackId).HasColumnName("FeedbackID");

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.SubjectId).HasColumnName("SubjectID");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Feedbacks)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK_Feedback_Account");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Feedbacks)
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("FK_Feedback_Subject");
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.HasKey(e => e.QuenstionId);

                entity.ToTable("Question");

                entity.Property(e => e.QuenstionId).HasColumnName("QuenstionID");

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.AnswerDescription)
                    .HasMaxLength(500)
                    .HasColumnName("Answer_Description");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.ReplyDate).HasColumnType("datetime");

                entity.Property(e => e.SubjectId).HasColumnName("SubjectID");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK_Question_Account");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("FK_Question_Subject");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.RoleId)
                    .ValueGeneratedNever()
                    .HasColumnName("role_id");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(50)
                    .HasColumnName("role_name");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.ToTable("Subject");

                entity.Property(e => e.SubjectId).HasColumnName("SubjectID");

                entity.Property(e => e.SubjectCode).HasMaxLength(50);

                entity.Property(e => e.SubjectName).HasMaxLength(50);
            });

            modelBuilder.Entity<SubjectAccount>(entity =>
            {
                entity.ToTable("Subject_Account");

                entity.Property(e => e.SubjectAccountId).HasColumnName("Subject_Account_id");

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.SubjectId).HasColumnName("SubjectID");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.SubjectAccounts)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK_Subject_Account_Account");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.SubjectAccounts)
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("FK_Subject_Account_Subject");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
