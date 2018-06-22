using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBTree
{
    public class RedBlackTree<T> where T : IComparable<T>
    {
        public Node<T> Root;
		
	public RedBlackTree()
        {
            Root = null;
        }

        public void Clear()
        {
            Root = null;
        }

        public bool IsEmpty()
        {
            if (Root == null)
                return true;
            else
                return false;
        }

        private void rightRotate(Node<T> x)
        {
            Node<T> y = x.LeftChild;
            x.LeftChild = y.RightChild;
            if (y.RightChild != null) y.RightChild.Parent = x;
            if (y != null) y.Parent = x.Parent;
            if (x.Parent != null)
            {
                if (x == x.Parent.RightChild)
                    x.Parent.RightChild = y;
                else
                    x.Parent.LeftChild = y;
            }
            else
                Root = y;
            y.RightChild = x;
            if (x != null) x.Parent = y;
        }

        private void leftRotate(Node<T> x)
        {
            Node<T> y = x.RightChild;
            x.RightChild = y.LeftChild;
            if (y.LeftChild != null) y.LeftChild.Parent = x;
            if (y != null) y.Parent = x.Parent;
            if (x.Parent != null)
            {
                if (x == x.Parent.LeftChild)
                    x.Parent.LeftChild = y;
                else
                    x.Parent.RightChild = y;
            }
            else Root = y;
            y.LeftChild = x;
            if (x != null) x.Parent = y;
        }

        private void checkInsert(Node<T> x)
        {
            while (x != Root && x.Parent.Color == 'R')
            {
                if (x.Parent == x.Parent.Parent.LeftChild)
                {
                    Node<T> y = x.Parent.Parent.RightChild;
                    if (y != null && y.Color == 'R')
                    {
                        x.Parent.Color = 'B';
                        y.Color = 'B';
                        x.Parent.Parent.Color = 'R';
                        x = x.Parent.Parent;
                    }
                    else
                    {
                        if (x == x.Parent.RightChild)
                        {
                            x = x.Parent;
                            leftRotate(x);
                        }                       
                        x.Parent.Color = 'B';
                        x.Parent.Parent.Color = 'R';
                        rightRotate(x.Parent.Parent);
                    }
                }
                else
                {
                    Node<T> y = x.Parent.Parent.LeftChild;

                    if (y != null && y.Color == 'R')
                    {
                        x.Parent.Color = 'B';
                        y.Color = 'B';
                        x.Parent.Parent.Color = 'R';
                        x = x.Parent.Parent;
                    }
                    else
                    {
                        if (x == x.Parent.LeftChild)
                        {
                            x = x.Parent;
                            rightRotate(x);
                        }
                        x.Parent.Color = 'B';
                        x.Parent.Parent.Color = 'R';
                        leftRotate(x.Parent.Parent);
                    }
                }
            }
            Root.Color = 'B';
        }

        private void checkDelete(Node<T> x)
        {
            while (x != Root && x.Color == 'B')
            {
                if (x == x.Parent.LeftChild)
                {
                    Node<T> w = x.Parent.RightChild;
                    if (w.Color == 'R')
                    {
                        w.Color = 'B';
                        x.Parent.Color = 'R';
                        leftRotate(x.Parent);
                        w = x.Parent.RightChild;
                    }
                    if (w.LeftChild.Color == 'B' && w.RightChild.Color == 'B')
                    {
                        w.Color = 'R';
                        x = x.Parent;
                    }
                    else
                    {
                        if (w.RightChild.Color == 'B')
                        {
                            w.LeftChild.Color = 'B';
                            w.Color = 'B';
                            rightRotate(w);
                            w = x.Parent.RightChild;
                        }
                        w.Color = x.Parent.Color;
                        x.Parent.Color = 'B';
                        w.RightChild.Color = 'B';
                        leftRotate(x.Parent);
                        x = Root;
                    }
                }
                else
                {
                    Node<T> w = x.Parent.LeftChild;
                    if (w.Color == 'R')
                    {
                        w.Color = 'B';
                        x.Parent.Color = 'R';
                        rightRotate(x.Parent);
                        w = x.Parent.LeftChild;
                    }
                    if (w.RightChild.Color == 'B' && w.LeftChild.Color == 'B')
                    {
                        w.Color = 'R';
                        x = x.Parent;
                    }
                    else
                    {
                        if (w.LeftChild.Color == 'B')
                        {
                            w.RightChild.Color = 'B';
                            w.Color = 'R';
                            leftRotate(w);
                            w = x.Parent.LeftChild;
                        }
                        w.Color = x.Parent.Color;
                        x.Parent.Color = 'B';
                        w.LeftChild.Color = 'B';
                        rightRotate(x.Parent);
                        x = Root;
                    }
                }
            }
            x.Color = 'B';
        }

        public Node<T> Insert(T elem)
        {
            Node<T> temp;
            if (Root == null)
            {
                Root = new Node<T>(elem, null);
                Root.Color = 'B';
                return Root;
            }
            temp = Root;
            while (true)
            {
                if (temp.Key.CompareTo(elem) > 0)
                {
                    if (temp.LeftChild == null)
                    {
                        temp.LeftChild = new Node<T>(elem, temp);
                        temp = temp.LeftChild;
                        break;
                    }
                    else
                        temp = temp.LeftChild;
                }
                else if (temp.Key.CompareTo(elem) <= 0)
                {
                    if (temp.RightChild == null)
                    {
                        temp.RightChild = new Node<T>(elem, temp);
                        temp = temp.RightChild;
                        break;
                    }
                    else
                        temp = temp.RightChild;
                }
                else
                    return null;
            }
            checkInsert(temp);
            return temp;
        }
		
        public bool Delete(T elem)
        {
            Node<T> x;
            Node<T> y;
            Node<T> z;
            z = Find(elem);
            if (z == null) 
		return false;
            if (z.LeftChild == null || z.RightChild == null) 
		y = z;
            else
            {
                y = z.RightChild;
                while (y.LeftChild != null)
                    y = y.LeftChild;
            }
            if (y.LeftChild != null)
                x = y.LeftChild;
            else
                x = y.RightChild;
            if (x != null) 
		x.Parent = y.Parent;
            if (y.Parent != null)
            {
                if (y == y.Parent.LeftChild)
                    y.Parent.LeftChild = x;
                else
                    y.Parent.RightChild = x;
            }                
            else
                Root = x;
            if (y != z) z.Key = y.Key;
            if (y.Color == 'B') checkDelete(x);
            return true;
        }

        public Node<T> Find(T elem)
        {
            Node<T> temp = Root;
            while (temp != null)
            {
                if (temp.Key.CompareTo(elem) == 0)
                    return temp;
                else if (temp.Key.CompareTo(elem) > 0)
                    temp = temp.LeftChild;
                else
                    temp = temp.RightChild;
            }
            return null;
        }

        public Node<T> FindPrevious(T elem)
        {
            Node<T> temp;
            temp = Find(elem);
            if (temp == null) return null;
            if (temp.LeftChild != null)
            {
                temp = temp.LeftChild;
                while (temp.RightChild != null)
                {
                    temp = temp.RightChild;
                }
                return temp;
            }
            else
            {
                if (temp == temp.Parent.RightChild)
                    return temp.Parent;
                else if (temp.Parent.Parent != null)
                    return temp.Parent.Parent; 
                else
                    return temp;
            }
        }

        public Node<T> FindNext(T elem)
        {
            Node<T> temp;
            temp = Find(elem);
            if (temp == null) return null;           
            if (temp.RightChild == null)
            {
                while (temp != Root)
                {
                    if (temp == temp.Parent.LeftChild)
                        return temp.Parent; 
                    else
                        temp = temp.Parent;
                }
            }
            else
            {
                temp = temp.RightChild;
                while (temp.LeftChild != null)
                    temp = temp.LeftChild;   
                return temp;
            }
            return null;
        }
    };
}
