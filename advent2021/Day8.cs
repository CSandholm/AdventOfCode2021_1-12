using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace advent2021
{
    internal class Day8
    {
        int uniqueInt = 0;
        List<List<string>> sortedInput;
        public void StartUp()
        {
            List<string> input = File.ReadAllLines
                (/* Full path */ "").ToList();
            sortedInput = new List<List<string>>();

            for (int i = 0; i < input.Count; i++)
            {
                sortedInput.Add(input[i].Split().Where(x => x.Trim() != "").ToList());
            }
            for(int i=0;i< sortedInput.Count; i+=2)
            {
                sortedInput[i] = sortedInput[i].OrderBy(s => s.Length).ToList();  
            }
        }
        public int Part1()
        {
            int a = Convert.ToInt32('a');
            int g = Convert.ToInt32('g');
            string[] num = new string[sortedInput.Count/2];
            int sum = 0;
            int loops = 0;
            for(int i=0;i< sortedInput.Count / 2; i++)
            {
                num[i] = "";
            }

            for (int i = 1; i < sortedInput.Count; i += 2)
            {
                string stringHolder = "";

                for (int j = 0; j < 4; j++)
                {
                    
                    int charCounter = 0;
                    int common1 = 0;
                    int common4 = 0;
                    int common7 = 0;
                    int common8 = 0;

                    for (int k = a; k <= g; k++)
                    {
                        int letterCount = sortedInput[i][j].Count(c => c == Convert.ToChar(k));

                        if (sortedInput[i][j].Count(c => c == Convert.ToChar(k)) > 0)
                        {
                            charCounter++;
                        }
                        //part2 - compare the amount of chared lines generates a certain code
                        if(sortedInput[i][j].Count(c => c == Convert.ToChar(k)) > 0)
                        {
                            //compare with one
                            if (letterCount == sortedInput[i - 1][0].Count(c => c == Convert.ToChar(k)))
                            {
                                common1++;
                            }
                            //compare with 7
                            if (letterCount == sortedInput[i - 1][2].Count(c => c == Convert.ToChar(k)))
                            {
                                common4++;
                            }
                            //compare with 4
                            if (letterCount == sortedInput[i - 1][1].Count(c => c == Convert.ToChar(k)))
                            {
                                common7++;
                            }
                            //compare with 8
                            if (letterCount == sortedInput[i - 1][9].Count(c => c == Convert.ToChar(k)))
                            {
                                common8++;
                            }
                        }
                    }
                    
                    //check for 1, 4, 7 & 8
                    if (charCounter == 2 || charCounter == 4 || charCounter == 3 || charCounter == 7)
                    {
                        uniqueInt++;
                    }

                    stringHolder = common1 + "" + common4 + "" + common7 + "" + common8;

                    if (stringHolder == "1225")
                        num[loops] += "2";
                    else if (stringHolder == "2335")
                        num[loops] += "3";
                    else if (stringHolder == "1325")
                        num[loops] += "5";
                    else if (stringHolder == "1326")
                        num[loops] += "6";
                    else if (stringHolder == "2436")
                        num[loops] += "9";
                    else if (stringHolder == "2336")
                        num[loops] += "0";
                    else if (stringHolder == "2437")
                        num[loops] += "8";
                    else if (stringHolder == "2424")
                        num[loops] += "4";
                    else if (stringHolder == "2233")
                        num[loops] += "7";
                    else
                        num[loops] += "1";
                }
                loops++;
            }

            for(int i=0;i<num.Length;i++)
            {
                Console.WriteLine(num[i]);
                sum += Convert.ToInt32(num[i]);
            } 
            return sum;  
        }
    }
}
/*
 * You barely reach the safety of the cave when the whale smashes into the cave mouth, collapsing it. Sensors indicate another exit to this cave at a much greater depth, so you have no choice but to press on.

As your submarine slowly makes its way through the cave system, you notice that the four-digit seven-segment displays in your submarine are malfunctioning; they must have been damaged during the escape. You'll be in a lot of trouble without them, so you'd better figure out what's wrong.

Each digit of a seven-segment display is rendered by turning on or off any of seven segments named a through g:

  0:      1:      2:      3:      4:
 aaaa    ....    aaaa    aaaa    ....
b    c  .    c  .    c  .    c  b    c
b    c  .    c  .    c  .    c  b    c
 ....    ....    dddd    dddd    dddd
e    f  .    f  e    .  .    f  .    f
e    f  .    f  e    .  .    f  .    f
 gggg    ....    gggg    gggg    ....

  5:      6:      7:      8:      9:
 aaaa    aaaa    aaaa    aaaa    aaaa
b    .  b    .  .    c  b    c  b    c
b    .  b    .  .    c  b    c  b    c
 dddd    dddd    ....    dddd    dddd
.    f  e    f  .    f  e    f  .    f
.    f  e    f  .    f  e    f  .    f
 gggg    gggg    ....    gggg    gggg

So, to render a 1, only segments c and f would be turned on; the rest would be off. 
To render a 7, only segments a, c, and f would be turned on.

The problem is that the signals which control the segments have been mixed up on each display. 
The submarine is still trying to display numbers by producing output on signal wires a through g, 
but those wires are connected to segments randomly. Worse, the wire/segment connections are mixed up separately for each four-digit display! 
(All of the digits within a display use the same connections, though.)

So, you might know that only signal wires b and g are turned on, but that doesn't mean segments b and g are turned on: 
the only digit that uses two segments is 1, so it must mean segments c and f are meant to be on. 
With just that information, you still can't tell which wire (b/g) goes to which segment (c/f). 
For that, you'll need to collect more information.

For each display, you watch the changing signals for a while, make a note of all ten unique signal patterns you see, 
and then write down a single four digit output value (your puzzle input). 
Using the signal patterns, you should be able to work out which pattern corresponds to which digit.

For example, here is what you might see in a single entry in your notes:

acedgfb cdfbe gcdfa fbcad dab cefabd cdfgeb eafb cagedb ab |
cdfeb fcadb cdfeb cdbaf
(The entry is wrapped here to two lines so it fits; in your notes, it will all be on a single line.)

Each entry consists of ten unique signal patterns, a | delimiter, and finally the four digit output value. 
Within an entry, the same wire/segment connections are used (but you don't know what the connections actually are). 
The unique signal patterns correspond to the ten different ways the submarine tries to render a digit using the current wire/segment connections. 
Because 7 is the only digit that uses three segments, dab in the above example means that to render a 7, signal lines d, a, and b are on. 
Because 4 is the only digit that uses four segments, eafb means that to render a 4, signal lines e, a, f, and b are on.

Using this information, you should be able to work out which combination of signal wires corresponds to each of the ten digits. 
Then, you can decode the four digit output value. Unfortunately, in the above example, 
all of the digits in the output value (cdfeb fcadb cdfeb cdbaf) use five segments and are more difficult to deduce.

For now, focus on the easy digits. Consider this larger example:

"be cfbegad cbdgef fgaecd cgeb fdcge agebfd fecdb fabcd edb |
fdgacbe cefdb cefbgd gcbe
edbfga begcd cbg gc gcadebf fbgde acbgfd abcde gfcbed gfec |
fcgedb cgb dgebacf gc
fgaebd cg bdaec gdafb agbcfd gdcbef bgcad gfac gcb cdgabef |
cg cg fdcagb cbg
fbegcd cbd adcefb dageb afcb bc aefdc ecdab fgdeca fcdbega |
efabcd cedba gadfec cb
aecbfdg fbg gf bafeg dbefa fcge gcbea fcaegb dgceab fcbdga |
gecf egdcabf bgf bfgea
fgeab ca afcebg bdacfeg cfaedg gcfdb baec bfadeg bafgc acf |
gebdcfa ecba ca fadegcb
dbcfg fgd bdegcaf fgec aegbdf ecdfab fbedc dacgb gdcebf gf |
cefg dcbef fcge gbcadfe
bdfegc cbegaf gecbf dfcage bdacg ed bedf ced adcbefg gebcd |
ed bcgafe cdgba cbgef
egadfb cdbfeg cegd fecab cgb gbdefca cg fgcdab egfdb bfceg |
gbdfcae bgc cg cgb
gcafb gcf dcaebfg ecagb gf abcdeg gaef cafbge fdbac fegbdc |
fgae cfgab fg bagce
Because the digits 1, 4, 7, and 8 each use a unique number of segments, 
you should be able to tell which combinations of signals correspond to those digits. 
Counting only digits in the output values (the part after | on each line), in the above example, 
there are 26 instances of digits that use a unique number of segments (highlighted above).

In the output values, how many times do digits 1, 4, 7, or 8 appear?*/
