using System;
using System.Collections.Generic;
using System.Linq;

public static class Dominoes
{
    public static bool CanChain(IEnumerable<(int, int)> dominoes)
    {
        var list = dominoes.ToList();

        // Порожній набір вважається валідним ланцюгом
        if (list.Count == 0)
            return true;

        // Ланцюг замкнений, тож першу кісточку можна зафіксувати як початок
        var used = new bool[list.Count];
        used[0] = true;

        return Search(list, used, 1, list[0].Item1, list[0].Item2);
    }

    private static bool Search(List<(int, int)> list, bool[] used, int usedCount, int start, int end)
    {
        // Усі кісточки використано: перше й останнє числа мають збігатися
        if (usedCount == list.Count)
            return start == end;

        for (int i = 0; i < list.Count; i++)
        {
            if (used[i])
                continue;

            var (a, b) = list[i];

            if (a == end)
            {
                used[i] = true;
                if (Search(list, used, usedCount + 1, start, b))
                    return true;
                used[i] = false;
            }

            // Перевернута кісточка (для дублів a == b це зайве, тож пропускаємо)
            if (b == end && a != b)
            {
                used[i] = true;
                if (Search(list, used, usedCount + 1, start, a))
                    return true;
                used[i] = false;
            }
        }

        return false;
    }
}