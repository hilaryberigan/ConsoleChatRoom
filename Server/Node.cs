using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Node<T> where T : IComparable
    {
        public T data; //this holds client object
        public Node<T> leftNode;
        public Node<T> rightNode;

        public Node(T data)
        {
            this.data = data;
        }
        public void InsertNewNode(T newNodeData)

        {


            Node<T> newNode = new Node<T>(newNodeData);
            leftNode = null;
            rightNode = null;
            int i = newNodeData.CompareTo(this.data);

            if ( i > 0 && rightNode == null)
            {
                rightNode = newNode;
                
            }
            else if (i > 0 && rightNode != null)
            {
                rightNode.InsertNewNode(newNodeData);
            }
            else if (i < 0 && leftNode == null)
            {
                leftNode = newNode;  
            }
            else if (i < 0 && leftNode != null)
            {
                leftNode.InsertNewNode(newNodeData);
                
            }
            else if (i == 0)
            {
                Console.WriteLine("Error occurred while storing client.");
                Console.WriteLine("There is already a client with that client number.");
            }
            else
            {
                Console.WriteLine("Error occurred while storing client.");
            }
        }

       

       



    }

        
}
