using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using YourNamespace.Data;
using YourNamespace.Models;

[HttpPost]
public async Task<IActionResult> CreateAjax([FromBody] Alumno alumno)
{
    if (ModelState.IsValid)
    {
        alumno.Id = Guid.NewGuid(); // Generar un nuevo Id
        _context.Alumnos.Add(alumno);
        await _context.SaveChangesAsync();
        return Json(new { success = true, message = "Alumno agregado con éxito.", alumno });
    }
    return Json(new { success = false, message = "Error al agregar el alumno." });
}

namespace YourNamespace.Controllers
{
    public class AlumnoController : Controller
    {
        private readonly AppDbContext _context;

        public AlumnoController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /Alumno/
        public async Task<IActionResult> Index()
        {
            return View(await _context.Alumnos.ToListAsync());
        }

        // GET: /Alumno/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Alumno/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Alumno alumno)
        {
            if (ModelState.IsValid)
            {
                alumno.Id = Guid.NewGuid();
                _context.Add(alumno);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(alumno);
        }

        // GET: /Alumno/Edit/{id}
        public async Task<IActionResult> Edit(Guid id)
        {
            var alumno = await _context.Alumnos.FindAsync(id);
            if (alumno == null) return NotFound();
            return View(alumno);
        }

        // POST: /Alumno/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Alumno alumno)
        {
            if (id != alumno.Id) return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(alumno);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(alumno);
        }

        // GET: /Alumno/Delete/{id}
        public async Task<IActionResult> Delete(Guid id)
        {
            var alumno = await _context.Alumnos.FindAsync(id);
            if (alumno == null) return NotFound();
            return View(alumno);
        }

        // POST: /Alumno/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var alumno = await _context.Alumnos.FindAsync(id);
            _context.Alumnos.Remove(alumno);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}