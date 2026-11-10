using System;
using System.Collections.Generic;

public static class MatchingBrackets
{
    public static bool IsPaired(string input)
    {
        var stack = new Stack<char>();

        foreach (char c in input)
        {
            switch (c)
            {
                case '(':
                case '[':
                case '{':
                    stack.Push(c);
                    break;

                case ')':
                    if (stack.Count == 0 || stack.Pop() != '(')
                        return false;
                    break;

                case ']':
                    if (stack.Count == 0 || stack.Pop() != '[')
                        return false;
                    break;

                case '}':
                    if (stack.Count == 0 || stack.Pop() != '{')
                        return false;
                    break;
            }
        }

        // Якщо в стеку щось лишилося, є незакриті дужки
        return stack.Count == 0;
    }
}