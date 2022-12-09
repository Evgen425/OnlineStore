using System.Collections.Concurrent;
using OnlineStore.Domain;
using OnlineStore.Models.Requests;


namespace OnlineStore.ApiClient.Fake;

public class ShopClientFake : IShopClient
{
    private readonly TimeSpan _delay;

    private readonly ConcurrentDictionary<long, Product> _products = new()
    {
        [1] = new Product(id: new Guid(), "Breadd", 999m)
    };

    public ShopClientFake(TimeSpan Delay = default)
    {
        _delay = Delay;
    }

    public async Task<IReadOnlyList<Product>> GetProducts()
    {
        await Task.Delay(_delay);
        return _products.Values.ToList().AsReadOnly();
    }

    public Task<Product> GetProduct(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task AddProduct(Product product)
    {
        // await Task.Delay(_delay);
        // _products.TryAdd(product.Id,product);
    }

    public Task UpdateProduct(Product product, Guid id)
    {
        throw new NotImplementedException();
    }

    public Task DeleteProduct(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task Register(RegisterRequest registerRequest, CancellationToken cts = default)
    {
        throw new NotImplementedException();
    }
}