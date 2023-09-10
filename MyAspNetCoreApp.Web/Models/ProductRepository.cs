using MyAspNetCoreApp.Web.Models;

namespace MyAspNetCoreApp.Web.Models
{
    public class ProductRepository
    {

        public static List<Product> _products = new List<Product>()
        {
                new() { Id = 1, Name = "Kalem1", Price = 100, Stock = 200 },
                new () { Id = 2, Name = "Kalem2", Price = 200, Stock = 300 },
                new () { Id = 3, Name = "Kalem3", Price = 300, Stock = 400 },
                new() { Id = 4, Name = "Kalem4", Price = 400, Stock = 500 },
                new() { Id = 5, Name = "Kalem5", Price = 500, Stock = 600 },
        };

        public List<Product> GetAll() => _products;
        
        public void Add(Product newProduct) => _products.Add(newProduct);

        public void Remove(int id)
        {
            var hasproduct= _products.FirstOrDefault(p => p.Id == id);  
            if (hasproduct == null) 
            {
                throw new Exception($"Bu id({id}'ye sahip ürün bulunmamaktadır.)");
            }
            _products.Remove(hasproduct);
        }  

        public void Update(Product updateproduct)
        {
            var hasproduct= _products.FirstOrDefault(x => x.Id == updateproduct.Id);
            if (hasproduct != null) {
                throw new Exception($"Bu id({updateproduct.Id}'ye sahip ürün bulunmamaktadır.)");
            }
            
            hasproduct.Name= updateproduct.Name;    
            hasproduct.Price= updateproduct.Price;  
            hasproduct.Stock=updateproduct.Stock;

            var index = _products.FindIndex(x=>x.Id == updateproduct.Id);
            _products[index] = hasproduct;


        }
    }
}
