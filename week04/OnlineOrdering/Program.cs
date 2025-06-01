using System;
using System.Collections.Generic;

// Main program
class Program
{
    static void Main(string[] args)
    {
        // First Order - USA
        Address address1 = new Address("123 Apple Street", "Provo", "UT", "USA");
        Customer customer1 = new Customer("Emily Johnson", address1);
        Order order1 = new Order(customer1);

        order1.AddProduct(new Product("Laptop", "LAP123", 899.99, 1));
        order1.AddProduct(new Product("Mouse", "MOU456", 19.99, 2));

        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order1.GetTotalPrice():F2}");
        Console.WriteLine("\n--------------------------------------\n");

        // Second Order - International
        Address address2 = new Address("77 Banana Ave", "Lagos", "Lagos", "Nigeria");
        Customer customer2 = new Customer("Chinedu Okoro", address2);
        Order order2 = new Order(customer2);

        order2.AddProduct(new Product("Smartphone", "SMP789", 299.99, 1));
        order2.AddProduct(new Product("Earbuds", "EAR321", 49.99, 1));
        order2.AddProduct(new Product("Charger", "CHR654", 25.99, 1));

        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order2.GetTotalPrice():F2}");
    }
}
