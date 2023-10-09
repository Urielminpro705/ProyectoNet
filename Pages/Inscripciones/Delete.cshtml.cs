using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Universidad.Data;
using Universidad.Models;

namespace Universidad.Pages_Inscripciones
{
    public class DeleteModel : PageModel
    {
        private readonly Universidad.Data.UniversidadDBContext _context;

        public DeleteModel(Universidad.Data.UniversidadDBContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Inscripcion Inscripcion { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Inscripcion == null)
            {
                return NotFound();
            }

            var inscripcion = await _context.Inscripcion.FirstOrDefaultAsync(m => m.id_inscripcion == id);

            if (inscripcion == null)
            {
                return NotFound();
            }
            else 
            {
                Inscripcion = inscripcion;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Inscripcion == null)
            {
                return NotFound();
            }
            var inscripcion = await _context.Inscripcion.FindAsync(id);

            if (inscripcion != null)
            {
                Inscripcion = inscripcion;
                _context.Inscripcion.Remove(Inscripcion);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
