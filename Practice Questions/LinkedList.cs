using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_Questions
{

    public class MyGeneric<T>
    {
        public T data;
    }


    public class LinkedList<T>
    {
        Node head;
        Node tail;

        //public LinkedList();
        public LinkedList()
        {
            Node head = null;
            Node tail = null;
        }

        //public LinkedList(Collection<T> c);
        //TODO

        //public T GetFirst();
        public T GetFirst()
        {
            return head.data;
        }

        //public T GetLast();
        public T GetLast()
        {
            return tail.data;
        }

        //public T RemoveFirst();
        //TODO

        //public T RemoveLast();
        //TODO

        //public void AddFirst(T o);
        public void AddFirst(T o)
        {
            Node add = new Node(o);
            if (head == null)
            {
                head = add;
                tail = add;
                return; 
            }
            add.next = head.next;
            tail.next = add;
            head = add;
        }

        //public void AddLast(T o);
        //TODO

        //public int Size();
        //TODO

        //public void Clear();
        //TODO



        //public void AddHead(T t)
        //{
        //    Node toInsert = new Node(t);
        //    toInsert.next = head;
        //    head = toInsert;
        //    Node current = head;
        //    while (current.next != null)
        //    {
        //        current = current.next;
        //    }
        //    tail = current;
        //}

        ////void AddTail(T t)
        ////{
        ////    Node toInsert = new Node(t);
        ////    Node current = head;
        ////    while(current.next.next != null)
        ////    {
        ////        current = current.next;
        ////    }
        ////    current.next = toInsert;
        ////    tail = toInsert;
        ////}

        //public void DeleteHead()
        //{
        //    head = head.next;
        //    tail.next = head;
        //}

        //public void DeleteTail()
        //{
        //    Node current = head;
        //    while (!current.next.Equals(tail))
        //    {
        //        current = current.next;
        //    }
        //    tail = current;
        //    tail.next = head;
        //}

        //private void DeleteFirstOccurance(T t)
        //{
        //    Node compare = new Node(t);
        //    Node current = head;
        //    Node prev = tail;

        //    while (current != null)
        //    {
        //        if (current.data.Equals(compare.data))
        //        {
        //            prev.next = current.next.next;
        //        }
        //        prev = current;
        //        current = current.next;
        //    }
        //}

        //public void DeleteIndex(int index)
        //{
        //    if (index == 0)
        //    {
        //        DeleteHead();
        //    }

        //    int i = 0;

        //    Node current = head;

        //    while (!current.Equals(tail))
        //    {
        //        if (i == index - 1)
        //        {
        //            DeleteNodeAfter(current);
        //            return;
        //        }
        //        current = current.next;
        //        i++;
        //    }

        //    DeleteTail();
        //}

        //private void DeleteNodeAfter(Node prev)
        //{
        //    if (prev.next.Equals(head))
        //    {
        //        DeleteHead();
        //        return;
        //    }
        //    if (prev.next.Equals(tail))
        //    {
        //        DeleteTail();
        //        return;
        //    }
        //    prev.next = prev.next.next;
        //}

        //public void PrintList()
        //{
        //    Node current = head;
        //    while (!current.Equals(tail))
        //    {
        //        Console.WriteLine($"Value: {current.data}");
        //        current = current.next;
        //    }
        //    Console.WriteLine($"Value: {current.data}");
        //    Console.WriteLine("");
        //}



        private class Node
        {
            public T data;
            public Node next;

            public Node(T t)
            {
                this.data = t;
                next = null;
            }
        }
    }
}
