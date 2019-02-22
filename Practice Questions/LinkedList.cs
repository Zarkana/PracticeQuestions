using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_Questions
{   

    public class CircularSinglelyLinkedList<T>
    {
        Node Head;
        Node Tail;
        //public int Size();
        public int Size { get; private set; }

        //public LinkedList();
        public CircularSinglelyLinkedList()
        {
            Head = null;
            Tail = null;
            Size = 0;
        }

        //public LinkedList(Collection<T> c);
        //TODO

        //public T GetFirst();
        public T GetFirst()
        {
            return Head.data;
        }

        //public T GetLast();
        public T GetLast()
        {
            return Tail.data;
        }


        //public T RemoveFirst();
        public T RemoveFirst()
        {
            if(Head != null)
            {            
                T data = Head.data;
                Tail.next = Head.next;
                Head = Head.next;
                if (Size > 0)
                    Size--;
                if (Size == 0)
                {
                    Head = null;
                    Tail = null;
                }
                return data;
            }
            if (Size > 0)
                Size--;
            if (Size == 0)
            {
                Head = null;
                Tail = null;
            }
            return default(T);
        }

        //public T RemoveLast();
        public T RemoveLast()
        {            
            if (Tail != null)
            {
                Node current = Head;
                while (!current.next.Equals(Tail))
                {
                    current = current.next;
                }
                Node tailPrev = current;

                T data = Tail.data;
                tailPrev.next = Tail.next;
                Tail = tailPrev;
                if (Size > 0)
                    Size--;
                if (Size == 0)
                {
                    Head = null;
                    Tail = null;
                }
                return data;
            }
            if(Size > 0)
                Size--;
            if (Size == 0)
            {
                Head = null;
                Tail = null;
            }
            return default(T);
        }

        public T RemoveAt(int index)
        {
            //TODO: implement like KthLast
            if(Head != null)
            {            
                Node current = Head;
                for(int i = 0; i < index; i++)
                {
                    current = current.next;
                }
                return RemoveNode(current);
            }
            return default(T);
        }

        public T RemoveKthElement()
        {

            return default(T);
        }

        public T RemoveKthLastElement(int k)
        {
            int index = 0;
            Node kth = null;
            Node current = Head;
            if (k+1 > Size)
            {
                throw new ArgumentOutOfRangeException("k went beyond Tail");
            }
            while (!current.Equals(Tail))
            {
                if (index >= k)
                {
                    if(kth == null)
                    {
                        kth = Head;
                    }
                    else
                    {
                        kth = kth.next;
                    }
                }
                index++;
                current = current.next;
            }
            if (kth == null)
            {
                kth = current;
            }
            else
            {
                kth = kth.next;
            }
            RemoveNode(kth);
            return kth.data;
        }

        //public void AddFirst(T o);
        public void AddFirst(T o)
        {
            Node add = new Node(o);
            if (Head == null)
            {
                Head = add;
                Head.next = Tail;
                Tail = add;
                Tail.next = Head;
                Size++;
                return; 
            }
            add.next = Head;
            Tail.next = add;
            Head = add;
            Size++;
        }

        //public void AddLast(T o);
        public void AddLast(T o)
        {
            Node add = new Node(o);
            if (Head == null)
            {
                AddFirst(o);
                return;
                //Head = add;
                //Head.next = Tail;
                //Tail = add;
                //Tail.next = Head;
                //Size++;
                //return;
            }

            Node current = Head;
            while(!current.next.Equals(Tail))
            {
                current = current.next;
            }

            add.next = Head;
            Tail.next = add;
            Tail = add;
            Size++;
        }
        
        public void RemoveDuplicates()
        {
            List<T> unique = new List<T>();
            Node current = Head;

            while(!current.Equals(Tail))
            {
                if (!unique.Contains(current.data))
                {
                    unique.Add(current.data);
                }
                current = current.next;
            }
            //If Tail has unique element
            if (!unique.Contains(current.data))
            {
                unique.Add(current.data);
            }

            for (int i = unique.Count; i > 0; i--)
            {
                current = Head;
                T compare = unique[0];
                unique.RemoveAt(0);
                bool found = false;
                while(!current.Equals(Tail))
                {
                    if (found && current.data.Equals(compare))
                    {
                        RemoveNode(current);
                    }
                    else if (current.data.Equals(compare))
                    {
                        found = true;
                    }
                    current = current.next;
                }
                if (found && current.data.Equals(compare))
                {
                    RemoveNode(current);
                }
            }
        }
        
        public void RemoveDuplicatesNoBuffer()
        {
            RemoveDuplicatesIterative(Head);
        }

        private void RemoveDuplicatesRecursive(Node start)
        {
            Node current = start.next;
            while(!current.Equals(Tail))
            {
                if(start.data.Equals(current.data))
                {
                    RemoveNode(current);
                }
                current = current.next;
            }
            //If Tail
            if (start.data.Equals(current.data))
            {
                RemoveNode(current);
            }

            if (start.Equals(Tail))
            {
                return;
            }
            RemoveDuplicatesRecursive(start.next);
        }

        private void RemoveDuplicatesIterative(Node start)
        {
            Node current = start.next;
            while (!start.Equals(Tail))
            {
                while (!current.Equals(Tail))
                {
                    if (start.data.Equals(current.data))
                    {
                        RemoveNode(current);
                    }
                    current = current.next;
                }
                //If Tail
                if (start.data.Equals(current.data))
                {
                    RemoveNode(current);
                }
                start = start.next;
                current = start.next;
            }
        }

        private T RemoveNode(Node toRemove)
        {
            if (Size == 1)
            {
                Head = null;
                Tail = null;
                Size--;
                return toRemove.data;                
            }
            else
            {
                if (toRemove.Equals(Tail))
                {
                    Node prev = Head;
                    while (!prev.next.Equals(Tail))
                    {
                        prev = prev.next;
                    }
                    prev.next = Head;
                    Tail = prev;
                    Size--;
                    return toRemove.data;
                }
                else if (toRemove.Equals(Head))
                {
                    Tail.next = Head.next;
                    Head = Head.next;
                    Size--;
                    return toRemove.data;
                }
                else
                {
                    Node prev = Head;
                    while (!prev.next.Equals(toRemove) && !prev.next.Equals(Tail))
                    {
                        prev = prev.next;
                    }
                    prev.next = toRemove.next;
                    Size--;
                    return toRemove.data;
                }
            }
        }

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
