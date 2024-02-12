using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using SnakeTask;
using static System.Console;
using static System.ConsoleKey;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            WindowHeight = 16;
            WindowWidth = 32;
            int screenwidth = WindowWidth;
            int screenheight = WindowHeight;
            Random randomnummer = new Random();
            int score = 5;
            int gameover = 0;
            Pixel hoofd = new Pixel();
            hoofd.Xpos = screenwidth / 2;
            hoofd.Ypos = screenheight / 2;
            hoofd.Schermkleur = ConsoleColor.Red;
            string movement = "RIGHT";
            List<int> xposlijf = new List<int>();
            List<int> yposlijf = new List<int>();
            int berryx = randomnummer.Next(0, screenwidth);
            int berryy = randomnummer.Next(0, screenheight);
            DateTime tijd = DateTime.Now;
            DateTime tijd2 = DateTime.Now;
            string buttonpressed = "no";

            ConsoleDrawer.DrawBorder(screenwidth, screenheight);

            while (true)
            {
                ConsoleDrawer.ClearConsole(screenwidth, screenheight);
                if (hoofd.Xpos == screenwidth - 1 || hoofd.Xpos == 0 || hoofd.Ypos == screenheight - 1 || hoofd.Ypos == 0)
                {
                    gameover = 1;
                }

                Console.ForegroundColor = ConsoleColor.Green;
                if (berryx == hoofd.Xpos && berryy == hoofd.Ypos)
                {
                    score++;
                    berryx = randomnummer.Next(1, screenwidth - 2);
                    berryy = randomnummer.Next(1, screenheight - 2);
                }
                for (int i = 0; i < xposlijf.Count(); i++)
                {
                    SetCursorPosition(xposlijf[i], yposlijf[i]);
                    Write("¦");
                    if (xposlijf[i] == hoofd.Xpos && yposlijf[i] == hoofd.Ypos)
                    {
                        gameover = 1;
                    }
                }
                if (gameover == 1)
                {
                    break;
                }
                SetCursorPosition(hoofd.Xpos, hoofd.Ypos);
                ForegroundColor = hoofd.Schermkleur;
                Write("■");
                SetCursorPosition(berryx, berryy);
                ForegroundColor = ConsoleColor.Cyan;
                Write("■");
                CursorVisible = false;
                tijd = DateTime.Now;
                buttonpressed = "no";
                while (true)
                {
                    tijd2 = DateTime.Now;
                    if (tijd2.Subtract(tijd).TotalMilliseconds > 500) { break; }
                    if (Console.KeyAvailable)
                    {
                        ConsoleKeyInfo toets = ReadKey(true);
                        if (toets.Key.Equals(ConsoleKey.UpArrow) && movement != "DOWN" && buttonpressed == "no")
                        {
                            movement = "UP";
                            buttonpressed = "yes";
                        }
                        if (toets.Key.Equals(ConsoleKey.DownArrow) && movement != "UP" && buttonpressed == "no")
                        {
                            movement = "DOWN";
                            buttonpressed = "yes";
                        }
                        if (toets.Key.Equals(ConsoleKey.LeftArrow) && movement != "RIGHT" && buttonpressed == "no")
                        {
                            movement = "LEFT";
                            buttonpressed = "yes";
                        }
                        if (toets.Key.Equals(ConsoleKey.RightArrow) && movement != "LEFT" && buttonpressed == "no")
                        {
                            movement = "RIGHT";
                            buttonpressed = "yes";
                        }
                    }
                }
                xposlijf.Add(hoofd.Xpos);
                yposlijf.Add(hoofd.Ypos);
                switch (movement)
                {
                    case "UP":
                        hoofd.Ypos--;
                        break;
                    case "DOWN":
                        hoofd.Ypos++;
                        break;
                    case "LEFT":
                        hoofd.Xpos--;
                        break;
                    case "RIGHT":
                        hoofd.Xpos++;
                        break;
                }
                if (xposlijf.Count() > score)
                {
                    xposlijf.RemoveAt(0);
                    yposlijf.RemoveAt(0);
                }
            }
            SetCursorPosition(screenwidth / 5, screenheight / 2);
            WriteLine("Game over, Score: " + score);
            SetCursorPosition(screenwidth / 5, screenheight / 2 + 1);
        }

       


    }
}