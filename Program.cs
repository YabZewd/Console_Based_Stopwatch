using System;
using System.Threading;

public class Program
{
    static void Main(string[] args)
    {
        Stopwatch stopwatch = new Stopwatch();

        stopwatch.OnStarted += message => DisplayMessage(message);
        stopwatch.OnStopped += message => DisplayMessage(message);
        stopwatch.OnReset += message => DisplayMessage(message);

        string lastMessage = string.Empty;

        void DisplayMessage(string message)
        {
            lastMessage = message;
        }

        Console.WriteLine("Stopwatch Application\nCommands: S to Start, T to Stop, R to Reset, Q to Quit\n");

        bool quit = false;

        while (!quit)
        {
            Console.Clear();
            Console.WriteLine("Stopwatch Application\nCommands: S to Start, T to Stop, R to Reset, Q to Quit\n");
            Console.WriteLine($"Time Elapsed: {stopwatch.TimeElapsed:hh\\:mm\\:ss}");

            if (!string.IsNullOrEmpty(lastMessage))
            {
                Console.WriteLine($"\n{lastMessage}");
            }

            if (Console.KeyAvailable)
            {
                ConsoleKey key = Console.ReadKey(intercept: true).Key;

                switch (key)
                {
                    case ConsoleKey.S:
                        stopwatch.Start();
                        break;
                    case ConsoleKey.T:
                        stopwatch.Stop();
                        break;
                    case ConsoleKey.R:
                        stopwatch.Reset();
                        break;
                    case ConsoleKey.Q:
                        quit = true;
                        stopwatch.Stop();
                        Console.WriteLine("Exiting application...");
                        break;
                    default:
                        Console.WriteLine("Invalid command. Use S, T, R, or Q.");
                        break;
                }
            }

            Thread.Sleep(100);
        }
    }
}
