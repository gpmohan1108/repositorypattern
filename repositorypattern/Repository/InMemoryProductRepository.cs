using repositorypattern.Exceptions;
using repositorypattern.Model;
using repositorypattern.Repository;

public class InMemoryProductRepository : IProductRepository
{
    private readonly List<Product> _products = new List<Product>();

    public IEnumerable<Product> GetAll()
    {
        return _products;
    }

    public Product GetById(int id)
    {
        var product = _products.FirstOrDefault(p => p.Id == id);
        if (product != null)
        {
            return product;
        }
        else
        {
            throw new NotFoundException("Id not found");
        }
        
    }

    public void Add(Product product)
    {
        _products.Add(product);
    }

    public void Update(Product product)
    {
        var existingProduct = GetById(product.Id);
        if (existingProduct != null)
        {
            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;
        }
    }

    public void Delete(int id)
    {
        var productToRemove = GetById(id);
        if (productToRemove != null)
        {
            _products.Remove(productToRemove);
        }
    }
}
