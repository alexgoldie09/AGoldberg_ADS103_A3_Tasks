/*
 * Program.cs
 * -----------
 * This is the main entry point for the application.
 * It demonstrates the creation and usage of a MaxHeap of Employee objects.
 * A variety of employee types (CEO, Programmer, Janitor) are inserted, sorted, and printed
 * based on salary in descending order.
 *
 * Tasks:
 *  - Instantiate at least 10 different Employee-derived objects.
 *  - Insert them into a MaxHeap and extract them in order of salary from high to low.
 *  - Print the job description and salary for each employee as they are removed.
 */

using System;
using System.Net.Http.Headers;

public class Program
{
    public static void Main()
    {
        MaxHeap heap = new MaxHeap();

        // DemoTest
        // heap.InsertEmployee(new Janitor());
        // heap.InsertEmployee(new CEO());
        // heap.InsertEmployee(new Programmer());

        // Step 4: Insert a mix of CEO, Programmer, and Janitor objects
        heap.InsertEmployee(new CEO("Alice", 250000, 50000));
        heap.InsertEmployee(new Programmer("Bob", 110000, 150, 20));
        heap.InsertEmployee(new Janitor("Charlie", 45000));
        heap.InsertEmployee(new CEO("Diana", 210000, 30000));
        heap.InsertEmployee(new Programmer("Eve", 95000, 80, 10));
        heap.InsertEmployee(new Janitor("Frank", 50000));
        heap.InsertEmployee(new Programmer("Grace", 105000, 100, 5));
        heap.InsertEmployee(new CEO("Henry", 195000, 25000));
        heap.InsertEmployee(new Janitor("Isabel", 47000));
        heap.InsertEmployee(new Programmer("Jack", 99000, 60, 15));

        // Optional Debug Output: show internal heap structure (not sorted)
        Console.WriteLine("=== Internal Heap (not sorted, but max at top) ===\n");
        heap.PrintHeap();
        Console.WriteLine();

        // Step 5: Extract employees in descending salary order
        Console.WriteLine("=== Employees Sorted by Salary (High → Low) ===");
        while (true)
        {
            // Extract the employee with the highest salary
            Employee? top = heap.ExtractMax();
            if (top == null) break;

            // Print the job description and salary
            top.OutputJobDescription();
            top.OutputEarnings();
        }
    }
}