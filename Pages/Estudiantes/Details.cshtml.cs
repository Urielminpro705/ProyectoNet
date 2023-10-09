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
    public class DetailsModel : PageModel
    {
        private readonly Universidad.Data.UniversidadDBContext _context;

        public DetailsModel(Universidad.Data.UniversidadDBContext context)
        {
            _context = context;
        }

      public Estudiante Estudiante { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Estudiante == null)
            {
                return NotFound();
            }

            var estudiante = await _context.Estudiante
            .Include(i => i.Inscripciones)
            .FirstOrDefaultAsync(m => m.id_estudiante == id);
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
    }
}
