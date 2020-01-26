using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SymTom.Models;

namespace SymTom.Data
{
    public class SymptomDbContext : DbContext
    {
        public DbSet<Symptom> Symptoms { get; set; }
        public SymptomDbContext(DbContextOptions<SymptomDbContext> options)
            : base(options)
        {
        }
    }
}
