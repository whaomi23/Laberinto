using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace LaberintoBFS
{
    public partial class Form1 : Form
    {
        // Definir el tamaño del laberinto
        private const int filas = 11;
        private const int columnas = 11;
        private int[,] laberinto = new int[filas, columnas]
        {
            {0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0},
            {0, 0, 1, 0, 1, 0, 1, 1, 0, 1, 0},
            {0, 1, 1, 0, 1, 0, 0, 1, 0, 1, 0},
            {0, 0, 0, 0, 1, 1, 0, 0, 0, 1, 0},
            {1, 1, 1, 0, 0, 1, 0, 1, 1, 1, 0},
            {0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0},
            {1, 1, 1, 1, 0, 1, 0, 1, 1, 0, 0},
            {0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0},
            {0, 1, 1, 1, 0, 1, 1, 0, 1, 1, 0},
            {0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0},
            {0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0}
        };

        private Point inicio = new Point(0, 0); // Posición de inicio (S)
        private Point salida = new Point(10, 10); // Posición de salida (E)
        private List<Point> camino;

        public Form1()
        {
            InitializeComponent();
            this.Text = "Laberinto BFS";
            this.ClientSize = new Size(600, 600);
            Button btnBuscar = new Button()
            {
                Text = "Buscar Camino",
                Location = new Point(250, 550),
                Width = 100
            };
            btnBuscar.Click += BtnBuscar_Click;
            this.Controls.Add(btnBuscar);
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            // Ejecutar BFS y obtener el camino
            camino = BFS(laberinto, inicio, salida);
            Invalidate(); // Redibujar el laberinto y el camino
        }

        private List<Point> BFS(int[,] laberinto, Point inicio, Point salida)
        {
            // Definir las direcciones y sus respectivas descripciones
            var movimientos = new List<Tuple<int, int, string>>()
    {
        new Tuple<int, int, string>(-1, 0, "Arriba"),   // Mover hacia arriba
        new Tuple<int, int, string>(1, 0, "Abajo"),     // Mover hacia abajo
        new Tuple<int, int, string>(0, -1, "Izquierda"), // Mover hacia la izquierda
        new Tuple<int, int, string>(0, 1, "Derecha")     // Mover hacia la derecha
    };

            Queue<Tuple<Point, List<Point>, List<string>>> cola = new Queue<Tuple<Point, List<Point>, List<string>>>();
            HashSet<Point> visitados = new HashSet<Point>();

            // Empezar desde el inicio
            cola.Enqueue(new Tuple<Point, List<Point>, List<string>>(inicio, new List<Point> { inicio }, new List<string> { "Inicio" }));
            visitados.Add(inicio);

            while (cola.Count > 0)
            {
                var current = cola.Dequeue();
                Point posicionActual = current.Item1;
                List<Point> caminoActual = current.Item2;
                List<string> direcciones = current.Item3;

                // Si encontramos la salida, imprimimos el camino y las direcciones
                if (posicionActual.Equals(salida))
                {
                    Console.WriteLine("Camino encontrado:");
                    for (int i = 0; i < caminoActual.Count; i++)
                    {
                        // Mostrar cada paso y su dirección
                        Console.WriteLine($"Paso {i + 1}: {caminoActual[i]} - {direcciones[i]}");
                    }
                    return caminoActual;
                }

                // Explorar las direcciones posibles
                for (int i = 0; i < movimientos.Count; i++)
                {
                    int newX = posicionActual.X + movimientos[i].Item1;
                    int newY = posicionActual.Y + movimientos[i].Item2;

                    if (newX >= 0 && newX < filas && newY >= 0 && newY < columnas &&
                        laberinto[newX, newY] == 0 && !visitados.Contains(new Point(newX, newY)))
                    {
                        visitados.Add(new Point(newX, newY));
                        var newCamino = new List<Point>(caminoActual) { new Point(newX, newY) };
                        var newDirecciones = new List<string>(direcciones) { movimientos[i].Item3 };
                        cola.Enqueue(new Tuple<Point, List<Point>, List<string>>(new Point(newX, newY), newCamino, newDirecciones)); // Agregar la nueva dirección
                    }
                }
            }

            // Si no se encuentra un camino
            Console.WriteLine("No se encontró un camino.");
            return null;
        }


        // Método para dibujar el laberinto y el camino
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            int cellSize = 40; // Tamaño de cada celda

            // Dibujar el laberinto
            for (int i = 0; i < filas; i++)
            {
                for (int j = 0; j < columnas; j++)
                {
                    if (laberinto[i, j] == 1) // Pared
                    {
                        g.FillRectangle(Brushes.Black, j * cellSize, i * cellSize, cellSize, cellSize);
                    }
                    else
                    {
                        g.FillRectangle(Brushes.White, j * cellSize, i * cellSize, cellSize, cellSize);
                    }
                    g.DrawRectangle(Pens.Gray, j * cellSize, i * cellSize, cellSize, cellSize);
                }
            }

            // Dibujar el camino
            if (camino != null)
            {
                foreach (var paso in camino)
                {
                    g.FillRectangle(Brushes.Green, paso.Y * cellSize, paso.X * cellSize, cellSize, cellSize);
                }
            }

            // Dibujar el inicio y la salida
            g.FillRectangle(Brushes.Red, inicio.Y * cellSize, inicio.X * cellSize, cellSize, cellSize);
            g.FillRectangle(Brushes.Blue, salida.Y * cellSize, salida.X * cellSize, cellSize, cellSize);
        }
    }
}