using nonoCore;
using System;


namespace nono
{
    public class Program
    {
        static void Main()
        {
            Console.Write("Enter horizontal and vertical map size: (i.e. 5 4): ");

            string[] read = Console.ReadLine().Split(' ');
            int x = int.Parse(read[0]);
            int y = int.Parse(read[1]);

            Console.Write("Enter map seed: (0 if default): ");
            int z = Convert.ToInt32(Console.ReadLine());
            Console.Clear();

            var field = new Map(y, x, z);
            var guess = new Guess(y, x, field);
            var ui = new ConsoleUI.ConsoleUI(field, guess);
            ui.Play();
        }
    }
}