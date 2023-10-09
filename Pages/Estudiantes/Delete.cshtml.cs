using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Universidad.Data;
using Universidad.Models;

namespace Universidad.Pages_Estudiantes
{
    public class DeleteModel : PageModel
    {
        private readonly Universidad.Data.UniversidadDBContext _context;

        public DeleteModel(Universidad.Data.UniversidadDBContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Estudiante Estudiante { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Estudiante == null)
            {
                return NotFound();
            }

            var estudiante = await _context.Estudiante.FirstOrDefaultAsync(m => m.id_estudiante == id);

            if (estudiante == null)
            {
                return NotFound();
            }
            else 
            {
                Estudiante = estudiante;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Estudiante == null)
            {
                return NotFound();
            }
            var estudiante = await _context.Estudiante.FindAsync(id);

            if (estudiante != null)
            {
                Estudiante = estudiante;
                _context.Estudiante.Remove(Estudiante);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
