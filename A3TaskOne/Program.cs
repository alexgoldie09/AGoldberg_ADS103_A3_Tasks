/*
 * Program.cs
 * --------------------
 * This file contains the main entry point and logic for benchmarking and comparing search performance
 * across three data structures:
 *   - LinkedList<int> (sequential structure)
 *   - BinarySearchTree (unbalanced)
 *   - AVLTree (self-balancing)
 *
 * Tasks:
 *   - Generates 150,000 random integers to populate each data structure.
 *   - Displays a menu allowing the user to search for a number in all structures.
 *   - Shows a sample of existing numbers to help the user.
 *   - Measures and prints search time for each structure.
 *
 * Extras:
 *  Microsoft. (2025). Stopwatch Class (System.Diagnostics). Microsoft.com.
 *  https://learn.microsoft.com/en-us/dotnet/api/system.diagnostics.stopwatch?view=net-9.0
 *  Microsoft. (2025). LinkedList<T> Class (System.Collections.Generic). Microsoft.com.
 *  https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.linkedlist-1?view=net-9.0
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;

public class Program
{
    private const int MAX_RANDOM_COUNT = 150000;
    private static bool hasQuit = false;

     // Initialise global data structures once at program start
    private static LinkedList<int> linkedList = new LinkedList<int>();
    private static BinarySearchTree bst = new BinarySearchTree();
    private static AVLTree avl = new AVLTree();

    /*
     * Main() is the entry point for the program.
     * - Generates random data (Step 3).
     * - Fills each data structure with the same values (Step 3).
     * - Starts the interactive menu loop (Step 4).
     */
    public static void Main()
    {
        int[] data = GenerateRandomNumbers(MAX_RANDOM_COUNT);

        AddToLinkedList(linkedList, data);
        AddToBST(bst, data);
        AddToAVL(avl, data);

        MenuDisplay(data);
    }

    /*
     * MenuDisplay() shows the main menu loop.
     * - Displays menu until the user chooses to exit.
     * - Clears the screen between interactions for clarity.
     * - Passes generated data to allow hint display.
     */
    private static void MenuDisplay(int[] randomData)
    {
        while(!hasQuit)
        {
            Console.Clear();
            Console.WriteLine("Select an option:");
            Console.WriteLine("1) Search for a number in all data structures");
            Console.WriteLine("2) Exit");

            int input = GetValidInput();

            Console.Clear();
            MenuSwitch(input, randomData);

            if (!hasQuit)
            {
                Console.WriteLine("\nPress Enter to return to the main menu...");
                Console.ReadLine();
            }
        }
    }

    /*
     * MenuSwitch() takes an integer input and integer array of random values, then routes
     * menu input to the correct handler.
     * - Case 1: Runs search logic on all structures using a helper method that takes the random values.
     * - Case 2: Exits the loop.
     */
    private static void MenuSwitch(int input, int[] randomData)
    {
        switch (input)
        {
            case 1:
                SearchForNumberInDataStructures(randomData);
                break;
            case 2:
                hasQuit = true;
                Console.WriteLine("Exiting program. Goodbye!");
                break;
        }
    }

    /*
     * GetValidInput() waits for user input and ensures it's within valid menu bounds.
     * - Repeats until the user enters 1 or 2.
     */
    private static int GetValidInput()
    {
        int choice;
        while(true)
        {
            Console.Write("\nEnter in option (1 – 2): ");
            string? input = Console.ReadLine();

            if (int.TryParse(input, out choice) && choice >= 1 && choice <= 2)
                return choice;

            Console.WriteLine("Invalid input. Please enter a number from 1 to 2.");
        }
    }

    /*
     * SearchForNumberInDataStructures() takes an integer array of random values, then runs a 
     * search across all data structures.
     * - Displays helpful values to search using a helper method (random sample from the array).
     * - Prompts the user to input a value.
     * - Displays search results and timing for each structure using the appropriate helper method.
     */
    private static void SearchForNumberInDataStructures(int[] randomData)
    {
        ShowSampleHelpNumbers(randomData);

        Console.Write("Enter the number to search for: ");
        string? input = Console.ReadLine();
        if (!int.TryParse(input, out int data))
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
            return;
        }

        Console.WriteLine($"\nSearching for value {data} in all data structures...");

        Console.WriteLine("\n--- LinkedList Search ---");
        TimedLinkedListSearch(linkedList, data);

        Console.WriteLine("\n--- Binary Search Tree Search ---");
        bst.TimedSearch(data);

        Console.WriteLine("\n--- AVL Tree Search ---");
        avl.TimedSearch(data);
    }

    /*
     * GenerateRandomNumbers() takes an integer count, then creates an array of random integers.
     * - Values range from 1 to 1,000,000 inclusive.
     */
    private static int[] GenerateRandomNumbers(int count)
    {
        Random rand = new Random();
        int[] nums = new int[count];
        for (int i = 0; i < count; i++)
        {
            nums[i] = rand.Next(1, 1000000);
        }
        return nums;
    }

    /*
     * ShowSampleHelpNumbers() takes an integer array of random values, then displays 10 randomly
     * sampled values from the array.
     * - Avoids duplicates using List.Contains()
     * - Helps the user know what values are guaranteed to be searchable.
     */
    private static void ShowSampleHelpNumbers(int[] randomData)
    {
        if (randomData == null || randomData.Length == 0) return;

        Random rand = new Random();
        List<int> sample = new List<int>();

        while (sample.Count < 10)
        {
            int index = rand.Next(randomData.Length);
            int value = randomData[index];

            if (!sample.Contains(value))
            {
                sample.Add(value);
            }
        }

        Console.WriteLine("\nIf you need help, these numbers exist in the data:");
        Console.WriteLine(string.Join(", ", sample));
    }

    /*
     * AddToLinkedList() takes a LinkedList<int> and values from an integer array, then fills it.
     * - AddLast() ensures that the original order of the data is preserved as it's inserted.
     *  - Ensures a fair comparison when searching.
     */
    private static void AddToLinkedList(LinkedList<int> list, int[] data)
    {
        foreach (int d in data)
        {
            list.AddLast(d);
        }
    }

    /*
     * AddToBST() takes a BinarySearchTree and values from an integer array, then fills it.
     */
    private static void AddToBST(BinarySearchTree bst, int[] data)
    {
        foreach (int d in data)
        {
            bst.Insert(d);
        }
    }

    /*
     * AddToAVL() takes a AVLTree and values from an integer array, then fills it.
     */
    private static void AddToAVL(AVLTree avl, int[] data)
    {
        foreach (int d in data)
        {
            avl.Insert(d);
        }
    }

    /* 
    * TimedSearch() takes an integer value and a LinkedList<int>, measures and prints the time 
    * taken to search for that value.
    * - Uses Stopwatch library to time execution.
    * - Uses a standard iterative loop to search.
    * - Prints whether the value was found and how long the search took.
    */
    private static void TimedLinkedListSearch(LinkedList<int> list, int data)
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Restart();

        bool found = false;
        foreach (int d in list)
        {
            if (d == data)
            {
                found = true;
                break;
            }
        }

        stopwatch.Stop();
        TimeSpan tsSearch = stopwatch.Elapsed;

        if (found)
        {
            Console.WriteLine($"\nValue {data} found in LinkedList.");
        }
        else
        {
            Console.WriteLine($"\nValue {data} NOT found in LinkedList.");
        }

        Console.WriteLine($"Search Time: {tsSearch.TotalMilliseconds:F6} ms");
    }
}
