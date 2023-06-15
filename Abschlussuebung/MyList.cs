using System.Collections;

public class MyList<T> : IEnumerable<T>
{
    private Node<T> head;

    public void Add(T data)
    {
        if (head == null)
        {
            head = new Node<T>(data);
            return;
        }

        Node<T> node = new Node<T>(data);

        Node<T> current = head;

        while (current.Next != null)
        {
            current = current.Next;
        }

        current.Next = node;
    }

    public T Pop()
    {
        if (head == null)
        {
            return default(T);
        }

        Node<T> node = head;
        head = head.Next;
        return node.Data;
    }

    public IEnumerator<T> GetEnumerator()
    {
        return new MyEnum<T>(head);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public T this[int index]
    {
        get
        {
            if (head == null)
            {
                throw new IndexOutOfRangeException();
            }
            int count = 0;
            Node<T> current = head;

            while (count < index)
            {
                count++;
                if (current == null)
                {
                    throw new IndexOutOfRangeException();
                }
                current = current.Next;
            }

            return current.Data;
        }
    }
}