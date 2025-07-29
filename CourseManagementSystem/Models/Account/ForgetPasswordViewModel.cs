namespace CMS.PL.Models.Account;

public class ForgetPasswordViewModel
{
    [Required(ErrorMessage = "Email is required !!")]
    [EmailAddress]
    public string Email { get; set; }
}
