using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SimpleSocial.Models;

namespace SimpleSocial.Data;

public class ApplicationDbContext : IdentityDbContext<User>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<SimpleSocial.Models.Post> Post { get; set; }

	public override int SaveChanges()
	{
		SetProperties();
		return base.SaveChanges();
	}

	public override Task<int> SaveChangesAsync(CancellationToken cancellationToken)
	{
		SetProperties();
		return base.SaveChangesAsync(cancellationToken);
	}
    private void SetProperties()
{
    foreach (var entity in ChangeTracker.Entries().Where(p => p.State == EntityState.Added))
    {
		var created = entity.Entity as ICreateDate;
		if (created != null)
		{
			created.CreateDate = DateTime.Now;
		}
    }
    
    foreach (var entity in ChangeTracker.Entries().Where(p=>p.State == EntityState.Modified))
    {
    	var updated = entity.Entity as IModifiedDate;
    	if (updated != null)
    	{
    		updated.ModifiedDate = DateTime.Now;
    	}
    }
}
}
