using Microsoft.AspNetCore.Mvc;
using OnlineStore.Data.Repositories;
using OnlineStore.Domain;

namespace OnlineStore.WebApi.Controllers;
[ApiController]
[Route("products")]
public class ProductController: ControllerBase
{
    private readonly IProductRepository _productRepository;
    
    public ProductController(IProductRepository productRepository)
    {
        _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
    }

    [HttpGet("get_all")]
    public async Task<IReadOnlyList<Product>> GetProducts(CancellationToken cancellationToken)
    {
       var product= await _productRepository.GetAll(cancellationToken);
       return product;
    }
    
    [HttpGet("get_by_id")]
    public async Task<Product> GetProduct([FromQuery]Guid id, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetById(id, cancellationToken);
        return product;
    }
    
    [HttpPost("add_Product")]
    public async Task<ActionResult<Product>> AddProduct(Product product, CancellationToken cancellationToken)
    {
        var newProduct=new Product(Guid.NewGuid(), product.Name, product.TotalPrice);
            await _productRepository.Add(newProduct, cancellationToken);
            return newProduct;
    }
    
    [HttpPut("update")]
    public async Task UpdateProduct(Product product, CancellationToken cancellationToken)
    {
        await _productRepository.Update(product, cancellationToken);
    }
    
    [HttpDelete("delete_p")]
    public async Task DeleteProduct(Guid id, CancellationToken cancellationToken)
    {
        await _productRepository.DeleteById(id, cancellationToken);
    }
}