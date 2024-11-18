using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRUDUSUARIOS2.Models;

namespace CRUDUSUARIOS2.Controllers
{
    public class LibroesController : Controller
    {
        private readonly GaminContext _context;

        public LibroesController(GaminContext context)
        {
            _context = context;
        }

        // GET: Libroes
        public async Task<IActionResult> Index()
        {
            try
            {
                var gaminContext = _context.Libros.Include(l => l.CodigoCategoriaNavigation).Include(l => l.NitEditorialNavigation);
                return View(await gaminContext.ToListAsync());
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Error al cargar los libros: {ex.Message}";
                return View();
            }
        }

        // GET: Libroes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                TempData["Error"] = "El ISBN no puede ser nulo.";
                return NotFound();
            }

            try
            {
                var libro = await _context.Libros
                    .Include(l => l.CodigoCategoriaNavigation)
                    .Include(l => l.NitEditorialNavigation)
                    .FirstOrDefaultAsync(m => m.Isbn == id);
                if (libro == null)
                {
                    TempData["Error"] = "No se encontró el libro.";
                    return NotFound();
                }

                return View(libro);
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Error al cargar los detalles del libro: {ex.Message}";
                return View();
            }
        }

        // GET: Libroes/Create
        public IActionResult Create()
        {
            try
            {
                ViewData["CodigoCategoria"] = new SelectList(_context.Categorias, "CodigoCategoria", "CodigoCategoria");
                ViewData["NitEditorial"] = new SelectList(_context.Editoriales, "Nit", "Nit");
                return View();
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Error al cargar los datos para crear un libro: {ex.Message}";
                return View();
            }
        }

        // POST: Libroes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Isbn,Titulo,Descripcion,NombreAutor,Publicacion,FechaRegistro,CodigoCategoria,NitEditorial")] Libro libro)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(libro);
                    await _context.SaveChangesAsync();
                    TempData["Success"] = "Libro creado exitosamente.";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    TempData["Error"] = $"Error al crear el libro: {ex.Message}";
                    ViewData["CodigoCategoria"] = new SelectList(_context.Categorias, "CodigoCategoria", "CodigoCategoria", libro.CodigoCategoria);
                    ViewData["NitEditorial"] = new SelectList(_context.Editoriales, "Nit", "Nit", libro.NitEditorial);
                    return View(libro);
                }
            }

            TempData["Error"] = "Los datos del libro no son válidos.";
            ViewData["CodigoCategoria"] = new SelectList(_context.Categorias, "CodigoCategoria", "CodigoCategoria", libro.CodigoCategoria);
            ViewData["NitEditorial"] = new SelectList(_context.Editoriales, "Nit", "Nit", libro.NitEditorial);
            return View(libro);
        }

        // GET: Libroes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                TempData["Error"] = "El ISBN no puede ser nulo.";
                return NotFound();
            }

            try
            {
                var libro = await _context.Libros.FindAsync(id);
                if (libro == null)
                {
                    TempData["Error"] = "No se encontró el libro para editar.";
                    return NotFound();
                }

                ViewData["CodigoCategoria"] = new SelectList(_context.Categorias, "CodigoCategoria", "CodigoCategoria", libro.CodigoCategoria);
                ViewData["NitEditorial"] = new SelectList(_context.Editoriales, "Nit", "Nit", libro.NitEditorial);
                return View(libro);
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Error al cargar el libro para editar: {ex.Message}";
                return View();
            }
        }

        // POST: Libroes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Isbn,Titulo,Descripcion,NombreAutor,Publicacion,FechaRegistro,CodigoCategoria,NitEditorial")] Libro libro)
        {
            if (id != libro.Isbn)
            {
                TempData["Error"] = "El ISBN proporcionado no coincide.";
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(libro);
                    await _context.SaveChangesAsync();
                    TempData["Success"] = "Libro actualizado exitosamente.";
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LibroExists(libro.Isbn))
                    {
                        TempData["Error"] = "El libro ya no existe.";
                        return NotFound();
                    }
                    else
                    {
                        TempData["Error"] = "Error de concurrencia al actualizar el libro.";
                        throw;
                    }
                }
                catch (Exception ex)
                {
                    TempData["Error"] = $"Error al actualizar el libro: {ex.Message}";
                }
            }

            ViewData["CodigoCategoria"] = new SelectList(_context.Categorias, "CodigoCategoria", "CodigoCategoria", libro.CodigoCategoria);
            ViewData["NitEditorial"] = new SelectList(_context.Editoriales, "Nit", "Nit", libro.NitEditorial);
            return View(libro);
        }

        // GET: Libroes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                TempData["Error"] = "El ISBN no puede ser nulo.";
                return NotFound();
            }

            try
            {
                var libro = await _context.Libros
                    .Include(l => l.CodigoCategoriaNavigation)
                    .Include(l => l.NitEditorialNavigation)
                    .FirstOrDefaultAsync(m => m.Isbn == id);
                if (libro == null)
                {
                    TempData["Error"] = "No se encontró el libro para eliminar.";
                    return NotFound();
                }

                return View(libro);
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Error al cargar el libro para eliminar: {ex.Message}";
                return View();
            }
        }

        // POST: Libroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            try
            {
                var libro = await _context.Libros.FindAsync(id);
                if (libro != null)
                {
                    _context.Libros.Remove(libro);
                    await _context.SaveChangesAsync();
                    TempData["Success"] = "Libro eliminado exitosamente.";
                }
                else
                {
                    TempData["Error"] = "No se encontró el libro para eliminar.";
                }
            }
            catch (DbUpdateException)
            {
                TempData["Error"] = "No se puede eliminar el libro porque está en uso.";
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Error al eliminar el libro: {ex.Message}";
            }

            return RedirectToAction(nameof(Index));
        }

        private bool LibroExists(string id)
        {
            return _context.Libros.Any(e => e.Isbn == id);
        }
    }
}
