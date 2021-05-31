using GifAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GifAPI.Context
{
    public class GifDbContext:DbContext
    {
        public GifDbContext(DbContextOptions<GifDbContext> options) : base(options){}

        public DbSet<GifModel> MyGifs { get; set; }
    }
}
