public class AVLNode : BSTNode
{
    public int height;

    // Default Constructor
    public AVLNode(int _data) : base(_data)
    {
        height = 1;
    }
}