namespace TwoCamerasTest
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if ( disposing && ( components != null ) )
            {
                components.Dispose( );
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent( )
        {
            this.components = new System.ComponentModel.Container();
            this.videoSourcePlayer1 = new AForge.Controls.VideoSourcePlayer();
            this.videoSourcePlayer2 = new AForge.Controls.VideoSourcePlayer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.camera1FpsLabel = new System.Windows.Forms.Label();
            this.camera1Combo = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.camera2FpsLabel = new System.Windows.Forms.Label();
            this.camera2Combo = new System.Windows.Forms.ComboBox();
            this.startButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.but_Open = new System.Windows.Forms.Button();
            this.but_Close = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // videoSourcePlayer1
            // 
            this.videoSourcePlayer1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.videoSourcePlayer1.ForeColor = System.Drawing.Color.White;
            this.videoSourcePlayer1.Location = new System.Drawing.Point(10, 47);
            this.videoSourcePlayer1.Name = "videoSourcePlayer1";
            this.videoSourcePlayer1.Size = new System.Drawing.Size(422, 332);
            this.videoSourcePlayer1.TabIndex = 0;
            this.videoSourcePlayer1.VideoSource = null;
            // 
            // videoSourcePlayer2
            // 
            this.videoSourcePlayer2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.videoSourcePlayer2.ForeColor = System.Drawing.Color.White;
            this.videoSourcePlayer2.Location = new System.Drawing.Point(10, 47);
            this.videoSourcePlayer2.Name = "videoSourcePlayer2";
            this.videoSourcePlayer2.Size = new System.Drawing.Size(405, 333);
            this.videoSourcePlayer2.TabIndex = 1;
            this.videoSourcePlayer2.VideoSource = null;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.camera1FpsLabel);
            this.groupBox1.Controls.Add(this.camera1Combo);
            this.groupBox1.Controls.Add(this.videoSourcePlayer1);
            this.groupBox1.Location = new System.Drawing.Point(10, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(438, 403);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Camera 1";
            // 
            // camera1FpsLabel
            // 
            this.camera1FpsLabel.Location = new System.Drawing.Point(365, 382);
            this.camera1FpsLabel.Name = "camera1FpsLabel";
            this.camera1FpsLabel.Size = new System.Drawing.Size(50, 17);
            this.camera1FpsLabel.TabIndex = 4;
            this.camera1FpsLabel.Text = "label1";
            this.camera1FpsLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // camera1Combo
            // 
            this.camera1Combo.FormattingEnabled = true;
            this.camera1Combo.Location = new System.Drawing.Point(10, 20);
            this.camera1Combo.Name = "camera1Combo";
            this.camera1Combo.Size = new System.Drawing.Size(322, 21);
            this.camera1Combo.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.camera2FpsLabel);
            this.groupBox2.Controls.Add(this.camera2Combo);
            this.groupBox2.Controls.Add(this.videoSourcePlayer2);
            this.groupBox2.Location = new System.Drawing.Point(454, 10);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(421, 403);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Camera 2";
            // 
            // camera2FpsLabel
            // 
            this.camera2FpsLabel.Location = new System.Drawing.Point(365, 383);
            this.camera2FpsLabel.Name = "camera2FpsLabel";
            this.camera2FpsLabel.Size = new System.Drawing.Size(50, 17);
            this.camera2FpsLabel.TabIndex = 5;
            this.camera2FpsLabel.Text = "label2";
            this.camera2FpsLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // camera2Combo
            // 
            this.camera2Combo.FormattingEnabled = true;
            this.camera2Combo.Location = new System.Drawing.Point(10, 20);
            this.camera2Combo.Name = "camera2Combo";
            this.camera2Combo.Size = new System.Drawing.Size(322, 21);
            this.camera2Combo.TabIndex = 2;
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(719, 419);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 4;
            this.startButton.Text = "&Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Enabled = false;
            this.stopButton.Location = new System.Drawing.Point(800, 419);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(75, 23);
            this.stopButton.TabIndex = 5;
            this.stopButton.Text = "S&top";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // but_Open
            // 
            this.but_Open.Location = new System.Drawing.Point(1041, 149);
            this.but_Open.Name = "but_Open";
            this.but_Open.Size = new System.Drawing.Size(75, 23);
            this.but_Open.TabIndex = 9;
            this.but_Open.Text = "Open";
            this.but_Open.UseVisualStyleBackColor = true;
            this.but_Open.Click += new System.EventHandler(this.but_Open_Click);
            this.but_Open.KeyDown += new System.Windows.Forms.KeyEventHandler(this.open_KeyDown);
            this.but_Open.KeyUp += new System.Windows.Forms.KeyEventHandler(this.open_KeyUp);
            // 
            // but_Close
            // 
            this.but_Close.Location = new System.Drawing.Point(1041, 178);
            this.but_Close.Name = "but_Close";
            this.but_Close.Size = new System.Drawing.Size(75, 23);
            this.but_Close.TabIndex = 10;
            this.but_Close.Text = "Close";
            this.but_Close.UseVisualStyleBackColor = true;
            this.but_Close.Click += new System.EventHandler(this.but_Close_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(938, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "IP server :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(938, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(938, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Otvet";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(896, 203);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "label4";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1128, 454);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.but_Close);
            this.Controls.Add(this.but_Open);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "MainForm";
            this.Text = "Two Cameras Test";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AForge.Controls.VideoSourcePlayer videoSourcePlayer1;
        private AForge.Controls.VideoSourcePlayer videoSourcePlayer2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox camera1Combo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox camera2Combo;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Label camera1FpsLabel;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label camera2FpsLabel;
        private System.Windows.Forms.Button but_Open;
        private System.Windows.Forms.Button but_Close;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

