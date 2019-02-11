using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace Practice_Questions
{


    [TestFixture]
    class LinkedListTests
    {
        [Test]
        public static void GetFirstEmpty()
        {
            SinglelyLinkedList<string> myStringList = new SinglelyLinkedList<string>();
            Assert.Throws<NullReferenceException>(() => myStringList.GetFirst());
        }

        [Test]
        public static void AddFirstGetFirst()
        {
            SinglelyLinkedList<string> myEmptyList = new SinglelyLinkedList<string>();
            string add = "Test";
            myEmptyList.AddFirst(add);
            Assert.AreEqual(myEmptyList.GetFirst(), add);

            SinglelyLinkedList<string> myStringList = new SinglelyLinkedList<string>();
            myStringList.AddFirst("Content");
            myStringList.AddFirst("Content2");
            add = "Test";
            myStringList.AddFirst(add);
            Assert.AreEqual(myStringList.GetFirst(), add);
        }

        [Test]
        public static void AddFirstRemoveFirst()
        {           
            SinglelyLinkedList<string> myStringList = new SinglelyLinkedList<string>();
            myStringList.AddFirst("abc");
            Assert.AreEqual(myStringList.Size, 1);

            myStringList.AddFirst("abcde");
            Assert.AreEqual(myStringList.Size, 2);

            Assert.AreEqual(myStringList.RemoveFirst(), "abcde");
            Assert.AreEqual(myStringList.Size, 1);

            Assert.AreEqual(myStringList.RemoveFirst(), "abc");
            Assert.AreEqual(myStringList.Size, 0);

            Assert.AreEqual(myStringList.RemoveFirst(), null);
            Assert.AreEqual(myStringList.Size, 0);

            SinglelyLinkedList<int> myIntList = new SinglelyLinkedList<int>();            
            myIntList.AddFirst(1);
            Assert.AreEqual(myIntList.Size, 1);

            myIntList.AddFirst(2);
            Assert.AreEqual(myIntList.Size, 2);

            Assert.AreEqual(myIntList.RemoveFirst(), 2);
            Assert.AreEqual(myIntList.Size, 1);

            Assert.AreEqual(myIntList.RemoveFirst(), 1);
            Assert.AreEqual(myIntList.Size, 0);

            Assert.AreEqual(myIntList.RemoveFirst(), 0);
            Assert.AreEqual(myIntList.Size, 0);

            SinglelyLinkedList<char> myCharList = new SinglelyLinkedList<char>();
            myCharList.AddFirst('a');
            Assert.AreEqual(myCharList.Size, 1);

            myCharList.AddFirst('b');
            Assert.AreEqual(myCharList.Size, 2);

            Assert.AreEqual(myCharList.RemoveFirst(), 'b');
            Assert.AreEqual(myCharList.Size, 1);

            Assert.AreEqual(myCharList.RemoveFirst(), 'a');
            Assert.AreEqual(myCharList.Size, 0);

            Assert.AreEqual(myCharList.RemoveFirst(), '\0');
            Assert.AreEqual(myCharList.Size, 0);

        }
        
        [Test]
        public static void AddLastGetLast()
        {
            SinglelyLinkedList<string> myStringList = new SinglelyLinkedList<string>();
            myStringList.AddLast("abc");
            myStringList.AddLast("abcde");
            Assert.AreEqual(myStringList.GetLast(), "abcde");

            SinglelyLinkedList<int> myIntList = new SinglelyLinkedList<int>();
            myIntList.AddLast(1);
            myIntList.AddLast(2);
            Assert.AreEqual(myIntList.GetLast(), 2);

            SinglelyLinkedList<char> myCharList = new SinglelyLinkedList<char>();
            myCharList.AddLast('a');
            myCharList.AddLast('b');
            Assert.AreEqual(myCharList.GetLast(), 'b');
        }

        [Test]
        public static void AddLastRemoveLast()
        {
            SinglelyLinkedList<string> myStringList = new SinglelyLinkedList<string>();
            myStringList.AddLast("abc");
            Assert.AreEqual(myStringList.Size, 1);

            myStringList.AddLast("abcde");
            Assert.AreEqual(myStringList.Size, 2);

            Assert.AreEqual(myStringList.RemoveLast(), "abcde");
            Assert.AreEqual(myStringList.Size, 1);

            Assert.AreEqual(myStringList.RemoveLast(), "abc");
            Assert.AreEqual(myStringList.Size, 0);

            Assert.AreEqual(myStringList.RemoveLast(), null);
            Assert.AreEqual(myStringList.Size, 0);

            SinglelyLinkedList<int> myIntList = new SinglelyLinkedList<int>();
            myIntList.AddLast(1);
            Assert.AreEqual(myIntList.Size, 1);

            myIntList.AddLast(2);
            Assert.AreEqual(myIntList.Size, 2);

            Assert.AreEqual(myIntList.RemoveLast(), 2);
            Assert.AreEqual(myIntList.Size, 1);

            Assert.AreEqual(myIntList.RemoveLast(), 1);
            Assert.AreEqual(myIntList.Size, 0);

            Assert.AreEqual(myIntList.RemoveLast(), 0);
            Assert.AreEqual(myIntList.Size, 0);

            SinglelyLinkedList<char> myCharList = new SinglelyLinkedList<char>();
            myCharList.AddLast('a');
            Assert.AreEqual(myCharList.Size, 1);

            myCharList.AddLast('b');
            Assert.AreEqual(myCharList.Size, 2);

            Assert.AreEqual(myCharList.RemoveLast(), 'b');
            Assert.AreEqual(myCharList.Size, 1);

            Assert.AreEqual(myCharList.RemoveLast(), 'a');
            Assert.AreEqual(myCharList.Size, 0);

            Assert.AreEqual(myCharList.RemoveLast(), '\0');
            Assert.AreEqual(myCharList.Size, 0);
            
        }

        [Test]
        public static void RemoveDuplicates()
        {
            SinglelyLinkedList<string> myStringList = new SinglelyLinkedList<string>();
            myStringList.AddFirst("first");
            myStringList.AddFirst("second");
            myStringList.AddFirst("third");
            myStringList.AddFirst("third");
            myStringList.AddFirst("GOTCHA");
            myStringList.AddFirst("third");
            myStringList.AddFirst("third");
            myStringList.AddFirst("third");
            myStringList.AddFirst("fourth");
            Assert.AreEqual(myStringList.Size, 9);

            myStringList.RemoveDuplicates();

            Assert.AreEqual(myStringList.Size, 5);
            Assert.AreEqual(myStringList.RemoveFirst(), "fourth");
            Assert.AreEqual(myStringList.RemoveFirst(), "third");
            Assert.AreEqual(myStringList.RemoveFirst(), "GOTCHA");
            Assert.AreEqual(myStringList.RemoveFirst(), "second");
            Assert.AreEqual(myStringList.RemoveFirst(), "first");
            Assert.AreEqual(myStringList.RemoveFirst(), null);


            SinglelyLinkedList<int> myIntList = new SinglelyLinkedList<int>();
            myIntList.AddFirst(1);
            myIntList.AddFirst(1);
            Assert.AreEqual(myIntList.Size, 2);

            myIntList.RemoveDuplicates();

            Assert.AreEqual(myIntList.Size, 1);
            Assert.AreEqual(myIntList.RemoveFirst(), 1);
            Assert.AreEqual(myIntList.RemoveFirst(), 0);

            SinglelyLinkedList<char> myCharList = new SinglelyLinkedList<char>();
            myCharList.AddFirst('a');
            myCharList.AddFirst('a');
            myCharList.AddFirst('a');
            myCharList.AddFirst('b');
            myCharList.AddFirst('b');
            myCharList.AddFirst('c');
            Assert.AreEqual(myCharList.Size, 6);

            myCharList.RemoveDuplicates();

            Assert.AreEqual(myCharList.Size, 3);
            Assert.AreEqual(myCharList.RemoveFirst(), 'c');
            Assert.AreEqual(myCharList.RemoveFirst(), 'b');
            Assert.AreEqual(myCharList.RemoveFirst(), 'a');
            Assert.AreEqual(myCharList.RemoveLast(), '\0');

        }

        [Test]
        public static void RemoveDuplicatesNoBuffer()
        {
            SinglelyLinkedList<string> myStringList = new SinglelyLinkedList<string>();
            myStringList.AddFirst("first");
            myStringList.AddFirst("second");
            myStringList.AddFirst("third");
            myStringList.AddFirst("third");
            myStringList.AddFirst("GOTCHA");
            myStringList.AddFirst("third");
            myStringList.AddFirst("third");
            myStringList.AddFirst("third");
            myStringList.AddFirst("fourth");
            Assert.AreEqual(myStringList.Size, 9);

            myStringList.RemoveDuplicatesNoBuffer();

            Assert.AreEqual(myStringList.Size, 5);
            Assert.AreEqual(myStringList.RemoveFirst(), "fourth");
            Assert.AreEqual(myStringList.RemoveFirst(), "third");
            Assert.AreEqual(myStringList.RemoveFirst(), "GOTCHA");
            Assert.AreEqual(myStringList.RemoveFirst(), "second");
            Assert.AreEqual(myStringList.RemoveFirst(), "first");
            Assert.AreEqual(myStringList.RemoveFirst(), null);


            SinglelyLinkedList<int> myIntList = new SinglelyLinkedList<int>();
            myIntList.AddFirst(1);
            myIntList.AddFirst(1);
            Assert.AreEqual(myIntList.Size, 2);

            myIntList.RemoveDuplicatesNoBuffer();

            Assert.AreEqual(myIntList.Size, 1);
            Assert.AreEqual(myIntList.RemoveFirst(), 1);
            Assert.AreEqual(myIntList.RemoveFirst(), 0);

            SinglelyLinkedList<char> myCharList = new SinglelyLinkedList<char>();
            myCharList.AddFirst('a');
            myCharList.AddFirst('a');
            myCharList.AddFirst('a');
            myCharList.AddFirst('b');
            myCharList.AddFirst('b');
            myCharList.AddFirst('c');
            Assert.AreEqual(myCharList.Size, 6);

            myCharList.RemoveDuplicatesNoBuffer();

            Assert.AreEqual(myCharList.Size, 3);
            Assert.AreEqual(myCharList.RemoveFirst(), 'c');
            Assert.AreEqual(myCharList.RemoveFirst(), 'b');
            Assert.AreEqual(myCharList.RemoveFirst(), 'a');
            Assert.AreEqual(myCharList.RemoveLast(), '\0');            

        }

        [Test]
        public static void RemoveAt()
        {
            SinglelyLinkedList<string> myStringList = new SinglelyLinkedList<string>();
            myStringList.AddFirst("one");
            myStringList.AddFirst("two");
            myStringList.AddFirst("three");
            myStringList.RemoveAt(3);

            //GetAt

        }




    }
}

