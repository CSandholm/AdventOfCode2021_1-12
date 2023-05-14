using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace advent2021
{
    internal class Day10
    {
        public int Part1()
        {
            List<char> save = new List<char>();
            List<string> input = new List<string>();
            List<string> corr = new List<string>();
            input = File.ReadAllLines
                (/* Full path */ "").ToList();
            char[] open = new char[] { '(', '[', '{', '<'};
            char[] close = new char[] { ')', ']', '}', '>' };
            int sum = 0;
            
            //save each opener in a stack and check that the next closer pairs with the latest opener.
            //if they check then remove the top of the stack and check the next closer
            //if closer do not match, then save that char to save list and carry on to the next string in input
            foreach (string i in input)
            {
                Stack stack = new Stack();

                for (int j = 0; j < i.Length; j++)
                {
                    if (i[j]==open[0]||i[j]==open[1]||i[j]==open[2]||i[j]==open[3])
                    {
                        stack.Push(i[j]);
                    }
                    else if 
                         (i[j] == close[0] && stack.Peek().ToString() == open[0].ToString() 
                        ||i[j] == close[1] && stack.Peek().ToString() == open[1].ToString()
                        || i[j] == close[2] && stack.Peek().ToString() == open[2].ToString()
                        || i[j] == close[3] && stack.Peek().ToString() == open[3].ToString())
                        stack.Pop();
                    else
                    {
                        save.Add(i[j]);

                        //for part2: save the corrupted lines and send to p2 as parameter together with input
                        corr.Add(i);

                        break;
                    }
                }
            }

            foreach(var i in save)
            {
                if (i == close[0])
                    sum += 3;
                if (i == close[1])
                    sum += 57;
                if (i == close[2])
                    sum += 1197;
                if (i == close[3])
                    sum += 25137;
            }
            Console.WriteLine("Day10 Part2: " + Part2(corr, input));
            return sum;
        }

        //part 2
        public long Part2(List<string> corr, List<string> input)
        {
            List<string> sortedInput = new List<string>();
            List<string> openers = new List<string>();
            char[] open = new char[] { '(', '[', '{', '<' };
            char[] close = new char[] { ')', ']', '}', '>' };

            for (int i = 0; i < input.Count; i++)
            {
                bool isCorr = false;
                for(int j = 0; j < corr.Count; j++)
                {
                    if (corr[j] == input[i])
                        isCorr = true;
                }
                if(!isCorr)
                    sortedInput.Add(input[i]);
            }

            foreach (string i in sortedInput)
            {
                Stack stack = new Stack();
                string temp = "";
                for (int j = 0; j < i.Length; j++)
                {
                    if (i[j] == open[0] || i[j] == open[1] || i[j] == open[2] || i[j] == open[3])
                    {
                        stack.Push(i[j]);
                    }
                    else if
                         (i[j] == close[0] && stack.Peek().ToString() == open[0].ToString()
                        || i[j] == close[1] && stack.Peek().ToString() == open[1].ToString()
                        || i[j] == close[2] && stack.Peek().ToString() == open[2].ToString()
                        || i[j] == close[3] && stack.Peek().ToString() == open[3].ToString())
                        stack.Pop();
                    else
                    {
                        break;
                    }
                }
                foreach(var v in stack)
                    temp += v.ToString();
                openers.Add(temp);
            }

            List<long> scores = new List<long>();

            for(int i=0;i<openers.Count;i++)
            {
                long score = 0;
                for(int j=0;j < openers[i].Length;j++)
                {
                    score *= 5;
                    if (openers[i][j] == open[0])
                        score += 1;
                    if (openers[i][j] == open[1])
                        score += 2;
                    if (openers[i][j] == open[2])
                        score += 3;
                    if (openers[i][j] == open[3])
                        score += 4;
                }
                scores.Add(score);
            }
            scores.Sort();
            return scores[(scores.Count/2)];
        }
    }
}
