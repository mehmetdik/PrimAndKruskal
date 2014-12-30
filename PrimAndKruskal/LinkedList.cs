using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _12253021HW4
{
    class LinkedList<T> where T : IComparable
    {
        Node<T> head;

        public Node<T> createNode(T val)
        {
            return new Node<T>(val);
        }
        public bool search(T val)
        {
            Node<T> iterator = head;
            while (iterator != null)
            {
                if (iterator.Value.CompareTo(val) == 0)
                    return true;
                iterator = iterator.Next;
            }
            return false;

        }

        public void addSorted(T val)
        {
            Node<T> newNode = createNode(val);
            if (head == null)
                head = newNode;
            else if (head.Value.CompareTo(val) >= 0)
            {
                newNode.Next = head;
                head = newNode;
                //addToFront(val);

            }
            else
            {
                Node<T> iterator = head.Next;
                Node<T> previous = head;
                while (iterator != null)
                {
                    if (iterator.Value.CompareTo(val) >= 0)
                    {
                        previous.Next = newNode;
                        newNode.Next = iterator;
                        break;
                    }
                    previous = iterator;
                    iterator = iterator.Next;
                }
                if (iterator == null)
                    previous.Next = newNode;



            }



        }
        public void addToEnd(T val)
        {
            if (head == null)
                head = createNode(val);//new Node<T>(val);
            else
            {
                Node<T> iterator = head;
                while (iterator.Next != null)
                {
                    iterator = iterator.Next;
                }
                iterator.Next = createNode(val);
            }
        }
        public void addToFront(T val)
        {
            Node<T> temp = createNode(val);
            temp.Next = head;
            head = temp;
        }
        public void display()
        {
            Node<T> iterator = head;

            while (iterator != null)
            {

                Console.WriteLine(iterator.ToString());
                iterator = iterator.Next;
            }
        }

        public void addAfterHead(T val)
        {
            if (head == null)
                head = createNode(val);
            else
            {
                Node<T> temp = createNode(val);
                temp.Next = head.Next;
                head.Next = temp;
            }
        }
        private Node<T> findPrev(Node<T> current)
        {
            Node<T> iterator = head;
            while (iterator.Next != current)
            {
                iterator = iterator.Next;
            }
            return iterator;
        }



        public void reverse()
        {
            Node<T> tempHead, iterator;
            iterator = head;
            while (iterator.Next != null)
                iterator = iterator.Next;
            tempHead = iterator;
            while (iterator != head)
            {
                iterator.Next = findPrev(iterator);
                iterator = iterator.Next;
            }
            iterator.Next = null;//head.next=null;
            head = tempHead;
        }




        public void delete(T val)
        {
            //Silinecek eleman listede yoksa çöker
            if (head != null)//hiç eleman yoksa
            {
                while (head.Value.CompareTo(val) == 0)//İlk eleman silinecekse
                {
                    head = head.Next;
                }
                if (head != null)
                {

                    Node<T> iterator = head.Next;
                    Node<T> prev = head;
                    while (iterator != null)
                    {

                        if (iterator.Value.CompareTo(val) == 0)
                        {
                            prev.Next = iterator.Next;
                            //break;
                        }
                        prev = iterator;
                        iterator = iterator.Next;
                    }
                }

            }

        }

        public int Length()
        {
            Node<T> iterator = head;
            int counter = 0;
            while (iterator != null)
            {
                counter++;
                iterator = iterator.Next;
            }
            return counter;
        }
    }
}
