using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course22
{
    internal class GeneralTree<T>
    {
        public class Node
        {
            public T Value { get; set; }
            public List<Node> Children { get; set; }


            public Node(T value)
            {
                this.Value = value;
                this.Children = new List<Node>();
            }


            // Method to add a child node to the node
            public void AddChild(Node child)
            {
                Children.Add(child);
            }
            public Node Find(T value)
            {
                if (EqualityComparer<T>.Default.Equals(value, this.Value))
                    return this;

                foreach (Node node in this.Children)
                {
                   Node n = node.Find(value);
                    if (n != null)
                        return n;

                }
                return null;
            }
        }

        public Node Root { get; private set; }
      
        public GeneralTree(T rootValue)
        {
            Root = new Node(rootValue);
        }

        public static void PrintTree(Node node, string indent = " ")
        {
            Console.WriteLine(indent + node.Value);

            foreach (var item in node.Children)
            {
                PrintTree(item, indent + "  ");
            }
        }
       public void PrintTree(string indent = " ")
        {
            Console.WriteLine(indent + this.Root.Value);

            foreach (var item in this.Root.Children)
            {
                PrintTree(item, indent + "  ");
            }
        }
        public void TraverseBFS() // breadth first means horizontally first
        {
            if (Root == null) return;

            var queue = new Queue<Node>();
            queue.Enqueue(Root);

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                Console.Write(current.Value + "  "); // Visit node

                foreach (var child in current.Children)
                {
                    queue.Enqueue(child);
                }
            }
            Console.WriteLine();
        }

        public Node Find(T value)
        {
            return Root.Find(value);
        }

        
    }
}
