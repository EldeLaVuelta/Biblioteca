using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRUDUSUARIOS3.Models;

namespace CRUDUSUARIOS3.Controllers
{
    public class Usuarios3Controller : Controller
    {
        private readonly SucioContext _context;

        public Usuarios3Controller(SucioContext context)
        {
            _context = context;
        }

        // GET: Usuarios3
        public async Task<IActionResult> Index()
        {
            return View(await _context.Usuarios3s.ToListAsync());
        }

        // GET: Usuarios3/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarios3 = await _context.Usuarios3s
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuarios3 == null)
            {
                return NotFound();
            }

            return View(usuarios3);
        }

        // GET: Usuarios3/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Usuarios3/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Fecha,Clave")] Usuarios3 usuarios3)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usuarios3);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(usuarios3);
        }

        // GET: Usuarios3/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarios3 = await _context.Usuarios3s.FindAsync(id);
            if (usuarios3 == null)
            {
                return NotFound();
            }
            return View(usuarios3);
        }

        // POST: Usuarios3/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Fecha,Clave")] Usuarios3 usuarios3)
        {
            if (id != usuarios3.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuarios3);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Usuarios3Exists(usuarios3.Id))
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
            return View(usuarios3);
        }

        // GET: Usuarios3/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarios3 = await _context.Usuarios3s
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuarios3 == null)
            {
                return NotFound();
            }

            return View(usuarios3);
        }

        // POST: Usuarios3/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuarios3 = await _context.Usuarios3s.FindAsync(id);
            if (usuarios3 != null)
            {
                _context.Usuarios3s.Remove(usuarios3);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Usuarios3Exists(int id)
        {
            return _context.Usuarios3s.Any(e => e.Id == id);
        }
    }
}
