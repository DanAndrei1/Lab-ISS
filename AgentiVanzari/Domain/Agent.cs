using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;

namespace AgentiVanzari.Domain;

public class AgentContext : DbContext
{
    public DbSet<Agent> Agents { get; set; }
 
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(connectionString:
            "Server=localhost;Port=5432;User Id=postgres;Password=fdrafydyx;Database=agenti;"); 
        base.OnConfiguring(optionsBuilder);
    }
}

[Table("users")]
public class Agent
{
    [Column("id")]
    public int Id { get; set; }
    
    [Column("name")]
    public string Name { get; set; }
    
    [Column("username")]
    public string Username { get; set; }
    
    [Column("password")]
    public string Password { get; set; }
}