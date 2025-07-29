namespace CMS.PL.Views.Account;
public class ResetPasswordViewModel
{
    [Required(ErrorMessage = "New Password is required !!")]
    [DataType(DataType.Password)]
    public string NewPassword { get; set; }
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Confirm Password is required !!")]
    [Compare(nameof(NewPassword), ErrorMessage = "Confirm Password doesn't match the password !!")]
    public string ConfirmPassword { get; set; }

}
