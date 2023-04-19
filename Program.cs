
using System.Drawing;

void main() 
{
    OchoReinas Board = new OchoReinas();
    Board.ShowAll = true;
    Board.Solve();
   
}

main();

class OchoReinas
{   
    public bool ShowSteps = false;
    public bool ShowAll = false;
    public int solutions = 0;
    public int pasocont = 0;
    public static int Size = 8;
    int[,] Tablero = new int[Size,Size];

    public void printBoard()
    {   

        for (int i = 0; i < Size; i++)
        {
            for (int j = 0; j < Size; j++)
            {
                Console.Write(Tablero[i, j] + " ");
            }
            Console.WriteLine();
        }
        pasocont++;
        Console.WriteLine("Paso: " + pasocont);
        Console.WriteLine();
    }
    public bool esValido(int[,] board, int row, int col)
    {
        for (int i = 0; i < col; i++) // a la izquierda
            if (board[row, i] == 1) return false;

        for (int i = row, j = col; i >= 0 && j >= 0; i--, j--) //diagonal superior izquierda
            if (board[i, j] == 1) return false;

        for (int i = row, j = col; i < Size && j >= 0; i++, j--) // diagonal inferior izquierda
            if (board[i, j] == 1) return false;

        
        if (ShowSteps) printBoard();

        return true; // Si se pudo
    }

    public bool solveDimension(int[,] board, int col, int Size)
    {

        // cuando se encuentra una solucion
        if (col == Size)
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    Console.Write(board[i, j] + " ");
                }
                Console.WriteLine();
            }
            solutions++;
            
            if (!ShowAll) return true; else Console.WriteLine("Solucion: #"+solutions);
        }

        // intentar poner una reina en cada celda de la columna
        for (int i = 0; i < Size; i++)
        {
            if (esValido(board, i, col))
            {
                board[i, col] = 1;
                if (solveDimension(board, col + 1, Size))
                    return true;

                // backtrack
                board[i, col] = 0;
            }
        }

        return false;
    }
    public void Solve() 
    {
        if (!solveDimension(Tablero, 0, Size))
            Console.WriteLine("Se imprimieron todas las soluciones");
    }
}


