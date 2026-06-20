# Chain of Responsibility Pattern - ATM Cash Dispenser

## Overview

This project demonstrates the **Chain of Responsibility Design Pattern** using a simple ATM cash dispenser example in C#.

When a user enters an amount to withdraw, the request is passed through a chain of note dispensers:

* ₹500 Note Dispenser
* ₹200 Note Dispenser
* ₹100 Note Dispenser

Each dispenser processes as much of the amount as it can and forwards the remaining amount to the next dispenser in the chain.

The project also demonstrates how to use **Dependency Injection (DI)** in a .NET Console Application using `Microsoft.Extensions.DependencyInjection`.

---

## Design Pattern Used

### Chain of Responsibility

The Chain of Responsibility pattern allows a request to be passed through a chain of handlers. Each handler decides whether it can process the request and optionally forwards the remaining work to the next handler.

### Benefits

* Loose coupling between sender and receivers.
* Easy to add new handlers without modifying existing ones.
* Follows the Open/Closed Principle.
* Improves maintainability and extensibility.

---

## Project Structure

```text
ChainOfResponsibilityPattern
│
├── IDispensar.cs
├── DispensarBase.cs
├── NoteDispensars.cs
│   ├── FiveHunderedNoteDispensar
│   ├── TwoHundredNoteDispensar
│   └── HundredNoteDispensar
│
└── Program.cs
```

---

## Components

### IDispensar

Defines the contract that every dispenser must implement.

```csharp
public interface IDispensar
{
    void Dispense(int amount);
}
```

### DispensarBase

Abstract base class that stores the reference to the next handler in the chain.

```csharp
public abstract class DispensarBase : IDispensar
{
    protected readonly IDispensar? Next;

    protected DispensarBase(IDispensar? dispensar)
    {
        Next = dispensar;
    }

    public abstract void Dispense(int amount);
}
```

### Concrete Dispensers

* FiveHunderedNoteDispensar
* TwoHundredNoteDispensar
* HundredNoteDispensar

Each dispenser handles its denomination and forwards the remaining amount to the next dispenser.

---

## Dependency Injection Configuration

The chain is assembled using the built-in .NET Dependency Injection container.

```csharp
services.AddTransient<IDispensar>(sp =>
    new FiveHunderedNoteDispensar(
        new TwoHundredNoteDispensar(
            new HundredNoteDispensar()
        )
    )
);
```

The application retrieves the root handler from the container:

```csharp
IDispensar dispensar =
    serviceProvider.GetRequiredService<IDispensar>();
```

---

## Execution Flow

Example request:

```text
Amount = 1800
```

Processing:

```text
1800 -> FiveHundredNoteDispensar
      -> Dispense 3 x 500
      -> Remaining 300

300 -> TwoHundredNoteDispensar
     -> Dispense 1 x 200
     -> Remaining 100

100 -> HundredNoteDispensar
     -> Dispense 1 x 100
```

Output:

```text
Dispensed 500 Note: 3
Dispensed 200 Note: 1
Dispensed 100 Note: 1
```

---

## Prerequisites

* .NET 8 (or later)
* Visual Studio 2022 / VS Code

---

## Running the Application

1. Clone the repository.

```bash
git clone <repository-url>
```

2. Navigate to the project folder.

```bash
cd ChainOfResponsibilityPattern
```

3. Restore dependencies.

```bash
dotnet restore
```

4. Run the application.

```bash
dotnet run
```

5. Enter an amount that is a multiple of 100.

Example:

```text
Enter the amount (Amount should be multiple of hundred):
1800
```

---

## Key Concepts Demonstrated

* Chain of Responsibility Pattern
* Dependency Injection in Console Applications
* Dependency Inversion Principle (DIP)
* Constructor Injection
* Loose Coupling
* Object Composition

---

## Future Enhancements

* Add support for ₹50 and ₹20 notes.
* Implement logging using `Microsoft.Extensions.Logging`.
* Create unit tests using xUnit.
* Make denominations configurable through `appsettings.json`.
* Automatically build the chain using DI registrations.

---

## Author

Created as a learning project to understand and implement the Chain of Responsibility Design Pattern in C# and .NET.
