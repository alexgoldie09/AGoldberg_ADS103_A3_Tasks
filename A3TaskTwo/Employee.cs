using System;

public abstract class Employee
{
    // Protected fields accessible to derived classes to modify stats if required.
    // Microsoft. (2022, January 25). protected keyword - C# reference. Microsoft.com. 
    // https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/protected
    protected string name = "";
    protected int salary;

    // Constructor to initialise employee attributes.
    public Employee(string newName, int newSalary)
    {
        name = newName;
        salary = newSalary;
    }

    public void OutputEarnings()
    {
        Console.WriteLine($"{name} earns a salary of ${salary} per year.");
    }

    public virtual void OutputJobDescription()
    {
        Console.WriteLine();
    }

    #region Setters and Getters
    public int GetSalary() => salary;
    #endregion
}