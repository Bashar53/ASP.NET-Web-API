using IBoss.Models;
using IBoss.Models.Dataseed;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace IBoss.DbCon;

public class IBossProjectDbContext : DbContext
{

    public IBossProjectDbContext(DbContextOptions<IBossProjectDbContext> options) : base(options)
    {
        
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
        modelBuilder.ApplyConfiguration(new EmployeeAttendanceConfiguration());
    }

    public DbSet<tblEmployee> Employees { get; set; } 
    public DbSet<tblEmployeeAttendance> EmployeeAttendances { get; set;}
}
