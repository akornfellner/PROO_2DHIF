
public class IntList
{
    public Node? Head { get; set; }

    public IntList()
    {
        Head = null;
    }

    public void Add(int value)
    {
        if (Head == null)
        {
            Head = new Node(value);
        }
        else
        {
            Node node = new Node(value);

            if (value <= Head.Data)
            {
                node.Next = Head;
                Head = node;
                return;
            }

            Node current = Head;

            while (current.Next != null && current.Next.Data <= value)
            {
                current = current.Next;
            }

            if (current.Next != null)
            {
                node.Next = current.Next;
            }

            current.Next = node;
        }
    }


    public void PrintList()
    {
        Node current = Head;

        while (current != null)
        {
            Console.WriteLine(current.Data);
            current = current.Next;
        }
    }
}
