/*
 * MaxHeap.cs
 * -----------
 * This file implements a Max Heap data structure for storing `Employee` objects.
 * The heap maintains the highest-salaried employee at the top (index 0) and is used
 * to organise and extract employees in descending order of salary.
 *
 * Tasks:
 *  - Implements insertion and extraction logic using standard heap algorithms.
 *  - Provides methods for printing the heap and retrieving the top (highest-paid) employee.
 *  - Performs Step 3.
 *
 * Reference:
 *  GeeksForGeeks. (2025, February 13). Introduction to Max Heap - Data Structure. GeeksforGeeks.
 *  https://www.geeksforgeeks.org/introduction-to-max-heap-data-structure/
 */
using System;
using System.Collections.Generic;

public class MaxHeap
{
    // Internal list to hold the heap of Employee objects.
    private List<Employee> heap = new List<Employee>();

    /*
     * Heapify() takes an int value to maintain the Max Heap property going upward (bottom-up).
     * - Compares the current node with its parent; if it's larger, it swaps and recurses.
     */
    private void Heapify(int i)
    {
        // Find parent
        int parent = (i - 1) / 2;

        // Ensure parent index is valid
        if (parent >= 0)
        {
            // If current salary > parent's salary, swap and recurse
            if(heap[i].GetSalary() > heap[parent].GetSalary())
            {
                var temp = heap[i];
                heap[i] = heap[parent];
                heap[parent] = temp;
                // Recursive call to continue bubbling up
                Heapify(parent);
            }
        }
    }

    /*
     * InsertEmployee() takes an Employee and inserts them into the heap and maintains the 
     * Max Heap structure.
     * - Add to end of list
     * - Restore heap by bubbling up
     */
    public void InsertEmployee(Employee emp)
    {
        heap.Add(emp);
        Heapify(heap.Count - 1);
    }

    /*
     * PrintHeap() displays all employee earnings from the heap.
     * - Useful for inspecting the internal (not sorted) heap state.
     */
    public void PrintHeap()
    {
        foreach (var emp in heap)
        {
            emp.OutputEarnings();
        }
    }

    /*
     * ExtractMax() removes and returns the highest-paid employee (the root of the heap).
     * - Moves the last element to the root, reduces the heap size, and restores order.
     */
    public Employee? ExtractMax()
    {
        if (heap.Count == 0) return null;

        Employee max = heap[0]; // The top of the heap

        heap[0] = heap[heap.Count - 1]; // Replace with last
        heap.RemoveAt(heap.Count - 1);  // Shrink the heap

        // Restore heap property
        HeapifyDown(0);

        return max;
    }

     /*
     * HeapifyDown() takes an int value to maintain the Max Heap property by pushing down the value
     * to its correct position. 
     * - Compares the current node with its children.
     */
    private void HeapifyDown(int i)
    {
        int largest = i; // Assume the current index is the largest
        int left = 2 * i + 1;  // Left child index
        int right = 2 * i + 2; // Right child index

        // Compare left child
        if (left < heap.Count && heap[left].GetSalary() > heap[largest].GetSalary())
        {
            largest = left;
        }

        // Compare right child
        if (right < heap.Count && heap[right].GetSalary() > heap[largest].GetSalary())
        {
            largest = right;
        }

        // If a child is larger, swap and recurse
        if (largest != i)
        {
            var temp = heap[i];
            heap[i] = heap[largest];
            heap[largest] = temp;

            HeapifyDown(largest);
        }
    }
}
