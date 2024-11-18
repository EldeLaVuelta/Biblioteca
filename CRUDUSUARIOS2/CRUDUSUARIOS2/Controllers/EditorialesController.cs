using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CRUDUSUARIOS2.Models;

namespace CRUDUSUARIOS2.Controllers
{
    public class EditorialesController : Controller
    {
        private readonly GaminContext _context;

        public EditorialesController(GaminContext context)
        {
            _context = context;
        }

        // GET: Editoriales
        public async Task<IActionResult> Index()
        {
            return View(await _context.Editoriales.ToListAsync());
        }

        // GET: Editoriales/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                TempData["Error"] = "El ID no puede ser nulo.";
                return NotFound();
            }

            var editoriale = await _context.Editoriales
                .FirstOrDefaultAsync(m => m.Nit == id);
            if (editoriale == null)
            {
                TempData["Error"] = "No se encontró la editorial.";
                return NotFound();
            }

            return View(editoriale);
        }

        // GET: Editoriales/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Editoriales/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nit,Nombres,Telefono,Direccion,Email,Sitioweb")] Editoriale editoriale)
        {
            if (ModelState.IsValid)
            {
                if (_context.Editoriales.Any(e => e.Nit == editoriale.Nit))
                {
                    TempData["Error"] = "El ID ya existe. Por favor, use un ID único.";
                    return View(editoriale);
                }

                try
                {
                    _context.Add(editoriale);
                    await _context.SaveChangesAsync();
                    TempData["Success"] = "Editorial creada exitosamente.";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    TempData["Error"] = $"Ocurrió un error al crear la editorial: {ex.Message}";
                }
            }
            else
            {
                TempData["Error"] = "Los datos ingresados no son válidos.";
            }

            return View(editoriale);
        }

        // GET: Editoriales/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                TempData["Error"] = "El ID no puede ser nulo.";
                return NotFound();
            }

            var editoriale = await _context.Editoriales.FindAsync(id);
            if (editoriale == null)
            {
                TempData["Error"] = "No se encontró la editorial.";
                return NotFound();
            }

            return View(editoriale);
        }

        // POST: Editoriales/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Nit,Nombres,Telefono,Direccion,Email,Sitioweb")] Editoriale editoriale)
        {
            if (id != editoriale.Nit)
            {
                TempData["Error"] = "El ID proporcionado no coincide.";
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(editoriale);
                    await _context.SaveChangesAsync();
                    TempData["Success"] = "Editorial actualizada exitosamente.";
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EditorialeExists(editoriale.Nit))
                    {
                        TempData["Error"] = "La editorial no existe.";
                        return NotFound();
                    }
                    else
                    {
                        TempData["Error"] = "Ocurrió un error de concurrencia.";
                        throw;
                    }
                }
                catch (Exception ex)
                {
                    TempData["Error"] = $"Ocurrió un error al actualizar la editorial: {ex.Message}";
                }
            }
            else
            {
                TempData["Error"] = "Los datos ingresados no son válidos.";
            }

            return View(editoriale);
        }

        // GET: Editoriales/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                TempData["Error"] = "El ID no puede ser nulo.";
                return NotFound();
            }

            var editoriale = await _context.Editoriales
                .FirstOrDefaultAsync(m => m.Nit == id);
            if (editoriale == null)
            {
                TempData["Error"] = "No se encontró la editorial.";
                return NotFound();
            }

            return View(editoriale);
        }

        // POST: Editoriales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var editoriale = await _context.Editoriales.FindAsync(id);
            if (editoriale == null)
            {
                TempData["Error"] = "No se encontró la editorial.";
                return RedirectToAction(nameof(Index));
            }

            try
            {
                _context.Editoriales.Remove(editoriale);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Editorial eliminada exitosamente.";
            }
            catch (DbUpdateException)
            {
                TempData["Error"] = "No se puede eliminar la editorial porque está en uso.";
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Ocurrió un error al eliminar la editorial: {ex.Message}";
            }

            return RedirectToAction(nameof(Index));
        }

        private bool EditorialeExists(int id)
        {
            return _context.Editoriales.Any(e => e.Nit == id);
        }
    }
}
