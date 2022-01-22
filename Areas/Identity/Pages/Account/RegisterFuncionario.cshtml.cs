using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using MyAirbnb.Models;

namespace MyAirbnb.Areas.Identity.Pages.Account
{
    [Authorize(Roles = "Gestor")]
    public class RegisterFuncionarioModel : PageModel
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ILogger<RegisterFuncionarioModel> _logger;
        private readonly ApplicationDbContext _context;

        public RegisterFuncionarioModel(
            UserManager<AppUser> userManager,
            ILogger<RegisterFuncionarioModel> logger,
            ApplicationDbContext context)
        {
            _userManager = userManager;
            _logger = logger;
            _context = context;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "A {0} tem de ter entre {2} e {1} caracteres.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "A password não é igual à anterior.")]
            public string ConfirmPassword { get; set; }

            [Required]
            [Display(Name = "Nome do funcionário")]
            public string FuncionarioNome { get; set; }
        }

        public void OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                var userId = Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                var empresaId = _context.Empresas.First(e => e.Id == userId).EmpresaId;
                var nFuncionarios = _userManager.GetUsersInRoleAsync("Funcionario").Result.Count;
                var user = new Funcionario()
                {
                    UserName = Input.FuncionarioNome, //mostrar nome em vez de email
                    Email = Input.Email,
                    NormalizedEmail = Input.Email,
                    FuncionarioId = nFuncionarios + 1,
                    FuncionarioNome = Input.FuncionarioNome,
                    EmpresaId = empresaId,
                    EmailConfirmed = true
                };
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("(MANAGER) Gestor created a new funcionario with password.");
                    await _userManager.AddToRoleAsync(user, "Funcionario");
                    return RedirectToAction("Index", "Funcionarios");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}