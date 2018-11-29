﻿using NUnit.Framework;
using System;
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


            //Console.WriteLine(compressString("aaabbc"));
            //Console.WriteLine(compressString("abbccc"));
            //Console.WriteLine(compressString("f"));
            //Console.WriteLine(compressString("fffggbbc"));

            //Console.WriteLine("aa" + " aa " + isOneEditAway("aa", "aa"));
            //Console.WriteLine("ab" + " aa " + isOneEditAway("ab", "aa"));
            //Console.WriteLine("aa" + " aaa " + isOneEditAway("aa", "aaa"));
            //Console.WriteLine("abb" + " aa " + isOneEditAway("abb", "aa"));
            //Console.WriteLine("aaa" + " a " + isOneEditAway("aaa", "a"));
            //Console.WriteLine("abb" + " aaa " + isOneEditAway("abb", "aaa"));
            //Console.WriteLine("aaaa" + " aba " + isOneEditAway("aaaa", "aba"));

            //Console.WriteLine(isPalindrome("illuminati"));            

            //char[] str = PrepUrlify("How do you do when I s a y things?");
            //int trueLength = GetTrueLength(str);
            //string urlified = URLify(str, trueLength);
            //Console.WriteLine(urlified);
            //char[] str = PrepUrlify("How do you do when I say things?");
            //int trueLength = GetTrueLength(str);
            //string urlified = URLifyAlt(str, trueLength);
            //Console.WriteLine(urlified);


            //int n = 99999;
            //int m = 9999;
            //Console.WriteLine(Multiply(n, m));


            int a = 10;
            int b = 12;
            Console.WriteLine("OR: " + BitWiseOperation(BitWiseOperator.Or, a, b));
            Console.WriteLine("AND: " + BitWiseOperation(BitWiseOperator.And, a, b));
            Console.WriteLine("XOR: " + BitWiseOperation(BitWiseOperator.Xor, a, b));


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

        }

        [Test]
        public void MyTest()
        {
            Assert.AreEqual("abc", "abc");
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
    }
}