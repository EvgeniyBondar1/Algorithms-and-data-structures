using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleFiller
{
    class Paint
    {
        int[,] map;
        int w, h;
        string symbols = " #<>^vx";

        ConsoleColor[] colors =
        {
            ConsoleColor.White,
            ConsoleColor.DarkBlue,
            ConsoleColor.Yellow,
            ConsoleColor.Yellow,
            ConsoleColor.Yellow,
            ConsoleColor.Yellow,
            ConsoleColor.Cyan
        };

        public Paint(int w, int h)
        {
            this.w = w;
            this.h = h;
            map = new int[w, h];
        }

        void SetMap(int x, int y, int number)
        {
            map[x, y] = number;
            PrintAt(x, y);
        }

        void PrintAt(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = colors[map[x, y]];
            Console.Write(symbols[map[x, y]]);
            Console.SetCursorPosition(0, 0);
        }

        bool IsEmpty(int x, int y)
        {
            if (x < 0 || x >= w) return false;
            if (y < 0 || y >= h) return false;
            return map[x, y] == 0;
        }

        public void PutRandomNumbers(int count)
        {
            Random random = new Random();
            for (int j = 0; j < count; j++)
                SetMap(random.Next(w), random.Next(h), 1);
        }

        public void Fill(int x, int y)
        {
            if (!IsEmpty(x, y)) return;
            
            Console.ReadKey();
            SetMap(x, y, 2);  Fill(x - 1, y);
            SetMap(x, y, 3);  Fill(x + 1, y);
            SetMap(x, y, 4);  Fill(x, y - 1);
            SetMap(x, y, 5);  Fill(x, y + 1); 
            SetMap(x, y, 6);
        }
    }
}
