using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace advent2021
{
    internal class GetDepthCounter
    {
        string[] depthLines = File.ReadAllLines(/* Full path */ "");
        int[] depthInt;
        int depthDeeperCounter;
        int depthSumCounter;
        public int GetDepthDeeperCounter()
        {
            ConvertFileToInt();
            GetDepthData();
            return depthDeeperCounter;
        }
        public int GetSumCounter()
        {
            ConvertFileToInt();
            GetSumData();
            return depthSumCounter;
        }

        private void ConvertFileToInt()
        {
            depthInt = new int[depthLines.Length];
            for (int i = 0; i < depthLines.Length; i++)
            {
                depthInt[i] = Convert.ToInt32(depthLines[i]);
            }
        }

        private void GetDepthData()
        {
            Console.WriteLine("Data loaded! Amount of measurement: " + depthLines.Length);

            int previous = depthInt[0];
            for (int i = 0; i < depthInt.Length; i++)
            {
                if (depthInt[i] > previous)
                {
                    depthDeeperCounter++;
                }
                previous = depthInt[i];
            }
        }

        private void GetSumData()
        {
            int previous = depthInt[0] + depthInt[1] + depthInt[2];
            for (int i=0;i<depthInt.Length;i++)
            {
                if (i+2 < depthInt.Length)
                {
                    if (depthInt[i] + depthInt[i + 1] + depthInt[i + 2] > previous)
                    {
                        depthSumCounter++;
                    }
                    previous = depthInt[i] + depthInt[i + 1] + depthInt[i + 2];
                }
            }
        }
    }
}
