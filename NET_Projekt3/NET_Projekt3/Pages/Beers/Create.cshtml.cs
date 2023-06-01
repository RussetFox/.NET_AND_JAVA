using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NET_Projekt3.Data;
using NET_Projekt3.Models;

namespace NET_Projekt3.Pages.Beers
{
    public class CreateModel : PageModel
    {
        private readonly NET_Projekt3.Data.NET_Projekt3Context _context;

        public CreateModel(NET_Projekt3.Data.NET_Projekt3Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Beer Beer { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Beer == null || Beer == null)
            {
                return Page();
            }

            _context.Beer.Add(Beer);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
