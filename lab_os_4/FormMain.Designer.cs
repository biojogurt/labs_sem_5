namespace lab_os_4
{
    partial class FormMain
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
            this.StartButton = new System.Windows.Forms.Button();
            this.PauseButton = new System.Windows.Forms.Button();
            this.ContinueButton = new System.Windows.Forms.Button();
            this.DataGridViewQueue = new System.Windows.Forms.DataGridView();
            this.LabelWorker2 = new System.Windows.Forms.Label();
            this.LabelWorker3 = new System.Windows.Forms.Label();
            this.LabelWorker4 = new System.Windows.Forms.Label();
            this.LabelWorker1 = new System.Windows.Forms.Label();
            this.LabelExplanation = new System.Windows.Forms.Label();
            this.LabelIdle = new System.Windows.Forms.Label();
            this.LabelRequesting = new System.Windows.Forms.Label();
            this.LabelWaiting = new System.Windows.Forms.Label();
            this.LabelWorking = new System.Windows.Forms.Label();
            this.LabelQueue = new System.Windows.Forms.Label();
            this.LabelWorker7 = new System.Windows.Forms.Label();
            this.LabelWorker6 = new System.Windows.Forms.Label();
            this.LabelWorker5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewQueue)).BeginInit();
            this.SuspendLayout();
            // 
            // StartButton
            // 
            this.StartButton.AutoSize = true;
            this.StartButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.StartButton.Location = new System.Drawing.Point(14, 389);
            this.StartButton.Margin = new System.Windows.Forms.Padding(5);
            this.StartButton.Name = "StartButton";
            this.StartButton.Padding = new System.Windows.Forms.Padding(5);
            this.StartButton.Size = new System.Drawing.Size(68, 38);
            this.StartButton.TabIndex = 0;
            this.StartButton.Text = "Старт";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // PauseButton
            // 
            this.PauseButton.AutoSize = true;
            this.PauseButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.PauseButton.Enabled = false;
            this.PauseButton.Location = new System.Drawing.Point(92, 389);
            this.PauseButton.Margin = new System.Windows.Forms.Padding(5);
            this.PauseButton.Name = "PauseButton";
            this.PauseButton.Padding = new System.Windows.Forms.Padding(5);
            this.PauseButton.Size = new System.Drawing.Size(68, 38);
            this.PauseButton.TabIndex = 1;
            this.PauseButton.Text = "Пауза";
            this.PauseButton.UseVisualStyleBackColor = true;
            this.PauseButton.Click += new System.EventHandler(this.PauseButton_Click);
            // 
            // ContinueButton
            // 
            this.ContinueButton.AutoSize = true;
            this.ContinueButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ContinueButton.Enabled = false;
            this.ContinueButton.Location = new System.Drawing.Point(170, 389);
            this.ContinueButton.Margin = new System.Windows.Forms.Padding(5);
            this.ContinueButton.Name = "ContinueButton";
            this.ContinueButton.Padding = new System.Windows.Forms.Padding(5);
            this.ContinueButton.Size = new System.Drawing.Size(108, 38);
            this.ContinueButton.TabIndex = 2;
            this.ContinueButton.Text = "Продолжить";
            this.ContinueButton.UseVisualStyleBackColor = true;
            this.ContinueButton.Click += new System.EventHandler(this.ContinueButton_Click);
            // 
            // DataGridViewQueue
            // 
            this.DataGridViewQueue.AllowUserToAddRows = false;
            this.DataGridViewQueue.AllowUserToDeleteRows = false;
            this.DataGridViewQueue.AllowUserToResizeColumns = false;
            this.DataGridViewQueue.AllowUserToResizeRows = false;
            this.DataGridViewQueue.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataGridViewQueue.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.DataGridViewQueue.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.DataGridViewQueue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridViewQueue.ColumnHeadersVisible = false;
            this.DataGridViewQueue.Location = new System.Drawing.Point(310, 287);
            this.DataGridViewQueue.Margin = new System.Windows.Forms.Padding(5);
            this.DataGridViewQueue.Name = "DataGridViewQueue";
            this.DataGridViewQueue.ReadOnly = true;
            this.DataGridViewQueue.RowHeadersVisible = false;
            this.DataGridViewQueue.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.DataGridViewQueue.RowTemplate.Height = 25;
            this.DataGridViewQueue.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DataGridViewQueue.Size = new System.Drawing.Size(280, 140);
            this.DataGridViewQueue.TabIndex = 3;
            this.DataGridViewQueue.Visible = false;
            // 
            // LabelWorker2
            // 
            this.LabelWorker2.AutoSize = true;
            this.LabelWorker2.Location = new System.Drawing.Point(49, 122);
            this.LabelWorker2.Margin = new System.Windows.Forms.Padding(40, 6, 6, 6);
            this.LabelWorker2.Name = "LabelWorker2";
            this.LabelWorker2.Padding = new System.Windows.Forms.Padding(5);
            this.LabelWorker2.Size = new System.Drawing.Size(74, 28);
            this.LabelWorker2.TabIndex = 12;
            this.LabelWorker2.Text = "Writer ";
            this.LabelWorker2.Visible = false;
            // 
            // LabelWorker3
            // 
            this.LabelWorker3.AutoSize = true;
            this.LabelWorker3.Location = new System.Drawing.Point(49, 162);
            this.LabelWorker3.Margin = new System.Windows.Forms.Padding(40, 6, 6, 6);
            this.LabelWorker3.Name = "LabelWorker3";
            this.LabelWorker3.Padding = new System.Windows.Forms.Padding(5);
            this.LabelWorker3.Size = new System.Drawing.Size(74, 28);
            this.LabelWorker3.TabIndex = 11;
            this.LabelWorker3.Text = "Writer ";
            this.LabelWorker3.Visible = false;
            // 
            // LabelWorker4
            // 
            this.LabelWorker4.AutoSize = true;
            this.LabelWorker4.Location = new System.Drawing.Point(49, 202);
            this.LabelWorker4.Margin = new System.Windows.Forms.Padding(40, 6, 6, 6);
            this.LabelWorker4.Name = "LabelWorker4";
            this.LabelWorker4.Padding = new System.Windows.Forms.Padding(5);
            this.LabelWorker4.Size = new System.Drawing.Size(74, 28);
            this.LabelWorker4.TabIndex = 10;
            this.LabelWorker4.Text = "Writer ";
            this.LabelWorker4.Visible = false;
            // 
            // LabelWorker1
            // 
            this.LabelWorker1.AutoSize = true;
            this.LabelWorker1.Location = new System.Drawing.Point(49, 82);
            this.LabelWorker1.Margin = new System.Windows.Forms.Padding(40, 6, 6, 6);
            this.LabelWorker1.Name = "LabelWorker1";
            this.LabelWorker1.Padding = new System.Windows.Forms.Padding(5);
            this.LabelWorker1.Size = new System.Drawing.Size(74, 28);
            this.LabelWorker1.TabIndex = 9;
            this.LabelWorker1.Text = "Writer ";
            this.LabelWorker1.Visible = false;
            // 
            // LabelExplanation
            // 
            this.LabelExplanation.AutoSize = true;
            this.LabelExplanation.Location = new System.Drawing.Point(346, 64);
            this.LabelExplanation.Margin = new System.Windows.Forms.Padding(40, 6, 6, 11);
            this.LabelExplanation.Name = "LabelExplanation";
            this.LabelExplanation.Padding = new System.Windows.Forms.Padding(5);
            this.LabelExplanation.Size = new System.Drawing.Size(114, 28);
            this.LabelExplanation.TabIndex = 8;
            this.LabelExplanation.Text = "Обозначения:";
            this.LabelExplanation.Visible = false;
            // 
            // LabelIdle
            // 
            this.LabelIdle.AutoSize = true;
            this.LabelIdle.Location = new System.Drawing.Point(346, 109);
            this.LabelIdle.Margin = new System.Windows.Forms.Padding(40, 6, 6, 6);
            this.LabelIdle.Name = "LabelIdle";
            this.LabelIdle.Padding = new System.Windows.Forms.Padding(5);
            this.LabelIdle.Size = new System.Drawing.Size(114, 28);
            this.LabelIdle.TabIndex = 4;
            this.LabelIdle.Text = "Бездействует";
            this.LabelIdle.Visible = false;
            // 
            // LabelRequesting
            // 
            this.LabelRequesting.AutoSize = true;
            this.LabelRequesting.Location = new System.Drawing.Point(346, 149);
            this.LabelRequesting.Margin = new System.Windows.Forms.Padding(40, 6, 6, 6);
            this.LabelRequesting.Name = "LabelRequesting";
            this.LabelRequesting.Padding = new System.Windows.Forms.Padding(5);
            this.LabelRequesting.Size = new System.Drawing.Size(162, 28);
            this.LabelRequesting.TabIndex = 7;
            this.LabelRequesting.Text = "Запрашивает доступ";
            this.LabelRequesting.Visible = false;
            // 
            // LabelWaiting
            // 
            this.LabelWaiting.AutoSize = true;
            this.LabelWaiting.Location = new System.Drawing.Point(346, 189);
            this.LabelWaiting.Margin = new System.Windows.Forms.Padding(40, 6, 6, 6);
            this.LabelWaiting.Name = "LabelWaiting";
            this.LabelWaiting.Padding = new System.Windows.Forms.Padding(5);
            this.LabelWaiting.Size = new System.Drawing.Size(90, 28);
            this.LabelWaiting.TabIndex = 6;
            this.LabelWaiting.Text = "В очереди";
            this.LabelWaiting.Visible = false;
            // 
            // LabelWorking
            // 
            this.LabelWorking.AutoSize = true;
            this.LabelWorking.Location = new System.Drawing.Point(346, 229);
            this.LabelWorking.Margin = new System.Windows.Forms.Padding(40, 6, 6, 6);
            this.LabelWorking.Name = "LabelWorking";
            this.LabelWorking.Padding = new System.Windows.Forms.Padding(5);
            this.LabelWorking.Size = new System.Drawing.Size(170, 28);
            this.LabelWorking.TabIndex = 5;
            this.LabelWorking.Text = "Пользуется ресурсом";
            this.LabelWorking.Visible = false;
            // 
            // LabelQueue
            // 
            this.LabelQueue.AutoSize = true;
            this.LabelQueue.Location = new System.Drawing.Point(310, 264);
            this.LabelQueue.Margin = new System.Windows.Forms.Padding(0);
            this.LabelQueue.Name = "LabelQueue";
            this.LabelQueue.Size = new System.Drawing.Size(280, 18);
            this.LabelQueue.TabIndex = 13;
            this.LabelQueue.Text = "Очередь ожидающих доступ к ресурсу";
            this.LabelQueue.Visible = false;
            // 
            // LabelWorker7
            // 
            this.LabelWorker7.AutoSize = true;
            this.LabelWorker7.Location = new System.Drawing.Point(49, 322);
            this.LabelWorker7.Margin = new System.Windows.Forms.Padding(40, 6, 6, 6);
            this.LabelWorker7.Name = "LabelWorker7";
            this.LabelWorker7.Padding = new System.Windows.Forms.Padding(5);
            this.LabelWorker7.Size = new System.Drawing.Size(74, 28);
            this.LabelWorker7.TabIndex = 14;
            this.LabelWorker7.Text = "Writer ";
            this.LabelWorker7.Visible = false;
            // 
            // LabelWorker6
            // 
            this.LabelWorker6.AutoSize = true;
            this.LabelWorker6.Location = new System.Drawing.Point(49, 282);
            this.LabelWorker6.Margin = new System.Windows.Forms.Padding(40, 6, 6, 6);
            this.LabelWorker6.Name = "LabelWorker6";
            this.LabelWorker6.Padding = new System.Windows.Forms.Padding(5);
            this.LabelWorker6.Size = new System.Drawing.Size(74, 28);
            this.LabelWorker6.TabIndex = 15;
            this.LabelWorker6.Text = "Writer ";
            this.LabelWorker6.Visible = false;
            // 
            // LabelWorker5
            // 
            this.LabelWorker5.AutoSize = true;
            this.LabelWorker5.Location = new System.Drawing.Point(49, 242);
            this.LabelWorker5.Margin = new System.Windows.Forms.Padding(40, 6, 6, 6);
            this.LabelWorker5.Name = "LabelWorker5";
            this.LabelWorker5.Padding = new System.Windows.Forms.Padding(5);
            this.LabelWorker5.Size = new System.Drawing.Size(74, 28);
            this.LabelWorker5.TabIndex = 16;
            this.LabelWorker5.Text = "Writer ";
            this.LabelWorker5.Visible = false;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(604, 441);
            this.Controls.Add(this.LabelWorker5);
            this.Controls.Add(this.LabelWorker6);
            this.Controls.Add(this.LabelWorker7);
            this.Controls.Add(this.LabelQueue);
            this.Controls.Add(this.LabelExplanation);
            this.Controls.Add(this.LabelIdle);
            this.Controls.Add(this.LabelRequesting);
            this.Controls.Add(this.LabelWorker2);
            this.Controls.Add(this.LabelWaiting);
            this.Controls.Add(this.LabelWorker3);
            this.Controls.Add(this.LabelWorking);
            this.Controls.Add(this.LabelWorker4);
            this.Controls.Add(this.LabelWorker1);
            this.Controls.Add(this.DataGridViewQueue);
            this.Controls.Add(this.ContinueButton);
            this.Controls.Add(this.PauseButton);
            this.Controls.Add(this.StartButton);
            this.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.SystemColors.WindowText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.ShowIcon = false;
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewQueue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button StartButton;
        private Button PauseButton;
        private Button ContinueButton;
        private DataGridView DataGridViewQueue;
        private Label LabelWorker2;
        private Label LabelWorker3;
        private Label LabelWorker4;
        private Label LabelWorker1;
        private Label LabelExplanation;
        private Label LabelIdle;
        private Label LabelRequesting;
        private Label LabelWaiting;
        private Label LabelWorking;
        private Label LabelQueue;
        private Label LabelWorker7;
        private Label LabelWorker6;
        private Label LabelWorker5;
    }
}