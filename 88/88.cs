public class Solution {
    /// <summary>
    /// Merge two arrays, where num1 will be sorted in-place afterwards with nums2 inserted.
    /// </summary>
    /// <param name="nums1">array of size n+m to accomodate the full sorted array</param>
    /// <param name="m">Number of elements in nums1 that need to be sorted</param>
    /// <param name="nums2">second array of sorted elements</param>
    /// <param name="n">nums length</param>
    public void Merge(int[] nums1, int m, int[] nums2, int n) {
        int secondIndex = n -1;
        int firstIndex = m-1;
        for(int i = nums1.Length -1; i>= 0; i--){
            if(secondIndex < 0 ){
                nums1[i] = nums1[firstIndex];
                firstIndex--;
            } else if (firstIndex < 0){
                nums1[i] = nums2[secondIndex];
                secondIndex--;
            } else {
                if(nums2[secondIndex] > nums1[firstIndex]){
                    nums1[i]  = nums2[secondIndex];
                    secondIndex--;
                } else if( nums2[secondIndex] <=  nums1[firstIndex]){
                    nums1[i] = nums1[firstIndex];
                    firstIndex--;
                }
            }
        }
    }
}