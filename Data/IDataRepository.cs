using System;
using System.Collections.Generic;
using System.Text;

namespace MCPServer.Data
{
    public interface IDataRepository
    {

        Customer? GetCustomerById(int id);
        IEnumerable<Customer> GetAllCustomers();
        IEnumerable<Customer> Search(string query);
        IEnumerable<Order> GetOrdersByCustomerId(int customerId);

    }
}
