using System;
using System.Collections.Generic;

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

    public void AddRandomPixels(int count)
    {
        Random random = new Random();
        for (int j = 0; j < count; j++)
            SetMap(random.Next(w), random.Next(h), 1);
    }

    public void FillLine()
    {
        for (int x = 0; x < w; x++)
            SetMap(x, 0, 1);
    }

    public void FillLineR(int x)
    {
        if (x >= w) return;
        FillLineR(x + 1);
        SetMap(x, 0, 1);
    }

    public void FillBox()
    {
        for (int x = 0; x < w; x++)
            for (int y = 0; y < h; y++)
                SetMap(x, y, 1);
    }

    public void FillBoxR(int x, int y, int v)
    {
        if (!IsEmpty(x, y)) return;
        SetMap(x, y, v);
        Console.ReadKey();
        FillBoxR(x - 1, y, 2);
        FillBoxR(x + 1, y, 3);
        FillBoxR(x, y + 1, 5);
        FillBoxR(x, y - 1, 4);
        SetMap(x, y, 6);
    }

    public void FillBoxStack(int x, int y)
    {
        Stack<Coord> stack = new Stack<Coord>();
        stack.Push(new Coord(x, y));
        while (stack.Count > 0)
        {
            Coord coord = stack.Pop();
            SetMap(coord.x, coord.y, 6);
            Push(coord.x - 1, coord.y, 2);
            Push(coord.x + 1, coord.y, 3);
            Push(coord.x, coord.y - 1, 4);
            Push(coord.x, coord.y + 1, 5);
            Console.ReadKey();
        }

        void Push(int a, int b, int c)
        {
            if (!IsEmpty(a, b)) return;
            SetMap(a, b, c);
            stack.Push(new Coord(a, b));
        }
    }

    public void FillBoxQueue(int x, int y)
    {
        Queue<Coord> queue = new Queue<Coord>();
        queue.Enqueue(new Coord(x, y));
        while (queue.Count > 0)
        {
            Coord coord = queue.Dequeue();
            SetMap(coord.x, coord.y, 6);
            Push(coord.x - 1, coord.y, 2);
            Push(coord.x + 1, coord.y, 3);
            Push(coord.x, coord.y - 1, 4);
            Push(coord.x, coord.y + 1, 5);
            Console.ReadKey();
        }

        void Push(int a, int b, int c)
        {
            if (!IsEmpty(a, b)) return;
            SetMap(a, b, c);
            queue.Enqueue(new Coord(a, b));
        }
    }


    private void SetMap(int x, int y, int v)
    {
        map[x, y] = v;
        Console.SetCursorPosition(x, y);
        Console.ForegroundColor = colors[v];
        Console.Write(symbols[v]);
        Console.SetCursorPosition(0, 0);
    }

    private bool IsEmpty(int x, int y)
    {
        if (x < 0 || x >= w) return false;
        if (y < 0 || y >= h) return false;
        return map[x, y] == 0;
    }

    struct Coord
    {
        public int x;
        public int y;

        public Coord(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
