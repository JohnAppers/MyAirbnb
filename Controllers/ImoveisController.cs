using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyAirbnb.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace MyAirbnb.Controllers
{
    public class ImoveisController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;


        public ImoveisController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Imoveis
        public async Task<IActionResult> Index(string search)
        {
            var applicationDbContext = _context.Imoveis.Include(i => i.Categoria);
            if (!String.IsNullOrEmpty(search))
            {
                var applicationDbContextSearch = _context.Imoveis.Include(i => i.Categoria).Where(a => a.Nome.Contains(search));
                return View(await applicationDbContextSearch.ToListAsync());
            }
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Imovels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imovel = await _context.Imoveis
                .Include(i => i.Categoria)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (imovel == null)
            {
                return NotFound();
            }

            return View(imovel);
        }

        // GET: Imovels/Create
        [Authorize(Roles = "Gestor")]
        public IActionResult Create()
        {
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "Id", "Name");
            return View();
        }

        // POST: Imovels/Create
        [HttpPost]
        [Authorize(Roles = "Gestor")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Imovel imovel, List<IFormFile> upload_imagem)
        {
            if (ModelState.IsValid)
            {
                //guardar ID do utilizador que o criou
                imovel.EmpresaId = Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

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

        // GET: Imovels/Edit/5
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
            return View(imovel);
        }

        // POST: Imovels/Edit/5
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
                    var imagem = upload_imagem[0];
                    if (imagem.Length > 0)
                    {
                        var path = Path.Combine(_webHostEnvironment.WebRootPath, "images", imovel.ImagemNome);
                        if (System.IO.File.Exists(path))
                            System.IO.File.Delete(path);
                        path = Path.Combine(_webHostEnvironment.WebRootPath, "images", imagem.FileName);
                        using (Stream fileStream = new FileStream(path, FileMode.Create))
                        {
                            await imagem.CopyToAsync(fileStream);
                        }
                        imovel.ImagemNome = imagem.FileName;
                    }

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
            return View(imovel);
        }

        // GET: Imovels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imovel = await _context.Imoveis
                .Include(i => i.Categoria)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (imovel == null)
            {
                return NotFound();
            }

            return View(imovel);
        }

        // POST: Imovels/Delete/5
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
