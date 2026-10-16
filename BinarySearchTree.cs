using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course22
{
    public class BinarySearchTree<T> : BinaryTree<T> where T :IComparable<T>
    {
        public BinarySearchTree(T rootValue) : base(rootValue) { }

        /// <summary>
        /// Inserts value with respect to Binary Search Tree rules.
        /// </summary>
        /// <param name="value"></param>
        public override void Insert(T value)
        {
            
          Root = this.Insert(Root, value);
            

        }
        private Node Insert(Node node, T value)
        {
            if (node == null)
            {
                 return new Node(value);
            }
                
            if (value.CompareTo(node.Value) <= 0) // value less than or equal root value, insert left
            {
                node.Left = Insert(node.Left!, value);
            }
            else // value greater than root, insert right
            {
               node.Right = Insert(node.Right!, value);
            }
            

            return node;
        }

        public Node Search(T value)
        {
            return Search(this.Root, value);
        }
        private Node Search(Node node,T value)
        {
            if(node == null || value.CompareTo(node.Value) == 0)
            {
                return node;
            }
           
            else if( value.CompareTo(node.Value) > 0)
            {
                return Search(node.Right!, value);
            }
            else
            {
                return Search(node.Left!, value);
            }

            
        }
        
       
    }
}
