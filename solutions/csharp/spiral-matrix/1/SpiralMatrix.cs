using System;

public static class SpiralMatrix
{
    public static int[,] GetMatrix(int size)
    {
        var matrix = new int[size, size];

        int top = 0;
        int bottom = size - 1;
        int left = 0;
        int right = size - 1;
        int value = 1;

        while (top <= bottom && left <= right)
        {
            // Зліва направо по верхньому рядку
            for (int col = left; col <= right; col++)
                matrix[top, col] = value++;
            top++;

            // Зверху вниз по правому стовпцю
            for (int row = top; row <= bottom; row++)
                matrix[row, right] = value++;
            right--;

            // Справа наліво по нижньому рядку
            if (top <= bottom)
            {
                for (int col = right; col >= left; col--)
                    matrix[bottom, col] = value++;
                bottom--;
            }

            // Знизу вгору по лівому стовпцю
            if (left <= right)
            {
                for (int row = bottom; row >= top; row--)
                    matrix[row, left] = value++;
                left++;
            }
        }

        return matrix;
    }
}