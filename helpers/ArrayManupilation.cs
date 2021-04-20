namespace caesar_cipher_igsr.helpers
{
    public class ArrayManupilation
    {
        /// <summary>
        /// Shift array with index (move positions based on shift index)
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="shiftIndex"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns>Array after shifting operation</returns>
         public static T[] ShiftByIndex<T>(T[] arr, int shiftIndex) {
            T[] tmp = new T[arr.Length];
            for (int i = 0; i < arr.Length; i++) {
                // move value based on the new index calculated
                // mod is for overlapping array
                tmp[(i + shiftIndex) % tmp.Length] = arr[i];
            }
            return tmp;
        }
    }
}