using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace GameOfLifeGUI
{
    public partial class MainForm : Form
    {
        private Graphics graphics;

        private readonly Pen pen = new Pen(Color.Black, 1);
        
        private readonly Brush blackBrush = new SolidBrush(Color.Black);

        private readonly Brush bgColorBrush;

        private const int rectSide = 15;

        private readonly Size rectSize = new Size(rectSide, rectSide);

        private const int sideBarBeginsAt = 700;

        private int generation = 0;

        private char[,] Map;

        private const char Alive = 'A';
        private const char Dead = 'D';

        public MainForm()
        {
            InitializeComponent();
            graphics = this.CreateGraphics();
            this.MouseClick += onMouseClick;

            this.Shown += new EventHandler(this.MainForm_Shown);

            Map = new char[sideBarBeginsAt, this.Height];

            bgColorBrush = new SolidBrush(this.BackColor);

            FillVirtualMap();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void onMouseClick(object sender, MouseEventArgs e)
        {
            if (e.X > sideBarBeginsAt) return;

            Point location = new Point();

            location.X = (int)Math.Floor(e.X / 15.0d) * rectSide;
            location.Y = (int)Math.Floor(e.Y / 15.0d) * rectSide;

            int x = location.X;
            int y = location.Y;

            char onMap = Map[x, y];

            if (onMap == Dead) Revive(x, y);

            else { Kill(x, y); }
        }

        private void Kill(int x, int y)
        {
            Map[x, y] = Dead;

            Rectangle rect = new Rectangle(new Point(x, y), rectSize);
            graphics.FillRectangle(bgColorBrush, rect);
            graphics.DrawRectangle(pen, rect);
        }

        private void Revive(int x, int y)
        {
            Map[x, y] = Alive;

            Rectangle rect = new Rectangle(new Point(x, y), rectSize);
            graphics.FillRectangle(blackBrush, rect);
        }

        private void CreateStartingMap()
        {
            for(int x = 0; x < sideBarBeginsAt; x += 15)
            {
                for(int y = 0; y < this.Height; y += 15)
                {
                    Rectangle rect = new Rectangle(new Point(x, y), rectSize);

                    graphics.DrawRectangle(pen, rect);
                }
            }
        }

        private void FillVirtualMap()
        {
            for (int x = 0; x < sideBarBeginsAt; x += rectSide)
            {
                for (int y = 0; y < this.Height; y += rectSide)
                {
                    Map[x, y] = Dead;
                }
            }
        }

        private int GetNumberOfAliveNeighbors(int x, int y)
        {
            int retval = 0;

            int currX = (x - rectSide) >= 0 ? (x - rectSide) : x;
            int currY = (y - rectSide) >= 0 ? (y - rectSide) : y;

            int savedY = currY;

            while (currX <= (x + rectSide) && (x + rectSide) < sideBarBeginsAt)
            {
                while (currY <= (y + rectSide) && (y + rectSide) < this.Height)
                {
                    if (currX == x && currY == y)
                    {
                        currY += rectSide;
                        continue;
                    }

                    if (Map[currX, currY] == Alive) retval++;

                    currY += rectSide;
                }

                currY = savedY;
                currX += rectSide;
            }

            return retval;
        }

        private void PerformStep()
        {
            List<Point> toKill = new List<Point>();
            List<Point> toRevive = new List<Point>();

            for (int x = 0; x < sideBarBeginsAt; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    char current = Map[x, y];

                    Point currentPoint = new Point(x, y);

                    int nAliveNeighbors = GetNumberOfAliveNeighbors(x, y);

                    if (current == Alive)
                    {
                        if (nAliveNeighbors < 2) toKill.Add(currentPoint);
                        else if (nAliveNeighbors > 3) toKill.Add(currentPoint);
                    }
                    else
                    {
                        if (nAliveNeighbors == 3) toRevive.Add(currentPoint);
                    }
                }
            }

            toKill.ForEach(p => Kill(p.X, p.Y));
            toRevive.ForEach(p => Revive(p.X, p.Y));

            generation++;
        }


        private void MainForm_Shown(object sender, EventArgs e)
        {
            CreateStartingMap();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer.Interval = (int)StepIntervalBox.Value;

            timer.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer.Stop();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            PerformStep();

            GenerationLabel.Text = generation.ToString();
        }
    }
}
