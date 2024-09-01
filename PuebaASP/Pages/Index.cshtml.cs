using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PruebaASP.Data;
using PuebaASP.Models;

namespace PuebaASP.Pages
{
    public class IndexModel : PageModel
    {
        private readonly PruebaASP.Data.MyDbContext _context;

        public IndexModel(PruebaASP.Data.MyDbContext context)
        {
            _context = context;
        }

        public IList<Persona> Persona { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Persona = await _context.Personas.ToListAsync();
        }
    }
}
