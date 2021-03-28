using System;
using System.Collections.Generic;
using System.Text;

namespace Program2
{
    class BracketsCheck
    {
        
        public bool IsOpen(char c)
        {
            if(c.Equals('(') || c.Equals('{') || c.Equals('['))
            {
                return true;
            }
            return false;
        }
        public bool IsClose(char c)
        {
            if (c.Equals(')') || c.Equals('}') || c.Equals(']'))
            {
                return true;
            }
            return false;
        }
        public  bool[] IsValid(string[] brackets, int n)
        {
            var bracPairs = new Dictionary<char, char>() {
            {'(', ')'},
            {'{', '}'},
            {'[', ']'}
            };

            bool[] result = new bool[n];
            Stack<char> myStack = new Stack<char>();
            int resultIndex = -1;

            foreach (string testString in brackets)
            {
                resultIndex++;
                if (testString.Equals(""))
                {
                    result[resultIndex] = true;
                    continue;
                }
                   
                for (int i = 0; i < testString.Length; i++)
                {
                    if (IsOpen(testString[i]))
                    {
                        myStack.Push(testString[i]);
                        //  Console.WriteLine(myStack.Peek());
                    }

                    else if (myStack.Count > 0 && IsClose(testString[i]))//({}), {{[}]}, ({})],[[[[[
                    {
                        char topValue = myStack.Pop();
                        if (!(bracPairs[topValue] == testString[i]))
                        {
                            result[resultIndex] = false;
                            break;
                        }
                    }
                    else
                    {
                        result[resultIndex] = false;
                        break;

                    }

                    if (i == testString.Length - 1 && myStack.Count==0)
                        result[resultIndex] = true;
                }
                myStack.Clear();
            }
            return result;
            
        }
    }
}
