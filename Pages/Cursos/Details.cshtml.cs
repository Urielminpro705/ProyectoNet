using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Universidad.Data;
using Universidad.Models;

namespace Universidad.Pages_Cursos
{
    public class DetailsModel : PageModel
    {
        private readonly Universidad.Data.UniversidadDBContext _context;

        public DetailsModel(Universidad.Data.UniversidadDBContext context)
        {
            _context = context;
        }

      public Curso Curso { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Curso == null)
            {
                return NotFound();
            }

            var curso = await _context.Curso.FirstOrDefaultAsync(m => m.id_curso == id);
            if (curso == null)
            {
                return NotFound();
            }
            else 
            {
                Curso = curso;
            }
            return Page();
        }
    }
}
