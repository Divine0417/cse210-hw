using System;
using System.Collections.Generic;

// Address class
public class Address
{
    private string street;
    private string city;
    private string stateOrProvince;
    private string country;

    public Address(string street, string city, string stateOrProvince, string country)
    {
        this.street = street;
        this.city = city;
        this.stateOrProvince = stateOrProvince;
        this.country = country;
    }

    public bool IsInUSA()
    {
        return country.Trim().ToUpper() == "USA";
    }

    public string GetFullAddress()
    {
        return $"{street}\n{city}, {stateOrProvince}\n{country}";
    }
}

// Customer class
public class Customer
{
    private string name;
    private Address address;

    public Customer(string name, Address address)
    {
        this.name = name;
        this.address = address;
    }

    public string GetName()
    {
        return name;
    }

    public Address GetAddress()
    {
        return address;
    }

    public bool LivesInUSA()
    {
        return address.IsInUSA();
    }
}

// Product class
public class Product
{
    private string name;
    private string productId;
    private double pricePerUnit;
    private int quantity;

    public Product(string name, string productId, double pricePerUnit, int quantity)
    {
        this.name = name;
        this.productId = productId;
        this.pricePerUnit = pricePerUnit;
        this.quantity = quantity;
    }

    public string GetPackingLabel()
    {
        return $"{name} (ID: {productId})";
    }

    public double GetTotalCost()
    {
        return pricePerUnit * quantity;
    }
}

// Order class
public class Order
{
    private List<Product> products = new List<Product>();
    private Customer customer;

    public Order(Customer customer)
    {
        this.customer = customer;
    }

    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    public double GetTotalPrice()
    {
        double total = 0;
        foreach (Product p in products)
        {
            total += p.GetTotalCost();
        }

        // Shipping cost
        total += customer.LivesInUSA() ? 5.0 : 35.0;
        return total;
    }

    public string GetPackingLabel()
    {
        string label = "Packing Label:\n";
        foreach (Product p in products)
        {
            label += "- " + p.GetPackingLabel() + "\n";
        }
        return label;
    }

    public string GetShippingLabel()
    {
        return $"Shipping Label:\n{customer.GetName()}\n{customer.GetAddress().GetFullAddress()}";
    }
}

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
