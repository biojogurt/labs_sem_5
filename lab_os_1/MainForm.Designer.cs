namespace lab_os_1
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
            this.StatusActionsTextBox = new System.Windows.Forms.TextBox();
            this.MainTable = new System.Windows.Forms.TableLayoutPanel();
            this.StatusStartStopTextBox = new System.Windows.Forms.TextBox();
            this.ButtonTable = new System.Windows.Forms.TableLayoutPanel();
            this.PauseButton = new System.Windows.Forms.Button();
            this.ResumeButton = new System.Windows.Forms.Button();
            this.MainTable.SuspendLayout();
            this.ButtonTable.SuspendLayout();
            this.SuspendLayout();
            // 
            // StatusActionsTextBox
            // 
            this.StatusActionsTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.StatusActionsTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StatusActionsTextBox.Location = new System.Drawing.Point(3, 3);
            this.StatusActionsTextBox.Multiline = true;
            this.StatusActionsTextBox.Name = "StatusActionsTextBox";
            this.StatusActionsTextBox.ReadOnly = true;
            this.StatusActionsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.StatusActionsTextBox.Size = new System.Drawing.Size(464, 408);
            this.StatusActionsTextBox.TabIndex = 0;
            this.StatusActionsTextBox.WordWrap = false;
            // 
            // MainTable
            // 
            this.MainTable.AutoSize = true;
            this.MainTable.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.MainTable.ColumnCount = 2;
            this.MainTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.MainTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.MainTable.Controls.Add(this.StatusStartStopTextBox, 1, 0);
            this.MainTable.Controls.Add(this.StatusActionsTextBox, 0, 0);
            this.MainTable.Controls.Add(this.ButtonTable, 0, 1);
            this.MainTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTable.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.MainTable.Location = new System.Drawing.Point(0, 0);
            this.MainTable.Margin = new System.Windows.Forms.Padding(0);
            this.MainTable.Name = "MainTable";
            this.MainTable.RowCount = 2;
            this.MainTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.MainTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.MainTable.Size = new System.Drawing.Size(784, 461);
            this.MainTable.TabIndex = 1;
            // 
            // StatusStartStopTextBox
            // 
            this.StatusStartStopTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.StatusStartStopTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StatusStartStopTextBox.Location = new System.Drawing.Point(473, 3);
            this.StatusStartStopTextBox.Multiline = true;
            this.StatusStartStopTextBox.Name = "StatusStartStopTextBox";
            this.StatusStartStopTextBox.ReadOnly = true;
            this.StatusStartStopTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.StatusStartStopTextBox.Size = new System.Drawing.Size(308, 408);
            this.StatusStartStopTextBox.TabIndex = 1;
            this.StatusStartStopTextBox.WordWrap = false;
            // 
            // ButtonTable
            // 
            this.ButtonTable.AutoSize = true;
            this.ButtonTable.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ButtonTable.ColumnCount = 2;
            this.ButtonTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ButtonTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ButtonTable.Controls.Add(this.PauseButton, 0, 0);
            this.ButtonTable.Controls.Add(this.ResumeButton, 1, 0);
            this.ButtonTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonTable.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.ButtonTable.Location = new System.Drawing.Point(0, 414);
            this.ButtonTable.Margin = new System.Windows.Forms.Padding(0);
            this.ButtonTable.Name = "ButtonTable";
            this.ButtonTable.RowCount = 1;
            this.ButtonTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ButtonTable.Size = new System.Drawing.Size(470, 47);
            this.ButtonTable.TabIndex = 2;
            // 
            // PauseButton
            // 
            this.PauseButton.AutoSize = true;
            this.PauseButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.PauseButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PauseButton.Location = new System.Drawing.Point(3, 3);
            this.PauseButton.Name = "PauseButton";
            this.PauseButton.Size = new System.Drawing.Size(229, 41);
            this.PauseButton.TabIndex = 0;
            this.PauseButton.Text = "Pause";
            this.PauseButton.UseVisualStyleBackColor = true;
            this.PauseButton.Click += new System.EventHandler(this.PauseButton_Click);
            // 
            // ResumeButton
            // 
            this.ResumeButton.AutoSize = true;
            this.ResumeButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ResumeButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ResumeButton.Location = new System.Drawing.Point(238, 3);
            this.ResumeButton.Name = "ResumeButton";
            this.ResumeButton.Size = new System.Drawing.Size(229, 41);
            this.ResumeButton.TabIndex = 1;
            this.ResumeButton.Text = "Resume";
            this.ResumeButton.UseVisualStyleBackColor = true;
            this.ResumeButton.Click += new System.EventHandler(this.ResumeButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.MainTable);
            this.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Text = "Потоки";
            this.MainTable.ResumeLayout(false);
            this.MainTable.PerformLayout();
            this.ButtonTable.ResumeLayout(false);
            this.ButtonTable.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox StatusActionsTextBox;
        private TableLayoutPanel MainTable;
        private TextBox StatusStartStopTextBox;
        private TableLayoutPanel ButtonTable;
        private Button PauseButton;
        private Button ResumeButton;
    }
}