using System;
using System.Collections.Generic;

public class Wąż
{
    public List<(int X, int Y)> Pozycje { get; private set; }
    public ConsoleColor Kolor { get; set; }
    public string Karacter { get; set; }
    private (int X, int Y) Kierunek;

    public Wąż(int startX, int startY)
    {
        Pozycje = new List<(int X, int Y)> { (startX, startY) };
        Kolor = ConsoleColor.Green;
        Karacter = "O";
        Kierunek = (1, 0); // początkowy kierunek - prawo
    }

    public void Move()
    {
        var głowa = Pozycje[0];
        głowa.X += Kierunek.X;
        głowa.Y += Kierunek.Y;
        Pozycje.Insert(0, głowa);
        Pozycje.RemoveAt(Pozycje.Count - 1);
    }

    public void Grow()
    {
        var ogon = Pozycje[Pozycje.Count - 1];
        Pozycje.Add((ogon.X, ogon.Y));
    }

    public void Draw()
    {
        foreach (var segment in Pozycje)
        {
            Console.SetCursorPosition(segment.X, segment.Y);
            Console.ForegroundColor = Kolor;
            Console.Write(Karacter);
        }
        Console.ResetColor();
    }

    public void ChangeDirection(ConsoleKey key)
    {
        switch (key)
        {
            case ConsoleKey.UpArrow:
                if (Kierunek != (0, 1)) Kierunek = (0, -1);
                break;
            case ConsoleKey.DownArrow:
                if (Kierunek != (0, -1)) Kierunek = (0, 1);
                break;
            case ConsoleKey.LeftArrow:
                if (Kierunek != (1, 0)) Kierunek = (-1, 0);
                break;
            case ConsoleKey.RightArrow:
                if (Kierunek != (-1, 0)) Kierunek = (1, 0);
                break;
        }
    }
}
