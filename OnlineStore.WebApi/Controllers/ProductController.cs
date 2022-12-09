using Microsoft.AspNetCore.Mvc;
using OnlineStore.Data.Repositories;
using OnlineStore.Domain;
using OnlineStore.Models;

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
    public async Task<IEnumerable<Product>> GetProducts(CancellationToken cancellationToken)
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
    public async Task AddProduct(Product product, CancellationToken cancellationToken)
    {
        await _productRepository.Add(product, cancellationToken);
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