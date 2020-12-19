using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Boids
{
    public partial class Form1 : Form
    {
        public static List<Bird> AllBirds;
        public static List<Bird> AllPredators;
        public static List<Obstacle> AllObstacles;
        public static int BirdWidth = 10;
        Random rnd = new Random();

        public Form1()
        {
            InitializeComponent();
            AllBirds = new List<Bird>();
            AllPredators = new List<Bird>();
            AllObstacles = new List<Obstacle>();
            for (int i = 0; i < 100; i++)
            {
                AllBirds.Add(new Bird(rnd, this));
            }
            for (int i = 0; i < 5; i++)
            {
                AllPredators.Add(new Bird(rnd, this));
            }
            for (int i = 0; i < 5; i++)
            {
                AllObstacles.Add(new Obstacle(rnd, this));
            }
        }

        public static List<Bird> GetAllBirds()
        {
            List<Bird> allBirds = new List<Bird>();
            foreach (var bird in AllBirds)
            {
                allBirds.Add(bird);
            }
            return allBirds;
        }

        protected override void OnPaint(PaintEventArgs e)
        {

            System.Drawing.Pen pen = new System.Drawing.Pen(Color.Black, 1);
            System.Drawing.Graphics formGraphics;
            formGraphics = this.CreateGraphics();

            foreach (var item in AllBirds)
            {
                item.CalculateNewPosition(this);
                

                formGraphics.DrawEllipse(pen, item.PositionX - BirdWidth / 2, item.PositionY - BirdWidth / 2, BirdWidth, BirdWidth);
                formGraphics.DrawLine(pen, item.PositionX, item.PositionY,
                    Convert.ToInt32(item.Heading.X / item.Heading.Length * 10 + item.PositionX),
                    Convert.ToInt32(item.Heading.Y / item.Heading.Length * 10 + item.PositionY));
            }

            pen.Color = Color.Red;
            foreach (var item in AllPredators)
            {
                item.CalculateNewPredatorPosition(this);
                item.PositionX = item.PositionX <= 0 ? this.Width : (item.PositionX >= this.Width ? 0 : item.PositionX);
                item.PositionY = item.PositionY <= 0
                    ? this.Height
                    : (item.PositionY >= this.Height ? 0 : item.PositionY);

                formGraphics.DrawEllipse(pen, item.PositionX - BirdWidth / 2, item.PositionY - BirdWidth / 2, BirdWidth, BirdWidth);
                formGraphics.DrawLine(pen, item.PositionX, item.PositionY,
                    Convert.ToInt32(item.Heading.X / item.Heading.Length * 10 + item.PositionX),
                    Convert.ToInt32(item.Heading.Y / item.Heading.Length * 10 + item.PositionY));
            }

            pen.Color = Color.Blue;
            foreach (var item in AllObstacles)
            {
                formGraphics.DrawEllipse(pen, item.x - item.r / 2, item.y - item.r / 2, item.r, item.r);
            }
            pen.Dispose();
            formGraphics.Dispose();
            this.Refresh();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            Bird.SeparationWeight = this.trackBarSeparation.Value;
            this.labelSeparation.Text = "Separation: " + trackBarSeparation.Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AllObstacles.Add(new Obstacle(rnd, this));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AllObstacles.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AllPredators.Add(new Bird(rnd, this));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AllPredators.Clear();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void trackBarAligment_Scroll(object sender, EventArgs e)
        {
            Bird.AlignmentWeight = this.trackBarAligment.Value;
            this.labelAligment.Text = "Aligment: " + trackBarAligment.Value.ToString();
        }

        private void trackBarCohesion_Scroll(object sender, EventArgs e)
        {
            Bird.CohesionWeight = this.trackBarCohesion.Value;
            this.labelCohesion.Text = "Cohesion: " + trackBarCohesion.Value.ToString();
        }
    }
}
