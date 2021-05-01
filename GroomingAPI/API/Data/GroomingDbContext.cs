﻿using API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data
{
    public class GroomingDbContext : DbContext
    {
        public GroomingDbContext(DbContextOptions<GroomingDbContext> options) : base(options)
        {
            this.Database.EnsureCreatedAsync();
        }

        public DbSet<Groomer> Groomers { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Pet> Pets { get; set; }
    }
}
