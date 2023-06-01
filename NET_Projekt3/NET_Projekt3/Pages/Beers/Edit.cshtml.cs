using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NET_Projekt3.Data;
using NET_Projekt3.Models;

namespace NET_Projekt3.Pages.Beers
{
    public class EditModel : PageModel
    {
        private readonly NET_Projekt3.Data.NET_Projekt3Context _context;

        public EditModel(NET_Projekt3.Data.NET_Projekt3Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Beer Beer { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Beer == null)
            {
                return NotFound();
            }

            var beer =  await _context.Beer.FirstOrDefaultAsync(m => m.ID == id);
            if (beer == null)
            {
                return NotFound();
            }
            Beer = beer;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Beer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BeerExists(Beer.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BeerExists(int id)
        {
          return (_context.Beer?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
