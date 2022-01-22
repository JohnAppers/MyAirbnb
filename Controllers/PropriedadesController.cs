using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyAirbnb.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MyAirbnb.Controllers
{
    [Authorize(Roles = "Gestor")]
    public class PropriedadesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public PropriedadesController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Propriedades
        public async Task<IActionResult> Index()
        {
            var userId = Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var empresa = _context.Empresas.First(i => i.Id == userId);
            var applicationDbContext = _context.Imoveis.Include(i => i.Categoria).Include(i => i.Funcionario).Include(i => i.Reservas).Where(i => i.EmpresaId == empresa.Id);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Propriedades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imovel = await _context.Imoveis
                .Include(i => i.Categoria)
                .Include(i => i.Funcionario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (imovel == null)
            {
                return NotFound();
            }

            return View(imovel);
        }

        // GET: Propriedades/Create
        public IActionResult Create()
        {
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "Id", "Name");
            return View();
        }

        // POST: Propriedades/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Imovel imovel, List<IFormFile> upload_imagem)
        {
            if (ModelState.IsValid)
            {
                //guardar ID da empresa que o criou
                var userId = Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                imovel.EmpresaId = userId;

                //guardar caminho da imagem do imóvel
                var imagem = upload_imagem[0];
                if (imagem.Length > 0)
                {
                    var path = Path.Combine(_webHostEnvironment.WebRootPath, "images", imagem.FileName);
                    using (Stream fileStream = new FileStream(path, FileMode.Create))
                    {
                        await imagem.CopyToAsync(fileStream);
                    }
                    imovel.ImagemNome = imagem.FileName;
                }
                _context.Add(imovel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "Id", "Name", imovel.CategoriaId);
            return View(imovel);
        }

        // GET: Propriedades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imovel = await _context.Imoveis.FindAsync(id);
            if (imovel == null)
            {
                return NotFound();
            }
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "Id", "Name", imovel.CategoriaId);
            ViewData["FuncionarioId"] = new SelectList(_context.Funcionarios, "Id", "FuncionarioNome", imovel.FuncionarioId);
            return View(imovel);
        }

        // POST: Propriedades/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Imovel imovel, List<IFormFile> upload_imagem)
        {
            if (id != imovel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //guardar caminho da imagem do imóvel
                    if (upload_imagem.Count != 0)
                    {
                        var imagem = upload_imagem[0];
                        if (imagem.Length > 0)
                        {
                            if (imovel.ImagemNome != null)
                            {
                                var path = Path.Combine(_webHostEnvironment.WebRootPath, "images", imovel.ImagemNome);
                                if (System.IO.File.Exists(path))
                                    System.IO.File.Delete(path);
                            }
                            var newPath = Path.Combine(_webHostEnvironment.WebRootPath, "images", imagem.FileName);
                            using (Stream fileStream = new FileStream(newPath, FileMode.Create))
                            {
                                await imagem.CopyToAsync(fileStream);
                            }
                            imovel.ImagemNome = imagem.FileName;
                        }
                    }
                    var userId = Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                    imovel.EmpresaId = userId;

                    _context.Update(imovel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ImovelExists(imovel.Id))
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
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "Id", "Name", imovel.CategoriaId);
            ViewData["FuncionarioId"] = new SelectList(_context.Funcionarios, "Id", "FuncionarioNome", imovel.FuncionarioId);
            return View(imovel);
        }

        // GET: Propriedades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imovel = await _context.Imoveis
                .Include(i => i.Categoria)
                .Include(i => i.Funcionario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (imovel == null)
            {
                return NotFound();
            }

            return View(imovel);
        }

        // POST: Propriedades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var imovel = await _context.Imoveis.FindAsync(id);
            _context.Imoveis.Remove(imovel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ImovelExists(int id)
        {
            return _context.Imoveis.Any(e => e.Id == id);
        }
    }
}
