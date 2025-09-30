using System;

class Program
{
    static void Main()
    {
        int color = 0;
        for (int i = 0; i <= 255; i++)
        {
            Console.Write("\x1b[38;2;37;150;190m*");
        }
        Console.ReadKey();
    }
}
