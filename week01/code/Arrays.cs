public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // STEP 1: Create a new array of doubles with the given length.
        // This array will store the multiples of the provided number.
        double[] result = new double[length];

        // STEP 2: Loop through the array indices from 0 to length - 1.
        // Each index represents one multiple of the number.
        for (int i = 0; i < length; i++)
        {
            // STEP 3: Calculate the multiple.
            // The first element should be number * 1,
            // the second element number * 2, and so on.
            result[i] = number * (i + 1);
        }

        // STEP 4: Return the completed array containing all multiples.
        return result;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // STEP 1: Determine how many elements will move from the end of the list to the front.
        // Rotating right by 'amount' means the last 'amount' elements will move to the beginning.
        int splitIndex = data.Count - amount;

        // STEP 2: Use GetRange to copy the last 'amount' elements into a temporary list.
        // These are the elements that will be moved to the front.
        List<int> rightPart = data.GetRange(splitIndex, amount);

        // STEP 3: Remove the last 'amount' elements from the original list.
        // This leaves only the elements that will be shifted to the right.
        data.RemoveRange(splitIndex, amount);

        // STEP 4: Insert the saved elements at the beginning of the list.
        // This completes the right rotation.
        data.InsertRange(0, rightPart);
    }
}
