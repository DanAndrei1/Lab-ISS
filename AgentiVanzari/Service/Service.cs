using System.Collections.Generic;
using AgentiVanzari.Domain;
using AgentiVanzari.Repository;

namespace AgentiVanzari.Service;

public class Service
{
    private readonly RepositoryUsers _repositoryUsers;
    private readonly RepositoryProducts _repositoryProducts;
    
    public Service()
    {
        _repositoryUsers = new RepositoryUsers();
        _repositoryProducts = new RepositoryProducts();
    }
    
    public bool Login(string username, string password)
    {
        var user = _repositoryUsers.GetByUserNameAndPassword(username, password).Result;
        return user != null;
    }
    
    public List<Product> GetAllProducts()
    {
        return _repositoryProducts.GetAll().Result;
    }
    
    public void OrderProduct(string productName, int quantity)
    {
        var product = _repositoryProducts.GetByName(productName).Result;
        product.Stock -= quantity;
        if (product.Stock>=0)
            _ = _repositoryProducts.Update(product);
    }
    
    public void DeleteProductsWithQuantityLessThan(int quantity)
    {
        var products = _repositoryProducts.GetAll().Result;
        foreach (var product in products)
        {
            if (product.Stock < quantity)
                _ = _repositoryProducts.Delete(product.Id);
        }
    }
}