using Microsoft.EntityFrameworkCore;

namespace BrianSantos.Models;

public class AppDataContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Sourc=luiz-hoffmann_brian-santos.db");
    }
}