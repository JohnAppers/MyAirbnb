using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyAirbnb.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyAirbnb.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexGestorModel : PageModel
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ApplicationDbContext _context;

        public IndexGestorModel(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        public string Username { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Display(Name = "Endereço")]
            public string Endereco { get; set; }

            [Display(Name = "Contacto")]
            public string Contact { get; set; }
        }

        private async Task LoadAsync(AppUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = _context.Empresas.First(e => e.UserName == userName).Contacto;
            var endereco = _context.Empresas.First(e => e.UserName == userName).Endereco;
            Username = userName;

            Input = new InputModel
            {
                Contact = phoneNumber.ToString(),
                Endereco = endereco
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            Empresa empresa = (Empresa)user;
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = _context.Empresas.First(e => e.UserName == userName).Contacto;
            var endereco = _context.Empresas.First(e => e.UserName == userName).Endereco;
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            if (Input.Contact != phoneNumber.ToString())
            {
                empresa.Contacto = Int32.Parse(Input.Contact);
                await _userManager.UpdateAsync(empresa);
            }

            if (Input.Contact != endereco)
            {
                empresa.Endereco = Input.Endereco;
                await _userManager.UpdateAsync(empresa);
            }

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}
