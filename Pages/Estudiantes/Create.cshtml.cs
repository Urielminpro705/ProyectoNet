using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Universidad.Data;
using Universidad.Models;

namespace Universidad.Pages_Estudiantes
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
            return Page();
        }

        [BindProperty]
        public Estudiante Estudiante { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Estudiante.Add(Estudiante);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
