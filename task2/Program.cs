// Напишите программу, которая на вход принимает позиции элемента в двумерном массиве, 
// и возвращает значение этого элемента или же указание, что такого элемента нет.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 1, 7 -> такого числа в массиве нет

var INPUT = (ROWCOUNT:"Введите количество строк", COLCOUNT:"Введите количество столбцов", 
            MINVALUE:"Введите минимальное значение массива", MAXVALUE:"Введите максимальное значение массива");

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

(int positionRow, int positionCol) InputPosition() // Ввод координат позиции в массиве human readable
{
    int posRow = InputInt("Введите номер строки");
    int posCol = InputInt("Введите номер столбца");
    return (posRow, posCol);
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

void PrintMatrix(int[,] matrix) // вывод матрицы на экран
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write($"{matrix[i, j], 4}");
        }
        Console.WriteLine();        
    }
}

void ShowMatrixPos(int[,] matrix, (int row, int col) pos) // Вывод на экран указанной позиции в массиве
{
    if (pos.row >= 1 && pos.row <= matrix.GetLength(0) && 
        pos.col >= 1 && pos.col <= matrix.GetLength(1))
    {
        Console.WriteLine($"Значение массива в позиции {pos.row}, {pos.col} = {matrix[pos.row - 1, pos.col - 1]}");
    }
    else
    {
        Console.WriteLine("Такого числа в массиве нет");
    }
}

int rowsCount = InputInt(INPUT.ROWCOUNT);
int columnsCount = InputInt(INPUT.COLCOUNT);
int minValue = InputInt(INPUT.MINVALUE);
int maxValue = InputInt(INPUT.MAXVALUE);

int[,] matrix = new int[rowsCount,columnsCount];
matrix = GenerateMatrix(rowsCount, columnsCount, minValue, maxValue);
PrintMatrix(matrix);
ShowMatrixPos(matrix, InputPosition());