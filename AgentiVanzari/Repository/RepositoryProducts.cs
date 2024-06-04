using System.Collections.Generic;
using System.Threading.Tasks;
using AgentiVanzari.Domain;
using Microsoft.EntityFrameworkCore;

namespace AgentiVanzari.Repository;

public class RepositoryProducts
{
    private List<Product> _products;
    
    public RepositoryProducts()
    {
        _products = new List<Product>();
    }
    
    public async Task<List<Product>> GetAll()
    {
        using var context = new ProductContext();
        return await context.Products.ToListAsync();
    }
    
    public async Task<Product> GetByName(string name)
    {
        using var context = new ProductContext();
        return await context.Products.FirstOrDefaultAsync(x => x.Name == name);
    }
    
    public async Task<Product> GetById(int id)
    {
        using var context = new ProductContext();
        return await context.Products.FirstOrDefaultAsync(x => x.Id == id);
    }
    
    public async Task Add(Product product)
    {
        using var context = new ProductContext();
        await context.Products.AddAsync(product);
        await context.SaveChangesAsync();
    }
    
    public async Task Update(Product product)
    {
        using var context = new ProductContext();
        context.Products.Update(product);
        await context.SaveChangesAsync();
    }
    
    public async Task Delete(int id)
    {
        using var context = new ProductContext();
        var product = await context.Products.FirstOrDefaultAsync(x => x.Id == id);
        context.Products.Remove(product);
        await context.SaveChangesAsync();
    }
}