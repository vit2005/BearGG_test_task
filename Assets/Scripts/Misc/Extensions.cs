using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extensions
{
    public static T Next<T>(this List<T> list, T element)
    {
        // Check if the list is empty
        if (list.Count == 0)
        {
            throw new InvalidOperationException("Cannot get the next element from an empty list.");
        }

        // Find the index of the element
        int index = list.IndexOf(element);

        // Check if the element is in the list
        if (index == -1)
        {
            throw new ArgumentException("Element not found in the list.");
        }

        // Calculate the index of the next element
        int nextIndex = (index + 1) % list.Count;

        // Return the next element
        return list[nextIndex];
    }
}
