﻿using Microsoft.EntityFrameworkCore;
using Parcial1LISBETH.Models;

namespace Parcial1LISBETH.DAL
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }

        public DbSet<Prestamo> prestamo { get; set; }
    }
}
