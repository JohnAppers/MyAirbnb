using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyAirbnb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MyAirbnb.Controllers
{
    [Authorize]
    public class ReservasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReservasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Reservas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Reservas.Include(r => r.Cliente).Include(r => r.Empresa).Include(r => r.Funcionario).Include(r => r.Imovel);
            var userId = Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            if (User.IsInRole("Cliente"))
            {
                return View(await applicationDbContext.Where(i => i.ClienteId == userId).ToListAsync());
            }
            else if (User.IsInRole("Gestor"))
            {
                return View(await applicationDbContext.Where(i => i.EmpresaId == userId).ToListAsync());
            }
            else if (User.IsInRole("Funcionario"))
            {
                return View(await applicationDbContext.Where(i => i.FuncionarioId == userId).ToListAsync());
            }
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Reservas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reservas
                .Include(r => r.Cliente)
                .Include(r => r.Empresa)
                .Include(r => r.Funcionario)
                .Include(r => r.Imovel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reserva == null)
            {
                return NotFound();
            }

            return View(reserva);
        }

        // GET: Reservas/Create
        [Authorize(Roles = "Cliente")]
        public IActionResult Create()
        {
            ViewData["ImovelId"] = new SelectList(_context.Imoveis, "Id", "Nome");
            return View();
        }

        // POST: Reservas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Cliente")]
        public async Task<IActionResult> Create([Bind("ImovelId,DateStart,DateEnd")] Reserva reserva)
        {
            if (ModelState.IsValid)
            {
                bool notAvailable = false;
                ICollection<Reserva> reservasImovel = _context.Reservas.Where(i => i.ImovelId == reserva.ImovelId).ToList();
                foreach (Reserva datas in reservasImovel)
                {
                    if ((reserva.DateStart > datas.DateStart && reserva.DateStart < datas.DateEnd) //se a reserva começar a meio
                        || (reserva.DateEnd > datas.DateStart && reserva.DateEnd < datas.DateStart) //se a reserva acabar a meio
                        || (reserva.DateStart < datas.DateStart && reserva.DateEnd > datas.DateEnd)) //se a reserva começar antes e acabar depois
                        notAvailable = true;
                }
                if (notAvailable)
                    ViewData["ErroData"] = "A data que escolheu não está disponível.";
                else if (reserva.DateStart > reserva.DateEnd) //se a reserva começar depois e acabar antes.....
                    ViewData["ErroData"] = "A data que escolheu não faz sentido.";
                else
                {
                    //guardar ID dos participantes
                    reserva.ClienteId = Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                    reserva.FuncionarioId = _context.Imoveis.First(i => i.Id == reserva.ImovelId).FuncionarioId;
                    reserva.EmpresaId = _context.Imoveis.First(i => i.Id == reserva.ImovelId).EmpresaId;

                    _context.Add(reserva);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            ViewData["ImovelId"] = new SelectList(_context.Imoveis, "Id", "Nome", reserva.ImovelId);
            return View(reserva);
        }

        // GET: Reservas/Edit/5
        [Authorize(Roles = "Cliente")]
        public async Task<IActionResult> EditCliente(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reservas.FindAsync(id);
            if (reserva == null)
            {
                return NotFound();
            }
            return View(reserva);
        }

        // POST: Reservas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Cliente")]
        public async Task<IActionResult> EditCliente(int id, [Bind("Id,DateStart,DateEnd,ImovelId,RatingImovel,CommentImovel,RatingFuncionario,CommentFuncionario,RatingGestor,CommentGestor")] Reserva reserva)
        {
            if (id != reserva.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var savedReserva = _context.Reservas.AsNoTracking().First(i => i.Id == id);
                    reserva.FuncionarioId = savedReserva.FuncionarioId;
                    reserva.EmpresaId = savedReserva.EmpresaId;
                    reserva.ClienteId = savedReserva.ClienteId;

                    _context.Update(reserva);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservaExists(reserva.Id))
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
            return View(reserva);
        }

        // GET: Reservas/Edit/5
        [Authorize(Roles = "Gestor")]
        public async Task<IActionResult> EditGestor(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reservas.FindAsync(id);
            if (reserva == null)
            {
                return NotFound();
            }
            return View(reserva);
        }

        // POST: Reservas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Gestor")]
        public async Task<IActionResult> EditGestor(int id, [Bind("Id,DateStart,DateEnd,ImovelId,RatingCliente,CommentCliente")] Reserva reserva)
        {
            if (id != reserva.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var savedReserva = _context.Reservas.AsNoTracking().First(i => i.Id == id);
                    reserva.FuncionarioId = savedReserva.FuncionarioId;
                    reserva.EmpresaId = savedReserva.EmpresaId;
                    reserva.ClienteId = savedReserva.ClienteId;
                    reserva.RatingGestor = savedReserva.RatingGestor;
                    reserva.RatingFuncionario = savedReserva.RatingFuncionario;
                    reserva.RatingImovel = savedReserva.RatingImovel;
                    reserva.CommentGestor = savedReserva.CommentGestor;
                    reserva.CommentFuncionario = savedReserva.CommentFuncionario;
                    reserva.CommentImovel = savedReserva.CommentImovel;

                    _context.Update(reserva);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservaExists(reserva.Id))
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
            return View(reserva);
        }

        // GET: Reservas/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reservas
                .Include(r => r.Cliente)
                .Include(r => r.Empresa)
                .Include(r => r.Funcionario)
                .Include(r => r.Imovel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reserva == null)
            {
                return NotFound();
            }

            return View(reserva);
        }

        // POST: Reservas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reserva = await _context.Reservas.FindAsync(id);
            _context.Reservas.Remove(reserva);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservaExists(int id)
        {
            return _context.Reservas.Any(e => e.Id == id);
        }
    }
}
