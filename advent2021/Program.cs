namespace advent2021
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //GetDepthCounter getDepth = new GetDepthCounter();
            //Position position = new Position();
            //Diagnos diagnos = new Diagnos();
            //Diagnosis diagnosis = new Diagnosis();
            //Bingo bingo = new Bingo();
            //Day5v2 day5v2 = new Day5v2();
            Day6 day6 = new Day6();
            Day7 day7 = new Day7();
            //Day8 day8 = new Day8();
            //Day9 day9 = new Day9();
            //Day10 day10 = new Day10();
            //Day11 day11 = new Day11();
            //Day12 day12 = new Day12();
            //Day13 day13 = new Day13();

            //diagnosis.SetMostCommon();
            //diagnos.runDiagnostics();
            //bingo.SetUp();
            //day5v2.SetUp();
            day6.StartUp();
            day7.StartUp();
            //day8.StartUp();
            //day9.StartUp();
            //day13.StartUp();

            //string gammaRate = diagnosis.GetMostCommon();
            //string epsilonRate = diagnosis.GetLeastCommon();
            //int gamma = Convert.ToInt32(gammaRate, 2);
            //int epsilon = Convert.ToInt32(epsilonRate, 2);
            //int powerConsumption = gamma*epsilon;

            //string oxygenString = diagnos.getOxygen();
            //string cO2String = diagnos.getCO2();
            //int oxygen = Convert.ToInt32(oxygenString, 2);
            //int cO2 = Convert.ToInt32(cO2String, 2);

            Console.WriteLine("Hello and welcome to the submarine program.");
            //Console.WriteLine("Increasing depth measurements: " + getDepth.GetDepthDeeperCounter());
            //Console.WriteLine("Sum counter: " + getDepth.GetSumCounter());
            //Console.WriteLine("Multiplied directions: " + position.MultiplyDirections());
            //Console.WriteLine("Power consumption: " + powerConsumption);
            //Console.WriteLine("Oxygen binary: " + oxygenString + " CO2 binary: " + cO2String);
            //Console.WriteLine("Oxygen int: " + oxygen + " CO2 int: " + cO2);
            //Console.WriteLine("Life support rating: " + oxygen*cO2);
            //Console.WriteLine("Bingo results win: " + bingo.BingoWin());
            //Console.WriteLine("Bingo result loose: " + bingo.BingoLoose());
            //Console.WriteLine("Convergence points: " + day5v2.Part1());
            Console.WriteLine("Amount of fish: " + day6.Part1());
            Console.WriteLine("leastFuel: " + day7.Part1());
            //Console.WriteLine("Day8 Part2: sum: " + day8.Part1());
            //Console.WriteLine("Day9 Part1: sum: " + day9.Part1());
            //Console.WriteLine("Day9 Part2: " + day9.Part2());
            //Console.WriteLine("Day10 Part1: " + day10.Part1());
            //Console.WriteLine("Day11 Part1: " + day11.Part1() + "flashes.");
            //day12.Part1();
        }
    }
}