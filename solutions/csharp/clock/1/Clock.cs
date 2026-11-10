using System;

public class Clock : IEquatable<Clock>
{
    private const int MinutesPerDay = 24 * 60;

    // Час зберігається як кількість хвилин від півночі (0..1439)
    private readonly int totalMinutes;

    public Clock(int hours, int minutes)
    {
        // Нормалізуємо в окремому виразі, щоб коректно обробити від'ємні значення
        long total = (long)hours * 60 + minutes;
        totalMinutes = (int)(((total % MinutesPerDay) + MinutesPerDay) % MinutesPerDay);
    }

    public Clock Add(int minutesToAdd)
    {
        return new Clock(0, totalMinutes + minutesToAdd);
    }

    public Clock Subtract(int minutesToSubtract)
    {
        return new Clock(0, totalMinutes - minutesToSubtract);
    }

    public bool Equals(Clock other)
    {
        return other is not null && totalMinutes == other.totalMinutes;
    }

    public override bool Equals(object obj)
    {
        return Equals(obj as Clock);
    }

    public override int GetHashCode()
    {
        return totalMinutes.GetHashCode();
    }

    public override string ToString()
    {
        return $"{totalMinutes / 60:D2}:{totalMinutes % 60:D2}";
    }
}