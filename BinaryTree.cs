using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course22
{
    public enum DepthFirstTraversalTechnique
    {
        /// <summary>
        /// Left, Root, Right
        /// </summary>
        InOrder = 1,

        /// <summary>
        /// Root, Left, Right
        /// </summary>
        PreOrder = 2,

        /// <summary>
        /// Left, Right, Root
        /// </summary>
        PostOrder = 3
    }
    public class BinaryTree<T>
    {
       
        
        public Node Root { get; set; }
       

        public BinaryTree(T rootValue)
        {
            Root = new Node (rootValue);
        }
        public BinaryTree()
        {

        }

        /// <summary>
        /// Level-Order Insertion (Breadth-First).
        /// It finds the first available empty spot from top to bottom, left to right, 
        /// keeping the tree complete.
        /// </summary>
        /// <param name="value"></param>
        public virtual void Insert(T value)
        {
            if (Root == null)
            {
                Root = new Node(value);
                return;
            }

            Queue<Node> nodes = new Queue<Node>();

            nodes.Enqueue(Root);

            while(nodes.Count > 0)
            {
                Node current = nodes.Dequeue();

                if(current.Left == null)
                {
                    current.Left = new Node(value);
                    break;
                }
                else
                {
                    nodes.Enqueue(current.Left);
                }

                if(current.Right == null)
                {
                    current.Right = new Node(value);
                    break;
                }
                else
                {
                    nodes.Enqueue(current.Right);
                }

            }
                
        }
        public static void TraverseBreadthFirst(Node root)
        {
            if (root == null)
                return;

            Queue<Node> nodes = new Queue<Node>();
            nodes.Enqueue(root);
            while (nodes.Count > 0)
            {
                Node current = nodes.Dequeue();
                Console.WriteLine(current.Value);
                if (current.Left != null)
                {
                    nodes.Enqueue(current.Left);
                }
                if (current.Right != null)
                {
                    nodes.Enqueue(current.Right);
                }
            }
        }

        public static void TraverseDepthFirst(Node root, DepthFirstTraversalTechnique techinique)
        {
            switch (techinique)
            {
                case DepthFirstTraversalTechnique.InOrder:
                    TraverseInOrder(root);
                    break;
                case DepthFirstTraversalTechnique.PreOrder:
                    TraversePreOrder(root);
                    break;
                case DepthFirstTraversalTechnique.PostOrder:
                    TraversePostOrder(root);
                    break;
            }
        }
        public void TraverseDepthFirst( DepthFirstTraversalTechnique techinique)
        {
            TraverseDepthFirst(this.Root, techinique);
        }
        private static void TraverseInOrder(Node root)
        {
            if (root == null)
                return;

            TraverseInOrder(root.Left!);
            Console.WriteLine(root.Value);
            TraverseInOrder(root.Right!);
        }
        private static void TraversePreOrder(Node root)
        {
            if (root == null)
                return;

            Console.WriteLine(root.Value);
            TraversePreOrder(root.Left!);
            TraversePreOrder(root.Right!);
        }
        private static void TraversePostOrder(Node root)
        {
            if (root == null)
                return;


            TraversePostOrder(root.Left!);
            TraversePostOrder(root.Right!);
            Console.WriteLine(root.Value);

        }
        private int MaxDepth(Node root)
        {
            if (root == null)
                return 0;

            int leftDepth = MaxDepth(root.Left);
            int rightDepth = MaxDepth(root.Right);

            return 1 + Math.Max(leftDepth, rightDepth);
        }
        public int GetTreeDepth()
        {
            return MaxDepth(this.Root);
        }
        // Method to determine if two trees are identical
        public static bool AreIdentical(Node root1, Node root2)
        {
            // Base case: both nodes are null
            if (root1 == null && root2 == null) return true;


            // If one is null and the other is not, they are not identical
            if (root1 == null || root2 == null) return false;


            // Check if the current nodes are identical and recursively check subtrees
            return EqualityComparer<T>.Default.Equals(root1.Value,root2.Value)
                && AreIdentical(root1.Left, root2.Left)
                && AreIdentical(root1.Right, root2.Right);
        }
       

        public class Node
        {
            public T Value { get; set; }
            public Node? Left { get; set; }
            public Node? Right { get; set; }
            public Node(T NodeValue)
            {
                 this.Value = NodeValue;
            }
            public void AddRightChild(T childValue)
            {
                 this.Right = new Node(childValue);
            }
            public void AddLeftChild(T childValue)
            {
                this.Left = new Node(childValue);
            }

            
           
        }

    }
}
