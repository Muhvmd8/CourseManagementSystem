namespace CMS.PL.Models.Account;

public class RegisterViewModel
{
    [Required(ErrorMessage="UserName is required !!")]
    public string UserName { get; set; }
    [Required(ErrorMessage = "FullName is required !!")]

    public string FullName { get; set; }
    [Required(ErrorMessage = "Email is required !!")]
    [EmailAddress]
    public string Email { get; set; }
    [Required(ErrorMessage = "Password is required !!")]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Confirm Password is required !!")]
    [Compare(nameof(Password), ErrorMessage= "Confirm Password doesn't match the password !!")]
    public string ConfirmPassword { get; set; }
    public bool IsAgree { get; set; }
}
