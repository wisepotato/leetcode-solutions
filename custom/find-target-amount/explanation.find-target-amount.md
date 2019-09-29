# Find number offucrences of an element in a sorted array

Given a sorted array of `n` elements, possibly with duplicates, find the number of occurrences of the `target` element.



**Example 1:**



```
Input: arr = [4, 4, 8, 8, 8, 15, 16, 23, 23, 42], target = 8
Output: 3
```

**Example 2:**

```
Input: arr = [3, 5, 5, 5, 5, 7, 8, 8], target = 6
Output: 0
```

**Example 3:**

```
Input: arr = [3, 5, 5, 5, 5, 7, 8, 8], target = 5
Output: 4
```

Expected `O(logn)` time solution.

Related problems:

- https://leetcode.com/problems/find-first-and-last-position-of-element-in-sorted-array



## Learned

* This is a divide & conquer approach because `O(log(n))` is needed, this is the worst case scenario
* Multiple subproblems
  * Finding the right binsize for your left and right
  * Making sure that the array is copied
  * Stop condition
* As always, take small arrays into account.