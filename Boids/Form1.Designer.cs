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
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSeparation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAligment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarCohesion)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // trackBarSeparation
            // 
            this.trackBarSeparation.Location = new System.Drawing.Point(4, 32);
            this.trackBarSeparation.Minimum = 1;
            this.trackBarSeparation.Name = "trackBarSeparation";
            this.trackBarSeparation.Size = new System.Drawing.Size(104, 45);
            this.trackBarSeparation.TabIndex = 0;
            this.trackBarSeparation.Value = 1;
            this.trackBarSeparation.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // trackBarAligment
            // 
            this.trackBarAligment.Location = new System.Drawing.Point(4, 102);
            this.trackBarAligment.Minimum = 1;
            this.trackBarAligment.Name = "trackBarAligment";
            this.trackBarAligment.Size = new System.Drawing.Size(104, 45);
            this.trackBarAligment.TabIndex = 0;
            this.trackBarAligment.Value = 1;
            this.trackBarAligment.Scroll += new System.EventHandler(this.trackBarAligment_Scroll);
            // 
            // trackBarCohesion
            // 
            this.trackBarCohesion.Location = new System.Drawing.Point(4, 172);
            this.trackBarCohesion.Minimum = 1;
            this.trackBarCohesion.Name = "trackBarCohesion";
            this.trackBarCohesion.Size = new System.Drawing.Size(104, 45);
            this.trackBarCohesion.TabIndex = 0;
            this.trackBarCohesion.Value = 1;
            this.trackBarCohesion.Scroll += new System.EventHandler(this.trackBarCohesion_Scroll);
            // 
            // labelSeparation
            // 
            this.labelSeparation.AutoSize = true;
            this.labelSeparation.Location = new System.Drawing.Point(21, 13);
            this.labelSeparation.Name = "labelSeparation";
            this.labelSeparation.Size = new System.Drawing.Size(70, 13);
            this.labelSeparation.TabIndex = 1;
            this.labelSeparation.Text = "Separation: 1";
            // 
            // labelAligment
            // 
            this.labelAligment.AutoSize = true;
            this.labelAligment.Location = new System.Drawing.Point(27, 83);
            this.labelAligment.Name = "labelAligment";
            this.labelAligment.Size = new System.Drawing.Size(59, 13);
            this.labelAligment.TabIndex = 1;
            this.labelAligment.Text = "Aligment: 1";
            // 
            // labelCohesion
            // 
            this.labelCohesion.AutoSize = true;
            this.labelCohesion.Location = new System.Drawing.Point(25, 153);
            this.labelCohesion.Name = "labelCohesion";
            this.labelCohesion.Size = new System.Drawing.Size(63, 13);
            this.labelCohesion.TabIndex = 1;
            this.labelCohesion.Text = "Cohesion: 1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 223);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Add obstacle";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(6, 281);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(116, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Add predator";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(6, 252);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(116, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "Remove obstacles";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(6, 310);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(116, 23);
            this.button4.TabIndex = 2;
            this.button4.Text = "Remove predators";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.trackBarSeparation);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.trackBarAligment);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.trackBarCohesion);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.labelSeparation);
            this.groupBox1.Controls.Add(this.labelCohesion);
            this.groupBox1.Controls.Add(this.labelAligment);
            this.groupBox1.Location = new System.Drawing.Point(728, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(124, 340);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Commands";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 438);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSeparation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAligment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarCohesion)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
    }
}

