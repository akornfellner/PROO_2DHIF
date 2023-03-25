using System.Collections;

public class MyEnum<T> : IEnumerator<T>
{
    private Node<T> head;
    private Node<T> current;

    public MyEnum(Node<T> head)
    {
        this.head = head;
        current = null;
    }

    public T Current
    {
        get { return current.Value; }
    }

    public void Dispose()
    {
    }

    object IEnumerator.Current
    {
        get { return Current; }
    }

    // be aware that this method is called before accessing the first element
    public bool MoveNext()
    {
        if (current == null)
        {
            current = head;
        }
        else
        {
            current = current.Next;
        }
        return current != null;
    }

    public void Reset()
    {
        current = null;
    }
}