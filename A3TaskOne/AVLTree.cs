/*
 * AVLTree.cs
 * --------------------
 * This file implements an AVL Tree — a self-balancing binary search tree (BST).
 *
 * Tasks:
 *  - The AVLNode class extends basic BSTNode with a height field and overrides left/right BSTNodes.
 *  - The AVLTree class inherits from BinarySearchTree to override for AVLNode specific features.
 *      - Insertion ensures tree remains balanced via rotations.
 *          - Nodes automatically rebalance after each insertion to maintain O(log n) height.
 *      - Performs Step 2 of the instructions.
 *
 * Extras:
 *  - AVL Trees provide more consistent search times than regular BSTs, especially with sorted input.
 *  - Balance factor is used to determine when rotations are needed.
 *
 * References:
 *  GeeksforGeeks. (2025, February 2). Insertion in an AVL Tree. GeeksforGeeks. 
 *  https://www.geeksforgeeks.org/insertion-in-an-avl-tree/
 *  Microsoft. (2025). Math.Max (System.Diagnostics). Microsoft.com.
 *  https://learn.microsoft.com/en-us/dotnet/api/system.math.max?view=net-9.0
 */

public class AVLNode : BSTNode
{
    public int height;

    // Hide base BSTNode left/right with AVLNode versions using new keyword
    // Microsoft. (2023, December 04). new modifier - C# reference. Microsoft.com. 
    // https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/new-modifier
    public new AVLNode? left;
    public new AVLNode? right;

    // Default Constructor
    public AVLNode(int _data) : base(_data)
    {
        height = 1;
    }
}

public class AVLTree : BinarySearchTree
{
    private AVLNode? root;

    // Default constructor
    public AVLTree() 
    {
        root = null;
    }

    /* 
    * Insert() takes an integer value and inserts that value into the tree, rebalancing as necessary.
    * - Overrides the original to ensure that the it uses the new AVLNode type.
    * - Uses a helper method to help handle the insertion.
    */
    public override void Insert(int data)
    {
        root = InsertRecursive(root, data);
    }

    /* 
    * InsertRecursive() takes an integer value, and AVLNode, then recursively inserts to return a node.
    * - Made private because AVLNode is specific to this class.
    * - If the current node is null, a new root is created.
    * - If data is less than current, recurse and insert to the left.
    * - If data is greater, recurse and insert to the right.
    * - Uses a helper method to help update the height of the ancestor node.
    * - Uses a helper method to help handle rotation and preserve balancing in height.
    */
    private AVLNode InsertRecursive(AVLNode? node, int data)
    {
        if (node == null)
            return new AVLNode(data);

        if (data < node.data)
            node.left = InsertRecursive(node.left, data);
        else if (data > node.data)
            node.right = InsertRecursive(node.right, data);
        else
            return node; // Duplicate are not allowed

        UpdateHeight(node);
        return Balance(node, data);
    }

    /* 
    * Search() takes an integer value and searches for that value in the tree.
    * - Overrides the original to ensure that the it uses the new AVLNode type.
    * - Uses a helper method to help handle the search.
    */
    protected override bool Search(int data)
    {
        return SearchRecursive(root, data);
    }

    /* 
    * SearchRecursive() takes an integer value, and AVLNode, then recursively searches to return a bool.
    * - Made private because AVLNode is specific to this class.
    * - If the current node is null, return false.
    * - Returns true if the value exists by recursing through the tree.
    * - Otherwise, returns false.
    */
    private bool SearchRecursive(AVLNode? node, int data)
    {
        if (node == null) { return false; }
        if (data == node.data) { return true; }

        return data < node.data
            ? SearchRecursive(node.left, data)
            : SearchRecursive(node.right, data);
    }

    /* 
    * UpdateHeight() takes an AVLNode and recalculates the height after insertion or rotation.
    * - The height of a node is equal to 1 + the greater of the heights of its left and right children.
    */
    private void UpdateHeight(AVLNode node)
    {
        node.height = 1 + Math.Max(GetNodeHeight(node.left), GetNodeHeight(node.right));
    }

    /* 
    * GetNodeHeight() takes an AVLNode and gets the height.
    * - Returns the height of a node, or 0 if the node is null.
    */
    private int GetNodeHeight(AVLNode? node)
    {
        if (node == null)
            return 0;
        return node.height;
    }

    /* 
    * GetBalance() takes an AVLNode and computes the balance factor.
    * - Positive = left-heavy
    * - Negative = right-heavy
    */
    private int GetBalance(AVLNode node)
    {
        return GetNodeHeight(node.left) - GetNodeHeight(node.right);
    }

    /*
    * Balance() takes an integer value, and AVLNode, then determines if a node needs rebalancing and applies
    * those rotations appropriately.
    * - If this node becomes unbalanced, then there are 4 cases below.
    */
    private AVLNode Balance(AVLNode node, int data)
    {
        int balance = GetBalance(node);

        // Left-Left
        if (balance > 1 && data < node.left!.data)
            return RotateRight(node);

        // Right-Right
        if (balance < -1 && data > node.right!.data)
            return RotateLeft(node);

        // Left-Right
        if (balance > 1 && data > node.left!.data)
        {
            node.left = RotateLeft(node.left);
            return RotateRight(node);
        }

        // Right-Left
        if (balance < -1 && data < node.right!.data)
        {
            node.right = RotateRight(node.right);
            return RotateLeft(node);
        }

        return node;
    }

    /*
    * RotateRight() takes an AVLNode and performs a right rotation around it.
    * - Used in Left-Left and Left-Right imbalance cases.
    */
    private AVLNode RotateRight(AVLNode y)
    {
        AVLNode x = y.left!;
        AVLNode? T2 = x.right;

        x.right = y;
        y.left = T2;

        UpdateHeight(y);
        UpdateHeight(x);

        return x;
    }

    /*
    * RotateLeft() takes an AVLNode and performs a left rotation around it.
    * - Used in Right-Right and Right-Left imbalance cases.
    */
    private AVLNode RotateLeft(AVLNode x)
    {
        AVLNode y = x.right!;
        AVLNode? T2 = y.left;

        y.left = x;
        x.right = T2;

        UpdateHeight(x);
        UpdateHeight(y);

        return y;
    }
}
