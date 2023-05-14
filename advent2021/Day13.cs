using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace advent2021
{
    internal class Day13
    {
        bool[,] map;
        (string, string) inst;

        public void Part1()
        {
            StartUp();
        }

        public void StartUp()
        {
            List<string> input = File.ReadAllLines
                (/* Full path */ "")
                .Select(x => x.Replace(",", " ")).ToList();

            map = new bool[input.Count - 2, 2];

            for (int i = 0; i < input.Count-2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    map[i, j] = true;
                }
            }
            inst = (input[input.Count - 2], input[input.Count - 1]);
        }
    }  
}

/*
6,10
0,14
9,10
0,3
10,4
4,11
6,0
6,12
4,1
0,13
10,12
3,4
3,0
8,4
1,10
2,14
8,10
9,0

fold along y=7
fold along x=5
*/