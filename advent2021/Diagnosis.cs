using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace advent2021
{
    internal class Diagnosis
    {
        string[] diaLines = System.IO.File.ReadAllLines(/* Full path */ "");
        string mostCommon;
        string leastCommon;

        string[] oxygen;
        public string GetMostCommon()
        {
            return mostCommon;
        }
        public string GetLeastCommon()
        {
            return leastCommon;
        }
        public void SetMostCommon()
        {
            oxygen = new string[diaLines.Length];

            for (int i=0; i<diaLines.Length; i++)
            {
                oxygen[i] = diaLines[i];
            }

            for (int j=0; j < 12; j++)
            {
                int zeroes = 0;
                int ones = 0;

                for (int i = 0; i < diaLines.Length; i++)
                {
                    if (diaLines[i][j] == '1')
                    {
                        ones++;
                    }
                    else
                    {
                        zeroes++;
                    }                    
                }
                if(zeroes <= ones)
                {
                    mostCommon += "1";
                    leastCommon += "0";

                    for (int i=0; i < oxygen.Length; i++)
                    {
                        if (oxygen[i][j] == '0')
                        {
                            oxygen = oxygen.Where(w => w != oxygen[i]).ToArray();
                        }
                    }
                }
                else
                {
                    mostCommon += "0";
                    leastCommon += "1";
                    for (int i = 0; i < oxygen.Length; i++)
                    {
                        if (oxygen[i][j] == '1')
                        {
                            oxygen = oxygen.Where(w => w != oxygen[i]).ToArray();
                        }
                    }
                }       
            }  
        }

        public void GetOxygen()
        {
            for(int i = 0; i < oxygen.Length; i++)
            {
                Console.WriteLine("Oxygen: " + oxygen[i]);
            }
            
        }
    }
}
