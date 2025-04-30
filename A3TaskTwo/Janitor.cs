/*
 * Janitor.cs
 * -----------
 * This file defines the `Janitor` class, which inherits from the abstract `Employee` class.
 * It represents janitorial staff within an organisation and overrides the base job description method.
 *
 * Tasks:
 *  - Provide constructors for both default and custom initialisation of Janitor objects.
 *  - Overrides base to display janitor-specific role description.
 *  - Used in polymorphic structures such as max heap sorting by salary.
 *  - Performs Step 2.
 *
 * References:
 *  Microsoft. (2022). C# Inheritance and base keyword. 
 *  https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/inheritance
 */

using System;
public class Janitor: Employee
{
    // Constructor with default values for Janitor.
    public Janitor() 
    : base(newName: "Gary Oldman", newSalary: 80000) {}

    // Overloaded constructor allowing custom stat values.
    public Janitor(string newName, int newSalary) 
    : base(newName, newSalary) {}

    public override void OutputJobDescription()
    {
        base.OutputJobDescription(); // Print new line
        Console.WriteLine($"{name} is a janitor. They are responsible for keeping the workplace clean and organised.");
    }
}