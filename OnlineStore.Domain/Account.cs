using System.ComponentModel.DataAnnotations;

namespace OnlineStore.Domain;

public record Account : IEntity
{
    public Guid Id { get; init; }
    [Required]
    public string Name { get; set; } = "";

    [Required]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = "";

    [Required]
    [MinLength(6)]
    [DataType(DataType.Password)]
    public string Password { get; set; } = "";

    public Account(Guid id,string name, string email, string password)
    {
        Id = id;
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Email = email ?? throw new ArgumentNullException(nameof(email));
        Password = password ?? throw new ArgumentNullException(nameof(password));
    }
    //for EF
    private Account(){}   
}

