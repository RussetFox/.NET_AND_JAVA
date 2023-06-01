using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NET_Projekt3.Data;
using NET_Projekt3.Models;

namespace NET_Projekt3.Pages.Beers
{
    public class IndexModel : PageModel
    {
        private readonly NET_Projekt3.Data.NET_Projekt3Context _context;

        public IndexModel(NET_Projekt3.Data.NET_Projekt3Context context)
        {
            _context = context;
        }

        public IList<Beer> Beer { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Beer != null)
            {
                Beer = await _context.Beer.ToListAsync();
            }
        }
    }
}
