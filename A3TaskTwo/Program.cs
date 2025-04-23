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

        // Mix of Employee types (Janitor, Programmer, CEO)
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

        Console.WriteLine("=== Internal Heap (not sorted, but max at top) ===\n");
        heap.PrintHeap(); // Shows heap structure
        Console.WriteLine();

        Console.WriteLine("=== Employees Sorted by Salary (High → Low) ===");
        while (true)
        {
            Employee? top = heap.ExtractMax(); // Removes one employee
            if (top == null) break;

            top.OutputJobDescription();
            top.OutputEarnings();
        }
    }
}