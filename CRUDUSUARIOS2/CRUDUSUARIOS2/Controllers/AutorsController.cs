using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CRUDUSUARIOS2.Models;

namespace CRUDUSUARIOS2.Controllers
{
    public class AutorsController : Controller
    {
        private readonly GaminContext _context;

        public AutorsController(GaminContext context)
        {
            _context = context;
        }

        // GET: Autors
        public async Task<IActionResult> Index()
        {
            return View(await _context.Autors.ToListAsync());
        }

        // GET: Autors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                TempData["Error"] = "ID no especificado.";
                return RedirectToAction(nameof(Index));
            }

            var autor = await _context.Autors.FirstOrDefaultAsync(m => m.IdAutor == id);
            if (autor == null)
            {
                TempData["Error"] = "El autor no existe.";
                return RedirectToAction(nameof(Index));
            }

            return View(autor);
        }

        // GET: Autors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Autors/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAutor,Nombre,Apellido,Nacionalidad")] Autor autor)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Verificar si el ID ya existe
                    if (_context.Autors.Any(a => a.IdAutor == autor.IdAutor))
                    {
                        TempData["Error"] = "El ID ya está en uso. Por favor, utiliza uno diferente.";
                        return RedirectToAction(nameof(Create));
                    }

                    _context.Add(autor);
                    await _context.SaveChangesAsync();
                    TempData["Success"] = "El autor se creó correctamente.";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    TempData["Error"] = "Ocurrió un error al crear el autor. Intenta nuevamente.";
                }
            }
            else
            {
                TempData["Error"] = "Datos inválidos. Revisa los campos.";
            }
            return View(autor);
        }

        // GET: Autors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                TempData["Error"] = "ID no especificado.";
                return RedirectToAction(nameof(Index));
            }

            var autor = await _context.Autors.FindAsync(id);
            if (autor == null)
            {
                TempData["Error"] = "El autor no existe.";
                return RedirectToAction(nameof(Index));
            }
            return View(autor);
        }

        // POST: Autors/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAutor,Nombre,Apellido,Nacionalidad")] Autor autor)
        {
            if (id != autor.IdAutor)
            {
                TempData["Error"] = "El ID no coincide.";
                return RedirectToAction(nameof(Index));
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(autor);
                    await _context.SaveChangesAsync();
                    TempData["Success"] = "El autor se actualizó correctamente.";
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AutorExists(autor.IdAutor))
                    {
                        TempData["Error"] = "El autor no existe.";
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        throw;
                    }
                }
                catch (Exception ex)
                {
                    TempData["Error"] = "Ocurrió un error al actualizar el autor.";
                }
            }
            else
            {
                TempData["Error"] = "Datos inválidos. Revisa los campos.";
            }
            return View(autor);
        }

        // GET: Autors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                TempData["Error"] = "ID no especificado.";
                return RedirectToAction(nameof(Index));
            }

            var autor = await _context.Autors.FirstOrDefaultAsync(m => m.IdAutor == id);
            if (autor == null)
            {
                TempData["Error"] = "El autor no existe.";
                return RedirectToAction(nameof(Index));
            }

            return View(autor);
        }

        // POST: Autors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var autor = await _context.Autors.FindAsync(id);
                if (autor == null)
                {
                    TempData["Error"] = "El autor no existe.";
                    return RedirectToAction(nameof(Index));
                }

                _context.Autors.Remove(autor);
                await _context.SaveChangesAsync();
                TempData["Success"] = "El autor se eliminó correctamente.";
            }
            catch (DbUpdateException)
            {
                TempData["Error"] = "No se pudo eliminar el autor. Es posible que tenga dependencias.";
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Ocurrió un error al intentar eliminar el autor.";
            }

            return RedirectToAction(nameof(Index));
        }

        private bool AutorExists(int id)
        {
            return _context.Autors.Any(e => e.IdAutor == id);
        }
    }
}
