using Microsoft.EntityFrameworkCore;

namespace BrianSantos.Models;

public class AppDataContext : DbContext
{
    public DbSet<Funcionario> Funcionarios { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=luiz-hoffmann_brian-santos.db");
    }
}