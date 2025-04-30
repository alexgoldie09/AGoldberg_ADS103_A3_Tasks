/*
 * BinarySearchTree.cs
 * --------------------
 * This file implements a basic Binary Search Tree (BST) data structure and related operations.
 *
 * Tasks:
 *  - The BSTNode class represent nodes with left and right children that contain integer data.
 *  - The BinarySearchTree class provides methods for insertion, searching, and printing.
 *      - Insertion follows the recursive method used by GeekforGeeks (2024a).
 *      - Searching follows the recursive method used by GeeksforGeeks (2024b) modified.
 *      - Performs Step 1 of the instructions.
 *  - Intended for demonstration and performance comparison with other data structures (e.g., AVL Tree).
 *
 * Extras:
 *  - Null pointers are used throughout to allow the BSTNode to hold null values.
 *
 * References:
 *  GeeksForGeeks. (2024, August 21). Binary Search Tree (BST) Traversals – Inorder, Preorder, Post Order. GeeksforGeeks. 
 *  https://www.geeksforgeeks.org/binary-search-tree-traversal-inorder-preorder-post-order/
 *  GeeksforGeeks. (2024, September 24a). Insertion in Binary Search Tree. GeeksforGeeks. 
 *  https://www.geeksforgeeks.org/insertion-in-binary-search-tree/
 *  GeeksforGeeks. (2024b, September 24b). Searching in Binary Search Tree. GeeksforGeeks. 
 *  https://www.geeksforgeeks.org/binary-search-tree-set-1-search-and-insertion/
 *  Microsoft. (2022, January 25). protected keyword - C# reference. Microsoft.com. 
 *  https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/protected
 *  Microsoft. (2025). Stopwatch Class (System.Diagnostics). Microsoft.com.
 *  https://learn.microsoft.com/en-us/dotnet/api/system.diagnostics.stopwatch?view=net-9.0
 */

using System;
using System.Diagnostics;

public class BSTNode 
{
    public int data;
    public BSTNode? left, right;

    // Default Constructor
    public BSTNode(int _data) 
    {
        data = _data;
        left = right = null;
    }
}

public class BinarySearchTree
{
    private BSTNode? root;

    // Default constructor
    public BinarySearchTree() 
    {
        root = null;
    }

    /* 
    * Insert() takes an integer value and inserts that value into the tree.
    * - Made public because it is used in the main driver program.
    * - Made virtual so that it can be used for inheritance in Step 2.
    * - Uses a helper method to help handle the insertion.
    */
    public virtual void Insert(int data)
    {
        root = InsertRecursive(root, data);
    }

    /* 
    * InsertRecursive() takes an integer value, and BSTNode, then recursively inserts to return a node.
    * - Made private because BSTNode is specific to this class.
    * - If the current node is null, a new root is created.
    * - If data is less than current, recurse and insert to the left.
    * - If data is greater, recurse and insert to the right.
    */
    private BSTNode InsertRecursive(BSTNode? node, int data) 
    {
        if (node == null) { return new BSTNode(data); }

        if (data < node.data)
        {
            node.left = InsertRecursive(node.left, data);
        }
        else if (data > node.data)
        {
            node.right = InsertRecursive(node.right, data);
        }

        return node;
    }

    /* 
    * Search() takes an integer value and searches for that value in the tree.
    * - Made protected virtual because it is an abstracted helper method that is used for inheritance in Step 2.
    * - Uses a helper method to help handle the search.
    */
    protected virtual bool Search(int data)
    {
        return SearchRecursive(root, data);
    }

    /* 
    * SearchRecursive() takes an integer value, and BSTNode, then recursively searches to return a bool.
    * - Made private because BSTNode is specific to this class.
    * - If the current node is null, return false.
    * - Returns true if the value exists by recursing through the tree.
    * - Otherwise, returns false.
    */
    private bool SearchRecursive(BSTNode? node, int data)
    {
        if (node == null) { return false; }
        if (data == node.data) { return true; }

        return data < node.data
            ? SearchRecursive(node.left, data)
            : SearchRecursive(node.right, data);
    }

    /* 
    * TimedSearch() takes an integer value, measures and prints the time taken to search for that value.
    * - Made public because it is used in the main driver program.
    * - Uses Stopwatch library to time execution.
    * - Uses a helper method to help handle the search.
    * - Prints whether the value was found and how long the search took.
    */
    public void TimedSearch(int data)
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Restart();

        bool found = Search(data);

        stopwatch.Stop();
        TimeSpan tsSearch = stopwatch.Elapsed;

        if (found)
        {
            Console.WriteLine($"\nValue {data} found in tree.");
        }
        else
        {
            Console.WriteLine($"\nValue {data} NOT found in tree.");
        }

        Console.WriteLine($"Search Time: {tsSearch.TotalMilliseconds:F6} ms");
    }
}