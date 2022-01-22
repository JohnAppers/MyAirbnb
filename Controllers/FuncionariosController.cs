using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyAirbnb.Models;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MyAirbnb.Controllers
{
    [Authorize(Roles = "Gestor")]
    public class FuncionariosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        public FuncionariosController(ApplicationDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Funcionarios
        public async Task<IActionResult> Index()
        {
            var thisUser = Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            return View(await _context.Funcionario.Where(f => f.EmpresaId == _context.Empresas.Find(thisUser).EmpresaId).ToListAsync());
        }

        // GET: Funcionarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcionario = await _context.Funcionario
                .FirstOrDefaultAsync(m => m.Id == id);
            if (funcionario == null)
            {
                return NotFound();
            }

            return View(funcionario);
        }

        // GET: Funcionarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcionario = await _context.Funcionario.FindAsync(id);
            if (funcionario == null)
            {
                return NotFound();
            }
            return View(funcionario);
        }

        // POST: Funcionarios/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Funcionario funcionario)
        {
            if (id != funcionario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var SavedUser = await _userManager.FindByIdAsync(funcionario.Id.ToString());
                    funcionario.SecurityStamp = SavedUser.SecurityStamp;
                    await _userManager.UpdateAsync(funcionario);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FuncionarioExists(funcionario.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(funcionario);
        }

        // GET: Funcionarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcionario = await _context.Funcionario
                .FirstOrDefaultAsync(m => m.Id == id);
            if (funcionario == null)
            {
                return NotFound();
            }

            return View(funcionario);
        }

        // POST: Funcionarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var funcionario = await _context.Funcionario.FindAsync(id);
            _context.Funcionario.Remove(funcionario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FuncionarioExists(int id)
        {
            return _context.Funcionario.Any(e => e.Id == id);
        }
    }
}
