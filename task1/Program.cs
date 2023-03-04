// Задайте двумерный массив размером m×n, заполненный случайными вещественными числами.

// m = 3, n = 4
// 0,5 7 -2 -0,2
// 1 -3,3 8 -9,9
// 8 7,8 -7,1 9

int InputInt(string message) // ввод целого числа с клавиатуры
{
    Console.Write($"{message} -> ");
    int value;
    if (int.TryParse(Console.ReadLine(), out value)) // проверка правильности ввода числа
    {
        return value;
    }
    Console.WriteLine("Ошибка: введено не целое число");
    Environment.Exit(1); // exit code программы при ошибке
    return 0; // функция возвращает 0, потому что надо что-то возвращать int
}

double[,] GenerateMatrix((int cols, int rows, int min, int max) param) //метод генерирует матрицу
{
    double[,] matrix = new double[param.cols,param.rows];
    Random rnd = new Random();
    for (int j = 0; j < param.rows; j++)
    {
        for (int i = 0; i < param.cols; i++)
        {
            matrix[i, j] = Math.Round(rnd.Next(param.min, param.max) * rnd.NextDouble(), 2);
        }        
    }
    return matrix;
}

void PrintMatrix(double[,] matrix) // вывод матрицы на экран
{
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            Console.Write($"{matrix[i, j], 8}");
        }
        Console.WriteLine();        
    }
}

(int row, int col, int min, int max) SetMatrixParams() // устанавливаем параметры матрицы
{
    (int row, int col, int min, int max) result = (
        InputInt("Введите количество строк в матрице"),
        InputInt("Введите количество столбцов в матрице"),
        InputInt("Введите минимально допустимое значение матрицы"),    
        InputInt("Введите максимально допустимое значение матрицы")
    );
    return result;
}

(int rows, int columns, int minValue, int maxValue) matrixParams = SetMatrixParams();
double[,] matrix = new double[matrixParams.columns,matrixParams.rows];
matrix = GenerateMatrix(matrixParams);
PrintMatrix(matrix);