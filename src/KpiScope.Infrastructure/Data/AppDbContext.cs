using KpiScope.Core.CompanyAggregate;
using KpiScope.Core.ContributorAggregate;
using KpiScope.Core.KpiAggregate;
using KpiScope.Core.KpiGroupAggregate;
using KpiScope.Core.UserAggregate;

namespace KpiScope.Infrastructure.Data;

public class AppDbContext : DbContext
{
  private readonly IDomainEventDispatcher? _dispatcher;

  public AppDbContext(DbContextOptions<AppDbContext> options,
        IDomainEventDispatcher? dispatcher = null)
      : base(options)
  {
    _dispatcher = dispatcher;
  }

  public DbSet<User> Users { get; set; }
  //public DbSet<Contributor> Contributors { get; set; }
  public DbSet<DynamicValue> DynamicValues { get; set; }
  public DbSet<Kpi> Kpis { get; set; }
  public DbSet<Company> Companies { get; set; }
  public DbSet<KpiGroup> KpiGroups { get; set; }
  public DbSet<KpiGroupCompany> KpiGroupCompanys { get; set; }
  public DbSet<KpiValue> KpiValues { get; set; }
  public DbSet<KpiConfirmation> KpiConfirmations { get; set; }
  public DbSet<KpiConfirmationUser> KpiConfirmationUsers { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<KpiGroupCompany>()
    .HasOne(x => x.Owner)
    .WithMany()
    .HasForeignKey(x => x.UserId)
    .OnDelete(DeleteBehavior.Restrict);
    modelBuilder.Entity<KpiConfirmationUser>()
        .HasOne(x => x.User)
        .WithMany()
        .HasForeignKey(x => x.UserId)
        .OnDelete(DeleteBehavior.Restrict);
  }
        
}
