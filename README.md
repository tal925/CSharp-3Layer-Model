# CSharp 3-Layer Model: Cashier and Inventory System

A Windows Forms desktop application for a food business, built with C# and .NET using a three-layer architecture (presentation, business logic and data access). It manages customers, products and sales promotions, and calculates orders at a cashier screen. Data is stored in XML files.

## Features

- Cashier screen: build an order from products, with the price calculated in the business layer and promotions applied to order lines
- Stock check on orders: the system verifies that a product exists and is in stock, and completing an order updates the stock
- Management screens for customers, products and sales (promotions)
- Product categories: pizza, salad, pasta, dessert and beverage
- XML-file persistence for customers, products and sales, with auto-incrementing IDs for products and sales
- A swappable data layer: an XML implementation (default) and an in-memory implementation

## Architecture

| Layer | Projects | Responsibility |
|-------|----------|----------------|
| Presentation | `UI` | Windows Forms screens for the cashier, manager, customers, products and sales |
| Business logic | `BL` (`BlApi`, `BlImplementation`, `BO`) | Business operations, business objects (BO) and business exceptions. For example, order calculations and stock updates are in `OrderImplementation.cs` |
| Data access | `DalFacade`, `DalXml`, `DalList` | `DalFacade` defines the data objects (DO) and the contracts; `DalXml` stores data in XML files and `DalList` stores it in memory |

`DalTest` and `BLTest2` are console projects used for manual testing of the data and business layers.

## Domain Model

| Entity | Main properties |
|--------|-----------------|
| Customer | ID, name, address, phone |
| Product | ID, name, category, price, stock amount |
| Sale (promotion) | ID, product, minimum quantity, sale price, applies to everyone, start and end dates |
| Order and order line | Calculated in the business layer: products, amounts, applied sales and final price |

Only customers, products and sales are persisted. Orders are calculated in the business layer and are not saved.

## Design

- **Interfaces and abstraction:** `IBL`, `IProduct`, `ICustemer`, `ISale`, `IOrder`, and on the data side `IDal` and a generic `ICrud<T>` that the entity interfaces inherit
- **Factories:** `BlApi/Factory.cs` creates the business layer and `DalApi/Factory.cs` loads the data layer selected in `dal-config.xml`
- **Singleton:** `DalXml` and `DalList` use a private constructor and a static instance
- **Mapping:** business objects (BO) and data objects (DO) are mapped manually, with `CopyToBO` and `CopyToDO` in `BO/Tools.cs`
- **Custom exceptions:** `BlDoesNotExistException`, `BlAlreadyExistsException` and `BlInvalidDataException` in the business layer; `DalDoesNotExistException`, `DalAlreadyExistsException` and `DalConfigException` in the data layer. Business-layer methods translate data-layer exceptions into business exceptions

## Data Storage

The data layer is selected in `dal-config.xml` (`xml` by default). The XML files are in the `xml` folder:

- `custemers.xml`: customers, read and written with `XmlSerializer`
- `products.xml` and `sales.xml`: products and sales, read and written with `XElement`
- `data-config.xml`: the ID counters for products and sales

No database is used.

## Tech Stack

| Area | Technologies |
|------|--------------|
| Language | C# |
| Framework | .NET 6, Windows Forms |
| Storage | XML (`XmlSerializer`, `XElement`) |

## Getting Started

### Prerequisites

- Windows
- Visual Studio, or the .NET SDK, with support for `net6.0-windows`

### Run

Open `DotNet2026_9146_3180.sln` in Visual Studio, set `UI` as the startup project and run it.

Or from PowerShell in the repository root:

```powershell
dotnet build .\DotNet2026_9146_3180.sln
Set-Location .\UI
dotnet run --project .\UI.csproj
```

The XML paths in the data layer are relative to the working directory, so when running from the command line, start the app from the `UI` folder.

## Known Limitations

- Orders are not saved after they are completed, only the product stock is updated
- Input validation is partial: the cashier screen and forms check basic input, but not every field
- There are no unit tests; the console projects `DalTest` and `BLTest2` are for manual testing
- The application runs on Windows only
