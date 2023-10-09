using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Universidad.Data;
using Universidad.Models;

namespace Universidad.Pages_Inscripciones
{
    public class CreateModel : PageModel
    {
        private readonly Universidad.Data.UniversidadDBContext _context;

        public CreateModel(Universidad.Data.UniversidadDBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["id_curso"] = new SelectList(_context.Curso, "id_curso", "id_curso");
        ViewData["id_estudiante"] = new SelectList(_context.Estudiante, "id_estudiante", "id_estudiante");
            return Page();
        }

        [BindProperty]
        public Inscripcion Inscripcion { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Inscripcion.Add(Inscripcion);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
