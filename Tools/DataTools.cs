using MCPServer.Data;
using ModelContextProtocol.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MCPServer.Tools
{
    [McpServerToolType]
    public class DataTools(IDataRepository repo)
    {
        [McpServerTool, Description("Get a customer by ID.")]
        public Customer? GetCustomerById(int id)
        {
            return repo.GetCustomerById(id);
        }

        [McpServerTool, Description("Get all customers.")]  
        public IEnumerable<Customer> GetAllCustomers()
        {
            return repo.GetAllCustomers();
        }

        [McpServerTool, Description("Search for customers.")]
        public IEnumerable<Customer> Search(string query)
        {
            return repo.Search(query);
        }

        [McpServerTool, Description("Get orders by customer ID.")]
        public IEnumerable<Order> GetOrdersByCustomerId(int customerId)
        {
            return repo.GetOrdersByCustomerId(customerId);
        }
    }
}
