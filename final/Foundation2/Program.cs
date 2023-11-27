using System;

class Program
{
    static void Initialize(List<Order> orders){
        List<Product> products = new List<Product>(); Customer customer;
        Address address; Product product;Order order;

        address = new Address("123 Hill Road", "Bakersfield", "CA", "USA");
        customer = new Customer("John Smith", address);
        product = new Product("Lemon Drops", "LD1009842", 6.54, 3);
        products.Add(product);
        product = new Product("Starbursts", "S0097564", 3.48, 5);
        products.Add(product);
        product = new Product("Bagelbites", "BB0040056", 6.27, 6);
        products.Add(product);
        order = new Order(products, customer);

        orders.Add(order);
        
        products = new List<Product>();
        address = new Address("3 Ruiz Blvd", "Sector 2", "Mexico City", "Mexico");
        customer = new Customer("Juan Lopez", address);
        product = new Product("Matcha Kit-Kats", "MK0012093", 3.79, 5);
        products.Add(product);
        product = new Product("Hershey Kisses", "HK0041902", 4.23, 2);
        products.Add(product);
        product = new Product("Chocolate Almonds", "C1060239", 3.16, 5);
        products.Add(product);
        order = new Order(products, customer);

        orders.Add(order);
    }
    static void Main(string[] args)
    {
        List<Order> orders = new List<Order>();
        Initialize(orders);
        foreach(Order order in orders){
            Console.WriteLine("Packing Label");
            Console.WriteLine(order.PackingLabel());
            Console.WriteLine("Shipping Label");
            Console.WriteLine(order.ShippingLabel());
            Console.WriteLine();
            Console.WriteLine($"Shipping Price: ${order.GetShippingPrice()}.00");
            Console.WriteLine($"Total Price: ${Math.Round(order.CalcTotalPrice(), 2)}\n");
        }
    }
}