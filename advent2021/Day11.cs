using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace advent2021
{
    internal class Day11
    {
        public int Part1()
        {
            List<string> input = File.ReadAllLines
                (/* Full path */ "").ToList();

            int[,] map = new int[input.Count, input[0].Length];
            int count = 0;
            int cycles = 0;
            bool synch = false;

            for (int i = 0; i < input.Count; i++)
            {
                for (int j = 0; j < input[0].Length; j++)
                {
                    map[i, j] = Convert.ToInt32(input[i][j] - '0');
                }
            }

            while(!synch)
            { 
                //fCount counts the amount of flashes each cycle
                int fCount = 0;
                cycles++;
                //Each octo gains one energy level
                for (int x = 0; x < map.GetLength(0); x++)
                {
                    for (int y = 0; y < map.GetLength(1); y++)
                    {
                        map[x, y]++;
                    }
                }
                //Octopus at level 10 flashes, increasing adjacent octopuses energy level by 1
                int z = 1;
                while (z > 0) 
                {
                    z = 0;
                    for (int x = 0; x < map.GetLength(0); x++)
                    {
                        for (int y = 0; y < map.GetLength(1); y++)
                        {
                            if (map[x, y] == 10)
                            {
                                Check(x, y, map);
                                fCount++;
                                z += 1;
                            }
                        }
                    }
                }
                if(fCount == map.GetLength(0)* map.GetLength(1))
                {
                    synch = true;
                    Console.WriteLine("Synch cycle: " + cycles);
                }
            }
            return count;

            void Check(int x, int y, int[,] map)
            {
                //check surrounding points and add 1 if not 0 or 10. 
                if(x > 0)
                {
                    if(map[x - 1, y] != 0 && map[x - 1, y] != 10)
                        map[x - 1, y]++;

                    if(y > 0 && map[x - 1, y - 1] != 0 && map[x - 1, y - 1] != 10)
                    {
                        map[x-1, y - 1]++;
                    }
                    if(y != map.GetLength(1) - 1 && map[x - 1, y + 1] != 0 && map[x - 1, y + 1] != 10)
                    {
                        map[x - 1, y + 1]++;
                    }
                }
                if(x != map.GetLength(0)-1)
                {
                    if(map[x + 1, y] != 0 && map[x + 1, y] != 10)
                        map[x + 1, y]++;

                    if (y > 0 && map[x + 1, y - 1] != 0 && map[x + 1, y - 1] != 10)
                    {
                        map[x + 1, y - 1]++;
                    }
                    if (y != map.GetLength(1) - 1 && map[x + 1, y + 1] != 0 && map[x + 1, y + 1] != 10)
                    {
                        map[x + 1, y + 1]++;
                    }
                }
                if(y > 0 && map[x, y - 1] != 0 && map[x, y - 1] != 10)
                    map[x,y - 1]++;
                if(y != map.GetLength(1) - 1 && map[x, y + 1] != 0 && map[x, y + 1] != 10)
                    map[x, y + 1]++;

                map[x, y] = 0;
                count++;
            }
        }
    }
}
/*
First, the energy level of each octopus increases by 1.
Then, any octopus with an energy level greater than 9 flashes. 
This increases the energy level of all adjacent octopuses by 1, including octopuses that are diagonally adjacent. 
If this causes an octopus to have an energy level greater than 9, it also flashes. 
This process continues as long as new octopuses keep having their energy level increased beyond 9. 
(An octopus can only flash at most once per step.)
Finally, any octopus that flashed during this step has its energy level set to 0, as it used all of its energy to flash.
*/