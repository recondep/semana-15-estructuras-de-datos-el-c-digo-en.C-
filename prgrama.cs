using System;
using System.Drawing;
using System.Windows.Forms;

public class RedSocialForm : Form
{
    public RedSocialForm()
    {
        this.Text = "Gráfico de Nodos y Conexiones - Red Social";
        this.Size = new Size(400, 400);
        this.Paint += new PaintEventHandler(DibujaGrafo);
    }

    private void DibujaGrafo(object sender, PaintEventArgs e)
    {
        Graphics g = e.Graphics;

        // Configuración de los nodos
        Color nodoColor = Color.FromArgb(76, 175, 80); // Color verde
        Pen enlacePen = new Pen(Color.FromArgb(153, 153, 153), 2);

        // Coordenadas de los nodos
        Point A = new Point(100, 100); // Usuario 1
        Point B = new Point(200, 100); // Usuario 2
        Point C = new Point(150, 200); // Usuario 3
        Point D = new Point(300, 200); // Usuario 4

        // Dibuja los enlaces
        g.DrawLine(enlacePen, A, B); // A-B
        g.DrawLine(enlacePen, A, C); // A-C
        g.DrawLine(enlacePen, B, C); // B-C
        g.DrawLine(enlacePen, B, D); // B-D
        g.DrawLine(enlacePen, C, D); // C-D

        // Dibuja los nodos
        g.FillEllipse(new SolidBrush(nodoColor), A.X - 20, A.Y - 20, 40, 40); // Nodo A
        g.FillEllipse(new SolidBrush(nodoColor), B.X - 20, B.Y - 20, 40, 40); // Nodo B
        g.FillEllipse(new SolidBrush(nodoColor), C.X - 20, C.Y - 20, 40, 40); // Nodo C
        g.FillEllipse(new SolidBrush(nodoColor), D.X - 20, D.Y - 20, 40, 40); // Nodo D

        // Dibuja etiquetas
        g.DrawString("A", new Font("Arial", 12), Brushes.White, A);
        g.DrawString("B", new Font("Arial", 12), Brushes.White, B);
        g.DrawString("C", new Font("Arial", 12), Brushes.White, C);
        g.DrawString("D", new Font("Arial", 12), Brushes.White, D);

        // Mostrar la matriz de adyacencia
        MostrarMatrizAdyacencia(g);
    }

    private void MostrarMatrizAdyacencia(Graphics g)
    {
        // Matriz de adyacencia
        int[,] matriz = new int[,]
        {
            { 0, 1, 1, 0 }, // A
            { 1, 0, 1, 1 }, // B
            { 1, 1, 0, 1 }, // C
            { 0, 1, 1, 0 }  // D
        };

        // Dibuja la matriz en la parte inferior de la ventana
        Font font = new Font("Arial", 10);
        int cellSize = 30;
        int startX = 20;
        int startY = 250;

        // Dibuja encabezados de la matriz
        g.DrawString("   ", font, Brushes.Black, startX, startY);
        g.DrawString("A", font, Brushes.Black, startX + cellSize, startY);
        g.DrawString("B", font, Brushes.Black, startX + 2 * cellSize, startY);
        g.DrawString("C", font, Brushes.Black, startX + 3 * cellSize, startY);
        g.DrawString("D", font, Brushes.Black, startX + 4 * cellSize, startY);

        for (int i = 0; i < 4; i++)
        {
            g.DrawString(((char)('A' + i)).ToString(), font, Brushes.Black, startX, startY + (i + 1) * cellSize);
            for (int j = 0; j < 4; j++)
            {
                g.DrawString(matriz[i, j].ToString(), font, Brushes.Black, startX + (j + 1) * cellSize, startY + (i + 1) * cellSize);
            }
        }
    }

    [STAThread]
    public static void Main()
    {
        Application.EnableVisualStyles();
        Application.Run(new RedSocialForm());
    }
}
