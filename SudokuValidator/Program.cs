using System;

class SudokuValidator
{
    public static bool IsValidSudoku(int[][] sudoku)
    {
        int N = sudoku.Length;
        int rootN = (int)Math.Sqrt(N);

        // Check rows and columns
        for (int i = 0; i < N; i++)
        {
            if (!IsValidRowOrColumn(sudoku, i, N) || !IsValidRowOrColumn(GetColumn(sudoku, i), 0, N))

                return false;
        }

        // Check little squares
        for (int i = 0; i < N; i += rootN)
        {
            for (int j = 0; j < N; j += rootN)
            {
                if (!IsValidLittleSquare(sudoku, i, j, rootN))
                    return false;
            }
        }

        return true;
    }

    private static bool IsValidRowOrColumn(int[][] sudoku, int index, int N)
    {
        bool[] visited = new bool[N + 1];

        foreach (int num in sudoku[index])
        {
            if (num < 1 || num > N || visited[num])
                return false;

            visited[num] = true;
        }

        return true;
    }

    private static bool IsValidLittleSquare(int[][] sudoku, int row, int col, int rootN)
    {
        bool[] visited = new bool[sudoku.Length + 1];

        for (int i = row; i < row + rootN; i++)
        {
            for (int j = col; j < col + rootN; j++)
            {
                int num = sudoku[i][j];
                if (num < 1 || num > sudoku.Length || visited[num])
                    return false;

                visited[num] = true;
            }
        }

        return true;
    }

    private static int[][] GetColumn(int[][] sudoku, int index)
    {
        int[][] column = new int[sudoku.Length][];
        for (int i = 0; i < sudoku.Length; i++)
        {
            column[i] = new int[] { sudoku[i][index] };
        }
        return column;
    }
}

class Program
{
    static void Main(string[] args)
    {
        int[][] goodSudoku1 = {
            new int[] {7,8,4,1,5,9,3,2,6},
            new int[] {5,3,9,6,7,2,8,4,1},
            new int[] {6,1,2,4,3,8,7,5,9},
            new int[] {9,2,8,7,1,5,4,6,3},
            new int[] {3,5,7,8,4,6,1,9,2},
            new int[] {4,6,1,9,2,3,5,8,7},
            new int[] {8,7,6,3,9,4,2,1,5},
            new int[] {2,4,3,5,6,1,9,7,8},
            new int[] {1,9,5,2,8,7,6,3,4}
        };

        int[][] goodSudoku2 = {
                new int[] {1,4, 2,3},
                new int[] {3,2, 4,1},

                new int[] {4,1, 3,2},
                new int[] {2,3, 1,4}
            };

        int[][] badSudoku1 =  {
                new int[] {1,2,3, 4,5,6, 7,8,9},
                new int[] {1,2,3, 4,5,6, 7,8,9},
                new int[] {1,2,3, 4,5,6, 7,8,9},

                new int[] {1,2,3, 4,5,6, 7,8,9},
                new int[] {1,2,3, 4,5,6, 7,8,9},
                new int[] {1,2,3, 4,5,6, 7,8,9},

                new int[] {1,2,3, 4,5,6, 7,8,9},
                new int[] {1,2,3, 4,5,6, 7,8,9},
                new int[] {1,2,3, 4,5,6, 7,8,9}
            };

        bool isValid = SudokuValidator.IsValidSudoku(badSudoku1);
        Console.WriteLine("Is the Sudoku valid? " + isValid);
    }
}
