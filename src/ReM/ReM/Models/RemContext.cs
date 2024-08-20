using System.Configuration;
using Microsoft.EntityFrameworkCore;

namespace ReM.Models;

public partial class RemContext : DbContext
{
    public RemContext()
    {
    }

    public RemContext(DbContextOptions<RemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<HistoricRequest> HistoricRequests { get; set; }

    public virtual DbSet<HistoricRequirement> HistoricRequirements { get; set; }

    public virtual DbSet<Release> Releases { get; set; }

    public virtual DbSet<Request> Requests { get; set; }

    public virtual DbSet<Requirement> Requirements { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // To protect potentially sensitive information in your connection string,
    // you should move it out of source code.You can avoid scaffolding the connection string
    // by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148.
    // For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL(ConfigurationManager.ConnectionStrings["ReM"].ConnectionString);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<HistoricRequest>(entity =>
        {
            entity.HasKey(e => new { e.RequestId, e.RequestVersion }).HasName("PRIMARY");

            entity.ToTable("historic_requests");

            entity.HasIndex(e => e.UserIdEditing, "FK_HISTORIC_EDITING_REQUEST");

            entity.HasIndex(e => e.UserIdApproval, "FK_HISTORIC_APPROVAL_REQUEST");

            entity.HasIndex(e => e.ReleaseId, "FK_RELEASE_REQUESTS");

            entity.Property(e => e.Body)
                .HasColumnType("mediumblob")
                .HasColumnName("body");
            entity.Property(e => e.Description)
                .HasMaxLength(300)
                .HasDefaultValueSql("''")
                .HasColumnName("description");
            entity.Property(e => e.IsActive)
                .HasMaxLength(1)
                .HasDefaultValueSql("'N'")
                .IsFixedLength()
                .HasColumnName("isActive");
            entity.Property(e => e.TimeApproval)
                .HasColumnType("datetime")
                .HasColumnName("timeApproval");
            entity.Property(e => e.TimeEditing)
                .HasColumnType("datetime")
                .HasColumnName("timeEditing");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .HasColumnName("title");
            entity.Property(e => e.Type)
                .HasColumnType("enum('bug','functionality')")
                .HasColumnName("type");

            entity.HasOne(d => d.Release).WithMany(p => p.HistoricRequests)
                .HasForeignKey(d => d.ReleaseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RELEASE_REQUESTS");

            entity.HasOne(d => d.Request).WithMany(p => p.HistoricRequests)
                .HasForeignKey(d => d.RequestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ORIGINAL_REQUEST");

            entity.HasOne(d => d.UserIdEditingNavigation).WithMany(p => p.HistoricRequestUserIdEditingNavigations)
                .HasForeignKey(d => d.UserIdEditing)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HISTORIC_EDITING_REQUEST");

            entity.HasOne(d => d.UserIdApprovalNavigation).WithMany(p => p.HistoricRequestUserIdApprovalNavigations)
                .HasForeignKey(d => d.UserIdApproval)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HISTORIC_APPROVAL_REQUEST");
        });

        modelBuilder.Entity<HistoricRequirement>(entity =>
        {
            entity.HasKey(e => new { e.RequirementId, e.RequirementVersion }).HasName("PRIMARY");

            entity.ToTable("historic_requirements");

            entity.HasIndex(e => new { e.RequestId, e.RequestVersion }, "FK_HISTORIC_DEVELOPMENT");

            entity.HasIndex(e => e.UserIdEditing, "FK_HISTORIC_EDITING_REQUIREMENT");

            entity.HasIndex(e => new { e.ParentRequirementId, e.ParentRequirementVersion }, "FK_HISTORIC_KINSHIP");

            entity.HasIndex(e => e.ReleaseId, "FK_RELEASE_REQUIREMENTS");

            entity.Property(e => e.Body)
                .HasColumnType("mediumblob")
                .HasColumnName("body");
            entity.Property(e => e.Description)
                .HasMaxLength(300)
                .HasDefaultValueSql("''")
                .HasColumnName("description");
            entity.Property(e => e.EstimatedHours).HasColumnName("estimatedHours");
            entity.Property(e => e.IsActive)
                .HasMaxLength(1)
                .HasDefaultValueSql("'N'")
                .IsFixedLength()
                .HasColumnName("isActive");
            entity.Property(e => e.TakenHours).HasColumnName("takenHours");
            entity.Property(e => e.TimeEditing)
                .HasColumnType("datetime")
                .HasColumnName("timeEditing");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .HasColumnName("title");
            entity.Property(e => e.Type)
                .HasColumnType("enum('functional','non-functional')")
                .HasColumnName("type");

            entity.HasOne(d => d.Release).WithMany(p => p.HistoricRequirements)
                .HasForeignKey(d => d.ReleaseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RELEASE_REQUIREMENTS");

            entity.HasOne(d => d.Requirement).WithMany(p => p.HistoricRequirements)
                .HasForeignKey(d => d.RequirementId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ORIGINAL_REQUIREMENT");

            entity.HasOne(d => d.UserIdEditingNavigation).WithMany(p => p.HistoricRequirements)
                .HasForeignKey(d => d.UserIdEditing)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HISTORIC_EDITING_REQUIREMENT");

            entity.HasOne(d => d.HistoricRequirementNavigation).WithMany(p => p.InverseHistoricRequirementNavigation)
                .HasForeignKey(d => new { d.ParentRequirementId, d.ParentRequirementVersion })
                .HasConstraintName("FK_HISTORIC_KINSHIP");

            entity.HasOne(d => d.HistoricRequest).WithMany(p => p.HistoricRequirements)
                .HasForeignKey(d => new { d.RequestId, d.RequestVersion })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HISTORIC_DEVELOPMENT");
        });

        modelBuilder.Entity<Release>(entity =>
        {
            entity.HasKey(e => e.ReleaseId).HasName("PRIMARY");

            entity.ToTable("releases");

            entity.HasIndex(e => e.UserIdCreation, "FK_CREATION_RELEASE");

            entity.HasIndex(e => e.Name, "UniqueName").IsUnique();

            entity.Property(e => e.Description)
                .HasMaxLength(300)
                .HasDefaultValueSql("''")
                .HasColumnName("description");
            entity.Property(e => e.NRequests).HasColumnName("nRequests");
            entity.Property(e => e.NRequirements).HasColumnName("nRequirements");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.TimeCreation)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("timeCreation");

            entity.HasOne(d => d.UserIdCreationNavigation).WithMany(p => p.Releases)
                .HasForeignKey(d => d.UserIdCreation)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CREATION_RELEASE");
        });

        modelBuilder.Entity<Request>(entity =>
        {
            entity.HasKey(e => e.RequestId).HasName("PRIMARY");

            entity.ToTable("requests");

            entity.HasIndex(e => e.UserIdApproval, "FK_APPROVAL_REQUEST");

            entity.HasIndex(e => e.UserIdCreation, "FK_CREATION_REQUEST");

            entity.HasIndex(e => e.UserIdEditing, "FK_EDITING_REQUEST");

            entity.Property(e => e.Body)
                .HasColumnType("mediumblob")
                .HasColumnName("body");
            entity.Property(e => e.Description)
                .HasMaxLength(300)
                .HasDefaultValueSql("''")
                .HasColumnName("description");
            entity.Property(e => e.IsActive)
                .HasMaxLength(1)
                .HasDefaultValueSql("'Y'")
                .IsFixedLength()
                .HasColumnName("isActive");
            entity.Property(e => e.TimeApproval)
                .HasColumnType("datetime")
                .HasColumnName("timeApproval");
            entity.Property(e => e.TimeCreation)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("timeCreation");
            entity.Property(e => e.TimeEditing)
                .HasColumnType("datetime")
                .HasColumnName("timeEditing");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .HasColumnName("title");
            entity.Property(e => e.Type)
                .HasColumnType("enum('bug','functionality')")
                .HasColumnName("type");

            entity.HasOne(d => d.UserIdApprovalNavigation).WithMany(p => p.RequestUserIdApprovalNavigations)
                .HasForeignKey(d => d.UserIdApproval)
                .HasConstraintName("FK_APPROVAL_REQUEST");

            entity.HasOne(d => d.UserIdCreationNavigation).WithMany(p => p.RequestUserIdCreationNavigations)
                .HasForeignKey(d => d.UserIdCreation)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CREATION_REQUEST");

            entity.HasOne(d => d.UserIdEditingNavigation).WithMany(p => p.RequestUserIdEditingNavigations)
                .HasForeignKey(d => d.UserIdEditing)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EDITING_REQUEST");
        });

        modelBuilder.Entity<Requirement>(entity =>
        {
            entity.HasKey(e => e.RequirementId).HasName("PRIMARY");

            entity.ToTable("requirements");

            entity.HasIndex(e => e.UserIdCreation, "FK_CREATION_REQUIREMENT");

            entity.HasIndex(e => e.RequestId, "FK_DEVELOPMENT");

            entity.HasIndex(e => e.UserIdEditing, "FK_EDITING_REQUIREMENT");

            entity.HasIndex(e => e.ParentRequirementId, "FK_KINSHIP");

            entity.Property(e => e.Body)
                .HasColumnType("mediumblob")
                .HasColumnName("body");
            entity.Property(e => e.Description)
                .HasMaxLength(300)
                .HasDefaultValueSql("''")
                .HasColumnName("description");
            entity.Property(e => e.EstimatedHours).HasColumnName("estimatedHours");
            entity.Property(e => e.IsActive)
                .HasMaxLength(1)
                .HasDefaultValueSql("'Y'")
                .IsFixedLength()
                .HasColumnName("isActive");
            entity.Property(e => e.ProgressPercentage).HasColumnName("progressPercentage");
            entity.Property(e => e.TakenHours).HasColumnName("takenHours");
            entity.Property(e => e.TimeCreation)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("timeCreation");
            entity.Property(e => e.TimeEditing)
                .HasColumnType("datetime")
                .HasColumnName("timeEditing");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .HasColumnName("title");
            entity.Property(e => e.Type)
                .HasColumnType("enum('functional','non-functional')")
                .HasColumnName("type");

            entity.HasOne(d => d.ParentRequirement).WithMany(p => p.InverseParentRequirement)
                .HasForeignKey(d => d.ParentRequirementId)
                .HasConstraintName("FK_KINSHIP");

            entity.HasOne(d => d.Request).WithMany(p => p.Requirements)
                .HasForeignKey(d => d.RequestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DEVELOPMENT");

            entity.HasOne(d => d.UserIdCreationNavigation).WithMany(p => p.RequirementUserIdCreationNavigations)
                .HasForeignKey(d => d.UserIdCreation)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CREATION_REQUIREMENT");

            entity.HasOne(d => d.UserIdEditingNavigation).WithMany(p => p.RequirementUserIdEditingNavigations)
                .HasForeignKey(d => d.UserIdEditing)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EDITING_REQUIREMENT");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PRIMARY");

            entity.ToTable("users");

            entity.HasIndex(e => e.Email, "UniqueEmail").IsUnique();

            entity.HasIndex(e => e.Username, "UniqueUsername").IsUnique();

            entity.Property(e => e.Company)
                .HasMaxLength(30)
                .HasColumnName("company");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.IsEditor)
                .HasMaxLength(1)
                .HasDefaultValueSql("'N'")
                .IsFixedLength()
                .HasColumnName("isEditor");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasColumnName("phone");
            entity.Property(e => e.Surname)
                .HasMaxLength(30)
                .HasColumnName("surname");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("username");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
