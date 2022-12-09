using OnlineStore.Domain;
using OnlineStore.Models.Requests;

namespace OnlineStore.ApiClient;

public interface IShopClient
{
    Task<IReadOnlyList<Product>> GetProducts();
    Task<Product> GetProduct(Guid id, CancellationToken cancellationToken= default);
    Task AddProduct(Product product);
    Task UpdateProduct(Product product, Guid id);
     Task DeleteProduct(Guid id);
     Task Register(RegisterRequest registerRequest, CancellationToken cts = default);

}