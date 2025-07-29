namespace CMS.PL.Models.Account;

public class LoginViewModel
{
    [Required(ErrorMessage = "UserName is required !!")]
    public string UserName { get; set; }
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Password is required !!")]
    public string Password { get; set; }
    public bool RememberMe { get; set; }
}
