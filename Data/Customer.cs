using System;
using System.Collections.Generic;
using System.Text;

namespace MCPServer.Data
{
    public record Customer(
        int Id,
        string Name,
        string Email,
        string Country 
    )
    {

    }
}
