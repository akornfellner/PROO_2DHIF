namespace Indexer;

public class StringList
{
    private Node? head;
    private int count;

    public void Add(string s)
    {
        if (head == null)
        {
            head = new Node(s);
        }
        else
        {
            Node current = head;

            while (current.Next != null)
            {
                current = current.Next;
            }

            current.Next = new Node(s);
        }
        count++;
    }

    public string this[int pos]
    {
        get
        {
            if (pos < 0 || pos >= count)
            {
                throw new IndexOutOfRangeException();
            }

            Node current = head;

            for (int i = 0; i < pos; i++)
            {
                current = current.Next;
            }

            return current.Data;
        }
    }

    public override string ToString()
    {
        if (head == null)
        {
            return "";
        }

        string result = "";

        Node current = head;

        while (current != null)
        {
            result += current.Data + "\n";
            current = current.Next;
        }

        return result;

    }
}