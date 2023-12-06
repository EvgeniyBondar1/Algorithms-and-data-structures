using System;

class Program
{
    static void Main(string[] args)
    {
        Paint paint = new Paint(50, 20);
        paint.AddRandomPixels(400);
        paint.FillBoxQueue(25, 10);
        Console.ReadKey();
    }

}
