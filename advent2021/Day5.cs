using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace advent2021
{
    internal class Day5
    {
        private List<string> input;
        private List<List<int>> changeInPosition;

        public void StartUp()
        {
            var splitInput = new List<List<string>>();
            changeInPosition = new List<List<int>>();
            input = File.ReadAllLines(/* Full path */ "").ToList();

            //splitInput till [x][0] är första värde (X&Y), [x][1] är andra värde.
            for(int i = 0; i < input.Count; i++)
            {
                splitInput.Add(input[i].Split().Where(x => x.Trim() != "->").ToList());
                for(int j = 0; j < 2; j++)
                {
                    splitInput[i][j] = splitInput[i][j].Replace(',',' ');
                }
                for(int j = 0; j < 2; j++)
                {
                    changeInPosition.Add(splitInput[i][j].Split().Where(x => x.Trim() != "").Select(int.Parse).ToList());
                }
            }
        }

        public int Part1()
        {
            int[] xMovement = new int[1000];
            int[] yMovement = new int[1000];
            int counter = 0;

            foreach(int x in xMovement)
            {
                xMovement[x] = 0;
                yMovement[x] = 0;
            }

            for (int i = 0; i <= changeInPosition.Count; i+=2)
            {

                if (i < changeInPosition.Count)
                {
                    int xPositionStart = changeInPosition[i][0];
                    int xPositionEnd = changeInPosition[i + 1][0];
                    int yPositionStart = changeInPosition[i][1];
                    int yPositionEnd = changeInPosition[i + 1][1];

                    if (xPositionStart == xPositionEnd)
                    {
                        xMovement[xPositionStart] -= 1;

                        var adder = yPositionStart - yPositionEnd;
                        if (adder < 0)
                        {
                            for(int j = yPositionStart; j<= yPositionEnd; j++)
                            {
                                yMovement[j] -= 1;
                            }
                        }
                        else
                        {
                            for (int j = yPositionEnd; j <= yPositionStart; j++)
                            {
                                yMovement[j] -= 1;
                            }
                        }
                    }
                    if (yPositionStart == yPositionEnd)
                    {
                        yMovement[yPositionStart] -= 1;

                        var adder = xPositionStart - xPositionEnd;
                        if(adder < 0)
                        {
                            for(int j= xPositionStart; j <= xPositionEnd; j++)
                            {
                                xMovement[j] -= 1;
                            }
                        }
                        else
                        {
                            for(int j = xPositionEnd; j <= xPositionStart; j++)
                            {
                                xMovement[j] = xMovement[j] -1;
                            }
                        }
                    }
                }
            }

            for(int i = 0; i < 1000; i++)
            {
                if (xMovement[i] == -1 && yMovement[i] == -1)
                {
                    counter++;
                }
                else if (xMovement[i] < -1) 
                {
                    counter++;
                }
                else if (yMovement[i] < -1)
                {
                    counter++;
                }
            }

            return counter;
        }
    }
}
