using System;

public class CircularBuffer<T>
{
    private readonly T[] buffer;
    private int head;   // індекс найстарішого елемента
    private int count;  // кількість елементів у буфері

    public CircularBuffer(int capacity)
    {
        buffer = new T[capacity];
        head = 0;
        count = 0;
    }

    public T Read()
    {
        if (count == 0)
            throw new InvalidOperationException("Buffer is empty.");

        T item = buffer[head];
        buffer[head] = default!;
        head = (head + 1) % buffer.Length;
        count--;
        return item;
    }

    public void Write(T value)
    {
        if (count == buffer.Length)
            throw new InvalidOperationException("Buffer is full.");

        int tail = (head + count) % buffer.Length;
        buffer[tail] = value;
        count++;
    }

    public void Overwrite(T value)
    {
        if (count < buffer.Length)
        {
            Write(value);
            return;
        }

        // Буфер заповнений: перезаписуємо найстаріший елемент
        buffer[head] = value;
        head = (head + 1) % buffer.Length;
    }

    public void Clear()
    {
        Array.Clear(buffer, 0, buffer.Length);
        head = 0;
        count = 0;
    }
}