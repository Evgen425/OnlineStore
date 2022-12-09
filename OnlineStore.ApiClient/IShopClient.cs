using OnlineStore.Domain;
using OnlineStore.Models;

namespace OnlineStore.ApiClient;

public interface IShopClient
{
    Task<IReadOnlyList<Product>> GetProducts();
    Task<Product> GetProduct(Guid id, CancellationToken cancellationToken= default);
    Task AddProduct(Product product);
    Task UpdateProduct(Product product, Guid id);
     Task DeleteProduct(Guid id);

}