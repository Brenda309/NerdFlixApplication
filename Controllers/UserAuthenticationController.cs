using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NerdFlixApplication.Models.DTO;
using NerdFlixApplication.Repositories.Abstract;

namespace NerdFlixApplication.Controllers
{
   
    public class UserAuthenticationController : Controller
    {
        private IUserAuthenticationService authService;
        public UserAuthenticationController(IUserAuthenticationService authService)
        {
            this.authService = authService;
        }
        /* We will create a user with admin rights, after that we are going
          to comment this method because we need only
          one user in this application 
          If you need other users ,you can implement this registration method with view
          I have create a complete tutorial for this, you can check the link in description box
         */
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register( RegistrationModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await authService.RegisterAsync(model);

                if (result.StatusCode == 1)
                {
                    return Ok(result.Message);
                }
                else
                {
                    return BadRequest(result.Message);
                }
            }

            return BadRequest("Invalid registration data.");
        }


        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var result = await authService.LoginAsync(model);
            if (result.StatusCode == 1)
                return RedirectToAction("Index", "Home");
            else
            {
                TempData["msg"] = "Could not logged in..";
                return RedirectToAction(nameof(Login));
            }
        }

        public async Task<IActionResult> Logout()
        {
            await authService.LogoutAsync();
            return RedirectToAction(nameof(Login));
        }

    }
}