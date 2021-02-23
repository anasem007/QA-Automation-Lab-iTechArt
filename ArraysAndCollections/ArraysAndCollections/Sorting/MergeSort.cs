using System.Collections.Generic;
using System.Linq;

namespace ArraysAndCollections.Sorting
{
    public static class MergeSort
    { 
        public static int[] MSort(int[] array)
        {
            if (array.Length == 1)
                return array;
            
            var middleIndex = array.Length / 2;
            
            return Merge(MSort(array.Take(middleIndex).ToArray()), MSort(array.Skip(middleIndex).ToArray()));
        }

        private static int[] Merge(IReadOnlyList<int> firstArray, IReadOnlyList<int> secondArray)
        {
            var firstArrayIndex = 0;
            var secondArrayIndex = 0;
            var mergedArray = new int[firstArray.Count + secondArray.Count];
            
            for (var i = 0; i < firstArray.Count + secondArray.Count; i++)
            {
                switch (secondArrayIndex < secondArray.Count)
                {
                    case true when firstArrayIndex < firstArray.Count:
                    {
                        if (firstArray[firstArrayIndex] > secondArray[secondArrayIndex])
                            mergedArray[i] = secondArray[secondArrayIndex++];
                        else
                            mergedArray[i] = firstArray[firstArrayIndex++];
                        break;
                    }
                    case true:
                        mergedArray[i] = secondArray[secondArrayIndex++];
                        break;
                    default:
                        mergedArray[i] = firstArray[firstArrayIndex++];
                        break;
                }
            }
            return mergedArray;
        }
    }
}