using System;
using System.Text;

public static class RotationalCipher
{
    public static string Rotate(string text, int shiftKey)
    {
        // Нормалізуємо ключ до діапазону 0..25
        int shift = ((shiftKey % 26) + 26) % 26;

        var result = new StringBuilder(text.Length);

        foreach (char c in text)
        {
            if (c >= 'a' && c <= 'z')
            {
                result.Append((char)('a' + (c - 'a' + shift) % 26));
            }
            else if (c >= 'A' && c <= 'Z')
            {
                result.Append((char)('A' + (c - 'A' + shift) % 26));
            }
            else
            {
                // Пробіли, цифри та розділові знаки залишаються без змін
                result.Append(c);
            }
        }

        return result.ToString();
    }
}