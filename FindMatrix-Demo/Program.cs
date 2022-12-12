// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

# region input N
Console.WriteLine("Input N:");
int N = Convert.ToInt32(Console.ReadLine());
# endregion

# region define matrix NxN
int[,] matrixInput = new int[N, N];
Console.WriteLine("Input matrix {0}x{0}:", N);
int index = 0;
do
{
    string strInput = Console.ReadLine();
    if (string.IsNullOrEmpty(strInput)) continue;
    var splitStrInput = strInput.Split(" ");
    int i = 0;
    foreach (string str in splitStrInput)
    {
        bool checkTypeInt = int.TryParse(str, out matrixInput[index, i]);
        if (!checkTypeInt) continue;
        i++;
        if (i >= N) break;
    }
    index++;
} while (index < N);
//printMatrix(matrixInput);
# endregion
//Console.WriteLine(matrixInput);
for (int i = N; i > 1; i--)
{
    Console.WriteLine("sub size {0}", i);
    var rstSubMatrix = subMatrix(matrixInput, N, i);
    if (rstSubMatrix != null)
    {
        Console.WriteLine("Result:");
        printMatrix(rstSubMatrix);
        return;
    }
}
Console.WriteLine("Result: Not Found");

bool checkSumMatrix(int[,] matrix, int size)
{
    int sumFirst, sumLast;
    sumFirst = sumLast = 0;
    for (int i = 0; i < size; i++)
    {
        sumFirst += matrix[i, i];
        sumLast += matrix[size - i - 1, i];
        //Console.WriteLine("First {0}, Last {1}", matrix[i, i], matrix[size - i - 1, i]);
    }
    //Console.WriteLine("Sum First {0}, Sum Last {1}", sumFirst, sumLast);
    return sumFirst == sumLast;
}

int[,]? subMatrix(int[,] matrix, int size, int sizeSubMatrix)
{
    for (int i = 0; i < size - sizeSubMatrix + 1; i++)
    {
        for (int j = 0; j < size - sizeSubMatrix + 1; j++)
        {
            int[,] subMatrix = new int[sizeSubMatrix, sizeSubMatrix];
            for (int z = 0; z < sizeSubMatrix; z++)
            {
                for (int t = 0; t < sizeSubMatrix; t++)
                {
                    subMatrix[z, t] = matrix[i + z, j + t];
                }
            }
            //printMatrix(subMatrix);
            if (checkSumMatrix(subMatrix, sizeSubMatrix))
            {
                return subMatrix;
            }
        }
    }
    return null;
}

void printMatrix(int[,] matrix)
{
    for (int x = 0; x < matrix.GetLength(0); x++)
    {
        for (int y = 0; y < matrix.GetLength(1); y++)
        {
            Console.Write(matrix[x, y] + "\t");
        }
        Console.WriteLine();
    }
}