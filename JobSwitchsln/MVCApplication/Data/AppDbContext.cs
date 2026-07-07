using MVCApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace MVCApplication.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<InterviewRound> InterviewRounds { get; set; }

    public virtual DbSet<JobApplication> JobApplications { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Companie__3214EC071C408B35");

            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Industry).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(200);
            entity.Property(e => e.Website).HasMaxLength(300);
        });

        modelBuilder.Entity<InterviewRound>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Intervie__3214EC075E382812");

            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.InterviewerName).HasMaxLength(150);
            entity.Property(e => e.Result)
                .HasMaxLength(50)
                .HasDefaultValue("Pending");
            entity.Property(e => e.RoundName).HasMaxLength(150);
            entity.Property(e => e.ScheduledDate).HasColumnType("datetime");

            entity.HasOne(d => d.JobApplication).WithMany(p => p.InterviewRounds)
                .HasForeignKey(d => d.JobApplicationId)
                .HasConstraintName("FK_InterviewRounds_JobApplications");
        });

        modelBuilder.Entity<JobApplication>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__JobAppli__3214EC0713A814BA");

            entity.Property(e => e.AppliedDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.JobLink).HasMaxLength(500);
            entity.Property(e => e.RoleTitle).HasMaxLength(200);
            entity.Property(e => e.SalaryExpectation).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasDefaultValue("Applied");

            entity.HasOne(d => d.Company).WithMany(p => p.JobApplications)
                .HasForeignKey(d => d.CompanyId)
                .HasConstraintName("FK_JobApplications_Companies");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
