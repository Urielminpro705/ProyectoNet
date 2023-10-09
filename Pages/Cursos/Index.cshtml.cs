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

namespace Universidad.Pages_Cursos
{
    public class IndexModel : PageModel
    {
        private readonly Universidad.Data.UniversidadDBContext _context;

        public IndexModel(Universidad.Data.UniversidadDBContext context)
        {
            _context = context;
        }

        public IList<Curso> Curso { get; set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }
        public async Task OnGetAsync()
        {
            var cursos = from m in _context.Curso
                        select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                cursos = cursos.Where(s => s.titulo.Contains(SearchString));
            }
                Curso = await cursos.ToListAsync();
        }
    }
}
