
namespace ArraysAndCollections.Sorting
{
    public static class QuickSort
    {
        public static void QSort(int[] array, int startIndex, int endIndex)
        {
            if (startIndex >= endIndex)
            {
                return;
            }

            int pivot = Partition(array, startIndex, endIndex);
            QSort(array, startIndex, pivot - 1);
            QSort(array, pivot + 1, endIndex);
        }

        private static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        private static int Partition(int[] array, int startIndex, int endIndex)
        {
            var pivotIndex = startIndex;
            for (var i = startIndex; i <= endIndex; i++)
            {
                if (array[i] > array[endIndex]) continue;
                Swap(ref array[pivotIndex], ref array[i]);
                pivotIndex++;
            }

            return --pivotIndex;
        }
    }
}