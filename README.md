# MCPServer

MCPServer is a .NET console application that exposes customer and order data through the [Model Context Protocol (MCP)](https://modelcontextprotocol.io/). It communicates over stdio, making it suitable for use with MCP-compatible clients such as AI assistants and developer tools.

## Features

- Retrieve a customer by ID
- List all customers
- Search customers by name or email
- Retrieve orders for a customer
- Discover tools automatically from the `Tools` assembly
- Use an in-memory repository with seeded sample data

## Requirements

- .NET 10 SDK
- An MCP-compatible client that supports stdio servers

Verify the installed SDK with:

```bash
dotnet --version
```

## Getting Started

From the project directory, restore dependencies and build the server:

```bash
dotnet restore
dotnet build
```

Run the server directly with:

```bash
dotnet run
```

The server waits for MCP messages on standard input and writes protocol messages to standard output. Logging is configured for standard error so it does not interfere with the stdio protocol.

## MCP Client Configuration

Configure your MCP client to launch the compiled application. For clients that use a JSON server configuration, the entry generally looks like this:

```json
{
  "mcpServers": {
    "mcpserver": {
      "command": "dotnet",
      "args": [
        "run",
        "--project",
        "C:/Projects/Workspace/MCPServer/MCPServer.csproj"
      ]
    }
  }
}
```

For a more stable client configuration, build first and point the client at the generated DLL:

```json
{
  "mcpServers": {
    "mcpserver": {
      "command": "dotnet",
      "args": [
        "C:/Projects/Workspace/MCPServer/bin/Debug/net10.0/MCPServer.dll"
      ]
    }
  }
}
```

Replace the paths with the absolute path used on your machine. On Windows, JSON paths can use forward slashes as shown above.

## Available Tools

The server exposes the following MCP tools:

| Tool | Parameters | Description |
| --- | --- | --- |
| `GetCustomerById` | `id: int` | Returns one customer, or `null` when no customer matches. |
| `GetAllCustomers` | None | Returns all customers. |
| `Search` | `query: string` | Finds customers whose name or email contains the query, case-insensitively. |
| `GetOrdersByCustomerId` | `customerId: int` | Returns all orders belonging to a customer. |

Tool names and descriptions are discovered by the MCP client from the server metadata.

## Data Model

Customers contain:

- `Id`
- `Name`
- `Email`
- `Country`

Orders contain:

- `Id`
- `CustomerId`
- `Product`
- `Price`
- `Total`
- `Ordered`

The default repository contains six sample customers and six sample orders. Order timestamps are generated when the application starts.

## Project Structure

```text
MCPServer/
├── Data/
│   ├── Customer.cs
│   ├── DataRepositiory.cs
│   ├── IDataRepository.cs
│   └── Order.cs
├── Tools/
│   └── DataTools.cs
├── MCPServer.csproj
└── Program.cs
```

- `Program.cs` configures dependency injection, logging, stdio transport, and tool discovery.
- `Data/` contains the data records and repository abstraction.
- `Tools/DataTools.cs` adapts repository operations into MCP tools.

## Development Notes

The application is intentionally small and uses in-memory data for demonstration and development. Restarting the server resets all data. To connect a persistent data source, implement `IDataRepository` and register the replacement in `Program.cs`.

There are currently no automated tests in the repository. A useful next step for production use would be unit tests for repository queries and MCP tool behavior, followed by a persistent repository and input validation.

## License

No license has been specified for this project.