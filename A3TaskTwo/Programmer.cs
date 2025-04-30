/*
 * Programmer.cs
 * -----------
 * This file defines the `Programmer` class, which inherits from the abstract `Employee` class.
 * It represents Programmer staff within an organisation.
 *
 * Tasks:
 *  - New variables added - bugsFixed, bugsCreated.
 *  - Provide constructors for both default and custom initialisation of Programmer objects.
 *  - Overrides base to display Programmer-specific role description and their bugs fixed and bugs created.
 *  - Used in polymorphic structures such as max heap sorting by salary.
 *  - Performs Step 2.
 *
 * References:
 *  Microsoft. (2022). C# Inheritance and base keyword. 
 *  https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/inheritance
 */

using System;
public class Programmer: Employee
{
    public int bugsFixed;
    public int bugsCreated;

    // Constructor with default values for Programmer.
    public Programmer() 
    : base(newName: "Alexander Goldberg", newSalary: 120000) 
    {
        bugsFixed = 100; // Default bugs fixed
        bugsCreated = 20; // Default bugs created
    }

    // Overloaded constructor allowing custom stat values.
    public Programmer(string newName, int newSalary, int newBugsFixed, int newBugsCreated) 
    : base(newName, newSalary) 
    {
        bugsFixed = newBugsFixed;
        bugsCreated = newBugsCreated;
    }

    public override void OutputJobDescription()
    {
        base.OutputJobDescription(); // Print new line
        Console.WriteLine($"{name} is a programmer. They write and maintain code for software products.");
        Console.WriteLine($"Bugs Fixed: {bugsFixed}");
        Console.WriteLine($"Bugs Created: {bugsCreated}");
    }

}