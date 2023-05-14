using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace advent2021
{
    internal class Bingo
    {
        private List<int> numbers;
        private readonly List<List<List<int>>> boards = new(); //list3:numbers, list2:board, list1:boards

        public void SetUp()
        {
            var input = File.ReadAllLines(/* Full path */ "").ToList();
            var numberOfBoards = (input.Count - 1) / 6;
            numbers = input[0].Split(",").Select(int.Parse).ToList(); //bort med ',' från första raden, spara till lista som int-värden

            for(int i=0; i<numberOfBoards; i++) //
            {
                var board = new List<List<int>>();

                for(var row = 0; row < 5; row++)
                {
                    //startar på rad 2, inte 0: (2+6*i+row). Lägger till nummer och split vid "". Nummer till int till lista
                    board.Add(input[2 + 6*i+row].Split().Where(x => x.Trim() != "").Select(int.Parse).ToList());
                }

                boards.Add(board); //Lägg till nuvarande board till boards
            }
        }

        public int BingoWin()
        {
            //loop numbers in boards and mark them -1 in boards if they're pulled.
            //if sum of a row is -1 then it's BINGO. If a column is -5 then that's a BINGO!
            //Calculte the sum of those numbers and multiply by the last drawn number.
            foreach (var number in numbers)  
                {
                    foreach (var board in boards)
                    {
                        for (var i = 0; i < 5; i++)
                            for (var j = 0; j < 5; j++)
                                if (board[i][j] == number)
                                    board[i][j] = -1;
                    }

                    foreach (var board in boards)
                    {
                        for (var i = 0; i < 5; i++)
                        {
                            if (board[i].Sum() == -5 || board.Select(x => x[i]).Sum() == -5)
                                return board.SelectMany(x => x).Where(x => x != -1).Sum() * number;
                        }
                    }
                }
                return 0;
        }
        public int BingoLoose()
        {
            //finalScore = the latest winningBoard, only the last winningBoard will be kept
            
            //loop through all boards and check for drawn numbers and mark set them to -1
            //check all rown and columns if 
            //new list winningBoards to keep all winning boards, remove all winningBoards(no need to keep them)
            var finalScore = 0;

            foreach(var number in numbers)
            {
                foreach(var board in boards)
                {
                    for (var i = 0; i < 5; i++)
                        for (var j = 0; j < 5; j++)
                        {
                            if (board[i][j] == number)
                                board[i][j] = -1;
                        }
                }

                var winningBoards = new List<List<List<int>>>();

                foreach(var board in boards)
                {
                    for(var i = 0; i < 5; i++)
                    {
                        if (board[i].Sum() == -5 || board.Select(x => x[i]).Sum() == -5)
                        {
                            finalScore = board.SelectMany(x => x).Where(x => x != -1).Sum() * number;
                            winningBoards.Add(board);
                        }
                    }
                }

                foreach(var board in winningBoards)
                {
                    boards.Remove(board);
                }
            }
            return finalScore;
        }
    }
}
