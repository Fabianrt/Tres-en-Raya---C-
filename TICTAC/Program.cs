int[,] tablero = new int[3, 3];
int[] movimiento = new int[3];
int jugador = 1;
bool activo = true;

void jugar()
{
    do
    {
        movimiento = validar(jugador);
        if (movimiento[2] == 0)
        {
            Console.WriteLine("Casilla Invalida \n");
        }
        else if (movimiento[2] == 2)
        {
            Console.WriteLine("Casilla Ocupada \n");
        }
        else if (movimiento[2] == 1) {
            Jugada(movimiento[0], movimiento[1], jugador);
            MostrarTablero();
            ComprobarGanador(jugador);
            if (jugador == 1)
            {
                jugador = 2;
            }
            else {
                jugador = 1;
            }
        }
    } while (activo);
}

//Empezar el juego
LimpiarTablero();
Console.WriteLine("TIC-TOE");
Console.WriteLine("-------X-------");
MostrarTablero();
jugar();


int[] validar(int jugador)
{
    int valido = 1;
    int[] coordenadas = { 0, 0, 0 };

    Console.WriteLine("Jugador {0}, su turno: ", jugador);
    Console.Write("Fila: ");
    int fila = Convert.ToInt32(Console.ReadLine());
    Console.Write("Columna: ");
    int columna = Convert.ToInt32(Console.ReadLine());

    // Verificamos que la
    if ((fila < 4 && fila > 0)){
        if ((columna < 4 && columna > 0))
        {
            if (tablero[fila - 1, columna - 1] != 0)
            {
                valido = 2;
            }
            else
            {
                valido = 1;
            }
        }
        else {
            valido = 0;
        }
    }
    else{
        valido = 0;
    }      

    coordenadas[0] = fila;
    coordenadas[1] = columna;
    coordenadas[2] = valido;

    return coordenadas;
}

void Jugada(int fila, int columna, int jugador)
{
    fila = fila - 1;
    columna = columna - 1;
    tablero[fila, columna] = jugador;
}

void ComprobarGanador(int jugador)
{
    //Por filas
    for (int i = 0; i < 3; i++)
    {
        if (tablero[i, 0] == jugador && tablero[i, 1] == jugador && tablero[i, 2] == jugador)
        {
            Console.WriteLine("Ganador Jugador {0}!", jugador);
            activo = false;
        }
    }
    //Por columnas
    for (int i = 0; i < 3; i++)
    {
        if (tablero[0, i] == jugador && tablero[1, i] == jugador && tablero[2, i] == jugador)
        {
            Console.WriteLine("Ganador Jugador {0}!", jugador);
            activo = false;
        }
    }
    //Diagonales
    if (tablero[0, 0] == jugador && tablero[1, 1] == jugador && tablero[2, 2] == jugador)
    {
        Console.WriteLine("Ganador Jugador {0}!", jugador);
        activo = false;
    }
    if (tablero[0, 2] == jugador && tablero[1, 1] == jugador && tablero[2, 0] == jugador)
    {
        Console.WriteLine("Ganador Jugador {0}!", jugador);
        activo = false;
    }
}


void LimpiarTablero()
{
    for (int i = 0; i < 3; i++)
    {
        for (int j = 0; j < 3; j++)
        {
            tablero[i, j] = 0;
        }
    }
}
void MostrarTablero()
{
    Console.WriteLine();
    for (int i = 0; i < 3; i++)
    {
        for (int j = 0; j < 3; j++)
        {
            if (tablero[i, j] == 0)
            {
                Console.Write("* ");
            }
            if (tablero[i, j] == 1)
            {
                Console.Write("X ");
            }
            if (tablero[i, j] == 2)
            {
                Console.Write("O ");
            }

        }
        Console.WriteLine();
    }
}