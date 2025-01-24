
using BLL;
using DTO;


public  class Program
{
    static readonly InventoryManager _manager = new InventoryManager();

    static void Main()
    { 

        while (true)
        {
            PrintLines();
            Console.WriteLine("\n Simple Inventory Management System");
            PrintLines();
            Console.WriteLine("1) Add Product");
            Console.WriteLine("2) Remove Product");
            Console.WriteLine("3) Update Product Quantity");
            Console.WriteLine("4) List Products");
            Console.WriteLine("5) Get Total Inventory Value");
            Console.WriteLine("6) Exit");
            PrintLines();
            Console.Write("Enter choice: ");

            switch (Console.ReadLine())
            {
                case "1":
                    AddProduct();
                    break;
                case "2":
                    RemoveProduct();
                    break;
                case "3":
                    UpdateProduct();
                    break;
                case "4":
                    ListProducts();
                    break;
                case "5":
                    GetTotalValue();
                    break;
                case "6":
                    return;
                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }
        }
    }

   
    private static void ListProducts()
    {
        List<Product> products = new List<Product>();
        var productResult = _manager.ListProducts();

       

        if(productResult.IsSuccess)
        {
            if (!productResult.IsListResult)
            {
                PrintLines();
                Console.WriteLine("Inventory is empty.");
                return;
            }

            foreach (var product in (dynamic)productResult.Result)
            {
                PrintLines();
                Console.WriteLine($"ID: {product.ProductId} || Name: {product.Name} || Quantity: {product.QuantityInStock} || Price: ${product.Price:F2}");
                
            }
        }
            
    }
    private static void AddProduct()
    {
        int productId = 0;
        string name = "";
        int quantityInStock = 0;
        decimal price = 0;

        try
        {
            Console.Write("Enter Product ID: ");
             productId = int.Parse(Console.ReadLine());

            Console.Write("Enter Name: ");
             name = Console.ReadLine();

            Console.Write("Enter Quantity: ");
             quantityInStock = int.Parse(Console.ReadLine());

            Console.Write("Enter Price: ");
             price = decimal.Parse(Console.ReadLine());
        }
        catch (Exception ex)
        {

            Console.WriteLine(ex.Message);
            return;
        }

        var result = _manager.AddProduct(new Product()
        {
            ProductId = productId,
            Name = name,
            QuantityInStock = quantityInStock,
            Price = price
        });

        if(result.IsSuccess)
        {
            PrintLines();
            Console.WriteLine("Product Added Successfully.");
        }
        else
        {
            PrintLines();
            Console.WriteLine(result.Result.ToString());
        }  
    }
    private static void RemoveProduct()
    {
        int productId = 0;

        try
        {
            Console.Write("Enter Product ID to Remove: ");
             productId = int.Parse(Console.ReadLine());
        }
        catch (Exception ex)
        {

            Console.WriteLine(ex.Message);
            return;
        }


        var result = _manager.RemoveProduct(productId);

        if (result.IsSuccess)
        {
            PrintLines();
            Console.WriteLine("Product Removed Successfully.");
        }
        else
        {
            PrintLines();
            Console.WriteLine(result.Result.ToString());
        }
    }
    private static void UpdateProduct()
    {
        int productId = 0;
        int newQuantity = 0;
        try
        {
            Console.Write("Enter Product ID: ");
            productId = int.Parse(Console.ReadLine());

            Console.Write("Enter New Quantity: ");
            newQuantity = int.Parse(Console.ReadLine());
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return;
        }
 

        var result = _manager.UpdateProduct(productId, newQuantity);

        if (result.IsSuccess)
        {
            PrintLines();
            Console.WriteLine("Product updated.");

        }
        else
        {
            PrintLines();
            Console.WriteLine(result.Result.ToString());
        }
            
    }

    private static void GetTotalValue()
    {
        var result = _manager.GetTotalValue();


        if (result.IsSuccess)
        {
            PrintLines();
            Console.WriteLine($"Total Inventory Value: ${result.Result:F2}");
        }
        else
        {
            PrintLines();
            Console.WriteLine(result.Result.ToString());
        }

    }


    private static void PrintLines()
    {
        Console.WriteLine("=======================================");
    }

}


