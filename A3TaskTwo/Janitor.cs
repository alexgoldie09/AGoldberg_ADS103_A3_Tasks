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