using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyAirbnb.Models;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyAirbnb.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexClienteModel : PageModel
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ApplicationDbContext _context;

        public IndexClienteModel(
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
            [Display(Name = "Nome")]
            public string Username { get; set; }

            [Display(Name = "Contacto")]
            public int Contacto { get; set; }
        }

        private async Task LoadAsync(AppUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = _context.Clientes.First(u => u.UserName == userName).Contacto;

            Input = new InputModel
            {
                Username = userName,
                Contacto = phoneNumber,
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
            Cliente cliente = (Cliente)user;
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = _context.Clientes.First(u => u.UserName == userName).Contacto;
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            if (Input.Contacto != phoneNumber)
            {
                cliente.Contacto = Input.Contacto;
                await _userManager.UpdateAsync(cliente);
            }

            if (Input.Username != userName)
            {
                cliente.UserName = Input.Username;
                await _userManager.UpdateAsync(cliente);
            }

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "O seu perfil foi atualizado.";
            return RedirectToPage();
        }
    }
}
