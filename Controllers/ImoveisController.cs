using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyAirbnb.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

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
            var applicationDbContext = _context.Imoveis.Include(i => i.Categoria).Include(i => i.Reservas);
            if (!String.IsNullOrEmpty(search))
            {
                var applicationDbContextSearch = _context.Imoveis.Include(i => i.Categoria).Include(i => i.Reservas).Where(a => a.Nome.Contains(search));
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

        private bool ImovelExists(int id)
        {
            return _context.Imoveis.Any(e => e.Id == id);
        }
    }
}
