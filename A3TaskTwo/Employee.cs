/*
 * Employee.cs
 * ------------
 * This file defines the abstract base class `Employee`, which is the foundation for multiple employee 
 * types (e.g., CEO, Programmer, Janitor). It provides shared fields and methods for handling employee
 * data such as name, salary, and job responsibilities.
 *
 * Tasks:
 *  - Define common fields (`name`, `salary`) with protected access for inheritance.
 *  - Provide a base constructor to initialise name and salary.
 *  - Implements a print earnings which is shared, and print job description base to be overriden.
 *  - A getter method for salary to allow external classes to access but not be able to set.
 *  - Performs Step 1.
 *
 * Extras:
 *  Intended for use in polymorphic operations such as storing in a MaxHeap of type Employee.
 *
 * References:
 *  Microsoft. (2022, January 25). protected keyword - C# reference. Microsoft.com. 
 *  https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/protected
 */
using System;

public abstract class Employee
{
    protected string name = "";
    protected int salary;

    // Constructor to initialise employee attributes.
    public Employee(string newName, int newSalary)
    {
        name = newName;
        salary = newSalary;
    }

    /*
     * OutputEarnings() prints the employee's name and salary to the console.
     * - Used across all employee types without needing to override.
     */
    public void OutputEarnings()
    {
        Console.WriteLine($"{name} earns a salary of ${salary} per year.");
    }

    /*
     * OutputJobDescription() prints a role-specific job description.
     * - Virtual method to be overridden by subclasses.
     */
    public virtual void OutputJobDescription()
    {
        Console.WriteLine(); // Placeholder for override
    }

    #region Setters and Getters
    /*
     * GetSalary() getter method to retrieve the employee's salary.
     * - Used in MaxHeap for comparing employees.
     */
    public int GetSalary() => salary;
    #endregion
}