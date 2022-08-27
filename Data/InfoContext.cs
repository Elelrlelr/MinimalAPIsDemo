using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MinimalApisDemo.Models;


public class InfoContext : DbContext
{
    public InfoContext (DbContextOptions<InfoContext> options)
     : base(options)
    {

    }
    public DbSet<Info> Info => Set<Info>();
}