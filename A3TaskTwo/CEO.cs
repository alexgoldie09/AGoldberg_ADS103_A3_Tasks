/*
 * CEO.cs
 * -----------
 * This file defines the `CEO` class, which inherits from the abstract `Employee` class.
 * It represents CEO staff within an organisation.
 *
 * Tasks:
 *  - New variable added - annualBonus.
 *  - Provide constructors for both default and custom initialisation of CEO objects.
 *  - Overrides base to display CEO-specific role description and their annual bonus.
 *  - Used in polymorphic structures such as max heap sorting by salary.
 *  - Performs Step 2.
 *
 * References:
 *  Microsoft. (2022). C# Inheritance and base keyword. 
 *  https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/inheritance
 */

using System;
public class CEO: Employee
{
    public int annualBonus;

    // Constructor with default values for CEO.
    public CEO() 
    : base(newName: "Donald Trump", newSalary: 185000) 
    {
        annualBonus = 20000; // Default annual bonus
    }

    // Overloaded constructor allowing custom stat values.
    public CEO(string newName, int newSalary, int newAnnualBonus) 
    : base(newName, newSalary) 
    {
        annualBonus = newAnnualBonus;
    }

    public override void OutputJobDescription()
    {
        base.OutputJobDescription(); // Print new line
        Console.WriteLine($"{name} is the CEO. They manage the overall direction of the company.");
        Console.WriteLine($"Projected Annual Bonus: ${annualBonus}");
    }
}