using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace advent2021
{
    internal class Diagnos
    {
        List<string> diagnos = File.ReadAllLines(/* Full path */ "").ToList();
        List<string> oxygen;
        List<string> cO2;

        public void runDiagnostics()
        {
            oxygen = new List<string>(diagnos.Count);
            cO2 = new List<string>(diagnos.Count);
            diagnos.ForEach((item) => oxygen.Add((string)item.Clone()));
            diagnos.ForEach((item) => cO2.Add((string)item.Clone()));

            for (int i=0; i < oxygen[0].Length; i++)
            {
                int zeroes = 0;
                int ones = 0;
                int coZeroes = 0;
                int coOnes = 0;

                //räkna oxygen ettor och nollor
                for(int j = 0; j < oxygen.Count; j++)
                {
                    if (oxygen[j][i] == '1')
                    {
                        ones++;
                    }
                    else
                    {
                        zeroes++;
                    }
                }
                for(int j = oxygen.Count - 1; j >= 0; j--)
                {
                    if(zeroes <= ones)
                    {
                        if (oxygen[j][i] == '0' && oxygen.Count > 1)
                        {
                            oxygen.RemoveAt(j);
                        } 
                    }
                    else
                    {
                        if (oxygen[j][i] == '1' && oxygen.Count > 1)
                        {
                            oxygen.RemoveAt(j);
                        }
                    }
                }
                //räkna co2 ettor och nollor
                for (int j = 0; j < cO2.Count; j++)
                {
                    if (cO2[j][i] == '1')
                    {
                        coOnes++;
                    }
                    else
                    {
                        coZeroes++;
                    }
                }
                for (int j = cO2.Count - 1; j >= 0; j--)
                {
                    if (coZeroes <= coOnes && cO2.Count > 1)
                    {
                        if(cO2[j][i] == '1')
                        {
                            cO2.RemoveAt(j);
                        }
                    }
                    else if(cO2.Count > 1)
                    {
                        if (cO2[j][i] == '0' && cO2.Count > 1)
                        {
                            cO2.RemoveAt(j);
                        }
                    }
                }
            }
        }
        
        public string getCO2()
        {
            return cO2[0];
        }
        public string getOxygen()
        {
            return oxygen[0];
        }
    }
}
