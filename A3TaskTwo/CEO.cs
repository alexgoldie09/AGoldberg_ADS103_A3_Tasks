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