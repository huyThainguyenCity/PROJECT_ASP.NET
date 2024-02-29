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
        public virtual DbSet<Answer> Answers { get; set; } = null!;
        public virtual DbSet<Question> Questions { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<Subject> Subjects { get; set; } = null!;
        public virtual DbSet<SubjectAnswer> SubjectAnswers { get; set; } = null!;
        public virtual DbSet<SubjectQuestion> SubjectQuestions { get; set; } = null!;
        public virtual DbSet<SubjectStudent> SubjectStudents { get; set; } = null!;
        public virtual DbSet<SubjectTeacher> SubjectTeachers { get; set; } = null!;
        public virtual DbSet<Teacher> Teachers { get; set; } = null!;

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

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .HasColumnName("password");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .HasColumnName("username");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_Account_Role");
            });

            modelBuilder.Entity<Answer>(entity =>
            {
                entity.ToTable("Answer");

                entity.Property(e => e.AnswerId).HasColumnName("AnswerID");

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.QuestionId).HasColumnName("QuestionID");

                entity.Property(e => e.ReplyDate).HasColumnType("datetime");

                entity.Property(e => e.SubjectId).HasColumnName("SubjectID");

                entity.Property(e => e.TeacherId).HasColumnName("TeacherID");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.Answers)
                    .HasForeignKey(d => d.QuestionId)
                    .HasConstraintName("FK_Answer_Question");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.Answers)
                    .HasForeignKey(d => d.TeacherId)
                    .HasConstraintName("FK_Answer_Teacher");
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.HasKey(e => e.QuenstionId);

                entity.ToTable("Question");

                entity.Property(e => e.QuenstionId).HasColumnName("QuenstionID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.Property(e => e.SubjectId).HasColumnName("SubjectID");
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

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.Property(e => e.AccountId).HasColumnName("Account_id");

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.Avatar).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.FullName).HasMaxLength(50);

                entity.Property(e => e.StudentCode).HasMaxLength(50);

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK_Student_Account");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.ToTable("Subject");

                entity.Property(e => e.SubjectId).HasColumnName("SubjectID");

                entity.Property(e => e.SubjectName).HasMaxLength(50);
            });

            modelBuilder.Entity<SubjectAnswer>(entity =>
            {
                entity.ToTable("Subject_Answer");

                entity.Property(e => e.SubjectAnswerId).HasColumnName("Subject_Answer_id");

                entity.Property(e => e.AnswerId).HasColumnName("Answer_id");

                entity.Property(e => e.SubjectId).HasColumnName("Subject_id");

                entity.HasOne(d => d.Answer)
                    .WithMany(p => p.SubjectAnswers)
                    .HasForeignKey(d => d.AnswerId)
                    .HasConstraintName("FK_Subject_Answer_Subject");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.SubjectAnswers)
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("FK_Subject_Answer_Answer");
            });

            modelBuilder.Entity<SubjectQuestion>(entity =>
            {
                entity.ToTable("Subject_Question");

                entity.Property(e => e.SubjectQuestionId)
                    .ValueGeneratedNever()
                    .HasColumnName("Subject_Question_id");

                entity.Property(e => e.QuestionId).HasColumnName("Question_id");

                entity.Property(e => e.SubjectId).HasColumnName("Subject_id");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.SubjectQuestions)
                    .HasForeignKey(d => d.QuestionId)
                    .HasConstraintName("FK_Subject_Question_Question");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.SubjectQuestions)
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("FK_Subject_Question_Subject");
            });

            modelBuilder.Entity<SubjectStudent>(entity =>
            {
                entity.HasKey(e => e.SubjectStudent1);

                entity.ToTable("Subject_Student");

                entity.Property(e => e.SubjectStudent1)
                    .ValueGeneratedNever()
                    .HasColumnName("Subject_Student");

                entity.Property(e => e.StudentId).HasColumnName("Student_id");

                entity.Property(e => e.SubjectId).HasColumnName("Subject_id");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.SubjectStudents)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK_Subject_Student_Student");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.SubjectStudents)
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("FK_Subject_Student_Subject");
            });

            modelBuilder.Entity<SubjectTeacher>(entity =>
            {
                entity.ToTable("Subject_Teacher");

                entity.Property(e => e.SubjectTeacherId)
                    .ValueGeneratedNever()
                    .HasColumnName("Subject_Teacher_id");

                entity.Property(e => e.SubjectId).HasColumnName("Subject_id");

                entity.Property(e => e.TeacherId).HasColumnName("Teacher_id");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.SubjectTeachers)
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("FK_Subject_Teacher_Subject");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.SubjectTeachers)
                    .HasForeignKey(d => d.TeacherId)
                    .HasConstraintName("FK_Subject_Teacher_Teacher");
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.ToTable("Teacher");

                entity.Property(e => e.TeacherId).HasColumnName("TeacherID");

                entity.Property(e => e.AccountId).HasColumnName("Account_id");

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.Avatar).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.FullName).HasMaxLength(50);

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Teachers)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK_Teacher_Account");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
