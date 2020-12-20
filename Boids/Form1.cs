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
        public static List<Predator> AllPredators;
        public static List<Obstacle> AllObstacles;
        public static int BirdWidth = 10;
        Random rnd = new Random();
        private bool toRun = false;
        private bool toDraw = true;

        public Form1()
        {
            InitializeComponent();
            AllBirds = new List<Bird>();
            AllPredators = new List<Predator>();
            AllObstacles = new List<Obstacle>();
            for (int i = 0; i < 100; i++)
            {
                AllBirds.Add(new Bird(rnd, this));
            }
            for (int i = 0; i < 5; i++)
            {
                AllPredators.Add(new Predator(rnd, this));
            }
            for (int i = 0; i < 5; i++)
            {
                AllObstacles.Add(new Obstacle(rnd, this));
            }
            this.DoubleBuffered = true;
            pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.Controls.Add(pictureBox1);
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
            pictureBox1.Invalidate();
            
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
            AllPredators.Add(new Predator(rnd, this));
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

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            toDraw = !toDraw;
            if (!this.toRun | (this.trackBar1.Value == 1 & toDraw))
                return;

            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White);
            }
            pictureBox1.Image = bmp;
            using (Graphics formGraphics = Graphics.FromImage(pictureBox1.Image))
            {
                Parallel.ForEach(AllBirds, bird =>
                {
                    bird.CalculateNewPosition(pictureBox1.Width, pictureBox1.Height);
                });
                foreach (var item in AllBirds)
                {
                    formGraphics.DrawEllipse(Pens.Black, item.PositionX - BirdWidth / 2, item.PositionY - BirdWidth / 2, BirdWidth, BirdWidth);
                    formGraphics.DrawLine(Pens.Black, item.PositionX, item.PositionY,
                        Convert.ToInt32(item.Heading.X / item.Heading.Length * 10 + item.PositionX),
                        Convert.ToInt32(item.Heading.Y / item.Heading.Length * 10 + item.PositionY));
                }
                Parallel.ForEach(AllPredators, predator =>
                {
                    predator.CalculateNewPosition(pictureBox1.Width, pictureBox1.Height);
                });
                foreach (var item in AllPredators)
                {
                    formGraphics.DrawEllipse(Pens.Red, item.PositionX - BirdWidth / 2, item.PositionY - BirdWidth / 2, BirdWidth, BirdWidth);
                    formGraphics.DrawLine(Pens.Red, item.PositionX, item.PositionY,
                        Convert.ToInt32(item.Heading.X / item.Heading.Length * 10 + item.PositionX),
                        Convert.ToInt32(item.Heading.Y / item.Heading.Length * 10 + item.PositionY));
                }

                foreach (var item in AllObstacles)
                {
                    formGraphics.DrawEllipse(Pens.Blue, item.x - item.r / 2, item.y - item.r / 2, item.r, item.r);
                }
            }
            pictureBox1.Invalidate();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (this.toRun)
            {
                btnStop.Text = "Start";
            }
            else
            {
                btnStop.Text = "Stop";
            }
            this.toRun = !this.toRun;
            this.Invalidate();

        }

        private void trackBar1_Scroll_1(object sender, EventArgs e)
        {
            double newSpeed = trackBar1.Value;
            if (newSpeed == 1)
                newSpeed = 2;
            Bird.Speed = newSpeed * 0.5;
            Predator.predatorSpeed = newSpeed * 0.5;
            lblSpeed.Text = "Speed: " + trackBar1.Value * 0.5;
        }
    }
}
