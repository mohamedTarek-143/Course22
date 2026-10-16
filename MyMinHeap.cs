using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course22
{
    public class Task
    {
        public string Name { get; set; } // Task name
        public int Priority { get; set; } // Task priority


        public Task(string name, int priority)
        {
            Name = name;
            Priority = priority;
        }


        public override string ToString()
        {
            return $"Task: {Name}, Priority: {Priority}";
        }
    }
    public class MyMinHeap
    {
        List<Task> heap = new List<Task>();

        public void Insert(Task task)
        {
            heap.Add(task);
            HeapifyUp(heap.Count -1);
        }

        private void HeapifyDown(int index)
        {
            int smallest = index;
            int left = 2 * index + 1;
            int right = 2 * index + 2;

            if (left < heap.Count && heap[left].Priority < heap[smallest].Priority)
                smallest = left;

            if (right < heap.Count && heap[right].Priority < heap[smallest].Priority)
                smallest = right;

            if(smallest != index) // on smallest changed
            {
                Swap(index, smallest);
                HeapifyDown(smallest);
            }
        }
        public void HeapifyUp(int index)
        {
            while (index > 0 && heap[index].Priority < heap[(index - 1) / 2].Priority)
            {
                Swap(index, (index - 1) / 2);
                index = (index - 1) / 2;
            }

        }
        public Task ExtractMin()
        {
            if (heap.Count == 0) return null;

            var minTask = heap[0];
            heap[0] = heap[heap.Count - 1];
            heap.RemoveAt(heap.Count - 1);
            HeapifyDown(0);

            return minTask;
        }

        private void Swap(int i, int j)
        {
            var temp = heap[i];
            heap[i] = heap[j];
            heap[j] = temp;
        }
        public bool IsEmpty()
        {
            return heap.Count == 0;
        }
    }
}
