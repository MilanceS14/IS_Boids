namespace Boids
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.trackBarSeparation = new System.Windows.Forms.TrackBar();
            this.trackBarAligment = new System.Windows.Forms.TrackBar();
            this.trackBarCohesion = new System.Windows.Forms.TrackBar();
            this.labelSeparation = new System.Windows.Forms.Label();
            this.labelAligment = new System.Windows.Forms.Label();
            this.labelCohesion = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.btnStop = new System.Windows.Forms.Button();
            this.lblSpeed = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSeparation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAligment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarCohesion)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // trackBarSeparation
            // 
            this.trackBarSeparation.Location = new System.Drawing.Point(5, 39);
            this.trackBarSeparation.Margin = new System.Windows.Forms.Padding(4);
            this.trackBarSeparation.Minimum = 1;
            this.trackBarSeparation.Name = "trackBarSeparation";
            this.trackBarSeparation.Size = new System.Drawing.Size(139, 56);
            this.trackBarSeparation.TabIndex = 0;
            this.trackBarSeparation.Value = 1;
            this.trackBarSeparation.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // trackBarAligment
            // 
            this.trackBarAligment.Location = new System.Drawing.Point(5, 126);
            this.trackBarAligment.Margin = new System.Windows.Forms.Padding(4);
            this.trackBarAligment.Minimum = 1;
            this.trackBarAligment.Name = "trackBarAligment";
            this.trackBarAligment.Size = new System.Drawing.Size(139, 56);
            this.trackBarAligment.TabIndex = 0;
            this.trackBarAligment.Value = 1;
            this.trackBarAligment.Scroll += new System.EventHandler(this.trackBarAligment_Scroll);
            // 
            // trackBarCohesion
            // 
            this.trackBarCohesion.Location = new System.Drawing.Point(5, 212);
            this.trackBarCohesion.Margin = new System.Windows.Forms.Padding(4);
            this.trackBarCohesion.Minimum = 1;
            this.trackBarCohesion.Name = "trackBarCohesion";
            this.trackBarCohesion.Size = new System.Drawing.Size(139, 56);
            this.trackBarCohesion.TabIndex = 0;
            this.trackBarCohesion.Value = 1;
            this.trackBarCohesion.Scroll += new System.EventHandler(this.trackBarCohesion_Scroll);
            // 
            // labelSeparation
            // 
            this.labelSeparation.AutoSize = true;
            this.labelSeparation.Location = new System.Drawing.Point(28, 16);
            this.labelSeparation.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSeparation.Name = "labelSeparation";
            this.labelSeparation.Size = new System.Drawing.Size(93, 17);
            this.labelSeparation.TabIndex = 1;
            this.labelSeparation.Text = "Separation: 1";
            // 
            // labelAligment
            // 
            this.labelAligment.AutoSize = true;
            this.labelAligment.Location = new System.Drawing.Point(36, 102);
            this.labelAligment.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelAligment.Name = "labelAligment";
            this.labelAligment.Size = new System.Drawing.Size(78, 17);
            this.labelAligment.TabIndex = 1;
            this.labelAligment.Text = "Aligment: 1";
            // 
            // labelCohesion
            // 
            this.labelCohesion.AutoSize = true;
            this.labelCohesion.Location = new System.Drawing.Point(33, 188);
            this.labelCohesion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCohesion.Name = "labelCohesion";
            this.labelCohesion.Size = new System.Drawing.Size(83, 17);
            this.labelCohesion.TabIndex = 1;
            this.labelCohesion.Text = "Cohesion: 1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(8, 409);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(155, 28);
            this.button1.TabIndex = 2;
            this.button1.Text = "Add obstacle";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(8, 481);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(155, 28);
            this.button2.TabIndex = 2;
            this.button2.Text = "Add predator";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(8, 445);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(155, 28);
            this.button3.TabIndex = 2;
            this.button3.Text = "Remove obstacles";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(8, 517);
            this.button4.Margin = new System.Windows.Forms.Padding(4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(155, 28);
            this.button4.TabIndex = 2;
            this.button4.Text = "Remove predators";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.trackBar1);
            this.groupBox1.Controls.Add(this.btnStop);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.trackBarSeparation);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.trackBarAligment);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.trackBarCohesion);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.labelSeparation);
            this.groupBox1.Controls.Add(this.lblSpeed);
            this.groupBox1.Controls.Add(this.labelCohesion);
            this.groupBox1.Controls.Add(this.labelAligment);
            this.groupBox1.Location = new System.Drawing.Point(971, 2);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(165, 553);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Commands";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(5, 301);
            this.trackBar1.Maximum = 4;
            this.trackBar1.Minimum = 1;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(139, 56);
            this.trackBar1.TabIndex = 4;
            this.trackBar1.Value = 2;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll_1);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(8, 379);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(155, 23);
            this.btnStop.TabIndex = 3;
            this.btnStop.Text = "Start";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // lblSpeed
            // 
            this.lblSpeed.AutoSize = true;
            this.lblSpeed.Location = new System.Drawing.Point(33, 274);
            this.lblSpeed.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Size = new System.Drawing.Size(65, 17);
            this.lblSpeed.TabIndex = 1;
            this.lblSpeed.Text = "Speed: 1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1136, 614);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1136, 614);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSeparation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAligment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarCohesion)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TrackBar trackBarSeparation;
        private System.Windows.Forms.TrackBar trackBarAligment;
        private System.Windows.Forms.TrackBar trackBarCohesion;
        private System.Windows.Forms.Label labelSeparation;
        private System.Windows.Forms.Label labelAligment;
        private System.Windows.Forms.Label labelCohesion;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label lblSpeed;
    }
}

