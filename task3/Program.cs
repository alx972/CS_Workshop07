// Задайте двумерный массив из целых чисел. Найдите среднее арифметическое элементов в каждом столбце.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// Среднее арифметическое каждого столбца: 4,6; 5,6; 3,6; 3.

var INPUT = (ROWCOUNT:"Введите количество строк", 
            COLCOUNT:"Введите количество столбцов", 
            MINVALUE:"Введите минимальное значение массива", 
            MAXVALUE:"Введите максимальное значение массива");
var ERROR = (NOTINTVALUE:"Ошибка: введено не целое число", 
            MATRIXERRORPARAMS:"Ошибка: введены недопустимые параметры матрицы");

int InputInt(string message) // ввод целого числа с клавиатуры
{
    Console.Write($"{message} -> ");
    int value;
    if (int.TryParse(Console.ReadLine(), out value)) // проверка правильности ввода числа
    {
        return value;
    }
    Console.WriteLine(ERROR.NOTINTVALUE);
    Environment.Exit(1); // exit code программы при ошибке
    return 0; // функция возвращает 0, потому что надо что-то возвращать int
}

bool ValidateMatrixParams(int row, int col) // проверка на правильность размера матрицы
{
    if (row > 0 && col > 0)
    {
        return true;
    }
    Console.WriteLine(ERROR.MATRIXERRORPARAMS);
    Environment.Exit(1); // exit code программы при ошибке
    return false;
}

int[,] GenerateMatrix(int rows, int cols, int min, int max) //метод генерирует матрицу
{
    int[,] matrix = new int[rows,cols];
    Random rnd = new Random();
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < cols; j++)
        {
            matrix[i, j] = rnd.Next(min, max);
        }        
    }
    return matrix;
}

int[] GetColumnFromMatrix(int[,] matrix, int colNumber) // получение столбца из матрицы
{
    int[] result = new int[matrix.GetLength(0)];
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        result[i] = matrix[i, colNumber];
    }
    return result;
}

double AverageValue(int[] array) // вычисление среднего значения массива
{
    double result;
    int sum = 0;
    for (int i = 0; i < array.Length; i++)
    {
        sum += array[i];
    }
    result = (double) sum / array.Length;
    return result;
}

void PrintMatrix(int[,] matrix) // вывод матрицы на экран
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write($"{matrix[i, j], 8}");
        }
        Console.WriteLine();        
    }
}

void PrintMatrixColsAverageValues(int[,] matrix) // вывод на экран средних значений столбцов матрицы
{
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        System.Console.Write($"{AverageValue(GetColumnFromMatrix(matrix, j)), 8}");
    }
    System.Console.WriteLine();
}

int rowsCount = InputInt(INPUT.ROWCOUNT);
int columnsCount = InputInt(INPUT.COLCOUNT);
int minValue = InputInt(INPUT.MINVALUE);
int maxValue = InputInt(INPUT.MAXVALUE);

if (ValidateMatrixParams(rowsCount, columnsCount)) 
{
    int[,] matrix = new int[rowsCount, columnsCount];
    matrix = GenerateMatrix(rowsCount, columnsCount, minValue, maxValue);
    PrintMatrix(matrix);
    System.Console.WriteLine();
    PrintMatrixColsAverageValues(matrix);
}
