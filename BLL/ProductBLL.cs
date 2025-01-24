using System;
using DAL;
using DTO;

namespace BLL
{

    public class InventoryManager 
    {
        private readonly ProductDAL _repository = new ProductDAL();
        private List<string> _errorMessages = new List<string>();
        private ResultDTO _resultView = new ResultDTO();


        private void ResetState()
        {
            _errorMessages.Clear();
            _resultView = new ResultDTO();
        }
       

        public ResultDTO AddProduct(Product product)
        {
            ResetState();

            var idExists = GetByID(product.ProductId);

            if (product.ProductId <= 0)
            {
                _errorMessages.Add("ProductId should be positive integer.");
            }

            if (string.IsNullOrEmpty(product.Name))
            {
                _errorMessages.Add("Product Name is required.");
            }

            if(product.Price < 0)
            {
                _errorMessages.Add("Product price should be non-negative.");
            }
            if (product.QuantityInStock < 0)
            {
                _errorMessages.Add("Product quantity should be non-negative.");
            }          

            if(idExists.Result != null )
            {
                _errorMessages.Add("Product ID already exists.");
            }

            if (_errorMessages.Count == 0)
            {
                _repository.AddProduct(product);
                _resultView.IsSuccess = true;
            }
            else
            {
                _resultView.IsSuccess = false;
                _resultView.Result = string.Join("\n", _errorMessages.ToArray());
            }        

            return _resultView;

        }

        public ResultDTO ListProducts()
        {
            ResetState();

            List<Product> products = _repository.ListProducts();

            if (products != null)
            {
                _resultView.IsSuccess = true;
                _resultView.IsListResult = true;

                if (products.Count == 0)
                {
                    _resultView.IsListResult = false;
                }

                _resultView.Result = products.ToList();
            }
            else
            {
                _resultView.IsSuccess = false;
            }

            return _resultView;
        }

        public ResultDTO RemoveProduct(int productId)
        {
            ResetState();

            if (productId <= 0)
            {
                _errorMessages.Add("ProductId should be positive integer.");
            }

            if(_errorMessages.Count == 0)
            {
                _repository.RemoveProduct(productId);
                _resultView.IsSuccess = true;
            }
            else
            {
                _resultView.IsSuccess = false;
                _resultView.Result = string.Join("\n", _errorMessages.ToArray());
            }

            return _resultView;
        }
        
        public ResultDTO UpdateProduct(int productId, int newQuantity)
        {
            ResetState();


            if (productId <= 0)
            {
                _errorMessages.Add("ProductId should be positive integer.");
            }

            if (newQuantity <= 0)
            {
                _errorMessages.Add("Product quantity should be non-negative.");
            }

            if (_errorMessages.Count == 0)
            {
                _repository.UpdateProduct(productId, newQuantity);
                _resultView.IsSuccess = true;
            }
            else
            {
                _resultView.IsSuccess = false;
                _resultView.Result = string.Join("\n", _errorMessages.ToArray());
            }

            return _resultView;
        }

        public ResultDTO GetTotalValue()
        {
            ResetState();

            decimal totalValue = _repository.GetTotalValue();

            if (totalValue != null)
            {
                _resultView.IsSuccess = true;
                _resultView.Result = totalValue.ToString();
            }
            else
            {
                _resultView.IsSuccess = false;
            }

            return _resultView;
        }

        public ResultDTO GetByID(int productID)
        {
            ResetState();

            var product = _repository.GetByID(productID);

            if(product != null)
            {
                _resultView.Result = product;
                _resultView.IsSuccess = true;
            }
            else 
            { 
                _resultView.IsSuccess = false; 
            }
            
            return _resultView ;
        }

    }

}