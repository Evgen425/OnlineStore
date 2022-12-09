using System.Net;
using System.Net.Http.Json;
using OnlineStore.Domain;
using OnlineStore.Models.Requests;

namespace OnlineStore.ApiClient;

public class ShopClient : IShopClient
{
    private const string DefaultHost = "https://api.mysite.com";
    private readonly string _host;

    private readonly HttpClient _httpClient;
    //private IShopClient _shopClientImplementation;

    public ShopClient(string host = DefaultHost, HttpClient? httpClient = null)
    {
        _host = host;
        _httpClient = httpClient ?? new HttpClient();
    }

    public async Task<IReadOnlyList<Product>> GetProducts()
    {
        string uri = $"{_host}/products/get_all";
        var response = await _httpClient.GetFromJsonAsync<IReadOnlyList<Product>>(uri);
        return response!;
    }

    public async Task<Product> GetProduct(Guid id, CancellationToken cancellationToken = default)
    {
        string uri = $"{_host}/products/get_by_id?id={id}";
        Product? product = await _httpClient.GetFromJsonAsync<Product>(uri, cancellationToken: cancellationToken);
        return product!;
    }

    public async Task AddProduct(Product product)
    {
        if (product is null)
        {
            throw new ArgumentNullException(nameof(product));
        }

        var uri = $"{_host}/products/add_Product";
        var response = await _httpClient.PostAsJsonAsync(uri, product);
        response.EnsureSuccessStatusCode();
    }

    public async Task UpdateProduct(Product newProduct, Guid id)
    {
        if (newProduct is null)
        {
            throw new ArgumentNullException(nameof(newProduct));
        }

        var uri = $"{_host}/products/update";
        var response = await _httpClient.PutAsJsonAsync(uri, newProduct);
        response.EnsureSuccessStatusCode();
    }

    public async Task DeleteProduct(Guid id)
    {
        var uri = $"{_host}/products/delete_p?id={id}";
        await _httpClient.DeleteAsync(uri);
    }
    public async Task Register(RegisterRequest request, CancellationToken cts = default)
    {
        if (request is null) throw new ArgumentNullException(nameof(request));
        var uri = $"{_host}/accounts/register";
        var response = await _httpClient.PostAsJsonAsync(uri, request, cts);
        if (response.StatusCode == HttpStatusCode.BadRequest)
        {
            var json = await response.Content.ReadAsStringAsync(cts);
            throw new Exception(json);
        }
        response.EnsureSuccessStatusCode();
    }
}