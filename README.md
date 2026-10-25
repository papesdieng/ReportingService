# ReportingService

ReportingService is a small example of **Hexagonal Architecture** (also known as Ports and Adapters) implemented with ASP.NET Core and Entity Framework Core. It demonstrates keeping the trade use case independent of the web framework and database implementation by connecting the core to external technologies through interfaces (ports).

## Project structure

- **`ReportingService.Entities`** — Trade model used by the application.
- **`ReportingService.Ports`** — Repository interface (`ITradeRepository`), the persistence port used by the domain service.
- **`ReportingService.Domain`** — Trade service contract and use-case implementation (`ITradeService`, `TradeService`). It coordinates the use case through the repository port rather than depending on Entity Framework.
- **`ReportingService.Adapters`** — Outbound persistence adapter: the Entity Framework `ReportingDbContext` and `TradeRepository` implementation of `ITradeRepository`.
- **`ReportingService`** — ASP.NET Core Web API, including the `TradeController` inbound adapter and dependency-injection configuration.
- **`ReportingService.Domain.Unit.Tests`** — Domain unit tests using TUnit, with NSubstitute for test doubles.

## Technology stack

- .NET 10 and C#
- ASP.NET Core Web API
- Entity Framework Core with the SQL Server provider
- TUnit for unit tests
- NSubstitute for substituting ports in unit tests

## Request flow

For `GET /api/trades`, the request passes through these layers:

1. The API's `TradeController` receives the HTTP request and calls `ITradeService`.
2. The domain's `TradeService` runs the use case and calls the `ITradeRepository` port.
3. The adapter's `TradeRepository` implements that port and reads trades through `ReportingDbContext` and Entity Framework Core.
4. The result returns to the controller, which responds with HTTP 200 and the trades.

The API project wires the service and repository implementations into dependency injection at startup. This keeps the domain's use-case logic from directly depending on ASP.NET Core or EF Core, and makes it possible to replace an adapter without changing the port contract.

## Run the API

The solution targets .NET 10. From the repository root:

```powershell
dotnet restore ReportingService.slnx
dotnet run --project ReportingService\ReportingService.csproj
```

The API uses the `DefaultConnection` connection string from `ReportingService\appsettings.json`. The checked-in default is SQL Server LocalDB; provide a suitable SQL Server connection string through ASP.NET Core configuration when running in another environment. Swagger is enabled in the Development environment.

The trade endpoint is:

```text
GET /api/trades
```

## Run the tests

The repository opts into the Microsoft Testing Platform runner for .NET test commands. Run the unit tests from the repository root:

```powershell
dotnet test ReportingService.slnx
```

The `TradeService` test substitutes `ITradeRepository` and checks that the service returns the expected trade data and forwards the cancellation token to the repository.
