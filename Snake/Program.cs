using System;

class Program
{
    static void Main(string[] args)
    {
        Console.CursorVisible = false;

        Obstakel obstakel = new Obstakel
        {
            Xpos = 10,
            Ypos = 5,
            SchermKleur = ConsoleColor.Red,
            Karacter = "X"
        };

        DrawObstakel(obstakel);

        Console.SetCursorPosition(0, Console.WindowHeight - 1);
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }

    static void DrawObstakel(Obstakel obstakel)
    {
        Console.SetCursorPosition(obstakel.Xpos, obstakel.Ypos);
        Console.ForegroundColor = obstakel.SchermKleur;
        Console.Write(obstakel.Karacter);
        Console.ResetColor();
    }
}
