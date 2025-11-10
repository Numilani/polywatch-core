using Microsoft.EntityFrameworkCore;

namespace polywatchcore;

public class AppDbContext : DbContext
{
  public DbSet<GDELTEvent> GDELTEvents {get;set;} = default!;

  public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}
 
  protected override void OnModelCreating(ModelBuilder builder)
  {
    builder.Entity<GDELTEvent>()
      .OwnsOne(x => x.Actor1);
    builder.Entity<GDELTEvent>()
      .OwnsOne(x => x.Actor2);
    builder.Entity<GDELTEvent>()
      .OwnsOne(x => x.Actor1Geodata);
    builder.Entity<GDELTEvent>()
      .OwnsOne(x => x.Actor2Geodata);
    builder.Entity<GDELTEvent>()
      .OwnsOne(x => x.ActionGeodata);
  }
}
