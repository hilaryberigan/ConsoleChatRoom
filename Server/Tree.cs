using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server

{
    class Tree<T> where T : IComparable
    {

        Node<T> root;

        public Tree()
        {
            root = null;
        }
        public bool IsEmpty()
        {
            return root == null;
        }

        public void Insert(T data)
        {
            Console.WriteLine("Storing new client information");
            if (IsEmpty())
            {
                root = new Node<T>(data);
            }
            else
            {
                root.InsertNewNode(data);
            }
        }

        public void Find(T item)
        {
            Node<T> temporary = root;
            if (item.CompareTo(temporary.data) > 0 )
            {
                temporary = temporary.rightNode;
            }
            if (item.CompareTo(temporary.data) < 0)
            {
                temporary = temporary.leftNode;
            }
            else if (item.CompareTo(temporary.data) == 0)
            {
                Console.WriteLine(temporary.data);
            }
        }      
    }

}
