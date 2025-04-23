using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;

public class Program
{
    private const int MAX_RANDOM_COUNT = 150000;
    private static bool hasQuit = false;
    // Initialise data structures
    private static LinkedList<int> linkedList = new LinkedList<int>();
    private static BinarySearchTree bst = new BinarySearchTree();
    private static AVLTree avl = new AVLTree();

    public static void Main()
    {
        // Generate random data
        int[] data = GenerateRandomNumbers(MAX_RANDOM_COUNT);

        // Insert random data into data structures
        AddToLinkedList(linkedList, data);
        AddToBST(bst, data);
        AddToAVL(avl, data);

        // Call menu loop
        MenuDisplay(data);
    }

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

    private static void AddToLinkedList(LinkedList<int> list, int[] data)
    {
        foreach (int d in data)
        {
            list.AddLast(d);
        }
    }

    private static void AddToBST(BinarySearchTree bst, int[] data)
    {
        foreach (int d in data)
            bst.Insert(d);
    }

    private static void AddToAVL(AVLTree avl, int[] data)
    {
        foreach (int d in data)
            avl.Insert(d);
    }

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
