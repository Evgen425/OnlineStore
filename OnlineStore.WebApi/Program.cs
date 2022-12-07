using Microsoft.EntityFrameworkCore;
using OnlineStore.Data;
using OnlineStore.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddCors();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();

const string dbPath = "myapp.db";
builder.Services.AddDbContext<AppDbContext>(
    options => options.UseSqlite($"Data Source={dbPath}"));
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(policy =>
{
    policy
        .AllowAnyMethod()
        .AllowAnyHeader()
        .WithOrigins("http://localhost:5084","https://api.mysite.com");
});

//
// app.MapGet("/products", async (
//         [FromServices] IProductRepository repository, CancellationToken cancellationToken)
//     =>
// {
//      var products= await repository.GetAll(cancellationToken);
//      return products; 
// });
//
// app.MapPost("/products/addProduct", async (
//     [FromBody]Product product,
//     [FromServices] IProductRepository repository, 
//     HttpResponse response, 
//     CancellationToken cancellationToken ) =>
// {
//     await repository.Add(product, cancellationToken);
// });
//
// app.MapGet("/get_product", async ([FromQuery] Guid id,
//     [FromServices] IProductRepository repository,
//     CancellationToken cancellationToken) =>
// {
//    var product= await repository.GetById(id, cancellationToken);
//    return product;
// });
//
//
// app.MapPost("/products/update/", async (
//     [FromBody]Product newProduct,
//     [FromServices] IProductRepository repository,
//     CancellationToken cancellationToken) =>
// {
//     await repository.Update(newProduct, cancellationToken);
// });
//
// app.MapDelete("/products/delete", async ([FromQuery]Guid id,
//     [FromServices] IProductRepository repository,
//     CancellationToken cancellationToken) =>
// {
//     await repository.Delete(id, cancellationToken);
// });

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();