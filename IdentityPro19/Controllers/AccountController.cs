using IdentityPro19.Models;
using IdentityPro19.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Permissions;

namespace IdentityPro19.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        #region InjectedServices
        private UserManager<ApplicationUser> userManager;
        private SignInManager<ApplicationUser> signInManager;
        private RoleManager<IdentityRole> roleManager;
        public AccountController(UserManager<ApplicationUser> _userManager,
            SignInManager<ApplicationUser> _signInManager,
            RoleManager<IdentityRole> _roleManager)
        {
            userManager = _userManager;
            signInManager = _signInManager;
            roleManager = _roleManager;
        }
        #endregion

        #region Users
     
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]


        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser()
                {
                    Email = model.Email,
                    UserName = model.Email,
                    PhoneNumber = model.Mobile,
                    Gender = model.G
                };

                var result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }

                return View(model);
            }

            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "Invalid user or password");
                return View(model);
            }
            return View(model);


        }

        [HttpGet]
        public IActionResult Logout()
        {
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public async Task<IActionResult> ConfirmLogout()
        {

            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        #endregion

        #region Roles

        [HttpGet]
        public IActionResult RolesList()
        {

            return View(roleManager.Roles);
        }

        [HttpGet]


        public IActionResult CreateRole()
        {
            return View();
        }
        [HttpPost]
       

        public async Task<IActionResult> CreateRole(CreateRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityRole role = new IdentityRole() { Name = model.Name };
                var result = await roleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("RolesList", "Account");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }
                return View(model);
            }
            return View(model);
        }
    

        [HttpGet]
    
        public async Task<IActionResult> EditRole(string? id)
        {
            if (id == null || string.IsNullOrEmpty(id))
            { return RedirectToAction(nameof(RolesList)); }

            var role = await roleManager.FindByIdAsync(id);
            if (role == null)
            {

                return RedirectToAction(nameof(RolesList));
            }
            EditRoleViewModel model = new EditRoleViewModel()
            {
                RoleId = role.Id,
                RoleName = role.Name
            };
            foreach (var user in userManager.Users)
            {
                if (await userManager.IsInRoleAsync(user, role.Name!))
                {
                    model.Names.Add(user.UserName!);
                }

            }
            return View(model);
        }
      

        [HttpPost]
        public async Task<IActionResult> EditRole(EditRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                //Old Role
                var role = await roleManager.FindByIdAsync(model.RoleId);
                if (role == null) { return RedirectToAction(nameof(RolesList)); };
                //update role name
                role.Name = model.RoleName;

                var result = await roleManager.UpdateAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(RolesList));
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }

                return View(model);
            }
            return View(model);
        }

        public IActionResult AccessDenied() { return View(); }
        #endregion



    }
}



