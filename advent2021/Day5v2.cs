using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace advent2021
{
    internal class Day5v2
    {
        private List<string> input;
        private int[,] xCoord;
        private int[,] yCoord;
        private int coordSize = 1000;

        public void SetUp()
        {
            //import file and sort coordinates
            List<List<int>> sortedInput = new List<List<int>>();
            input = File.ReadAllLines(/* Full path */ "").ToList();
            xCoord = new int[coordSize, 2];
            yCoord = new int[coordSize, 2];
            
            for (int i = 0; i < input.Count; i++)
            {
                input[i] = input[i].Replace(',', ' ').Replace("-> ", string.Empty);
                sortedInput.Add(input[i].Split().Where(x => x.Trim() != " ").Select(int.Parse).ToList());

                for(int j = 0; j < 1; j++)
                {
                    xCoord[i,j] = sortedInput[i][j];
                    xCoord[i,j+1] = sortedInput[i][j+2];
                    yCoord[i,j] = sortedInput[i][j+1];
                    yCoord[i,j+1] = sortedInput[i][j+3];
                }
            }
        }

        public int Part1()
        {
            int[,] points = new int[coordSize, coordSize];
            int countPoints = 0;

            foreach(int point in points)
            {
                points[point,point] = 0;
            }

            for(int i = 0; i < coordSize; i++)
            {
                int lowestX = Math.Min(xCoord[i, 0], xCoord[i, 0 + 1]);
                int lowestY = Math.Min(yCoord[i, 0], yCoord[i, 0 + 1]);
                int highestX = Math.Max(xCoord[i, 0], xCoord[i, 0 + 1]);
                int highestY = Math.Max(yCoord[i, 0], yCoord[i, 0 + 1]);
                int betweenX = highestX - lowestX;
                int betweenY = highestY - lowestY;

                //set diagonal and horizontal lines
                if(lowestX == highestX && lowestY != highestY)
                {
                    for (int z = lowestY; z <= highestY; z++)
                    {
                        points[lowestX,z]++;
                    }
                }
                if(lowestY == highestY && lowestX != highestX)
                {
                    for (int z = lowestX; z <= highestX; z++)
                    {
                        points[z, lowestY]++;
                    }

                }
                //part2: set diagonal lines
                if ((lowestX != highestX && lowestY != highestY) && (betweenX == betweenY))
                {
                    int x0 = xCoord[i, 0];
                    int x1 = xCoord[i, 0 + 1];
                    int y0 = yCoord[i, 0];
                    int y1 = yCoord[i, 0 + 1];
                    
                    //determine the direction of lines
                    if(x0 < x1)
                    {
                        if (y0 < y1)
                        {
                            for (int z = 0; z <= betweenX; z++)
                            {
                                points[x0, y0]++;
                                y0++;
                                x0++;
                            }
                        }
                        else
                        {
                            for (int z = 0; z <= betweenX; z++)
                            {
                                points[x0, y0]++;
                                y0--;
                                x0++;
                            }
                        }
                    }
                    else
                    {
                        if (y0 < y1)
                        {
                            for (int z = 0; z <= betweenX; z++)
                            {
                                points[x0, y0]++;
                                y0++;
                                x0--;
                            }
                        }
                        else
                        {
                            for (int z = 0; z <= betweenX; z++)
                            {
                                points[x0, y0]++;
                                y0--;
                                x0--;
                            }
                        }
                    }
                }
            }
            for(int x = 0; x < coordSize; x++)
            {
                for (int y = 0; y < coordSize; y++)
                {
                    if (points[y, x] > 1)
                    {
                        countPoints++;
                    }
                }
            }   
            return countPoints;
        }
    }
}
