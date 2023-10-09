using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Universidad.Data;
using Universidad.Models;

namespace Universidad.Pages_Inscripciones
{
    public class EditModel : PageModel
    {
        private readonly Universidad.Data.UniversidadDBContext _context;

        public EditModel(Universidad.Data.UniversidadDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Inscripcion Inscripcion { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Inscripcion == null)
            {
                return NotFound();
            }

            var inscripcion =  await _context.Inscripcion.FirstOrDefaultAsync(m => m.id_inscripcion == id);
            if (inscripcion == null)
            {
                return NotFound();
            }
            Inscripcion = inscripcion;
           ViewData["id_curso"] = new SelectList(_context.Curso, "id_curso", "id_curso");
           ViewData["id_estudiante"] = new SelectList(_context.Estudiante, "id_estudiante", "id_estudiante");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Inscripcion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InscripcionExists(Inscripcion.id_inscripcion))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool InscripcionExists(int id)
        {
          return _context.Inscripcion.Any(e => e.id_inscripcion == id);
        }
    }
}
