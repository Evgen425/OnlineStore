using System.ComponentModel.DataAnnotations;

namespace OnlineStore.Models.Requests;

public class RegisterRequest
{
    [Required(ErrorMessage = "Name is required")] 
    public string Name { get; set; }

    [Required(ErrorMessage = "Email is required")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }

    [Required(ErrorMessage = "Password is required")]
    [MinLength(6)]
    [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{6,}$")]
    public string Password { get; set; }

    [Required]
    [Compare("Password", ErrorMessage = "Пароли не соответствуют.")]
   
    public string ConfirmPassword { get; set; }
}