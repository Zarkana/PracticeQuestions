using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_Questions
{
    interface IJoe : IPerson
    {
        void Add<T>(T item);
    }

    interface IPerson
    {
        void AddFirst<T>(T item);
    }

    public class Joe : IPerson
    {

        //This is NOT explicitly implemented?
        public void AddFirst<T>(T item)
        {
            Console.WriteLine("NOT explicitly implemented");
        }

        //This is explicitly implemented?
        void IPerson.AddFirst<T>(T item){
            Console.WriteLine("explicitly implemented");
        }
    }

}
