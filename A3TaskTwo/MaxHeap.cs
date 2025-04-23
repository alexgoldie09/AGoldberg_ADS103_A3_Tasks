using System;
using System.Collections.Generic;

public class MaxHeap
{
    private List<Employee> heap = new List<Employee>();

    // Heapify from bottom-up
    private void Heapify(int i)
    {
        // Find parent
        int parent = (i - 1) / 2;

        if (parent >= 0)
        {
            // For Max-Heap
            // If current node is greater than its parent
            // Swap both of them and call heapify again
            // for the parent
            if(heap[i].GetSalary() > heap[parent].GetSalary())
            {
                // Swap
                var temp = heap[i];
                heap[i] = heap[parent];
                heap[parent] = temp;
                // Recursively heapify the parent node
                Heapify(parent);
            }
        }
    }

    // Insert an employee into the heap
    public void InsertEmployee(Employee emp)
    {
        heap.Add(emp);
        Heapify(heap.Count - 1);
    }

    // Print the heap by salary
    public void PrintHeap()
    {
        foreach (var emp in heap)
        {
            emp.OutputEarnings();
        }
    }

    public Employee? ExtractMax()
    {
        if (heap.Count == 0) return null;

        Employee max = heap[0]; // The top of the max heap (highest salary)

        // Move the last element to the root
        heap[0] = heap[heap.Count - 1];
        heap.RemoveAt(heap.Count - 1); // This removes the current "max"

        // Re-heapify from the top down
        HeapifyDown(0);

        return max;
    }


    private void HeapifyDown(int i)
    {
        int largest = i; // Assume the current index is the largest
        int left = 2 * i + 1;  // Left child index
        int right = 2 * i + 2; // Right child index

        // Check if left child exists and has a larger salary than current largest
        if (left < heap.Count && heap[left].GetSalary() > heap[largest].GetSalary())
        {
            largest = left; // Update largest to left child
        }

        // Check if right child exists and has a larger salary than current largest
        if (right < heap.Count && heap[right].GetSalary() > heap[largest].GetSalary())
        {
            largest = right; // Update largest to right child
        }

        // If largest is no longer the current index, we need to swap
        if (largest != i)
        {
            // Swap current with the largest child
            var temp = heap[i];
            heap[i] = heap[largest];
            heap[largest] = temp;

            // Recursively call HeapifyDown on the swapped child
            HeapifyDown(largest);
        }
        // Else: the heap property is satisfied, so we stop
    }
}
