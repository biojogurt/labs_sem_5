namespace lab_os_3
{
    partial class MainForm
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
            this.MainButton = new System.Windows.Forms.Button();
            this.MainLabel = new System.Windows.Forms.Label();
            this.flp = new System.Windows.Forms.FlowLayoutPanel();
            this.ListsLabel = new System.Windows.Forms.Label();
            this.ListsTextBox = new System.Windows.Forms.TextBox();
            this.HeapsLabel = new System.Windows.Forms.Label();
            this.HeapsTextBox = new System.Windows.Forms.TextBox();
            this.flp.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainButton
            // 
            this.MainButton.AutoSize = true;
            this.MainButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flp.SetFlowBreak(this.MainButton, true);
            this.MainButton.Location = new System.Drawing.Point(6, 66);
            this.MainButton.Name = "MainButton";
            this.MainButton.Size = new System.Drawing.Size(66, 28);
            this.MainButton.TabIndex = 1;
            this.MainButton.Text = "Начать";
            this.MainButton.UseVisualStyleBackColor = true;
            this.MainButton.Click += new System.EventHandler(this.MainButton_Click);
            // 
            // MainLabel
            // 
            this.MainLabel.AutoSize = true;
            this.MainLabel.Location = new System.Drawing.Point(6, 100);
            this.MainLabel.Margin = new System.Windows.Forms.Padding(3);
            this.MainLabel.Name = "MainLabel";
            this.MainLabel.Size = new System.Drawing.Size(0, 18);
            this.MainLabel.TabIndex = 2;
            // 
            // flp
            // 
            this.flp.AutoSize = true;
            this.flp.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flp.Controls.Add(this.ListsLabel);
            this.flp.Controls.Add(this.ListsTextBox);
            this.flp.Controls.Add(this.HeapsLabel);
            this.flp.Controls.Add(this.HeapsTextBox);
            this.flp.Controls.Add(this.MainButton);
            this.flp.Controls.Add(this.MainLabel);
            this.flp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flp.Location = new System.Drawing.Point(0, 0);
            this.flp.Name = "flp";
            this.flp.Padding = new System.Windows.Forms.Padding(3);
            this.flp.Size = new System.Drawing.Size(784, 561);
            this.flp.TabIndex = 3;
            // 
            // ListsLabel
            // 
            this.ListsLabel.AutoSize = true;
            this.ListsLabel.Location = new System.Drawing.Point(6, 9);
            this.ListsLabel.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.ListsLabel.Name = "ListsLabel";
            this.ListsLabel.Size = new System.Drawing.Size(224, 18);
            this.ListsLabel.TabIndex = 6;
            this.ListsLabel.Text = "Максимальное количество куч";
            // 
            // ListsTextBox
            // 
            this.flp.SetFlowBreak(this.ListsTextBox, true);
            this.ListsTextBox.Location = new System.Drawing.Point(236, 6);
            this.ListsTextBox.Name = "ListsTextBox";
            this.ListsTextBox.Size = new System.Drawing.Size(120, 25);
            this.ListsTextBox.TabIndex = 4;
            this.ListsTextBox.Text = "50";
            // 
            // HeapsLabel
            // 
            this.HeapsLabel.AutoSize = true;
            this.HeapsLabel.Location = new System.Drawing.Point(6, 39);
            this.HeapsLabel.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.HeapsLabel.Name = "HeapsLabel";
            this.HeapsLabel.Size = new System.Drawing.Size(248, 18);
            this.HeapsLabel.TabIndex = 5;
            this.HeapsLabel.Text = "Максимальное количество блоков";
            // 
            // HeapsTextBox
            // 
            this.flp.SetFlowBreak(this.HeapsTextBox, true);
            this.HeapsTextBox.Location = new System.Drawing.Point(260, 36);
            this.HeapsTextBox.Name = "HeapsTextBox";
            this.HeapsTextBox.Size = new System.Drawing.Size(120, 25);
            this.HeapsTextBox.TabIndex = 3;
            this.HeapsTextBox.Text = "50";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.flp);
            this.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.SystemColors.WindowText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.flp.ResumeLayout(false);
            this.flp.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button MainButton;
        private Label MainLabel;
        private FlowLayoutPanel flp;
        private Label ListsLabel;
        private TextBox ListsTextBox;
        private Label HeapsLabel;
        private TextBox HeapsTextBox;
    }
}