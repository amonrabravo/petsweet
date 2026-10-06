using System.ComponentModel.DataAnnotations;

namespace PetSweet.Models;

public record LoginViewModel
{
    [Display(Name = "E-Posta")]
    [DataType(DataType.EmailAddress)]
    [Required(ErrorMessage = "E-Posta alanı gereklidir.")]
    public string Email { get; set; } = null!;

    [Display(Name = "Parola")]
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Parola alanı gereklidir.")]
    public string Password { get; set; } = null!;

    [Display(Name = "Beni hatırla")]
    public bool RememberMe { get; set; }
}
