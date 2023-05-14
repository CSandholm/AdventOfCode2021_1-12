using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace advent2021
{
    internal class Position
    {
        string positionLines = System.IO.File.ReadAllText(/* Full path */ "");
        int forward;
        int down;
        int up;
        int aim;
        int depth;

        public int MultiplyDirections()
        {
            GetDirections();

            Console.WriteLine("Up, Down, Forward: " + up + "," + down + "," + forward);

            int muliplied = depth * forward;

            return muliplied;
        }
        private void GetDirections()
        {

            string[] positionWords = positionLines.Split(new string[] { " ", "\r\n", "\r", "\n" }, StringSplitOptions.None);

            for (int i=0; i < positionWords.Length; i++)
            {
                if (positionWords[i].Contains("forward"))
                {
                    if(aim != 0)
                    {
                        depth += aim * Convert.ToInt32(positionWords[i + 1]);
                    }
                    forward += Convert.ToInt32(positionWords[i + 1]);    
                }
                else if (positionWords[i].Contains("down"))
                {
                    aim += Convert.ToInt32(positionWords[i + 1]);
                    down += Convert.ToInt32(positionWords[i+1]);
                }
                else if (positionWords[i].Contains("up"))
                {
                    aim -= Convert.ToInt32(positionWords[i + 1]);
                    up += Convert.ToInt32(positionWords[i+1]);
                }
            }
        }
    }
}
