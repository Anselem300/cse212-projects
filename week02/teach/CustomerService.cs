using System;
using System.Collections.Generic;

/// <summary>
/// Maintain a Customer Service Queue. Allows new customers to be
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService
{
    public static void Run()
    {
        Console.WriteLine("Test 1: Invalid max size defaults to 10");
        var cs1 = new CustomerService(0);
        Console.WriteLine(cs1);
        Console.WriteLine("Expected: max_size=10");
        Console.WriteLine("=================");

        Console.WriteLine("Test 2: Add customers up to max size");
        var cs2 = new CustomerService(2);
        cs2.AddTestCustomer("Alice", "A1", "Login issue");
        cs2.AddTestCustomer("Bob", "B2", "Payment issue");
        Console.WriteLine(cs2);
        Console.WriteLine("Expected: size=2");
        Console.WriteLine("=================");

        Console.WriteLine("Test 3: Add customer when queue is full");
        cs2.AddTestCustomer("Charlie", "C3", "Network issue");
        Console.WriteLine("=================");

        Console.WriteLine("Test 4: Serve customer when queue has items");
        cs2.ServeCustomer();
        Console.WriteLine("=================");

        Console.WriteLine("Test 5: Serve customer when queue is empty");
        var cs3 = new CustomerService(1);
        cs3.ServeCustomer();
        Console.WriteLine("=================");
    }

    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize)
    {
        _maxSize = maxSize <= 0 ? 10 : maxSize;
    }

    /// <summary>
    /// Defines a Customer record for the service queue.
    /// </summary>
    private class Customer
    {
        public Customer(string name, string accountId, string problem)
        {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }

        public override string ToString()
        {
            return $"{Name} ({AccountId}) : {Problem}";
        }
    }

    /// <summary>
    /// Adds a new customer using console input.
    /// </summary>
    private void AddNewCustomer()
    {
        if (_queue.Count >= _maxSize)
        {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }

        Console.Write("Customer Name: ");
        var name = Console.ReadLine()!.Trim();

        Console.Write("Account Id: ");
        var accountId = Console.ReadLine()!.Trim();

        Console.Write("Problem: ");
        var problem = Console.ReadLine()!.Trim();

        _queue.Add(new Customer(name, accountId, problem));
    }

    /// <summary>
    /// Dequeues and serves the next customer.
    /// </summary>
    private void ServeCustomer()
    {
        if (_queue.Count == 0)
        {
            Console.WriteLine("No customers to serve.");
            return;
        }

        var customer = _queue[0];
        Console.WriteLine(customer);
        _queue.RemoveAt(0);
    }

    /// <summary>
    /// Helper method for automated testing (no console input).
    /// </summary>
    private void AddTestCustomer(string name, string accountId, string problem)
    {
        if (_queue.Count >= _maxSize)
        {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }

        _queue.Add(new Customer(name, accountId, problem));
    }

    public override string ToString()
    {
        return $"[size={_queue.Count} max_size={_maxSize} => {string.Join(", ", _queue)}]";
    }
}
