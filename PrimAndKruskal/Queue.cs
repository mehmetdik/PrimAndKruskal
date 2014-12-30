using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _12253021HW4
{
    class Queue<T> where T : IComparable
    {
        int rear;
        int front;
        T[] items;
        public Queue(int size)
        {
            items = new T[size];
            rear = front = -1;
        }
        public void clear()
        {
            front = rear = -1;
        }
        public int size()
        {
            return items.Length;
        }
        public bool isEmpty()
        {
            return front == rear;
        }
        public bool isFull()
        {
            return rear == size() - 1;//rear==items.Length-1
        }
        public void enQueue(T val)
        {
            if (isFull())
                throw new Exception("Queue is Full");
            else
            {
                items[++rear] = val;
            }
        }

        public T deQueue()
        {
            if (isEmpty())
                throw new Exception("Queue is empty");
            else
            {
                front++;
                return items[front];
            }
        }

        public void display()
        {
            if (isEmpty())
                Console.WriteLine("Queue is Empty");
            else
            {
                int temp = front + 1;
                while (temp <= rear)
                {
                    Console.WriteLine(items[temp++]);
                }
            }

        }

        internal void enQueue(Vertex iterator)
        {
            throw new NotImplementedException();
        }


    }
}
