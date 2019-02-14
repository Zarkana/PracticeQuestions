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
            Assert.AreEqual(1, myStringList.Size);

            myStringList.AddFirst("abcde");
            Assert.AreEqual(2, myStringList.Size);

            Assert.AreEqual("abcde", myStringList.RemoveFirst());
            Assert.AreEqual(1, myStringList.Size);

            Assert.AreEqual("abc", myStringList.RemoveFirst());
            Assert.AreEqual(0, myStringList.Size);

            Assert.AreEqual(null, myStringList.RemoveFirst());
            Assert.AreEqual(0, myStringList.Size);

            SinglelyLinkedList<int> myIntList = new SinglelyLinkedList<int>();
            myIntList.AddFirst(1);
            Assert.AreEqual(1, myIntList.Size);

            myIntList.AddFirst(2);
            Assert.AreEqual(2, myIntList.Size);

            Assert.AreEqual(2, myIntList.RemoveFirst());
            Assert.AreEqual(1, myIntList.Size);

            Assert.AreEqual(1, myIntList.RemoveFirst());
            Assert.AreEqual(0, myIntList.Size);

            Assert.AreEqual(0, myIntList.RemoveFirst());
            Assert.AreEqual(0, myIntList.Size);

            SinglelyLinkedList<char> myCharList = new SinglelyLinkedList<char>();
            myCharList.AddFirst('a');
            Assert.AreEqual(1, myCharList.Size);

            myCharList.AddFirst('b');
            Assert.AreEqual(2, myCharList.Size);

            Assert.AreEqual(myCharList.RemoveFirst(), 'b');
            Assert.AreEqual(1, myCharList.Size);

            Assert.AreEqual(myCharList.RemoveFirst(), 'a');
            Assert.AreEqual(0, myCharList.Size);

            Assert.AreEqual(myCharList.RemoveFirst(), '\0');
            Assert.AreEqual(0, myCharList.Size);

        }

        [Test]
        public static void AddLastGetLast()
        {
            SinglelyLinkedList<string> myStringList = new SinglelyLinkedList<string>();
            myStringList.AddLast("abc");
            myStringList.AddLast("abcde");
            Assert.AreEqual("abcde", myStringList.GetLast());

            SinglelyLinkedList<int> myIntList = new SinglelyLinkedList<int>();
            myIntList.AddLast(1);
            myIntList.AddLast(2);
            Assert.AreEqual(2, myIntList.GetLast());

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
            Assert.AreEqual(1, myStringList.Size);

            myStringList.AddLast("abcde");
            Assert.AreEqual(2, myStringList.Size);

            Assert.AreEqual("abcde", myStringList.RemoveLast());
            Assert.AreEqual(1, myStringList.Size);

            Assert.AreEqual("abc", myStringList.RemoveLast());
            Assert.AreEqual(0, myStringList.Size);

            Assert.AreEqual(null, myStringList.RemoveLast());
            Assert.AreEqual(0, myStringList.Size);

            SinglelyLinkedList<int> myIntList = new SinglelyLinkedList<int>();
            myIntList.AddLast(1);
            Assert.AreEqual(1, myIntList.Size);

            myIntList.AddLast(2);
            Assert.AreEqual(2, myIntList.Size);

            Assert.AreEqual(2, myIntList.RemoveLast());
            Assert.AreEqual(1, myIntList.Size);

            Assert.AreEqual(1, myIntList.RemoveLast());
            Assert.AreEqual(0, myIntList.Size);

            Assert.AreEqual(0, myIntList.RemoveLast());
            Assert.AreEqual(0, myIntList.Size);

            SinglelyLinkedList<char> myCharList = new SinglelyLinkedList<char>();
            myCharList.AddLast('a');
            Assert.AreEqual(1, myCharList.Size);

            myCharList.AddLast('b');
            Assert.AreEqual(2, myCharList.Size);

            Assert.AreEqual(myCharList.RemoveLast(), 'b');
            Assert.AreEqual(1, myCharList.Size);

            Assert.AreEqual(myCharList.RemoveLast(), 'a');
            Assert.AreEqual(0, myCharList.Size);

            Assert.AreEqual(myCharList.RemoveLast(), '\0');
            Assert.AreEqual(0, myCharList.Size);

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
            Assert.AreEqual(9, myStringList.Size);

            myStringList.RemoveDuplicates();

            Assert.AreEqual(5, myStringList.Size);
            Assert.AreEqual("fourth", myStringList.RemoveFirst());
            Assert.AreEqual("third", myStringList.RemoveFirst());
            Assert.AreEqual("GOTCHA", myStringList.RemoveFirst());
            Assert.AreEqual("second", myStringList.RemoveFirst());
            Assert.AreEqual("first", myStringList.RemoveFirst());
            Assert.AreEqual(null, myStringList.RemoveFirst());


            SinglelyLinkedList<int> myIntList = new SinglelyLinkedList<int>();
            myIntList.AddFirst(1);
            myIntList.AddFirst(1);
            Assert.AreEqual(2, myIntList.Size);

            myIntList.RemoveDuplicates();

            Assert.AreEqual(1, myIntList.Size);
            Assert.AreEqual(1, myIntList.RemoveFirst());
            Assert.AreEqual(0, myIntList.RemoveFirst());

            SinglelyLinkedList<char> myCharList = new SinglelyLinkedList<char>();
            myCharList.AddFirst('a');
            myCharList.AddFirst('a');
            myCharList.AddFirst('a');
            myCharList.AddFirst('b');
            myCharList.AddFirst('b');
            myCharList.AddFirst('c');
            Assert.AreEqual(6, myCharList.Size);

            myCharList.RemoveDuplicates();

            Assert.AreEqual(3, myCharList.Size);
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
            Assert.AreEqual(9, myStringList.Size);

            myStringList.RemoveDuplicatesNoBuffer();

            Assert.AreEqual(5, myStringList.Size);
            Assert.AreEqual("fourth", myStringList.RemoveFirst());
            Assert.AreEqual("third", myStringList.RemoveFirst());
            Assert.AreEqual("GOTCHA", myStringList.RemoveFirst());
            Assert.AreEqual("second", myStringList.RemoveFirst());
            Assert.AreEqual("first", myStringList.RemoveFirst());
            Assert.AreEqual(null, myStringList.RemoveFirst());


            SinglelyLinkedList<int> myIntList = new SinglelyLinkedList<int>();
            myIntList.AddFirst(1);
            myIntList.AddFirst(1);
            Assert.AreEqual(2, myIntList.Size);

            myIntList.RemoveDuplicatesNoBuffer();

            Assert.AreEqual(1, myIntList.Size);
            Assert.AreEqual(1, myIntList.RemoveFirst());
            Assert.AreEqual(0, myIntList.RemoveFirst());

            SinglelyLinkedList<char> myCharList = new SinglelyLinkedList<char>();
            myCharList.AddFirst('a');
            myCharList.AddFirst('a');
            myCharList.AddFirst('a');
            myCharList.AddFirst('b');
            myCharList.AddFirst('b');
            myCharList.AddFirst('c');
            Assert.AreEqual(6, myCharList.Size);

            myCharList.RemoveDuplicatesNoBuffer();

            Assert.AreEqual(3, myCharList.Size);
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
            Assert.AreEqual(3, myStringList.Size);
            Assert.AreEqual("three", myStringList.RemoveAt(0));
            Assert.AreEqual("two", myStringList.RemoveAt(0));
            Assert.AreEqual("one", myStringList.RemoveAt(0));
            Assert.AreEqual(0, myStringList.Size);

            myStringList.AddFirst("one");
            myStringList.AddFirst("two");
            myStringList.AddFirst("three");
            Assert.AreEqual(3, myStringList.Size);
            Assert.AreEqual("one", myStringList.RemoveAt(2));
            Assert.AreEqual("two", myStringList.RemoveAt(1));
            Assert.AreEqual("three", myStringList.RemoveAt(0));
            Assert.AreEqual(0, myStringList.Size);

            myStringList.AddFirst("one");
            myStringList.AddFirst("two");
            myStringList.AddFirst("three");
            Assert.AreEqual(3, myStringList.Size);
            Assert.AreEqual("two", myStringList.RemoveAt(1));
            Assert.AreEqual("one", myStringList.RemoveAt(1));
            Assert.AreEqual("three", myStringList.RemoveAt(0));
            Assert.AreEqual(0, myStringList.Size);

            SinglelyLinkedList<int> myIntList = new SinglelyLinkedList<int>();
            myIntList.AddFirst(1);
            myIntList.AddFirst(2);
            myIntList.AddFirst(3);
            Assert.AreEqual(3, myIntList.Size);
            Assert.AreEqual(3, myIntList.RemoveAt(0));
            Assert.AreEqual(2, myIntList.RemoveAt(0));
            Assert.AreEqual(1, myIntList.RemoveAt(0));
            Assert.AreEqual(0, myIntList.Size);


            SinglelyLinkedList<char> myCharList = new SinglelyLinkedList<char>();
            myCharList.AddFirst('a');
            myCharList.AddFirst('b');
            myCharList.AddFirst('c');
            Assert.AreEqual(3, myCharList.Size);
            Assert.AreEqual('c', myCharList.RemoveAt(0));
            Assert.AreEqual('b', myCharList.RemoveAt(0));
            Assert.AreEqual('a', myCharList.RemoveAt(0));
            Assert.AreEqual(0, myCharList.Size);
        }

        [Test]
        public static void RemoveKthLast()
        {
            SinglelyLinkedList<string> myStringList = new SinglelyLinkedList<string>();
            myStringList.AddLast("one");
            myStringList.AddLast("two");
            myStringList.AddLast("three");
            Assert.AreEqual(3, myStringList.Size);
            Assert.AreEqual("three", myStringList.RemoveKthLastElement(0));
            Assert.AreEqual("two", myStringList.RemoveKthLastElement(0));
            Assert.AreEqual("one", myStringList.RemoveKthLastElement(0));
            Assert.AreEqual(0, myStringList.Size);

            myStringList.AddLast("one");
            myStringList.AddLast("two");
            myStringList.AddLast("three");
            Assert.AreEqual(3, myStringList.Size);
            Assert.AreEqual("three", myStringList.RemoveKthLastElement(2));
            Assert.AreEqual("two", myStringList.RemoveKthLastElement(1));
            Assert.AreEqual("one", myStringList.RemoveKthLastElement(0));
            Assert.AreEqual(0, myStringList.Size);

            myStringList.AddLast("one");
            myStringList.AddLast("two");
            myStringList.AddLast("three");
            Assert.AreEqual(3, myStringList.Size);
            Assert.AreEqual("two", myStringList.RemoveKthLastElement(1));
            Assert.AreEqual("three", myStringList.RemoveKthLastElement(1));
            Assert.AreEqual("one", myStringList.RemoveKthLastElement(0));
            Assert.AreEqual(0, myStringList.Size);

            SinglelyLinkedList<int> myIntList = new SinglelyLinkedList<int>();
            myIntList.AddLast(1);
            myIntList.AddLast(2);
            myIntList.AddLast(3);
            Assert.AreEqual(3, myIntList.Size);
            Assert.AreEqual(3, myIntList.RemoveKthLastElement(0));
            Assert.AreEqual(2, myIntList.RemoveKthLastElement(0));
            Assert.AreEqual(1, myIntList.RemoveKthLastElement(0));
            Assert.AreEqual(0, myIntList.Size);


            SinglelyLinkedList<char> myCharList = new SinglelyLinkedList<char>();
            myCharList.AddLast('a');
            myCharList.AddLast('b');
            myCharList.AddLast('c');
            Assert.AreEqual(3, myCharList.Size);
            Assert.AreEqual('c', myCharList.RemoveKthLastElement(0));
            Assert.AreEqual('b', myCharList.RemoveKthLastElement(0));
            Assert.AreEqual('a', myCharList.RemoveKthLastElement(0));
            Assert.AreEqual(0, myCharList.Size);
        }


    }
}

