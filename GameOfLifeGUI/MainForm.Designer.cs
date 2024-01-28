namespace GameOfLifeGUI
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
            this.components = new System.ComponentModel.Container();
            this.StartGameButton = new System.Windows.Forms.Button();
            this.StopGameButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.GenerationLabel = new System.Windows.Forms.Label();
            this.StepIntervalBox = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.SaveStateButton = new System.Windows.Forms.Button();
            this.LoadStateButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.StepIntervalBox)).BeginInit();
            this.SuspendLayout();
            // 
            // StartGameButton
            // 
            this.StartGameButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.StartGameButton.Location = new System.Drawing.Point(720, 30);
            this.StartGameButton.Name = "StartGameButton";
            this.StartGameButton.Size = new System.Drawing.Size(152, 69);
            this.StartGameButton.TabIndex = 0;
            this.StartGameButton.Text = "Start game";
            this.StartGameButton.UseVisualStyleBackColor = true;
            this.StartGameButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // StopGameButton
            // 
            this.StopGameButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.StopGameButton.Location = new System.Drawing.Point(720, 159);
            this.StopGameButton.Name = "StopGameButton";
            this.StopGameButton.Size = new System.Drawing.Size(152, 69);
            this.StopGameButton.TabIndex = 1;
            this.StopGameButton.Text = "Stop game";
            this.StopGameButton.UseVisualStyleBackColor = true;
            this.StopGameButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(716, 261);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "Generation:";
            // 
            // GenerationLabel
            // 
            this.GenerationLabel.AutoSize = true;
            this.GenerationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.GenerationLabel.Location = new System.Drawing.Point(825, 261);
            this.GenerationLabel.Name = "GenerationLabel";
            this.GenerationLabel.Size = new System.Drawing.Size(20, 24);
            this.GenerationLabel.TabIndex = 3;
            this.GenerationLabel.Text = "0";
            this.GenerationLabel.Click += new System.EventHandler(this.label2_Click);
            // 
            // StepIntervalBox
            // 
            this.StepIntervalBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.StepIntervalBox.Location = new System.Drawing.Point(720, 368);
            this.StepIntervalBox.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.StepIntervalBox.Minimum = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.StepIntervalBox.Name = "StepIntervalBox";
            this.StepIntervalBox.Size = new System.Drawing.Size(125, 29);
            this.StepIntervalBox.TabIndex = 4;
            this.StepIntervalBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.StepIntervalBox.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(716, 345);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Step interval (ms)";
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // SaveStateButton
            // 
            this.SaveStateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.SaveStateButton.Location = new System.Drawing.Point(720, 440);
            this.SaveStateButton.Name = "SaveStateButton";
            this.SaveStateButton.Size = new System.Drawing.Size(73, 69);
            this.SaveStateButton.TabIndex = 6;
            this.SaveStateButton.Text = "Save state";
            this.SaveStateButton.UseVisualStyleBackColor = true;
            this.SaveStateButton.Click += new System.EventHandler(this.SaveStateButton_Click);
            // 
            // LoadStateButton
            // 
            this.LoadStateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LoadStateButton.Location = new System.Drawing.Point(799, 440);
            this.LoadStateButton.Name = "LoadStateButton";
            this.LoadStateButton.Size = new System.Drawing.Size(73, 69);
            this.LoadStateButton.TabIndex = 7;
            this.LoadStateButton.Text = "Load state";
            this.LoadStateButton.UseVisualStyleBackColor = true;
            this.LoadStateButton.Click += new System.EventHandler(this.LoadStateButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.LoadStateButton);
            this.Controls.Add(this.SaveStateButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.StepIntervalBox);
            this.Controls.Add(this.GenerationLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.StopGameButton);
            this.Controls.Add(this.StartGameButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Game of Life";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.StepIntervalBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button StartGameButton;
        private System.Windows.Forms.Button StopGameButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label GenerationLabel;
        private System.Windows.Forms.NumericUpDown StepIntervalBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Button SaveStateButton;
        private System.Windows.Forms.Button LoadStateButton;
    }
}

