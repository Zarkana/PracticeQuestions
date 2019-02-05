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
            LinkedList<string> myList = new LinkedList<string>();
            Assert.Throws<NullReferenceException>(() => myList.GetFirst());
        }

        [Test]
        public static void AddFirstToEmpty()
        {
            LinkedList<string> myList = new LinkedList<string>();
            string add = "Test";
            myList.AddFirst(add);
            Assert.AreEqual(myList.GetFirst(), add);
        }

        [Test]
        public static void AddFirstToFilled()
        {
            LinkedList<string> myList = new LinkedList<string>();
            myList.AddFirst("Content");
            myList.AddFirst("Content2");
            string add = "Test";
            myList.AddFirst(add);
            Assert.AreEqual(myList.GetFirst(), add);
        }







    }
}
