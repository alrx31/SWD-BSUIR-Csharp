using System.Diagnostics.CodeAnalysis;

class ЛР1
{
    public static void Main(String[] args)
    {

        string? input = Console.ReadLine();

    }

    class Ring<T> where T : IComparable<T>
    {
        internal class Node
        {
            public T Data { get; set; }
            public Node Next { get; set; }
            public Node Prev { get; set; }
            public Node( T data)
            {
                this.Data = data;

            }

            public void setNext(Node node)
            {
                this.Next = node;
            }
            public void setPrev(Node node)
            {
                this.Prev = Prev;
            }
            public T getData() => Data;

        }

        public Node Head { get; set; }
        public int size { get; set; }


        public Ring()
        {
            this.Head = null;
            this.size = 0;
        }



        public bool CheckDublicates(T data)
        {
            Node current = Head;
            for (int i = 0; i < size; i++)
            {
                if (current.Data.Equals(data))
                {
                    return true;
                }
                current = current.Next;
            }
            return false;
        }


        public void addElement(T data)
        {

            bool dubles = CheckDublicates(data);

            if (dubles)
            {
                if (Head == null)
                {
                    Head = new Node(data);
                    Head.setNext(Head);
                    Head.setPrev(Head);
                }
                else
                {
                    Node temp = Head;
                    for (int i = 0; i < size; i++)
                    {
                        temp = temp.Next;
                    }
                    temp.setNext(new Node(data));
                    temp = temp.Next;
                    temp.setNext(Head);
                }
                size++;
            }
        }


        public void deleteByIndex(int index)
        {
            try
            {

                Node current = Head;
                for (int i = 0; i < index; i++)
                {
                    current = current.Next;
                }

                current.Next.setPrev(current.Prev);
                current.Prev.setNext(current.Next);
                current = null;
                size--;
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }


        public int getIndexByData(T value)
        {
            Node current = Head;
            for (int i = 0; i < size; i++)
            {
                if (current.Data.Equals(value))
                {
                    return i;
                }
            }
            return -1;
        }



        public void Print()
        {
            Node current = Head;
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine("value: " + current.Data);
                current = current.Next;
            }
        }


        public void Sort()
        {
            try
            {
                Node current = Head;
                for (int i = 0; i < size - 1; i++)
                {
                    for (int j = 0; j < size - i - 1; j++)
                    {
                        if(current.Data.CompareTo(current.Data)  == 1)
                        {
                                // смена местами 
                        }
                        current = current.Next;

                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

    }
}