using repositorypattern;
using repositorypattern.Exceptions;
using repositorypattern.Model;
using repositorypattern.Repository;

public class InMemoryProductRepository : IProductRepository
{
   
    private readonly dBContext _dBcontext;
    public InMemoryProductRepository(dBContext dbcontext)
    {
            _dBcontext = dbcontext;
    }
    public IEnumerable<Product> GetAll()
    {
       return _dBcontext.Products.ToList();
        
    }

    public Product GetById(int id)
    {
        //This is for the exception handling
        var products = _dBcontext.Products.ToList();
        var product = products.FirstOrDefault(p => p.Id == id);
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
        _dBcontext.Products.Add(product);

        _dBcontext.SaveChanges();
    }

    public void Update(Product product)
    {
        var existingProduct = GetById(product.Id);
        if (existingProduct != null)
        {
            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;
            _dBcontext.SaveChanges();
        }
    }

    public void Delete(int id)
    {
        var products = _dBcontext.Products.ToList();
        var productToRemove = GetById(id);
        if (productToRemove != null)
        {
            products.Remove(productToRemove);
        }
    }
}
