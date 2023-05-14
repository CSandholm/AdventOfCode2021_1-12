using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace advent2021
{
    internal class Day12
    {
        public void Part1()
        {
            List<string> input = File.ReadAllLines
                (/* Full Path */ "")
                .Select(x => x.Replace("-", " ")).ToList();
            Graph graph = new Graph();
            bool twice = false;
            //get pairs from input, inst two caves and add to graph, add neighbour to connections
            foreach(var line in input)
            {
                var pair = line.Trim().Split(' ');
                Cave a = graph.getCave(pair[0]);
                Cave b = graph.getCave(pair[1]);
                a.connections.Add(b);
                b.connections.Add(a);
            }

            int total = Visit(graph.getCave("start"), new Stack<Cave>(), twice);
            Console.WriteLine("Total amount of paths: " + total);

            static int Visit(Cave n, Stack<Cave> path, bool twice)
            {
                //if the "end", add a path
                if (n.name == "end")
                {
                    twice = false;
                    return 1;
                }

                //if not the end
                int paths = 0;
                path.Push(n);
                foreach(var neighbour in n.connections)
                {
                    //skip if neighbour is small and visited
                    if (neighbour.small && path.Contains(neighbour))
                        if(twice)
                            continue;
                        else
                            twice = true;
                            
                    paths += Visit(neighbour, path, twice);
                }
                path.Pop();
                return paths;
            }
        }
    }

    class Cave
    {
        public Cave(string name)
        {
            this.name = name;
            this.small = name.ToLower() == name;
        }

        public string name;
        public bool small;
        public List<Cave> connections = new List<Cave>();
    }

    class Graph
    {
        Dictionary<string, Cave> nodes = new  Dictionary<string, Cave>();

        public Cave getCave(string name)
        {
            //Check if the node is counted for
            if(nodes.TryGetValue(name, out Cave v))
                return v;

            //If cave is not counted for add a new cave and return it
            Cave n = new Cave(name);
            nodes.Add(name,n);
            return n;
        }
    }
}
