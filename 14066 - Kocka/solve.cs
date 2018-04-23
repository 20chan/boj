using System;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        var xy = Console.ReadLine()
            .Split()
            .Select(s => Convert.ToInt32(s))
            .ToArray();

        var arr = new int[xy[0], xy[1]];
        for (int y = 0; y < xy[0]; y++)
        {
            var r = Console.ReadLine()
                .Split()
                .Select(s => Convert.ToInt32(s))
                .ToArray();
            for (int x = 0; x < xy[1]; x++)
                arr[y, x] = r[x];
        }

        Console.WriteLine(Eval(arr));
    }

    static string[] s = new string[] {
        "+---+",
        "|   |/",
        "|   | +",
        "+---+ |",
        "./   /|",
        "..+---+"
    };
    public static string Eval(int[,] arr)
    {
        var width = arr.GetLength(1);
        var height = arr.GetLength(0);

        int x_len = 1 + 4 * width + 2 * height,
            y_len = 0;

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                var cur = 2 * (height - y - 1) + 3 * (arr[y, x] + 1);
                y_len = Math.Max(cur, y_len);
            }
        }

        var result = new char[y_len][];
        for (int y = 0; y < y_len; y++)
        {
            result[y] = new char[x_len];
            for (int x = 0; x < x_len; x++)
                result[y][x] = '.';
        }

        for (int y = 0; y < height; y++)
        {
            var ry = height - y - 1;
            for (int x = 0; x < width; x++)
            {
                var len = arr[y, x];
                (int left, int bottom) = (x * 4 + ry * 2, ry * 2);
                for (int i = bottom; i < bottom + 3 * len; i += 3)
                {
                    for (int xx = 0; xx < 6; xx++)
                    {
                        for (int yy = 0; yy < s[xx].Length; yy++)
                        {
                            if (s[xx][yy] == '.') continue;
                            result[i + xx][left + yy] = s[xx][yy];
                        }
                    }
                }
            }
        }

        return string.Join("\n", result.Reverse().Select(cs => new string(cs)));
    }
}