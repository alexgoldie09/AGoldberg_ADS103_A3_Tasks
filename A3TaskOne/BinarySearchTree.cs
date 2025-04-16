using System;
using System.Diagnostics;

public class BinarySearchTree
{
    public BSTNode? root;

    // Default constructor
    public BinarySearchTree() 
    {
        root = null;
    }

    public virtual void Insert(int data)
    {
        root = InsertRecursive(root, data);
    }

    // Insert data in the tree
    protected virtual BSTNode InsertRecursive(BSTNode? node, int data) 
    {
        // Return a new node if the tree is empty
        if (node == null) { return new BSTNode(data); }

        // Traverse to the right place and insert the node
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

    protected bool Search(int data)
    {
        return SearchRecursive(root, data);
    }

    // Search data in the tree
    protected bool SearchRecursive(BSTNode? node, int data)
    {
        if (node == null) { return false; }
        if (data == node.data) { return true; }

        return data < node.data
            ? SearchRecursive(node.left, data)
            : SearchRecursive(node.right, data);
    }

    public void InOrder()
    {
        InOrderRecursive(root);
        Console.WriteLine();
    }

    // Inorder Traversal
    private void InOrderRecursive(BSTNode? node)
    {
        if (node == null) 
        {
            return;
        }

        InOrderRecursive(node.left);
        Console.Write($"{node.data} -> ");
        InOrderRecursive(node.right);
    }
}