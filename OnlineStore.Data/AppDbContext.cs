using Microsoft.EntityFrameworkCore;
using OnlineStore.Domain;
using OnlineStore.Models;

namespace OnlineStore.Data;

public class AppDbContext : DbContext
{
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Account> Accounts => Set<Account>();

    public AppDbContext(
        DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }
}