using DatabaseWorkWpf.Models;
using Microsoft.EntityFrameworkCore;

namespace DatabaseWorkWpf.Utils;

public class ApplicationContext : DbContext
{
    public DbSet<Client>? Clients { get; set; }
    public DbSet<Manager>? Managers { get; set; }
    public DbSet<Sale>? Sales { get; set; }
    public DbSet<Good>? Goods { get; set; }
    public DbSet<Estimate>? Estimates { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer(
        "Data Source=localhost;Initial Catalog=Sales;Integrated Security=True;Trust Server Certificate=true");
    
}