using nonoCore;
using nonoCore.Entity;
using nonoCore.Service;
using System;

namespace nono.ConsoleUI
{
    public class ConsoleUI
    {
        private readonly Map _field;
        private readonly Guess _guess;

        private readonly IScoreService _scoreService = new ScoreServiceEF();
        private readonly CommentService _commentService = new CommentServiceFile();
        private readonly RatingService _ratingService = new RatingServiceFile();

        public ConsoleUI(Map field, Guess guess)
        {
            _field = field;
            _guess = guess;
        }

        public void Play()
        {
            DateTime startedTime = DateTime.Now;

            do
            {
                PrintField();
                Console.WriteLine();
                PrintGuess();
                ProcessInput();
                Console.Clear();
            } while (!_guess.isSolved());

            PrintGuess();
            DateTime finishedTime = DateTime.Now;

            _scoreService.AddScore(new Score { Player = Environment.UserName, FinishedAt = finishedTime, StartedAt = startedTime, Seconds = finishedTime.Second - startedTime.Second });
            Console.WriteLine("Game solved!");
            PrintTopScores();
        }

        private void PrintField()
        {
            for (var row = 0; row < _field.RowCount; row++)
            {
                for (var column = 0; column < _field.ColumnCount; column++)
                {
                    var tile = _field[row, column];
                    if (tile != null)
                    {
                        Console.Write(" {0} |", tile.Value);
                    }
                }

                Console.WriteLine();
            }
        }

        private void PrintGuess()
        {
            for (var row = 0; row < _field.RowCount; row++)
            {
                for (var column = 0; column < _field.ColumnCount; column++)
                {
                    var tile = _guess[row, column];
                    if (tile != null)
                    {
                        if (tile.Value == 0)
                        {
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write(" {0} |", (char)79);
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write(" {0} |", (char)88);
                        }
                    }
                }

                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
            }
        }

        private void ProcessInput()
        {
            int x;
            int y;
            string[] read;

            do
            {
                Console.Write("Enter X and Y (i.e. 5 4): ");

                read = Console.ReadLine().Split(' ');
                x = int.Parse(read[0]);
                y = int.Parse(read[1]);

                if (x >= _guess.RowCount || y >= _guess.ColumnCount)
                {
                    Console.WriteLine("X or Y coordinates too big!");
                }
                else if (x < 0 || y < 0)
                {
                    Console.WriteLine("X or Y coordinates too small!");
                }
            } while (x >= _guess.RowCount || y >= _guess.ColumnCount);


            try
            {
                _guess.playerGuess(x, y);
            }
            catch (FormatException)
            {

            }
        }

        private void PrintTopScores()
        {
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("---------------------  TOP SCORES ------------------------");
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("Player   Time");
            foreach (var score in _scoreService.GetTopScores())
            {
                Console.WriteLine("{0}\t{1} seconds", score.Player, score.Seconds);
            }

            Console.WriteLine("----------------------------------------------------------");
        }
    }
}