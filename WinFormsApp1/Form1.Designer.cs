namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pictureBox1 = new PictureBox();
            button1 = new Button();
            stp = new Button();
            comboBox1 = new ComboBox();
            capture = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(99, 68);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(506, 272);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // button1
            // 
            button1.Location = new Point(449, 381);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 1;
            button1.Text = "start";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // stp
            // 
            stp.Location = new Point(530, 381);
            stp.Name = "stp";
            stp.Size = new Size(75, 23);
            stp.TabIndex = 1;
            stp.Text = "stp";
            stp.UseVisualStyleBackColor = true;
            stp.Click += stop_Click;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(99, 32);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(506, 23);
            comboBox1.TabIndex = 2;
            // 
            // capture
            // 
            capture.Location = new Point(368, 381);
            capture.Name = "capture";
            capture.Size = new Size(75, 23);
            capture.TabIndex = 1;
            capture.Text = "capture";
            capture.UseVisualStyleBackColor = true;
            capture.Click += capture_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(comboBox1);
            Controls.Add(stp);
            Controls.Add(capture);
            Controls.Add(button1);
            Controls.Add(pictureBox1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private Button button1;
        private Button stp;
        private ComboBox comboBox1;
        private Button capture;
    }
}
