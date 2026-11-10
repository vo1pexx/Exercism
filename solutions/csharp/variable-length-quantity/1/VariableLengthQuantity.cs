using System;
using System.Collections.Generic;

public static class VariableLengthQuantity
{
    public static uint[] Encode(uint[] numbers)
    {
        var result = new List<uint>();

        foreach (uint number in numbers)
        {
            var bytes = new Stack<uint>();

            // Молодші 7 бітів без прапорця продовження (біт №7 = 0)
            bytes.Push(number & 0x7F);
            uint rest = number >> 7;

            // Решта груп по 7 бітів: прапорець 0x80 вказує, що байт не останній
            while (rest > 0)
            {
                bytes.Push((rest & 0x7F) | 0x80);
                rest >>= 7;
            }

            // Стек віддає байти від старшого до молодшого
            result.AddRange(bytes);
        }

        return result.ToArray();
    }

    public static uint[] Decode(uint[] bytes)
    {
        var result = new List<uint>();
        uint current = 0;
        bool incomplete = false;

        foreach (uint b in bytes)
        {
            // Якщо вже назбирано 28 бітів, ще 7 не вміститься в uint
            if ((current >> 25) != 0)
                throw new OverflowException("Number does not fit in 32 bits.");

            current = (current << 7) | (b & 0x7F);

            if ((b & 0x80) != 0)
            {
                // Біт №7 встановлено: число триває
                incomplete = true;
            }
            else
            {
                result.Add(current);
                current = 0;
                incomplete = false;
            }
        }

        // Остання послідовність не завершилася байтом без прапорця
        if (incomplete)
            throw new InvalidOperationException("Incomplete byte sequence.");

        return result.ToArray();
    }
}
