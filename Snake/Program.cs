using System;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        Console.CursorVisible = false;
        Wąż wąż = new Wąż(5, 5);
        Obstakel jedzenie = new Obstakel { Xpos = 10, Ypos = 10, SchermKleur = ConsoleColor.Red, Karacter = "X" };
        int punkty = 0;

        while (true)
        {
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(true).Key;
                wąż.ChangeDirection(key);
            }

            wąż.Move();

            if (wąż.Pozycje[0].X == jedzenie.Xpos && wąż.Pozycje[0].Y == jedzenie.Ypos)
            {
                wąż.Grow();
                jedzenie = new Obstakel { Xpos = new Random().Next(Console.WindowWidth), Ypos = new Random().Next(Console.WindowHeight), SchermKleur = ConsoleColor.Red, Karacter = "X" };
                punkty++;
            }

            Console.Clear();
            wąż.Draw();
            DrawObstakel(jedzenie);
            DisplayScore(punkty);

            Thread.Sleep(200);
        }
    }

    static void DrawObstakel(Obstakel obstakel)
    {
        Console.SetCursorPosition(obstakel.Xpos, obstakel.Ypos);
        Console.ForegroundColor = obstakel.SchermKleur;
        Console.Write(obstakel.Karacter);
        Console.ResetColor();
    }

    static void DisplayScore(int score)
    {
        Console.SetCursorPosition(0, 0);
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write($"Score: {score}");
        Console.ResetColor();
    }
}
