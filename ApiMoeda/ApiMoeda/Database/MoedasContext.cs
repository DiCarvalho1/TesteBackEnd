using ApiMoeda.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMoeda.Database
{
    public class MoedasContext : DbContext
    {
        public MoedasContext(DbContextOptions<MoedasContext> options) : base(options)
        {

        }

        public DbSet<Dinheiro> Dinheiros { get; set; }
    }
}
