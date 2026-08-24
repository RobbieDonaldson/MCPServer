using System;
using System.Collections.Generic;
using System.Text;

namespace MCPServer.Data
{
    public record Order(int Id, int CustomerId, string Product, decimal Price, decimal Total, DateTime Ordered)
    {

    }

}
