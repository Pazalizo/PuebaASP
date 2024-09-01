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
    public class DetailsModel : PageModel
    {
        private readonly PruebaASP.Data.MyDbContext _context;

        public DetailsModel(PruebaASP.Data.MyDbContext context)
        {
            _context = context;
        }

        public Persona Persona { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var persona = await _context.Personas.FirstOrDefaultAsync(m => m.Id == id);
            if (persona == null)
            {
                return NotFound();
            }
            else
            {
                Persona = persona;
            }
            return Page();
        }
    }
}
