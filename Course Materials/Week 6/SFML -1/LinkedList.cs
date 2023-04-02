using System;
using System.Collections.Generic;
using System.Text;
using SFML.Graphics;
using SFML.System;

namespace sfml_list_example
{
    public class Node<T> where T : Shape
    {
        public Node<T> next;
        public T data;

        public Node(T data)
        {
            this.data = data;
        }

        public void Delete()
        {
            this.next = null;
            this.data = null;
        }
    }
    
    public class LinkedList<T> where T : Shape
    {
        public Node<T> head;
        public int count;

        public LinkedList()
        {
            count = 0;
        }

        public void Enqueue(T data)
        {
            Node<T> newNode = new Node<T>(data);
            newNode.next = this.head;
            this.head = newNode;
            this.count++;
            Console.WriteLine(this.count);
        }

        public T Dequeue()
        {
            if (this.head == null) return null;

            Node<T> trav = this.head;
            Node<T> trav_trail = this.head;
            while (trav.next != null)
            {
                trav_trail = trav;
                trav = trav.next;
            }

            trav_trail.next = null;
            this.count--;
            if (this.count == 0)
                this.head = null;
            Console.WriteLine(this.count);
            GC.Collect();
            return trav.data;
        }

        public void Empty()
        {
            while (this.count > 0)
                this.Dequeue();
        }
    }
}
