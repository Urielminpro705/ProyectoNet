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
    public class IndexModel : PageModel
    {
        private readonly Universidad.Data.UniversidadDBContext _context;

        public IndexModel(Universidad.Data.UniversidadDBContext context)
        {
            _context = context;
        }

        public IList<Estudiante> Estudiante { get;set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }
        public async Task OnGetAsync()
        {
            var estudiantes = from e in _context.Estudiante
                        select e;
            if (!string.IsNullOrEmpty(SearchString))
            {
                estudiantes = estudiantes.Where(s => s.Nombre.Contains(SearchString));
            }
                Estudiante = await estudiantes.ToListAsync();
        }
    }
}
