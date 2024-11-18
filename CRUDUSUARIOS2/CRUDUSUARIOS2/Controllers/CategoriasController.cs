using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CRUDUSUARIOS2.Models;

namespace CRUDUSUARIOS2.Controllers
{
    public class CategoriasController : Controller
    {
        private readonly GaminContext _context;

        public CategoriasController(GaminContext context)
        {
            _context = context;
        }

        // GET: Categorias
        public async Task<IActionResult> Index()
        {
            return View(await _context.Categorias.ToListAsync());
        }

        // GET: Categorias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                TempData["Error"] = "ID no válido.";
                return RedirectToAction(nameof(Index));
            }

            var categoria = await _context.Categorias
                .FirstOrDefaultAsync(m => m.CodigoCategoria == id);

            if (categoria == null)
            {
                TempData["Error"] = "Categoría no encontrada.";
                return RedirectToAction(nameof(Index));
            }

            return View(categoria);
        }

        // GET: Categorias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categorias/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodigoCategoria,Nombre")] Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                if (_context.Categorias.Any(c => c.Nombre == categoria.Nombre))
                {
                    TempData["Error"] = "Ya existe una categoría con este nombre.";
                    return View(categoria);
                }

                try
                {
                    _context.Add(categoria);
                    await _context.SaveChangesAsync();
                    TempData["Success"] = "Categoría creada exitosamente.";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception)
                {
                    TempData["Error"] = "Error al crear la categoría.";
                }
            }

            return View(categoria);
        }

        // GET: Categorias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                TempData["Error"] = "ID no válido.";
                return RedirectToAction(nameof(Index));
            }

            var categoria = await _context.Categorias.FindAsync(id);
            if (categoria == null)
            {
                TempData["Error"] = "Categoría no encontrada.";
                return RedirectToAction(nameof(Index));
            }

            return View(categoria);
        }

        // POST: Categorias/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodigoCategoria,Nombre")] Categoria categoria)
        {
            if (id != categoria.CodigoCategoria)
            {
                TempData["Error"] = "ID no coincide.";
                return RedirectToAction(nameof(Index));
            }

            if (ModelState.IsValid)
            {
                if (_context.Categorias.Any(c => c.Nombre == categoria.Nombre && c.CodigoCategoria != id))
                {
                    TempData["Error"] = "Ya existe otra categoría con este nombre.";
                    return View(categoria);
                }

                try
                {
                    _context.Update(categoria);
                    await _context.SaveChangesAsync();
                    TempData["Success"] = "Categoría actualizada exitosamente.";
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoriaExists(categoria.CodigoCategoria))
                    {
                        TempData["Error"] = "La categoría no existe.";
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        throw;
                    }
                }
                catch (Exception)
                {
                    TempData["Error"] = "Error al actualizar la categoría.";
                }
            }

            return View(categoria);
        }

        // GET: Categorias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                TempData["Error"] = "ID no válido.";
                return RedirectToAction(nameof(Index));
            }

            var categoria = await _context.Categorias
                .FirstOrDefaultAsync(m => m.CodigoCategoria == id);

            if (categoria == null)
            {
                TempData["Error"] = "Categoría no encontrada.";
                return RedirectToAction(nameof(Index));
            }

            return View(categoria);
        }

        // POST: Categorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var categoria = await _context.Categorias.FindAsync(id);
                if (categoria != null)
                {
                    _context.Categorias.Remove(categoria);
                    await _context.SaveChangesAsync();
                    TempData["Success"] = "Categoría eliminada exitosamente.";
                }
                else
                {
                    TempData["Error"] = "La categoría no existe.";
                }
            }
            catch (Exception)
            {
                TempData["Error"] = "Error al eliminar la categoría.";
            }

            return RedirectToAction(nameof(Index));
        }

        private bool CategoriaExists(int id)
        {
            return _context.Categorias.Any(e => e.CodigoCategoria == id);
        }
    }
}
