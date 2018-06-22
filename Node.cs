using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBTree
{
    public class Node<T>
    {
        public T Key;
        public Node<T> LeftChild;
        public Node<T> RightChild;
        public Node<T> Parent;
        public char Color;

        public Node(T data, Node<T> parent)
        {
            Key = data;
			LeftChild = null;
            RightChild = null;
            Parent = parent;
            Color = 'R';
        }
    }
}

