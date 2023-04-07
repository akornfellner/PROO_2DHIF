using System.Collections;

public class MyList<T> : IEnumerable<T>
{
    private Node<T> head;

    public void Add(T value)
    {
        if (head == null)
        {
            head = new Node<T>(value);
        }
        else
        {
            Node<T> current = head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = new Node<T>(value);
        }
    }

    public bool Contains(T value)
    {
        Node<T> current = head;
        while (current != null)
        {
            if (current.Value.Equals(value))
            {
                return true;
            }
            current = current.Next;
        }
        return false;
    }

    public T this[int index]
    {
        get
        {
            Node<T> current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }
            return current.Value;
        }
    }

    public T Remove(int index)
    {
        if (index == 0)
        {
            T value = head.Value;
            head = head.Next;
            return value;
        }
        else
        {
            Node<T> current = head;
            for (int i = 0; i < index - 1; i++)
            {
                current = current.Next;
            }
            T value = current.Next.Value;
            current.Next = current.Next.Next;
            return value;
        }
    }

    public int Count
    {
        get
        {
            int count = 0;
            Node<T> current = head;
            while (current != null)
            {
                count++;
                current = current.Next;
            }
            return count;
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        return new MyEnum<T>(head);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}