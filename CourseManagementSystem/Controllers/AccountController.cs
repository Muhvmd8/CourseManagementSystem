namespace CMS.PL.Controllers;
public class AccountController(UserManager<ApplicationUser> userManager,
    SignInManager<ApplicationUser> signInManager) : Controller
{
    private readonly UserManager<ApplicationUser> _userManager = userManager;
    private readonly SignInManager<ApplicationUser> _signInManager = signInManager;

    public IActionResult Index() => View();
    #region Register
    [HttpGet]
    public IActionResult Register() => View();
    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel viewModel)
    {
        if (!ModelState.IsValid)
            return View(viewModel);

        var user = await _userManager.FindByNameAsync(viewModel.UserName);
        if (user is null)
        {
            user = await _userManager.FindByEmailAsync(viewModel.Email);    
            if (user is null)
            {
                user = new ApplicationUser
                {
                    UserName = viewModel.UserName,
                    Email = viewModel.Email,
                    FullName = viewModel.FullName,
                    //IsAgree = viewModel.IsAgree,
                };

                var result = await _userManager.CreateAsync(user, viewModel.Password);
                if (result.Succeeded) return RedirectToAction(nameof(Login));

                foreach (var error in result.Errors)
                    ModelState.AddModelError(string.Empty, error.Description);
            }
        }
        ModelState.AddModelError(string.Empty, "Invalid Sign Up !!");
        return View(viewModel);
    }
    #endregion

    #region Login
    [HttpGet]
    public IActionResult Login() => View();
    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel viewModel)
    {
        if (!ModelState.IsValid)
            return View(viewModel);

        var user = await _userManager.FindByNameAsync(viewModel.UserName);
        if (user is not null)
        {
            var result = await _signInManager.PasswordSignInAsync(user, viewModel.Password, viewModel.RememberMe, false);
            if (result.Succeeded)
                return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        ModelState.AddModelError(string.Empty, "Invalid Login !! Up !!");
        return View(viewModel);
    }
    #endregion

    #region Log Out
    [HttpGet]
    public new async Task<IActionResult> SignOut()
    {
        await _signInManager.SignOutAsync(); // Delete the token from cockies 
        return RedirectToAction(nameof(Login));
    }
    #endregion

    #region Forget Password
    [HttpGet]
    public IActionResult ForgetPassword() => View();
    [HttpPost] 
    public async Task<IActionResult> SendResetPasswordUrl(ForgetPasswordViewModel viewModel)
    {
        if (!ModelState.IsValid) return View(viewModel);

        var user = await _userManager.FindByEmailAsync(viewModel.Email);
        if (user is not null)
        {
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            // Create URL
            var url = Url.Action("ResetPassword", "Account", new { email = viewModel.Email, token }, Request.Scheme);
            // Create Email 
            var email = new Email()
            {
                To = viewModel.Email,
                Subject = "Reset Password",
                Body = url
            };
            // Send Email
            var flag = EmailSettings.SendEmail(email);
            if (flag)
            {
                // Check your inbox
                return RedirectToAction(nameof(CheckYourInbox));
            }
        }
        
        return View(nameof(ForgetPassword), viewModel);
    }
    #endregion

    public IActionResult CheckYourInbox() => View();
    [HttpGet]
    public IActionResult ResetPassword(string email, string token)
    {
        TempData["email"] = email;
        TempData["token"] = token;
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> ResetPassword(ResetPasswordViewModel viewModel)
    {
        if (!ModelState.IsValid) 
            return View(viewModel);
        var email = TempData["email"]  as string;
        var token = TempData["token"] as string ;

        if (email is null || token is null) return BadRequest("Invalid Operation");

        var user = await _userManager.FindByEmailAsync(email);

        if (user is not null)
        {
            var result = await _userManager.ResetPasswordAsync(user, token, viewModel.NewPassword);
            if (result.Succeeded) return RedirectToAction(nameof(Login));
        }
        ModelState.AddModelError(string.Empty, "Invalid Reset Password Operation");
        return View(viewModel);  
    }
}
