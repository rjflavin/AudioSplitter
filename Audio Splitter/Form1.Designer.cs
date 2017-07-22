namespace Audio_Splitter
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
            this.inputFileTextArea = new System.Windows.Forms.TextBox();
            this.outputDirectoryTextArea = new System.Windows.Forms.TextBox();
            this.InputFileLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.InputFileButton = new System.Windows.Forms.Button();
            this.OutputDirectoryButton = new System.Windows.Forms.Button();
            this.SplitButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // inputFileTextArea
            // 
            this.inputFileTextArea.Location = new System.Drawing.Point(115, 12);
            this.inputFileTextArea.Name = "inputFileTextArea";
            this.inputFileTextArea.ReadOnly = true;
            this.inputFileTextArea.Size = new System.Drawing.Size(374, 20);
            this.inputFileTextArea.TabIndex = 0;
            // 
            // outputDirectoryTextArea
            // 
            this.outputDirectoryTextArea.Location = new System.Drawing.Point(115, 44);
            this.outputDirectoryTextArea.Name = "outputDirectoryTextArea";
            this.outputDirectoryTextArea.Size = new System.Drawing.Size(374, 20);
            this.outputDirectoryTextArea.TabIndex = 1;
            // 
            // InputFileLabel
            // 
            this.InputFileLabel.AutoSize = true;
            this.InputFileLabel.Location = new System.Drawing.Point(27, 14);
            this.InputFileLabel.Name = "InputFileLabel";
            this.InputFileLabel.Size = new System.Drawing.Size(53, 13);
            this.InputFileLabel.TabIndex = 2;
            this.InputFileLabel.Text = "Input File:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Output Directory:";
            // 
            // InputFileButton
            // 
            this.InputFileButton.Location = new System.Drawing.Point(496, 9);
            this.InputFileButton.Name = "InputFileButton";
            this.InputFileButton.Size = new System.Drawing.Size(102, 23);
            this.InputFileButton.TabIndex = 4;
            this.InputFileButton.Text = "Browse";
            this.InputFileButton.UseVisualStyleBackColor = true;
            this.InputFileButton.Click += new System.EventHandler(this.InputFileButton_Click);
            // 
            // OutputDirectoryButton
            // 
            this.OutputDirectoryButton.Location = new System.Drawing.Point(496, 41);
            this.OutputDirectoryButton.Name = "OutputDirectoryButton";
            this.OutputDirectoryButton.Size = new System.Drawing.Size(102, 23);
            this.OutputDirectoryButton.TabIndex = 5;
            this.OutputDirectoryButton.Text = "Browse";
            this.OutputDirectoryButton.UseVisualStyleBackColor = true;
            this.OutputDirectoryButton.Click += new System.EventHandler(this.OutputDirectoryButton_Click);
            // 
            // SplitButton
            // 
            this.SplitButton.Location = new System.Drawing.Point(15, 305);
            this.SplitButton.Name = "SplitButton";
            this.SplitButton.Size = new System.Drawing.Size(583, 42);
            this.SplitButton.TabIndex = 7;
            this.SplitButton.Text = "Split Files";
            this.SplitButton.UseVisualStyleBackColor = true;
            this.SplitButton.Click += new System.EventHandler(this.SplitButton_Click);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(12, 73);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(525, 226);
            this.panel1.TabIndex = 8;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(519, 223);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(553, 73);
            this.trackBar1.Maximum = 50;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar1.Size = new System.Drawing.Size(45, 219);
            this.trackBar1.TabIndex = 9;
            this.trackBar1.Value = 5;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 355);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.SplitButton);
            this.Controls.Add(this.OutputDirectoryButton);
            this.Controls.Add(this.InputFileButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.InputFileLabel);
            this.Controls.Add(this.outputDirectoryTextArea);
            this.Controls.Add(this.inputFileTextArea);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Audio Splitter";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox inputFileTextArea;
        private System.Windows.Forms.TextBox outputDirectoryTextArea;
        private System.Windows.Forms.Label InputFileLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button InputFileButton;
        private System.Windows.Forms.Button OutputDirectoryButton;
        private System.Windows.Forms.Button SplitButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TrackBar trackBar1;
    }
}

