using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Exer4MVC.Models;

namespace Exer4MVC.Data
{
    public class Exer4MVCContext : DbContext
    {
        public Exer4MVCContext (DbContextOptions<Exer4MVCContext> options)
            : base(options)
        {
        }

        public DbSet<Exer4MVC.Models.MVCCRUD> MVCCRUD { get; set; }
    }
}
