using OnlineStore.Domain;
using OnlineStore.Models;

namespace OnlineStore.ApiClient.Test;

public class ProductApiTest
{
    [Fact]
    public async Task One_product_added_to_catalog()
    {
        
        var shopClient = new ShopClient("http://localhost:5008");
        
        var id = Guid.NewGuid();
        var product = (new Product(id, "bread", 110m));
        await shopClient.DeleteProduct(product.Id);
        await shopClient.AddProduct(product);
        var serverProduct = await shopClient.GetProduct(product.Id);
        await shopClient.DeleteProduct(product.Id);
        Assert.Equal(product, serverProduct);
    }
}