using System;

public static class Logger
{
    public static void Logo()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(@" 
   ____ ____  ____             __  ____  
  | __ ) ___||  _ \    __   __/ /_|___ \ 
  |  _ \___ \| |_) |___\ \ / / '_ \ __) |
  | |_) |__) |  __/_____\ V /| (_) / __/ 
  |____/____/|_|         \_/  \___/_____|");

        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("      Brawl Stars Private Server v62 by pmdrkdv");
        Console.ForegroundColor = ConsoleColor.Gray;
    }
    public static void Print(string log)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("[d] " + log);
    }
    public static void Warning(string log)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("[W] " + log);
    }

    public static void Error(string log)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("[e] " + log);
    }
}



