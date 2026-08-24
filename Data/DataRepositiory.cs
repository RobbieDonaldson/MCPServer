using System;
using System.Collections.Generic;
using System.Text;

namespace MCPServer.Data
{

    

    public class DataRepositiory : IDataRepository
    {
        public readonly List<Customer> _customers = new()
        {
            new Customer(1, "John Doe1", "john.doe@example.com", "USA"),
            new Customer(2, "Jane Smith", "jane.smith@example.com", "Canada"),
            new Customer(3, "Bob Johnson", "bob.johnson@example.com", "UK"),
            new Customer(4, "Alice Williams", "alice.williams@example.com", "Australia"),
            new Customer(5, "Charlie Brown", "charlie.brown@example.com", "Germany"),
            new Customer(6, "Diana Davis", "diana.davis@example.com", "France"),
        };

        public readonly List<Order> _orders = new()
        {
            new Order(1, 1, "Product A", 100.00m, 100.00m, DateTime.Now),
            new Order(2, 2, "Product B", 200.00m, 200.00m, DateTime.Now),
            new Order(3, 3, "Product C", 150.00m, 150.00m, DateTime.Now),
            new Order(4, 4, "Product D", 300.00m, 300.00m, DateTime.Now),
            new Order(5, 5, "Product E", 250.00m, 250.00m, DateTime.Now),
            new Order(6, 6, "Product F", 400.00m, 400.00m, DateTime.Now)
        };

        public Customer? GetCustomerById(int id)
        {
            return _customers.Find(c => c.Id == id);
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return _customers;
        }

        public IEnumerable<Customer> Search(string query) => _customers.FindAll(c => c.Name.Contains(query, StringComparison.OrdinalIgnoreCase) || c.Email.Contains(query, StringComparison.OrdinalIgnoreCase));

        public IEnumerable<Order> GetOrdersByCustomerId(int customerId)
        {
            return _orders.FindAll(o => o.CustomerId == customerId);
        }

    }
}
            