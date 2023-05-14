using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace advent2021
{
    internal class Day9
    {
        int[,] sortedInput;
        List<List<int>> coords = new List<List<int>>();
        public void StartUp()
        {
            List<string> input = File.ReadAllLines
                (/* Full path */ "").ToList();
            sortedInput = new int[input.Count, input[0].Length];

            for(int i = 0; i < input.Count; i++)
            {
                for(int j = 0; j < input[0].Length; j++)
                {
                    sortedInput[i,j] = Convert.ToInt32(input[i][j] - '0');
                }
            }
        }

        public int Part1()
        {
            List<int> lowPoints = new List<int>();
            int sum = 0;
            int count = 0;

            for (int x = 0; x < sortedInput.GetLength(0); x++)
            {
                for(int y = 0; y < sortedInput.GetLength(1); y++)
                {
                    int point = sortedInput[x, y];

                    if (x > 0 && sortedInput[x - 1, y] <= point)
                    {
                            continue;
                    }
                    if(x != sortedInput.GetLength(0) -1 && sortedInput[x + 1, y] <= point)
                    {
                            continue;
                    }
                    if(y > 0 && sortedInput[x, y - 1] <= point)
                    {
                            continue;
                    }
                    if(y != sortedInput.GetLength(1) - 1 && sortedInput[x, y + 1] <= point)
                    {

                            continue;
                    }
                    
                    lowPoints.Add(point);
                    count++;
                    AddCoord(x, y);
                }
            }
            for(int i = 0; i < lowPoints.Count; i++)
            {
                sum += lowPoints[i] + 1;
            }
            Console.WriteLine("Amount of low points: " + count);
            return sum;
        }

        //Part2
        public int Part2()
        {
            int product = 1;
            List<int> basins = new List<int>();
            bool[,] map = new bool[sortedInput.GetLength(0), sortedInput.GetLength(1)];

            for(int i = 0; i<coords.Count;i++)
            {
                int x = coords[i][0];
                int y = coords[i][1];

                basins.Add(Check(x, y, map));
            }
            basins.Sort();

            for(int i=basins.Count-1;i>basins.Count-4;i--)
            {
                product *= basins[i];
            }

            return product;
        }
        private void AddCoord(int x, int y)
        {
            coords.Add(new List<int> {x ,y});
        }

        private int Check(int x, int y, bool[,] map)
        {
            //if coords are counted for or 9, do not count to size
            if (sortedInput[x, y] == 9 || map[x, y])
                return 0;

            //point is valid
            int size = 1;
            map[x, y] = true;

            //recurse all neighbours
            if (x > 0)
            {
                size += Check(x - 1, y, map);
            }
            if (x != sortedInput.GetLength(0) - 1)
            {
                size += Check(x + 1, y, map);
            }
            if (y > 0)
            {
                size += Check(x, y - 1, map);
            }
            if (y != sortedInput.GetLength(1) - 1)
            {
                size += Check(x, y + 1, map);
            }

            return size;
        }
    }
}
/*if(x == 0)
{
    if(y == 0)
    {
        if(sortedInput[y+1,x] > point && sortedInput[y, x+1] > point)
        {
            lowPoints.Add(point);
        }
    }
    else if(y == sortedInput.GetLength(0) - 1)
    {
        if(sortedInput[y - 1, x] > point && sortedInput[y, x + 1] > point)
        {
            lowPoints.Add(point);
        }
    }
    else
    {
        if(sortedInput[y + 1, x] > point && sortedInput[y, x + 1] > point && sortedInput[y - 1, x] > point)
        {
            lowPoints.Add(point);
        }
    }
}
else if(x == sortedInput.GetLength(1) - 1)
{
    if (y == 0)
    {
        if (sortedInput[y + 1, x] > point && sortedInput[y, x - 1] > point)
        {
            lowPoints.Add(point);
        }
    }
    else if (y == sortedInput.GetLength(0) - 1)
    {
        if (sortedInput[y - 1, x] > point && sortedInput[y, x - 1] > point)
        {
            lowPoints.Add(point);
        }
    }
    else
    {
        if (sortedInput[y + 1, x] > point && sortedInput[y, x - 1] > point && sortedInput[y - 1, x] > point)
        {
            lowPoints.Add(point);
        }
    }
}
else
{
    if (y == 0)
    {
        if (sortedInput[y + 1, x] > point && sortedInput[y, x - 1] > point && sortedInput[y, x + 1] > point)
        {
            lowPoints.Add(point);
        }
    }
    else if (y == sortedInput.GetLength(0) - 1)
    {
        if (sortedInput[y - 1, x] > point && sortedInput[y, x - 1] > point && sortedInput[y, x + 1] > point)
        {
            lowPoints.Add(point);
        }
    }
    else
    {
        if (sortedInput[y + 1, x] > point && sortedInput[y - 1, x] > point 
            && sortedInput[y, x - 1] > point && sortedInput[y, x + 1] > point)
        {
            lowPoints.Add(point);
        }
    }
}*/




/* PART 2 First Check!
 * if (x > 0 && sortedInput[x - 1, y] != 9 && !map[x - 1, y])
            {
                map[x - 1, y] = true;
                bCounter++;
                Check(x - 1, y);
            }
            if (x != sortedInput.GetLength(0) - 1 && sortedInput[x + 1, y] != 9 && !map[x + 1, y])
            {
                map[x + 1, y] = true;
                bCounter++;
                Check(x + 1, y);
            }
            if (y > 0 && sortedInput[x, y - 1] != 9 && !map[x, y - 1])
            {
                map[x, y - 1] = true;
                bCounter++;
                Check(x, y - 1);  
            }
            if (y != sortedInput.GetLength(1) - 1 && sortedInput[x, y + 1] != 9 && !map[x, y + 1])
            {
                map[x, y + 1] = true;
                bCounter++;
                Check(x, y + 1);
            }*/