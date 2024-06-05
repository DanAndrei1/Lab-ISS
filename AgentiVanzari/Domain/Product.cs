using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AgentiVanzari.Domain;

public class ProductContext : DbContext
{
    public DbSet<Product> Products { get; set; }
 
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(connectionString:
            "Server=localhost;Port=5432;User Id=postgres;Password=fdrafydyx;Database=agenti;"); 
        base.OnConfiguring(optionsBuilder);
    }
}

[Table("products")]
public class Product
{
    public Product(int id, string name, int stock)
    {
        Id = id;
        Name = name;
        Stock = stock;
    }
    
    public Product() { }
    
    [Column("id")]
    public int Id { get; set; }
    
    [Column("name")]
    public string Name { get; set; }
    
    [Column("quantity")]
    public int Stock { get; set; }
}