using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NET_Projekt3.Models;

namespace NET_Projekt3.Data
{
    public class NET_Projekt3Context : DbContext
    {
        public NET_Projekt3Context (DbContextOptions<NET_Projekt3Context> options)
            : base(options)
        {
        }

        public DbSet<NET_Projekt3.Models.Beer> Beer { get; set; } = default!;
    }
}
