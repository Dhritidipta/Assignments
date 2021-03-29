using System;
using System.Collections.Generic;
using System.Text;

namespace Program1
{
    class CountDistinctPairs
    {
        public string[] Names{get; private set;}
        private readonly int n;
        public CountDistinctPairs(string[] names, int n)
        {
            this.n = n;
            Names = names;
        }
        public int CountPairs()
        {
            int i, j, count = 0;
            //assuming the names are of 2words:
            string[] name1 = new string[2];
            string[] name2 = new string[2];


            for (i = 0; i < n - 1; i++)
            {
                for (j = i + 1; j < n; j++)
                {
                    name1 = Names[i].Split(" ");
                    name2 = Names[j].Split(" ");
                    if ((name1[0] == name2[0] && name1[1] == name2[1]) || (name1[0] == name2[1] && name1[1] == name2[0]))
                        count++;
                }
            }
            return count;
        }
    }
}
