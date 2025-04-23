using System;
public class Programmer: Employee
{
    public int bugsFixed;
    public int bugsCreated;

    // Constructor with default values for CEO.
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