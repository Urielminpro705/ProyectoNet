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

        public async Task OnGetAsync()
        {
            if (_context.Estudiante != null)
            {
                Estudiante = await _context.Estudiante.ToListAsync();
            }
        }
    }
}
