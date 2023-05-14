using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace advent2021
{
    internal class Day6
    {
        int maxHealth = 8;
        int birthRate = 7;
        int startAmount;
        List<long> fish;
        public void StartUp()
        {
            //fish-List tracks how many fish that have a certain amount of days to birth a new fish

            List<string> input = GetInput().Replace(",", " ").Split().Where(x => x.Trim() != " ").ToList();
            fish = new List<long>();
            startAmount = input.Count; 

            for (int i=0;i<=maxHealth;i++)
            {
                fish.Add(0);
            }

            for (int i = 0; i < startAmount; i++)
            {
                fish[Convert.ToInt32(input[i])]++;
            }
        }

        public long Part1()
        {
            //the amount of fish in [0] will give birth to equal amount of new fish, and equal to the fish going back to maxHealth.
            //amountOfFish tracks startAmount + each new fish

            int days = 256;
            long amountOfFish = startAmount;

            for(int d = 0; d < days; d++)
            {
                fish[birthRate] += fish[0];
                fish.Add(fish[0]);
                amountOfFish += fish[0];
                fish.RemoveAt(0);
            }
            return amountOfFish;
        }

        private string GetInput()
        {
            string input = "3,5,1,5,3,2,1,3,4,2,5,1,3,3,2,5," +
                "1,3,1,5,5,1,1,1,2,4,1,4,5,2,1,2,4,3,1,2,3,4," +
                "3,4,4,5,1,1,1,1,5,5,3,4,4,4,5,3,4,1,4,3,3,2," +
                "1,1,3,3,3,2,1,3,5,2,3,4,2,5,4,5,4,4,2,2,3,3," +
                "3,3,5,4,2,3,1,2,1,1,2,2,5,1,1,4,1,5,3,2,1,4," +
                "1,5,1,4,5,2,1,1,1,4,5,4,2,4,5,4,2,4,4,1,1,2," +
                "2,1,1,2,3,3,2,5,2,1,1,2,1,1,1,3,2,3,1,5,4,5," +
                "3,3,2,1,1,1,3,5,1,1,4,4,5,4,3,3,3,3,2,4,5,2," +
                "1,1,1,4,2,4,2,2,5,5,5,4,1,1,5,1,5,2,1,3,3,2," +
                "5,2,1,2,4,3,3,1,5,4,1,1,1,4,2,5,5,4,4,3,4,3," +
                "1,5,5,2,5,4,2,3,4,1,1,4,4,3,4,1,3,4,1,1,4,3," +
                "2,2,5,3,1,4,4,4,1,3,4,3,1,5,3,3,5,5,4,4,1,2," +
                "4,2,2,3,1,1,4,5,3,1,1,1,1,3,5,4,1,1,2,1,1,2," +
                "1,2,3,1,1,3,2,2,5,5,1,5,5,1,4,4,3,5,4,4";

            //string input = "3,4,3,1,2";

            return input;
        }
    }
}
