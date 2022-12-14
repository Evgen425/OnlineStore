namespace OnlineStore.Domain;

public record Product:IEntity
{
    public Guid Id { get; init; }
    public string Name { get; set; }
    public decimal TotalPrice { get; set; }
    private Product()
    {
    }

    public Product(Guid id,string name,decimal totalPrice)
    {
        Id = id;
        Name = name;
        TotalPrice = totalPrice;
    }

}