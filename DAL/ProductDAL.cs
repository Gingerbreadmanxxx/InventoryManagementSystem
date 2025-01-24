using DTO;

namespace DAL
{
    public class ProductDAL
    {
        private readonly List<Product> _products = new List<Product>();

        public Product GetByID(int productId)
        {
            var product = _products.Find(x => x.ProductId == productId);

            return product;
        }

        public bool AddProduct(Product product)
        {
            _products.Add(product);

            return true;
        }

        public List<Product> ListProducts()
        {
           return _products;
        }

        public bool RemoveProduct(int productId)
        {
            var product = _products.FirstOrDefault(x => x.ProductId == productId);
            if (product == null)
            {
                return false;
            }

            _products.Remove(product);
            return true;
        }

        public bool UpdateProduct(int productID, int newQuantity)
        {
            var product = _products.FirstOrDefault(x => x.ProductId == productID);
            if (product == null)
            {
                return false;
            }
            product.QuantityInStock = newQuantity;

            return true;
        }

        public decimal GetTotalValue()
        {
            return _products.Sum(p => p.Price * p.QuantityInStock);
        }

    }
}
