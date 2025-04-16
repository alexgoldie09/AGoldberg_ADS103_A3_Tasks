public class AVLTree : BinarySearchTree
{
    public override void Insert(int data)
    {
        root = InsertRecursive(root as AVLNode, data);
    }

    private AVLNode InsertRecursive(AVLNode? node, int data)
    {
        if (node == null)
            return new AVLNode(data);

        if (data < node.data)
            node.left = InsertRecursive(node.left as AVLNode, data);
        else if (data > node.data)
            node.right = InsertRecursive(node.right as AVLNode, data);
        else
            return node; // Duplicate not allowed

        UpdateHeight(node);
        return Balance(node, data);
    }

    private void UpdateHeight(AVLNode node)
    {
        node.height = 1 + Math.Max(GetNodeHeight(node.left), GetNodeHeight(node.right));
    }

    private int GetNodeHeight(BSTNode? node)
    {
        return (node as AVLNode)?.height ?? 0;
    }

    private int GetBalance(AVLNode node)
    {
        return GetNodeHeight(node.left) - GetNodeHeight(node.right);
    }

    private AVLNode Balance(AVLNode node, int data)
    {
        int balance = GetBalance(node);

        // Left Left
        if (balance > 1 && node.left is AVLNode leftLL && data < leftLL.data)
            return RotateRight(node);

        // Right Right
        if (balance < -1 && node.right is AVLNode rightRR && data > rightRR.data)
            return RotateLeft(node);

        // Left Right
        if (balance > 1 && node.left is AVLNode leftLR && data > leftLR.data)
        {
            node.left = RotateLeft(leftLR);
            return RotateRight(node);
        }

        // Right Left
        if (balance < -1 && node.right is AVLNode rightRL && data < rightRL.data)
        {
            node.right = RotateRight(rightRL);
            return RotateLeft(node);
        }

        return node;
    }

    private AVLNode RotateRight(AVLNode y)
    {
        AVLNode x = y.left as AVLNode ?? throw new InvalidOperationException("Left child must be AVLNode");
        AVLNode? T2 = x.right as AVLNode;

        x.right = y;
        y.left = T2;

        UpdateHeight(y);
        UpdateHeight(x);

        return x;
    }

    private AVLNode RotateLeft(AVLNode x)
    {
        AVLNode y = x.right as AVLNode ?? throw new InvalidOperationException("Right child must be AVLNode");
        AVLNode? T2 = y.left as AVLNode;

        y.left = x;
        x.right = T2;

        UpdateHeight(x);
        UpdateHeight(y);

        return y;
    }
}
