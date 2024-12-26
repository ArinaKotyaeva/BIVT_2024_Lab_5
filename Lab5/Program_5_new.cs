using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Numerics;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class Program
{
    public static void Main()
    {
        Program program = new Program();
    }
    #region Level 1
    public long Task_1_1(int n, int k)
    {
        long answer = 0;

        // code here

        if (k > n || k < 0)
        {
            return 0;
        }

        long factorialN = Factorial(n);
        long factorialK = Factorial(k);
        long factorialNMinusK = Factorial(n - k);


        answer = factorialN / (factorialK * factorialNMinusK);

        return answer;
    }

    private long Factorial(int number)
    {
        if (number == 0 || number == 1)
        {
            return 1;
        }

        long result = 1;
        for (int i = 2; i <= number; i++)
        {
            result *= i;
        }
        // end

        return result;
    }

    public int Task_1_2(double[] first, double[] second)
    {
        int answer = 0;

        // code here

        if (first.Length != 3 || second.Length != 3)
        {
            throw new ArgumentException("Each input array must contain exactly three elements representing the sides of a triangle.");
        }

        double a1 = first[0];
        double b1 = first[1];
        double c1 = first[2];

        double a2 = second[0];
        double b2 = second[1];
        double c2 = second[2];


        if (!IsValidTriangle(a1, b1, c1) || !IsValidTriangle(a2, b2, c2))
        {
            return -1;
        }

        double area1 = GeronArea(a1, b1, c1);
        double area2 = GeronArea(a2, b2, c2);

        if (area1 > area2) return 1;
        else if (area1 < area2) return 2;
        else return 0;
    }

    private bool IsValidTriangle(double a, double b, double c)
    {
        return a + b > c && a + c > b && b + c > a;
    }


    private double GeronArea(double a, double b, double c)
    {
        double s = (a + b + c) / 2;
        return Math.Sqrt(s * (s - a) * (s - b) * (s - c));
    }

    static double GetDistance(double v, double a, int t)
    {
        double S = v * t + (a * t * t) / 2;
        return S;
    }


    // end


    public int Task_1_3a(double v1, double a1, double v2, double a2, int time)
    {
        int answer = 0;

        double distanceObject1 = v1 * time + 0.5 * a1 * time * time;
        double distanceObject2 = v2 * time + 0.5 * a2 * time * time;


        if (distanceObject1 > distanceObject2)
        {
            answer = 1;
        }
        else if (distanceObject1 < distanceObject2)
        {
            answer = 2;
        }
        else
        {
            answer = 0;
        }

        return answer;
    }

    public int Task_1_3b(double v1, double a1, double v2, double a2)
    {
        int answer = 0;

        // code here

        for (int hours = 1; ; hours++)
        {
            double distance1 = GetDistance(v1, a1, hours);
            double distance2 = GetDistance(v2, a2, hours);

            if (distance2 >= distance1)
            {
                return hours;
            }
        }

        // end

        return answer;
    }
    #endregion

    #region Level 2
    public void Task_2_1(int[,] A, int[,] B)
    {
        // code here

        // create and use FindMaxIndex(matrix, out row, out column);

        // end
    }

    public void Task_2_2(double[] A, double[] B)
    {
        // code here

        int maxIndexA = FindMaxIndex(A);
        int maxIndexB = FindMaxIndex(B);

        if (maxIndexA < maxIndexB)
        {
            UpdateArrayWithAverage(A, maxIndexA);
        }
        else if (maxIndexA > maxIndexB)
        {
            UpdateArrayWithAverage(B, maxIndexB);
        }

        // end
    }

    private int FindMaxIndex(double[] array)
    {
        if (array == null || array.Length == 0)
            throw new ArgumentException("Array cannot be null or empty.");

        int maxIndex = 0;
        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] > array[maxIndex])
            {
                maxIndex = i;
            }
        }
        return maxIndex;
    }

    private void UpdateArrayWithAverage(double[] array, int maxIndex)
    {
        double sum = 0;
        double count = 0;

        for (int j = maxIndex + 1; j < array.Length; j++)
        {
            sum += array[j];
            count += 1;
        }

        double average = count > 0 ? sum / count : 0;

        for (int j = 0; j < array.Length; j++)
        {
            if (array[j] == array[maxIndex])
            {
                array[j] = average;
            }
        }
    }
    public void Task_2_3(ref int[,] B, ref int[,] C)
    {
        // code here

        //  create and use method FindDiagonalMaxIndex(matrix);

        // end
    }

    public void Task_2_4(int[,] A, int[,] B)
    {
        // code here
        int diagonalMaxIndexA = FindDiagonalMaxIndex(A);
        int diagonalMaxIndexB = FindDiagonalMaxIndex(B);
        for (int rowIndex = 0; rowIndex < A.GetLength(0); rowIndex++)
        {
            int tempValue = B[rowIndex, diagonalMaxIndexB];
            B[rowIndex, diagonalMaxIndexB] = A[diagonalMaxIndexA, rowIndex];
            A[diagonalMaxIndexA, rowIndex] = tempValue;
        }

        // end
    }

    public int FindDiagonalMaxIndex(int[,] matrix)
    {
        int maxIndex = 0;
        int maxValue = matrix[0, 0];

        for (int index = 0; index < matrix.GetLength(0); index++)
        {
            if (matrix[index, index] > maxValue)
            {
                maxValue = matrix[index, index];
                maxIndex = index;
            }
        }

        return maxIndex;
    }

    public void Task_2_5(int[,] A, int[,] B)
    {
        // code here

        // create and use FindMaxInColumn(matrix, columnIndex, out rowIndex);

        // end
    }

    public void Task_2_6(ref int[] A, int[] B)
    {

        if (A.Length == 0 || B.Length == 0) return;


        int maxIndexA = FindMax(A);
        int maxIndexB = FindMax(B);
        A = DeleteElement(A, maxIndexA);
        B = DeleteElement(B, maxIndexB);

        int[] resultArray = new int[A.Length + B.Length];

        for (int index = 0; index < A.Length; index++)
        {
            resultArray[index] = A[index];
        }

        for (int index = 0; index < B.Length; index++)
        {
            resultArray[index + A.Length] = B[index];
        }


        A = resultArray;
    }

    private int FindMax(int[] array)
    {
        int maxIndex = 0;
        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] > array[maxIndex])
            {
                maxIndex = i;
            }
        }
        return maxIndex;
    }
    private int[] DeleteElement(int[] array, int index)
    {
        if (array.Length == 0) return array;

        int[] newArray = new int[array.Length - 1];
        for (int i = 0, j = 0; i < array.Length; i++)
        {
            if (i != index)
            {
                newArray[j++] = array[i];
            }
        }
        return newArray;
    }

    public void Task_2_7(ref int[,] B, int[,] C)
    {
        // code here

        // create and use CountRowPositive(matrix, rowIndex);
        // create and use CountColumnPositive(matrix, colIndex);

        // end
    }

    public void Task_2_8(int[] A, int[] B)
    {
        int maxIndexA = GetIndexOfMax(A);
        int maxIndexB = GetIndexOfMax(B);

        SortArrayPart(A, maxIndexA + 1);
        SortArrayPart(B, maxIndexB + 1);

    }

    private int GetIndexOfMax(int[] array)
    {
        int maxIndex = 0;
        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] > array[maxIndex])
            {
                maxIndex = i;
            }
        }
        return maxIndex;
    }

    private void SortArrayPart(int[] array, int startIndex)
    {
        if (startIndex >= array.Length)
        {
            return;
        }

        for (int i = startIndex; i < array.Length - 1; i++)
        {
            for (int j = startIndex; j < array.Length - (i - startIndex + 1); j++)
            {
                if (array[j] > array[j + 1])
                {
                    int temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;
                }
            }
        }
    }

    public int[] Task_2_9(int[,] A, int[,] C)
    {
        int[] answer = default(int[]);

        // code here

        // create and use SumPositiveElementsInColumns(matrix);

        // end

        return answer;
    }

    public void Task_2_10(ref int[,] matrix)
    {
        int highestValue = int.MinValue;
        int highestValueColumnIndex = 0;
        int lowestValue = int.MaxValue;
        int lowestValueColumnIndex = 0;


        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {

                if (row >= col)
                {
                    if (matrix[row, col] > highestValue)
                    {
                        highestValue = matrix[row, col];
                        highestValueColumnIndex = col;
                    }
                }

                else
                {
                    if (matrix[row, col] < lowestValue)
                    {
                        lowestValue = matrix[row, col];
                        lowestValueColumnIndex = col;
                    }
                }
            }
        }

        if (highestValueColumnIndex > lowestValueColumnIndex)
        {
            matrix = RemoveColumn(matrix, highestValueColumnIndex);
            matrix = RemoveColumn(matrix, lowestValueColumnIndex);
        }
        else if (lowestValueColumnIndex > highestValueColumnIndex)
        {
            matrix = RemoveColumn(matrix, lowestValueColumnIndex);
            matrix = RemoveColumn(matrix, highestValueColumnIndex);
        }
        else
        {
            matrix = RemoveColumn(matrix, highestValueColumnIndex);
        }

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write(matrix[row, col] + " ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();


    }
    static int[,] RemoveColumn(int[,] matrix, int columnIndex)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        int[,] result = new int[rows, cols - 1];

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                if (col < columnIndex)
                {
                    result[row, col] = matrix[row, col];
                }
                else if (col > columnIndex)
                {
                    result[row, col - 1] = matrix[row, col];
                }
            }
        }

        return result;
    }

    public void Task_2_11(int[,] A, int[,] B)
    {
        // code here

        // use FindMaxIndex(matrix, out row, out column); from Task_2_1

        // end
    }
    public void Task_2_12(int[,] A, int[,] B)
    {
        // code here
        int maxColumnIndexA = GetMaxColumnIndex(A);
        int maxColumnIndexB = GetMaxColumnIndex(B);

        for (int row = 0; row < A.GetLength(0); row++)
        {
            int tempValue = A[row, maxColumnIndexA];
            A[row, maxColumnIndexA] = B[row, maxColumnIndexB];
            B[row, maxColumnIndexB] = tempValue;
        }
    }

    static int GetMaxColumnIndex(int[,] matrix)
    {
        int maxColumnIndex = 0;
        int maxElement = matrix[0, 0];

        for (int col = 0; col < matrix.GetLength(1); col++)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if (matrix[row, col] > maxElement)
                {
                    maxElement = matrix[row, col];
                    maxColumnIndex = col;
                }
            }
        }

        return maxColumnIndex;
    }

    public void Task_2_13(ref int[,] matrix)
    {
        // code here

        // create and use RemoveRow(matrix, rowIndex);

        // end
    }

    public void Task_2_14(int[,] matrix)
    {
        for (int rowIndex = 0; rowIndex < matrix.GetLength(0); rowIndex++)
        {
            SortRowAscending(matrix, rowIndex);
        }

    }


    private void SortRowAscending(int[,] matrix, int rowIndex)
    {
        int columns = matrix.GetLength(1);

        for (int i = 0; i < columns - 1; i++)
        {
            for (int j = 0; j < columns - 1 - i; j++)
            {
                if (matrix[rowIndex, j] > matrix[rowIndex, j + 1])
                {
                    int temp = matrix[rowIndex, j];
                    matrix[rowIndex, j] = matrix[rowIndex, j + 1];
                    matrix[rowIndex, j + 1] = temp;
                }
            }
        }
    }

    private void SortDiagonalElements(int[,] matrix)
    {
        int size = Math.Min(matrix.GetLength(0), matrix.GetLength(1));
        int[] diagonalElements = new int[size];


        for (int i = 0; i < size; i++)
        {
            diagonalElements[i] = matrix[i, i];
        }

        for (int i = 0; i < size - 1; i++)
        {
            for (int j = 0; j < size - 1 - i; j++)
            {
                if (diagonalElements[j] > diagonalElements[j + 1])
                {
                    int temp = diagonalElements[j];
                    diagonalElements[j] = diagonalElements[j + 1];
                    diagonalElements[j + 1] = temp;
                }
            }
        }
        for (int i = 0; i < size; i++)
        {
            matrix[i, i] = diagonalElements[i];
        }
    }
    public int Task_2_15(int[,] A, int[,] B, int[,] C)
    {
        int answer = 0;

        // code here

        // create and use GetAverageWithoutMinMax(matrix);

        // end

        // 1 - increasing   0 - no sequence   -1 - decreasing
        return answer;
    }

    public void Task_2_16(int[] A, int[] B)
    {
        SortNegativeElements(A);
        SortNegativeElements(B);
    }

    private void SortNegativeElements(int[] array)
    {
        int negativeCount = 0;
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] < 0)
            {
                negativeCount++;
            }
        }

        int[] negatives = new int[negativeCount];
        int index = 0;

        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] < 0)
            {
                negatives[index] = array[i];
                index++;
            }
        }

        for (int i = 0; i < negatives.Length - 1; i++)
        {
            for (int j = 0; j < negatives.Length - 1 - i; j++)
            {
                if (negatives[j] < negatives[j + 1])
                {
                    int temp = negatives[j];
                    negatives[j] = negatives[j + 1];
                    negatives[j + 1] = temp;
                }
            }
        }

        index = 0;
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] < 0)
            {
                array[i] = negatives[index];
                index++;
            }
        }
    }

      

    public void Task_2_17(int[,] A, int[,] B)
    {
        // code here

        // create and use SortRowsByMaxElement(matrix);

        // end
    }

    public void Task_2_18(int[,] A, int[,] B)
    {
        SortDiagonalElements(A);
        SortDiagonalElements(B);
    }

    private void SortDiagonalElements(int[,] matrix)
    {
        int size = matrix.GetLength(0);
        int[] diagonalElements = new int[size];

        for (int i = 0; i < size; i++)
        {
            diagonalElements[i] = matrix[i, i];
        }

        for (int i = 0; i < diagonalElements.Length - 1; i++)
        {
            for (int j = 0; j < diagonalElements.Length - 1 - i; j++)
            {
                if (diagonalElements[j] > diagonalElements[j + 1])
                {
                    int temp = diagonalElements[j];
                    diagonalElements[j] = diagonalElements[j + 1];
                    diagonalElements[j + 1] = temp;
                }
            }
        }

        for (int i = 0; i < size; i++)
        {
            matrix[i, i] = diagonalElements[i];
        }
    }

    private void SortArrayPart(int[,] matrix, int rowIndex)
    {
        int columns = matrix.GetLength(1);
        int[] rowElements = new int[columns];

        for (int j = 0; j < columns; j++)
        {
            rowElements[j] = matrix[rowIndex, j];
        }
        for (int i = 0; i < rowElements.Length - 1; i++)
        {
            for (int j = 0; j < rowElements.Length - 1 - i; j++)
            {
                if (rowElements[j] > rowElements[j + 1])
                {
                    int temp = rowElements[j];
                    rowElements[j] = rowElements[j + 1];
                    rowElements[j + 1] = temp;
                }
            }
        }
        for (int j = 0; j < columns; j++)
        {
            matrix[rowIndex, j] = rowElements[j];
        }
    }
    private void SortRowAscending(int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        for (int i = 0; i < rows; i++)
        {
            SortArrayPart(matrix, i);
        }
    }

    public void Task_2_19(ref int[,] matrix)
    {
        // code here

        // use RemoveRow(matrix, rowIndex); from 2_13

        // end
    }
    public void Task_2_20(ref int[,] A, ref int[,] B)
    {
        RemoveColumnsWithoutZeros(ref A);
        RemoveColumnsWithoutZeros(ref B);
    }
    private void RemoveColumnsWithoutZeros(ref int[,] matrix)
    {
        for (int col = matrix.GetLength(1) - 1; col >= 0; col--)
        {
            bool hasZero = false;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if (matrix[row, col] == 0)
                {
                    hasZero = true;
                    break;
                }
            }
            if (!hasZero) RemoveColumn(ref matrix, col);
        }
    }
    static int CountNegativeInRow(int[,] matrix, int rowIndex)
    {
        int count = 0;
        for (int col = 0; col < matrix.GetLength(1); col++)
        {
            if (matrix[rowIndex, col] < 0) count++;
        }
        return count;
    }
    static int FindMaxNegativePerColumn(int[,] matrix, int columnIndex)
    {
        int maxNegative = int.MinValue;
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            if (matrix[row, columnIndex] < 0 && matrix[row, columnIndex] > maxNegative)
            {
                maxNegative = matrix[row, columnIndex];
            }
        }
        return maxNegative;
    }

    static void RemoveColumn(ref int[,] originalMatrix, int columnIndex)
    {
        int rows = originalMatrix.GetLength(0);
        int cols = originalMatrix.GetLength(1);
        int[,] newMatrix = new int[rows, cols - 1];

        for (int j = 0; j < columnIndex; j++)
        {
            for (int i = 0; i < rows; i++)
            {
                newMatrix[i, j] = originalMatrix[i, j];
            }
        }

        for (int j = columnIndex; j < cols - 1; j++)
        {
            for (int i = 0; i < rows; i++)
            {
                newMatrix[i, j] = originalMatrix[i, j + 1];
            }
        }

        originalMatrix = newMatrix;
    }

    public void Task_2_21(int[,] A, int[,] B, out int[] answerA, out int[] answerB)
    {
        answerA = null;
        answerB = null;

        // code here

        // create and use CreateArrayFromMins(matrix);

        // end
    }

    public void Task_2_22(int[,] matrix, out int[] rows, out int[] cols)
    {
        rows = null;
        cols = null;

        rows = new int[matrix.GetLength(0)];
        cols = new int[matrix.GetLength(1)];

        //делегаты
        Func<int[,], int, int> countNegativesInRow = CountNegativesInRow;
        Func<int[,], int, int> getMaxNegativeInColumn = GetMaxNegativeInColumn;

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            rows[i] = countNegativesInRow(matrix, i);
        }

        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            cols[j] = getMaxNegativeInColumn(matrix, j);
        }
    }

    static int CountNegativesInRow(int[,] matrix, int rowIndex)
    {
        int count = 0;
        for (int col = 0; col < matrix.GetLength(1); col++)
        {
            if (matrix[rowIndex, col] < 0)
            {
                count++;
            }
        }
        return count;
    }

    static int GetMaxNegativeInColumn(int[,] matrix, int columnIndex)
    {
        int maxNegative = int.MinValue;
        bool foundNegative = false;

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            if (matrix[row, columnIndex] < 0)
            {
                foundNegative = true;
                if (matrix[row, columnIndex] > maxNegative)
                {
                    maxNegative = matrix[row, columnIndex];
                }
            }
        }

        return foundNegative ? maxNegative : 0; 
    }

    public void Task_2_23(double[,] A, double[,] B)
    {
        // code here

        // create and use MatrixValuesChange(matrix);

        // end
    }

    public void Task_2_24(int[,] A, int[,] B)
    {
        int rowIndex = 0;
        int columnIndex = 0;
        FindMaxIndex(A, out rowIndex, out columnIndex);
        A = SwapColumnDiagonal(A, columnIndex);

        FindMaxIndex(B, out rowIndex, out columnIndex);
        B = SwapColumnDiagonal(B, columnIndex);
    }

    static void FindMaxIndex(int[,] matrix, out int row, out int column)
    {
        int maxValue = int.MinValue;
        row = 0;
        column = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] > maxValue)
                {
                    maxValue = matrix[i, j];
                    row = i;
                    column = j;
                }
            }
        }
    }

    static int[,] SwapColumnDiagonal(int[,] matrix, int colIndex)
    {
        int size = matrix.GetLength(0);
        for (int i = 0; i < size; i++)
        {
            int temp = matrix[i, colIndex];
            matrix[i, colIndex] = matrix[i, i];
            matrix[i, i] = temp;
        }
        return matrix;
    }

    static int FindRowWithMaxNegativeCount(int[,] matrix)
    {
        int maxCount = 0;
        int rowIndex = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            int negativeCount = CountNegativeInRow(matrix, i);
            if (negativeCount > maxCount)
            {
                maxCount = negativeCount;
                rowIndex = i;
            }
        }
        return rowIndex;
    }


    public void Task_2_25(int[,] A, int[,] B, out int maxA, out int maxB)
    {
        maxA = 0;
        maxB = 0;

        // code here

        // create and use FindRowWithMaxNegativeCount(matrix);
        // in FindRowWithMaxNegativeCount create and use CountNegativeInRow(matrix, rowIndex); like in 2_22

        // end
    }

    public void Task_2_26(int[,] A, int[,] B)
    {
        int maxRowA = FindRowWithMaxNegativeCount(A);
        int maxRowB = FindRowWithMaxNegativeCount(B);

        for (int column = 0; column < A.GetLength(1); column++)
        {
            int temp = A[maxRowA, column];
            A[maxRowA, column] = B[maxRowB, column];
            B[maxRowB, column] = temp;
        }
    }

    public void Task_2_27(int[,] A, int[,] B)
    {
        // code here

        // create and use FindRowMaxIndex(matrix, rowIndex, out columnIndex);
        // create and use ReplaceMaxElementOdd(matrix, row, column);
        // create and use ReplaceMaxElementEven(matrix, row, column);

        // end
    }

    public void Task_2_28a(int[] first, int[] second, ref int answerFirst, ref int answerSecond)
    {
        answerFirst = DetermineMonotonicity(first, 0, first.Length - 1);
        answerSecond = DetermineMonotonicity(second, 0, second.Length - 1);
    }

    static int[,] GetMonotonicIntervals(int[] array, int start, int end)
    {
        int count = 0;
        for (int i = start; i <= end - 1; i++)
        {
            for (int j = i + 1; j <= end; j++)
            {
                if (DetermineMonotonicity(array, i, j) == 1 || DetermineMonotonicity(array, i, j) == -1) count++;
            }
        }
        int[,] result = new int[count, 2];
        int index = 0;
        for (int i = start; i <= end - 1; i++)
        {
            for (int j = i + 1; j <= end; j++)
            {
                if (DetermineMonotonicity(array, i, j) == 1 || DetermineMonotonicity(array, i, j) == -1)
                {
                    result[index, 0] = i;
                    result[index, 1] = j;
                    index++;
                }
            }
        }
        return result;
    }

    static int DetermineMonotonicity(int[] array, int startIndex, int endIndex)
    {
        int monotonicityType = 0;
        bool isIncreasing = true;
        bool isDecreasing = true;
        for (int i = startIndex; i < endIndex; i++)
        {
            if (array[i + 1] < array[i])
            {
                isIncreasing = false;
            }
            else if (array[i + 1] > array[i])
            {
                isDecreasing = false;
            }
        }
        if (isIncreasing) monotonicityType = 1;
        else if (isDecreasing) monotonicityType = -1;
        return monotonicityType;
    }

    public void Task_2_28b(int[] first, int[] second, ref int[,] answerFirst, ref int[,] answerSecond)
    {
        answerFirst = GetMonotonicIntervals(first, 0, first.Length - 1);
        answerSecond = GetMonotonicIntervals(second, 0, second.Length - 1);
    }

    static int[] GetLongestInterval(int[,] intervals)
    {
        int[] longestInterval = new int[2];
        int maxLength = 0;
        int rowCount = intervals.GetLength(0);
        for (int i = 0; i < rowCount; i++)
        {
            if (intervals[i, 1] - intervals[i, 0] > maxLength)
            {
                maxLength = intervals[i, 1] - intervals[i, 0];
                longestInterval[0] = intervals[i, 0];
                longestInterval[1] = intervals[i, 1];
            }
        }
        return longestInterval;
    }

    public void Task_2_28c(int[] first, int[] second, ref int[] answerFirst, ref int[] answerSecond)
    {
        answerFirst = GetLongestInterval(GetMonotonicIntervals(first, 0, first.Length - 1));
        answerSecond = GetLongestInterval(GetMonotonicIntervals(second, 0, second.Length - 1));
    }

    public delegate void RowSortingStyle(ref int[,] matrix, int rowIndex);

    static void SortInAscendingOrder(ref int[,] matrix, int rowIndex)
    {
        for (int i = 0; i < matrix.GetLength(1) - 1; i++)
            for (int j = 0; j < matrix.GetLength(1) - i - 1; j++)
                if (matrix[rowIndex, j] > matrix[rowIndex, j + 1])
                {
                    int temp = matrix[rowIndex, j];
                    matrix[rowIndex, j] = matrix[rowIndex, j + 1];
                    matrix[rowIndex, j + 1] = temp;
                }
    }

    static void SortInDescendingOrder(ref int[,] matrix, int rowIndex)
    {
        for (int i = 0; i < matrix.GetLength(1) - 1; i++)
            for (int j = 0; j < matrix.GetLength(1) - i - 1; j++)
                if (matrix[rowIndex, j] < matrix[rowIndex, j + 1])
                {
                    int tempValue = matrix[rowIndex, j];
                    matrix[rowIndex, j] = matrix[rowIndex, j + 1];
                    matrix[rowIndex, j + 1] = tempValue;
                }
    }
    #endregion

    #region Level 3
    public void Task_3_1(ref double[,] firstSumAndY, ref double[,] secondSumAndY)
    {
        // code here

        // create and use public delegate SumFunction(x) and public delegate YFunction(x)
        // create and use method GetSumAndY(sFunction, yFunction, a, b, h);
        // create and use 2 methods for both functions calculating at specific x

        // end
    }

    public void Task_3_2(int[,] matrix)
    {
        RowSortingStyle sortingMethod = default(RowSortingStyle);

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            if (i % 2 == 0)
            {
                sortingMethod = SortInAscendingOrder;
            }
            else
            {
                sortingMethod = SortInDescendingOrder;
            }
            sortingMethod(ref matrix, i);
        }

        // code here

        // create and use public delegate RowSortingStyle(matrix, rowIndex);
        // create and use methods SortInAscendingOrder(matrix, rowIndex) and SortInDescendingOrder(matrix, rowIndex)
        // change method in variable sortingMethod in the loop here and use it for row sorting

        // end
    }

    public delegate int[] TriangleExtractor(int[,] matrix);

    static int[] ExtractUpperTriangle(int[,] matrix)
    {
        int count = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (i <= j) count++;
            }
        }
        int[] resultArray = new int[count];
        int arrayIndex = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (i <= j)
                {
                    resultArray[arrayIndex] = matrix[i, j];
                    arrayIndex++;
                }
            }
        }
        return resultArray;
    }

    static int[] ExtractLowerTriangle(int[,] matrix)
    {
        int count = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (i >= j) count++;
            }
        }
        int[] resultArray = new int[count];
        int arrayIndex = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (i >= j)
                {
                    resultArray[arrayIndex] = matrix[i, j];
                    arrayIndex++;
                }
            }
        }
        return resultArray;
    }

    static int CalculateSum(TriangleExtractor triangleDelegate, int[,] matrix)
    {
        int sum = 0;
        int[] array = triangleDelegate(matrix);
        for (int i = 0; i < array.Length; i++)
        {
            sum += array[i] * array[i];
        }
        return sum;
    }

    public double Task_3_3(double[] array)
    {
        double answer = 0;
        // SwapDirection swapper = default(SwapDirection); - uncomment me

        // code here

        // create and use public delegate SwapDirection(array);
        // create and use methods SwapRight(array) and SwapLeft(array)
        // create and use method GetSum(array, start, h) that sum elements with a negative indexes
        // change method in variable swapper in the if/else and than use swapper(matrix)

        // end

        return answer;
    }

    public int Task_3_4(int[,] matrix, bool isUpperTriangle)
    {
        int result = 0;

        // code here
        TriangleExtractor triangleMethod;

        // create and use public delegate TriangleExtractor(matrix);
        // create and use methods ExtractUpperTriangle(array) and ExtractLowerTriangle(array)
        // create and use CalculateSum(TriangleExtractor, matrix)
        if (isUpperTriangle) triangleMethod = ExtractUpperTriangle;
        else triangleMethod = ExtractLowerTriangle;

        // end
        result = CalculateSum(triangleMethod, matrix);
        return result;
    }

    public delegate int ElementFinderDelegate(int[,] matrix);

    static int FindMaxDiagonalElementIndex(int[,] matrix)
    {
        int maxElement = int.MinValue;
        int maxElementIndex = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            if (matrix[i, i] > maxElement)
            {
                maxElement = matrix[i, i];
                maxElementIndex = i;
            }
        }
        return maxElementIndex;
    }
    static int FindMaxInFirstRowIndex(int[,] matrix)
    {
        int maxElement = int.MinValue;
        int maxElementIndex = 0;
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (matrix[0, j] > maxElement)
            {
                maxElement = matrix[0, j];
                maxElementIndex = j;
            }
        }
        return maxElementIndex;
    }
    static int[,] ExchangeColumns(int[,] matrix, ElementFinderDelegate firstDelegate, ElementFinderDelegate secondDelegate)
    {
        int firstIndex = firstDelegate(matrix);
        int secondIndex = secondDelegate(matrix);
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            int tempValue = matrix[i, secondIndex];
            matrix[i, secondIndex] = matrix[i, firstIndex];
            matrix[i, firstIndex] = tempValue;
        }
        return matrix;
    }

    public void Task_3_5(out int func1, out int func2)
    {
        func1 = 0;
        func2 = 0;

        // code here

        // use public delegate YFunction(x, a, b, h) from Task_3_1
        // create and use method CountSignFlips(YFunction, a, b, h);
        // create and use 2 methods for both functions

        // end
    }

    public void Task_3_6(int[,] matrix)
    {
        // code here
        FindIndex diagonalIndexDelegate = GetMaxDiagonalElementIndex;
        FindIndex firstRowIndexDelegate = GetMaxInFirstRowIndex;
        matrix = SwapColumns(matrix, diagonalIndexDelegate, firstRowIndexDelegate);

        // create and use public delegate FindIndex(matrix);
        // use method GetMaxDiagonalElementIndex(matrix) like in Task_2_3;
        // create and use method GetMaxInFirstRowIndex(matrix);
        // create and use method SwapColumns(matrix, GetMaxDiagonalElementIndex, GetMaxInFirstRowIndex);

        // end
    }

    public delegate int FindIndex(int[,] matrix);

    static int GetMaxDiagonalElementIndex(int[,] matrix)
    {
        int maxElement = int.MinValue;
        int maxIndex = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            if (matrix[i, i] > maxElement)
            {
                maxElement = matrix[i, i];
                maxIndex = i;
            }
        }
        return maxIndex;
    }

    static int GetMaxInFirstRowIndex(int[,] matrix)
    {
        int maxElement = int.MinValue;
        int maxIndex = 0;
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (matrix[0, j] > maxElement)
            {
                maxElement = matrix[0, j];
                maxIndex = j;
            }
        }
        return maxIndex;
    }

    static int[,] SwapColumns(int[,] matrix, FindIndex firstDelegate, FindIndex secondDelegate)
    {
        int firstIndex = firstDelegate(matrix);
        int secondIndex = secondDelegate(matrix);
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            int tempValue = matrix[i, secondIndex];
            matrix[i, secondIndex] = matrix[i, firstIndex];
            matrix[i, firstIndex] = tempValue;
        }
        return matrix;
    }

    public void Task_3_7(ref int[,] B, int[,] C)
    {
        // code here


    }

    public void Task_3_10(ref int[,] matrix)
    {

        int highestValue = int.MinValue;
        int highestValueColumnIndex = 0;
        int lowestValue = int.MaxValue;
        int lowestValueColumnIndex = 0;

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (row >= col)
                {
                    if (matrix[row, col] > highestValue)
                    {
                        highestValue = matrix[row, col];
                        highestValueColumnIndex = col;
                    }
                }
                else
                {
                    if (matrix[row, col] < lowestValue)
                    {
                        lowestValue = matrix[row, col];
                        lowestValueColumnIndex = col;
                    }
                }
            }
        }

        ColumnRemoverDelegate remover = RemoveColumns;

        matrix = remover(matrix, highestValueColumnIndex, lowestValueColumnIndex);

    }
    public delegate int[,] ColumnRemoverDelegate(int[,] matrix, int index1, int index2);


    public static int[,] RemoveColumns(int[,] matrix, int index1, int index2)
    {
        int rows = matrix.GetLength(0); 
        int cols = matrix.GetLength(1); 
        int newColsCount = cols; 

        if (index1 != index2)
        {
            newColsCount -= 2;
        }
        else
        {
            newColsCount -= 1;
        }

        int[,] result = new int[rows, newColsCount];

        int newColIndex = 0;

        for (int col = 0; col < cols; col++)
        {
            if (col != index1 && col != index2)
            {
                for (int row = 0; row < rows; row++)
                {
                    result[row, newColIndex] = matrix[row, col];
                }
                newColIndex++;
            }
        }

        return result;
    }

    public static void PrintMatrix(int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                Console.Write(matrix[row, col] + " ");
            }
            Console.WriteLine();
        }
    }

    public void Task_3_13(ref int[,] matrix)
    {
    // code here

    // use public delegate FindElementDelegate(matrix) from Task_3_6
    // create and use method RemoveRows(matrix, findMax, findMin)

    // end
    }

    public void Task_3_22(int[,] matrix, out int[] rows, out int[] cols)
    {
        rows = null;
        cols = null;

        NegativeCountDelegate countNegative = CountNegativesInRow;
        NegativeCountDelegate findMaxNegative = FindMaxNegativeInColumn;

        LocateNegatives(matrix, countNegative, findMaxNegative, out rows, out cols);
    }

    public delegate int NegativeCountDelegate(int[,] matrix, int index);

    static int FindMaxNegativeInColumn(int[,] matrix, int columnIndex)
    {
        int maxNegative = Int32.MinValue;
        int rowCount = matrix.GetLength(0);

        for (int i = 0; i < rowCount; i++)
        {
            if (matrix[i, columnIndex] < 0 && matrix[i, columnIndex] > maxNegative)
            {
                maxNegative = matrix[i, columnIndex];
            }
        }
        return maxNegative;
    }

    static void LocateNegatives(int[,] matrix, NegativeCountDelegate countFunc, NegativeCountDelegate maxFunc, out int[] rows, out int[] cols)
    {
        int rowCount = matrix.GetLength(0);
        int columnCount = matrix.GetLength(1);

        rows = new int[rowCount];
        cols = new int[columnCount];

        for (int i = 0; i < rowCount; i++)
        {
            rows[i] = countFunc(matrix, i);
        }

        for (int j = 0; j < columnCount; j++)
        {
            cols[j] = maxFunc(matrix, j);
        }
    }

    public void Task_3_27(int[,] A, int[,] B)
    {
        // code here

    

        // end
    }
   
    public void Task_3_28a(int[] first, int[] second, ref int answerFirst, ref int answerSecond)
    {
        // code here

        SequenceCheck isIncreasing = CheckIncreasingSequence;
        SequenceCheck isDecreasing = CheckDecreasingSequence;

        answerFirst = EvaluateSequence(first, isIncreasing, isDecreasing);
        answerSecond = EvaluateSequence(second, isIncreasing, isDecreasing);
    }

    public delegate bool SequenceCheck(int[] array, int start, int end);

    static bool CheckIncreasingSequence(int[] array, int start, int end)
    {
        for (int i = start; i < end; i++)
        {
            if (array[i + 1] < array[i])
            {
                return false;
            }
        }
        return true;
    }

    static bool CheckDecreasingSequence(int[] array, int start, int end)
    {
        for (int i = start; i < end; i++)
        {
            if (array[i + 1] > array[i])
            {
                return false;
            }
        }
        return true;
    }

    static int EvaluateSequence(int[] array, SequenceCheck increasing, SequenceCheck decreasing)
    {
        bool isIncreasing = increasing(array, 0, array.Length - 1);
        bool isDecreasing = decreasing(array, 0, array.Length - 1);

        if (isIncreasing) return 1;
        else if (isDecreasing) return -1;
        else return 0;
    }

    public void Task_3_28c(int[] first, int[] second, ref int[] answerFirstIncrease, ref int[] answerFirstDecrease, ref int[] answerSecondIncrease, ref int[] answerSecondDecrease)
    {
        // code here

        IsSequence IncreasingDelegate = FindIncreasingSequence;
        IsSequence DecreasingDelegate = FindDecreasingSequence;

        answerFirstIncrease = FindLongestSequence(first, IncreasingDelegate);
        answerFirstDecrease = FindLongestSequence(first, DecreasingDelegate);
        answerSecondIncrease = FindLongestSequence(second, IncreasingDelegate);
        answerSecondDecrease = FindLongestSequence(second, DecreasingDelegate);
        // create public delegate IsSequence(array, left, right);
        // use method FindIncreasingSequence(array, A, B); from Task_3_28a
        // use method FindDecreasingSequence(array, A, B); from Task_3_28a
        // create and use method FindLongestSequence(array, sequence);

        // end
    }
    public delegate bool IsSequence(int[] array, int left, int right);
    static bool FindIncreasingSequence(int[] array, int A, int B)
    {
        for (int i = A; i <= B - 1; i++)
        {
            if (array[i + 1] < array[i])
            {
                return false;
            }
        }
        return true;
    }

    static bool FindDecreasingSequence(int[] array, int A, int B)
    {
        for (int i = A; i <= B - 1; i++)
        {
            if (array[i + 1] > array[i])
            {
                return false;
            }
        }
        return true;
    }
    static int[] FindLongestSequence(int[] array, IsSequence s)
    {
        int[] newar = new int[2];
        int dlina = -1000;
        for (int i = 0; i < array.Length - 1; i++)
        {
            for (int j = i + 1; j <= array.Length - 1; j++)
            {
                if (s(array, i, j) == true)
                {
                    if (j - i > dlina)
                    {
                        dlina = j - i;
                        newar[0] = i;
                        newar[1] = j;
                    }
                }

            }
        }
        return newar;
    }
    #endregion
    #region bonus part
    public double[,] Task_4(double[,] matrix, int index)
    {
        // MatrixConverter[] mc = new MatrixConverter[4]; - uncomment me

        // code here

        // create public delegate MatrixConverter(matrix);
        // create and use method ToUpperTriangular(matrix);
        // create and use method ToLowerTriangular(matrix);
        // create and use method ToLeftDiagonal(matrix); - start from the left top angle
        // create and use method ToRightDiagonal(matrix); - start from the right bottom angle

        // end

        return matrix;
    }
    #endregion
}
