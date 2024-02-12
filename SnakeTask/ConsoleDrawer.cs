using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
namespace SnakeTask
{
    public static class ConsoleDrawer
    {
        public static void ClearConsole(int screenwidth, int screenheight)
        {
            var blackLine = string.Join("", new byte[screenwidth - 2].Select(b => " ").ToArray());
            ForegroundColor = ConsoleColor.Black;
            for (int i = 1; i < screenheight - 1; i++)
            {
                SetCursorPosition(1, i);
                Write(blackLine);
            }
        }

        public static void DrawBorder(int screenwidth, int screenheight)
        {
            var horizontalBar = string.Join("", new byte[screenwidth].Select(b => "■").ToArray());

            SetCursorPosition(0, 0);
            Write(horizontalBar);
            SetCursorPosition(0, screenheight - 1);
            Write(horizontalBar);

            for (int i = 0; i < screenheight; i++)
            {
                SetCursorPosition(0, i);
                Write("■");
                SetCursorPosition(screenwidth - 1, i);
                Write("■");
            }
        }
    }
}
