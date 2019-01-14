using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_Questions
{
    [TestFixture]
    class Program
    {
        public enum BitWiseOperator { And, Or, Xor, Not}

        static void Main(string[] args)
        {
            String wordToCount = "aa";
            Console.WriteLine("The word " + wordToCount + " can be reordered in " + countPermutations(wordToCount) + " ways");

            wordToCount = "ab";
            Console.WriteLine("The word " + wordToCount + " can be reordered in " + countPermutations(wordToCount) + " ways");

            wordToCount = "abc";
            Console.WriteLine("The word " + wordToCount + " can be reordered in " + countPermutations(wordToCount) + " ways");

            wordToCount = "ramona";
            Console.WriteLine("The word " + wordToCount + " can be reordered in " + countPermutations(wordToCount) + " ways");

            wordToCount = "abba zabba";
            Console.WriteLine("The word " + wordToCount + " can be reordered in " + countPermutations(wordToCount) + " ways");

            wordToCount = "mississippi";
            Console.WriteLine("The word " + wordToCount + " can be reordered in " + countPermutations(wordToCount) + " ways");


            //char[] str = PrepUrlify("How do you do when I s a y things?");
            //int trueLength = GetTrueLength(str);
            //string urlified = URLify(str, trueLength);
            //Console.WriteLine(urlified);
            //char[] str = PrepUrlify("How do you do when I say things?");
            //int trueLength = GetTrueLength(str);
            //string urlified = URLifyAlt(str, trueLength);
            //Console.WriteLine(urlified);


            //int n = 2;
            //int m = 5;
            //Console.WriteLine(Multiply(n, m));
            //Console.WriteLine(InneficientMultiply(n, m));

            //int[,] matrix = new int[4, 4] { { 2, 1, 9, 3 }, { 1, 2, 3, 1 }, { 1, 3, 2, 1 }, { 3, 1, 1, 2 } };

            //Console.WriteLine("Matrix 1");
            //int[,] matrix = new int[4, 4] { { 0, 1, 9, 3 }, { 1, 2, 2, 1 }, { 1, 3, 2, 1 }, { 3, 1, 1, 0 } };
            //printMatrix(matrix);

            //matrix = rotateMatrix(matrix);
            ////printMatrix(matrix);

            //matrix = rotateMatrix(matrix);
            ////printMatrix(matrix);

            //matrix = rotateMatrix(matrix);
            ////printMatrix(matrix);

            //matrix = rotateMatrix(matrix);
            //printMatrix(matrix);            

            //matrix = zeroMatrix(matrix);
            //printMatrix(matrix);

            //Console.WriteLine("Matrix 2");
            //matrix = new int[3, 5] { { 2, 1, 1, 1, 1 }, { 1, 1, 3, 1, 0 }, { 1, 3, 2, 1, 0 } };
            //printMatrix(matrix);

            //matrix = zeroMatrix(matrix);
            //printMatrix(matrix);

            //matrix = new int[4, 4] { { 0, 1, 9, 3 }, { 1, 2, 2, 1 }, { 1, 3, 2, 1 }, { 3, 1, 1, 0 } };
            //matrix = zeroMatrixImproved(matrix);
            //printMatrix(matrix);

            //CollectionsPractice();


            //int a = 10;
            //int b = 12;
            //Console.WriteLine("OR: " + BitWiseOperation(BitWiseOperator.Or, a, b));
            //Console.WriteLine("AND: " + BitWiseOperation(BitWiseOperator.And, a, b));
            //Console.WriteLine("XOR: " + BitWiseOperation(BitWiseOperator.Xor, a, b));


            //Console.WriteLine(Multiply(30, 30));
            //Console.WriteLine(Multiply(1003, 3));

            //string s1 = "absc";
            //string s2 = "scax";
            //Console.WriteLine(isPermutation(s1, s2));
            //Console.WriteLine(isPermutationEnhanced(s1, s2));
            //Console.WriteLine(IsUniqueString("abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZa"));
            //Console.WriteLine(IsUniqueString("abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ"));
            //Console.WriteLine(IsUniqueStrinAlt("abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZa"));
            //Console.WriteLine(IsUniqueStrinAlt("abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ"));


            //Console.WriteLine(isRotation("rotation","ionrotat"));
            //Console.WriteLine(isRotation("rotation", "ionrott"));
        }

        [Test]
        public void MyTest()
        {
            Assert.AreEqual("abc", "abc");
        }

        //TODO make generic!
        public static int countPermutations(string str)
        {
            int permutations = calcPermutation(str.Length);
            Dictionary<int, int> frequencies = new Dictionary<int, int>();

            for(int i = 0; i < str.Length; i++)
            {
                if(!frequencies.ContainsKey(str[i]))
                    frequencies.Add(str[i], 1);
                else
                    frequencies[str[i]]++;
            }
            int redundantPermutations = 1;
            foreach(var frequency in frequencies)
            {
                if(frequency.Value > 1)
                    redundantPermutations *= calcPermutation(frequency.Value);
            }
            return permutations / redundantPermutations;
        }

        public static int calcPermutation(int multiplyBy, int permutations = 1)
        {
            if (multiplyBy == 1) //base case of 1
            {
                return permutations;
            }
            return calcPermutation(multiplyBy - 1, permutations * multiplyBy) ;

        }



        public static void printMatrix(int[,] mat)
        {
            int rows = mat.GetLength(0);
            int cols = mat.GetLength(1);
            for (int row = 0; row < rows; row++)
            {
                

                for (int col = 0; col < cols; col++)
                {
                    Console.Write(mat[row,col]);
                    
                }                
                Console.WriteLine("");
            }
            Console.WriteLine("");
        }

        public static int[,] rotateMatrix(int[,] mat)
        {
            int n = mat.GetLength(0);
            Console.WriteLine("Matrix rotated");
            for (int layer = 0; layer < n / 2; layer++)
            {
                for(int i = layer; i < n - 1 - layer; i++)
                {
                    int temp = mat[layer,i];
                    mat[layer, i] = mat[i, n - 1 - layer];
                    mat[i, n - 1 - layer] = mat[n - 1 - layer, n - 1 - i];
                    mat[n - 1 - layer, n - 1 - i] = mat[n - 1 - i, layer];
                    mat[n - 1 - i, layer] = temp;
                }
            }

            return mat;
        }

        public static int[,] zeroMatrixImproved(int[,] mat)
        {
            List<int> rows = new List<int>();
            List<int> cols = new List<int>();

            int width = mat.GetLength(0);
            int height = mat.GetLength(1);

            for (int i = 0; i < height; i++)
            {
                for(int j = 0; j < width; j++)
                {
                    if(mat[i,j] == 0)
                    {
                        rows.Add(i);
                        cols.Add(j);
                    }
                }
            }

            for(int i = 0; i < rows.Count; i++)//for every row with a zero
            {
                for(int j = 0; j < width; j++)//make each element in that row zero
                {
                    mat[rows[i], j] = 0;
                }
            }
            for(int i= 0; i < cols.Count; i++)//for every col with a zero
            {
                for(int j = 0; j < height; j++)//make each element in that col zero
                {
                    mat[j, cols[i]] = 0;
                }
            }         

            return mat; 
        }

        public static int[,] zeroMatrix(int[,] mat)
        {
            HashSet<int> isSet = new HashSet<int>();
            int height = mat.GetLength(0);
            int width = mat.GetLength(1);

            Console.WriteLine("Zeromatrixed");
            for (int row = 0; row < height; row++)
            {
                for(int col = 0; col < width; col++)
                {
                    if(!isSet.Contains(calcIndex(row, col, width)))
                    {
                        if(mat[row,col] == 0)
                        {
                            //set entire row to zero
                            for(int c = 0; c < width; c++)
                            {
                                if(mat[row, c] != 0)
                                {                                
                                    mat[row, c] = 0;
                                    isSet.Add(calcIndex(row, c, width));
                                }
                            }
                            //set entire column to zero
                            for(int r = 0; r < height; r++)
                            {
                                if (mat[r, col] != 0)
                                {
                                    mat[r, col] = 0;
                                    isSet.Add(calcIndex(r, col, width));
                                }
                            }
                            break;
                        }
                    }
                }
            }

            return mat;
        }

        public static int calcIndex(int row, int col, int width)
        {
            //return (row + 1) * (col + 1) - 1;
            return (width * row) + col;
        }

        public static bool isRotation(string s1, string s2)
        {
            s2 += s2;
            if (s2.Contains(s1))
            {
                return true;
            }
            return false;
        }

        public static int BitWiseOperation(BitWiseOperator operatorType, int a, int b)
        {
            switch (operatorType)
            {
                case BitWiseOperator.And:
                    return a & b;
                    break;
                case BitWiseOperator.Or:
                    return a | b;
                    break;
                case BitWiseOperator.Xor:
                    return a ^ b;
                    break;

            }
            return 0;
        }

        public static int Multiply(int n, int m)
        {
            int answer = 0, count = 0;
            while(m > 0)
            {
                //check for set bit and left
                //shift n, count times
                if(m % 2 == 1)//if odd
                {
                    answer = answer + (n << count);
                }

                //increment of place value (count)
                count++;

                //make m equal to itself divided in half
                m = m >> 1;
            }
            return answer;
        }

        public static int InneficientMultiply(int n, int m)
        {
            int answer = 0;
            int twosin = m / 2;//how many twos are in

            //while(m > 1)
            //{
            //    if(twosin > 0)
            //    {
            //        answer += n << 1;
            //        twosin--;
            //        m--;
            //        m--;
            //    }else if(m )
            //    {
            //        answer += n;
            //    }


                
                
            //}

            return answer;
        }

        public static string compressString2(string a)
        {
            char[] orig = a.ToCharArray();
            char[] compressed = new char[orig.Length * 2];
            char currChar = orig[0];
            int compIndex = 0;
            int currCharCount = 0;

            for(int i = 0; i < orig.Length; i++)
            {
                //if (currCharCount == 0)
                //{
                //    currChar = orig[i];
                //    currCharCount++;
                //}else 
                if (orig[i] == currChar)
                {
                    currCharCount++;
                }else
                {
                    compressed[compIndex] = currChar;
                    compressed[compIndex + 1] = currCharCount.ToString().ToCharArray()[0];
                    compIndex += 2;

                    currChar = orig[i];
                    currCharCount = 1;
                }
            }
            compressed[compIndex] = currChar;
            compressed[compIndex + 1] = currCharCount.ToString().ToCharArray()[0];

            return new String(compressed);
        }

        public static string compressString(string str)
        {
            int count = 0;//no digit has been counted
            char currChar = str[0];
            int compIndex = 0;
            string original = str;
            for(int i = 0; i < str.Length; i++)
            {
                if (i == str.Length - 1)
                {
                    compIndex++;
                    if (original.Length <= compIndex)
                    {
                        return original;
                    }
                    //str = replaceChar(str, compIndex, currChar);
                    //compIndex++;//move up compressed index to enter in count
                    //str = replaceChar(str, compIndex, ("" + count).ToCharArray()[0]);
                }

                if(currChar == original[i])
                {
                    count++;//increment the count for the current char
                }else
                {
                    str = replaceChar(str, compIndex, currChar);//TODO: broken, should be appending to a new string not replacing, or something
                    currChar = original[i];//new currChar equal to the new char we just ran into
                    
                    compIndex++;//move up compressed index to enter in count
                    str = replaceChar(str, compIndex, ("" + count).ToCharArray()[0]);
                    compIndex++;//move compressed index past the count digit
                    count = 1;//reset count to 1 because we have already reached the first new digit                   
                }
            }


            if(original.Length < compIndex)
            {
                return original;
            }
            else
            {
                //return str.Remove(compIndex);
                return str;
            }
        }

        public static string replaceChar(string str, int index, char c)
        {
            StringBuilder sb = new StringBuilder(str);
            sb[index] = (char)c; // index starts at 0!
            return sb.ToString();
        }

        public static bool isOneEditAway(string a, string b)
        {
            bool edited = false;
            int bIndex = 0;
            if (Math.Abs(a.Length - b.Length) > 1) return false;
            for(int i = 0; i < a.Length; i++)
            {
                if(a[i] != b[bIndex])
                {
                    if (edited)
                    {
                        return false;
                    }
                    edited = true;
                    if(a.Length < b.Length){
                        bIndex++;
                    }else if (a.Length > b.Length){
                        bIndex--;
                    }
                }
                bIndex++;
            }
            return true;
        }

        public static bool isPalindrome(string str)
        {
            int oddCount = 0;
            Dictionary<char, int> freq = new Dictionary<char, int>();
            for(int i = 0; i < str.Length; i++)
            {
                if (!freq.ContainsKey(str[i]))
                {
                    freq.Add(str[i], 1);
                }else
                {
                    freq[str[i]]++;
                }
                if(freq[str[i]] % 2 == 0)
                {
                    oddCount--;
                }
                else
                {
                    oddCount++;
                }
            }
            if(oddCount > 1)
            {
                return false;
            }        
            return true;
        }

        public static bool isPalindromeEnhanced(string str)
        {
            int odd = 0;
            HashSet<char> freq = new HashSet<char>();

            for(int i = 0; i < str.Length; i++)
            {
                if (!freq.Contains(str[i]))//if didn't contain
                {
                    freq.Add(str[i]);
                    odd++;
                }else//if did contain
                {
                    freq.Remove(str[i]);
                    odd--;
                }
            }

            if(odd > 1) { return false; } else { return true; }
        }


        static char[] PrepUrlify(string str)
        {
            int WhiteSpaces = CountWhiteSpaces(str.ToCharArray(), str.Length);

            for(int i = 0; i < WhiteSpaces; i++)
            {
                str += "  ";
            }
            return str.ToCharArray();
        }

        static int GetTrueLength(char[] str)
        {
            int padding = 0;
            for(int i = 0; i < str.Length; i++)
            {
                if(str[(str.Length - 1) - i] != ' ')
                {
                    break;
                }
                else
                {
                    padding++;
                }
            }            
            return str.Length - padding;
        }

        static string URLify(char[] str, int trueLength)
        {
            int WhiteSpaces = CountWhiteSpaces(str, trueLength);
            int index = str.Length;
            for (int i = trueLength-1; WhiteSpaces > 0; i--){                
                if(str[i] == ' ')
                {
                    str[index - 1] = '0';
                    str[index - 2] = '2';
                    str[index - 3] = '%';
                    WhiteSpaces--;
                    index = index - 3;
                }
                else
                {
                    str[index -1] = str[i];
                    index--;
                }
            }


            return new string(str);
        }
        static string URLifyAlt(char[] str, int tLen)
        {
            int tIndex = tLen - 1;
            int fIndex = str.Length - 1;
            while(tIndex > 0)
            {
                if(str[tIndex] == ' ')
                {
                    str[fIndex] = '0';
                    fIndex--;
                    str[fIndex] = '2';
                    fIndex--;
                    str[fIndex] = '%';
                    fIndex--;
                }
                else
                {
                    str[fIndex] = str[tIndex];
                    fIndex--;
                }
                tIndex--;
            }


            return new string(str);
        }

        static int CountWhiteSpaces(char[] str, int len)
        {
            int WhiteSpaces = 0;
            for(int i = 0; i < len; i++)
            {
                if (str[i] == ' ') WhiteSpaces++;
            }
            return WhiteSpaces;
        }

        static bool isPermutation(string s, string t)
        {
            if (s.Length != t.Length) return false;

            return sortString(s).Equals(sortString(t));
        }

        static bool isPermutationEnhanced(string s, string t)
        {
            if (s.Length != t.Length) return false;

            int[] frequencies = new int[128];
            for(int i = 0; i < s.Length; i++)
            {
                frequencies[s[i]]++;
            }
            for(int i = 0; i < t.Length; i++)
            {
                frequencies[t[i]]--;
                if(frequencies[t[i]] < 0)
                {
                    return false;
                }
            }

            return true;
        }

        static string sortString(string s)
        {
            char[] charArray = s.ToArray();
            Array.Sort(charArray);
            return new string(charArray);
        }

        static bool IsUniqueString(string s)
        {
            if(s.Length > 128)
            {
                return false;
            }

            HashSet<char> hs = new HashSet<char>();

            foreach(char c in s)
            {
                if (hs.Contains(c))
                {
                    return false;
                }
                else
                {
                    hs.Add(c);
                }
            }


            return true;
        }

        static bool IsUniqueStrinAlt(string s)
        {
            if (s.Length > 128) return false;
            

            Dictionary<char, int> frequency = new Dictionary<char, int>();

            for (int i = 0; i < s.Length; i++)
            {
                if (frequency.ContainsKey(s[i])){
                    return false;
                }else
                {
                    frequency[s[i]] = 1;
                }                    
            }
            return true;
        }

        /// <summary>
        /// System.Collections Namespace
        /// The System.Collections namespace contains interfaces and classes that define various collections of objects, such as lists, queues, bit arrays, hash tables and dictionaries.
        /// from https://docs.microsoft.com/en-us/dotnet/api/system.collections?view=netframework-4.7.2
        /// </summary>
        public static void CollectionsPractice()
        {
            //CLASSES

            /// <summary> 
            /// ArrayList	
            /// Implements the IList interface using an array whose size is dynamically increased as required.
            /// </summary>
            ArrayList myAL = new ArrayList();
            myAL.Add(1);
            myAL.Add("Custom Text");
            PrintValues(myAL);

            /// <summary> 
            /// BitArray	
            /// Manages a compact array of bit values, which are represented as Booleans, where true indicates that the bit is on (1) and false indicates the bit is off (0).
            /// </summary>

            /// <summary> 
            /// CaseInsensitiveComparer	
            /// Compares two objects for equivalence, ignoring the case of strings.
            /// </summary>

            /// <summary> 
            /// CaseInsensitiveHashCodeProvider	
            /// Supplies a hash code for an object, using a hashing algorithm that ignores the case of strings.
            /// </summary>

            /// <summary> 
            /// CollectionBase	
            /// Provides the abstract base class for a strongly typed collection.
            /// </summary>

            /// <summary> 
            /// Comparer	
            /// Compares two objects for equivalence, where string comparisons are case-sensitive.
            /// </summary>

            /// <summary> 
            /// DictionaryBase	
            /// Provides the abstract base class for a strongly typed collection of key/value pairs.
            /// </summary>

            /// <summary> 
            /// Hashtable	
            /// Represents a collection of key/value pairs that are organized based on the hash code of the key.
            /// </summary>

            /// <summary> 
            /// Queue	
            /// Represents a first-in, first-out collection of objects.
            /// </summary>

            /// <summary> 
            /// ReadOnlyCollectionBase	
            /// Provides the abstract base class for a strongly typed non-generic read-only collection.
            /// </summary>

            /// <summary> 
            /// SortedList	
            /// Represents a collection of key/value pairs that are sorted by the keys and are accessible by key and by index.
            /// </summary>

            /// <summary> 
            /// Stack	
            /// Represents a simple last-in-first-out (LIFO) non-generic collection of objects.
            /// </summary>

            /// <summary> 
            /// StructuralComparisons	
            /// Provides objects for performing a structural comparison of two collection objects.
            /// </summary>

            // STRUCTS

            /// <summary> 
            /// DictionaryEntry	
            /// Defines a dictionary key/value pair that can be set or retrieved.
            /// </summary>
            /// 

            // INTERFACES

            /// <summary> 
            /// ICollection	
            /// Defines size, enumerators, and synchronization methods for all nongeneric collections.
            /// </summary>

            /// <summary> 
            /// IComparer	
            /// Exposes a method that compares two objects.
            /// </summary>

            /// <summary> 
            /// IDictionary	
            /// Represents a nongeneric collection of key/value pairs.
            /// </summary>

            /// <summary> 
            /// IDictionaryEnumerator	
            /// Enumerates the elements of a nongeneric dictionary.
            /// </summary>

            /// <summary> 
            /// IEnumerable	
            /// Exposes an enumerator, which supports a simple iteration over a non-generic collection.
            /// </summary>

            /// <summary> 
            /// IEnumerator	
            /// Supports a simple iteration over a non-generic collection.
            /// </summary>

            /// <summary> 
            /// IEqualityComparer	
            /// Defines methods to support the comparison of objects for equality.
            /// </summary>

            /// <summary> 
            /// IHashCodeProvider	
            /// Supplies a hash code for an object, using a custom hash function.
            /// </summary>

            /// <summary> 
            /// IList	
            /// Represents a non-generic collection of objects that can be individually accessed by index.
            /// </summary>

            /// <summary> 
            /// IStructuralComparable	
            /// Supports the structural comparison of collection objects.
            /// </summary>

            /// <summary> 
            /// IStructuralEquatable	
            /// Defines methods to support the comparison of objects for structural equality.
            /// </summary>

        }

        public static void PrintValues(IEnumerable myList)
        {
            foreach (Object obj in myList)
                Console.WriteLine("{0}", obj);
            Console.WriteLine();
        }

    }
}
