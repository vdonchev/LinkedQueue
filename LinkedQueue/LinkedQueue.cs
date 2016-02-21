namespace LinkedQueue
{
    using System;

    public class LinkedQueue<T>
    {
        private LinkedQueueNode<T> start;
        private LinkedQueueNode<T> end;

        public LinkedQueue()
        {
            this.Count = 0;
        }

        public int Count { get; private set; }

        public void Enqueue(T element)
        {
            var newElement = new LinkedQueueNode<T>(element);

            if (this.Count == 0)
            {
                this.start = this.end = newElement;
            }
            else
            {
                this.end.Next = newElement;
                this.end = newElement;
            }

            this.Count++;
        }

        public T Dequeue()
        {
            if (this.Count <= 0)
            {
                throw new InvalidOperationException("Queue is empty.");
            }

            var elementToReturn = this.start;
            this.start = this.start.Next;
            this.Count--;

            return elementToReturn.Value;
        }

        public T Peak()
        {
            if (this.Count <= 0)
            {
                throw new InvalidOperationException("Queue is empty.");
            }

            var currentElement = this.start.Value;

            return currentElement;
        }

        public T[] ToArray()
        {
            var arrToReturn = new T[this.Count];
            var currentNode = this.start;
            var arrIndex = 0;
            while (currentNode != null)
            {
                arrToReturn[arrIndex] = currentNode.Value;
                arrIndex++;
                currentNode = currentNode.Next;
            }

            return arrToReturn;
        }
        
        private class LinkedQueueNode<T>
        {
            public LinkedQueueNode(T value)
            {
                this.Value = value;
            }

            public T Value { get; private set; }

            public LinkedQueueNode<T> Next { get; set; }
        }
    }
}
