using Microsoft.EntityFrameworkCore;
using OnlineStore.Domain;
using OnlineStore.Models;

namespace OnlineStore.Data.Repositories;

public class ProductRepository :EfRepository<Product>, IProductRepository
{
  
    public ProductRepository(AppDbContext dbContext) : base(dbContext)
    {
        if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
    }

    public async Task<IReadOnlyList<Product>> FindByName(string text, CancellationToken cancellationToken = default)
    {
        if (text == null) throw new ArgumentNullException(nameof(text));
        var products= await Entities.Where(p => p.Name.Contains(text)).ToListAsync(cancellationToken);
       return products;
    }
} 