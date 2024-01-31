using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using System.Xml.Schema;

namespace GameOfLifeGUI
{
    public partial class MainForm : Form
    {
        private Graphics graphics;

        private readonly string InitialSaveLocation = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

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

            EnableClickEvents();

            this.Shown += new EventHandler(this.MainForm_Shown);
            this.ResizeRedraw = false;

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

            location.X = (int)Math.Floor(e.X / (decimal)rectSide) * rectSide;
            location.Y = (int)Math.Floor(e.Y / (decimal)rectSide) * rectSide;

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
            generation = 0;
            UpdateGenerationLabel();

            for (int x = 0; x < sideBarBeginsAt; x += rectSide)
            {
                for(int y = 0; y < this.Height; y += rectSide)
                {
                    Kill(x, y);
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

        private void EnableClickEvents()
        {
            this.MouseClick += onMouseClick;
        }

        private void DisableClickEvents()
        {
            this.MouseClick -= onMouseClick;
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

            DisableClickEvents();

            SaveStateButton.Enabled = false;
            LoadStateButton.Enabled = false;
            ClearButton.Enabled = false;
            StepIntervalBox.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer.Stop();

            EnableClickEvents();

            SaveStateButton.Enabled = true;
            LoadStateButton.Enabled = true;
            ClearButton.Enabled = true;
            StepIntervalBox.Enabled = true;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            PerformStep();

            UpdateGenerationLabel();
        }

        private void UpdateGenerationLabel()
        {
            GenerationLabel.Text = generation.ToString();
        }

        private void SaveStateToFile(string path)
        {
            string toWrite = "";

            for(int i = 0; i < sideBarBeginsAt; i += rectSide)
            {
                for(int k = 0; k < this.Height; k += rectSide)
                {
                    if (Map[i, k] == Alive) toWrite += (i + " " + k) + Environment.NewLine;
                }
            }

            File.WriteAllText(path, toWrite);
        }

        private void LoadStateFromFile(string path)
        {
            if (Path.GetExtension(path) != ".gol") return;

            List<string> lines = File.ReadAllLines(path).ToList();

            CreateStartingMap();

            foreach (string line in lines)
            {
                string[] split = line.Split(' ');

                int x = int.Parse(split[0]);
                int y = int.Parse(split[1]);

                Revive(x, y);
            }
        }

        private void SaveStateButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();

            dialog.OverwritePrompt = true;
            dialog.DefaultExt = ".gol";
            dialog.SupportMultiDottedExtensions = false;
            dialog.AddExtension = true;

            dialog.InitialDirectory = InitialSaveLocation;

            DialogResult result = dialog.ShowDialog(owner: this);

            if(result == DialogResult.OK)
            {
                SaveStateToFile(dialog.FileName);

                MessageBox.Show("State saved successfully!");
            }

            else if(result != DialogResult.Cancel)
            {
                MessageBox.Show("Error while saving state!");
            }
        }

        private void LoadStateButton_Click(object sender, EventArgs e)
        {
            string path = "";

            OpenFileDialog dialog = new OpenFileDialog();

            dialog.InitialDirectory = InitialSaveLocation;

            DialogResult result = dialog.ShowDialog();

            if(result == DialogResult.OK) path = dialog.FileName;

            else if(result != DialogResult.Cancel)
            {
                MessageBox.Show("Error while loading state!");
                return;
            }

            LoadStateFromFile(path);
        }

        private void MainForm_Validated(object sender, EventArgs e)
        {

        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            CreateStartingMap();
        }
    }
}
