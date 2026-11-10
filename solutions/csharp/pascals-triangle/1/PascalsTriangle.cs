using System;
using System.Collections.Generic;

public static class PascalsTriangle
{
    public static IEnumerable<IEnumerable<int>> Calculate(int rows)
    {
        var triangle = new List<IEnumerable<int>>();

        if (rows <= 0)
            return triangle;

        var previous = new int[] { 1 };
        triangle.Add(previous);

        for (int r = 1; r < rows; r++)
        {
            var current = new int[r + 1];

            // Крайні значення завжди дорівнюють 1
            current[0] = 1;
            current[r] = 1;

            // Внутрішні значення: сума двох сусідів із попереднього рядка
            for (int i = 1; i < r; i++)
                current[i] = previous[i - 1] + previous[i];

            triangle.Add(current);
            previous = current;
        }

        return triangle;
    }
}
