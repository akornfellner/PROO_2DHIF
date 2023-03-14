public class MyList<T> where T : IComparable<T>
{
    private Node<T>? head;

    public void Add(T data)
    {
        if (head == null)
        {
            head = new Node<T>(data);
        }
        else
        {
            Node<T> current = head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = new Node<T>(data);
        }
    }

    public void PrintAll()
    {
        Node<T>? current = head;
        while (current != null)
        {
            Console.WriteLine(current.Data);
            current = current.Next;
        }
    }

    public T GetBiggest()
    {
        Node<T>? current = head;
        T biggest = current.Data;
        while (current != null)
        {
            if (current.Data.CompareTo(biggest) > 0)
            {
                biggest = current.Data;
            }
            current = current.Next;
        }
        return biggest;
    }
}