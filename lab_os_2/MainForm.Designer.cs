namespace lab_os_2
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
            this.Button1 = new System.Windows.Forms.Button();
            this.Button2 = new System.Windows.Forms.Button();
            this.fbd = new System.Windows.Forms.FolderBrowserDialog();
            this.ButtonResult = new System.Windows.Forms.Button();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.LabelResult = new System.Windows.Forms.Label();
            this.tlp = new System.Windows.Forms.TableLayoutPanel();
            this.TextBoxMinSize = new System.Windows.Forms.TextBox();
            this.tlp.SuspendLayout();
            this.SuspendLayout();
            // 
            // Button1
            // 
            this.Button1.AutoSize = true;
            this.Button1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Button1.Location = new System.Drawing.Point(18, 18);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(137, 29);
            this.Button1.TabIndex = 0;
            this.Button1.Text = "Открыть каталог 1";
            this.Button1.UseVisualStyleBackColor = true;
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // Button2
            // 
            this.Button2.AutoSize = true;
            this.Button2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Button2.Location = new System.Drawing.Point(18, 53);
            this.Button2.Name = "Button2";
            this.Button2.Size = new System.Drawing.Size(137, 29);
            this.Button2.TabIndex = 1;
            this.Button2.Text = "Открыть каталог 2";
            this.Button2.UseVisualStyleBackColor = true;
            this.Button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // ButtonResult
            // 
            this.ButtonResult.AutoSize = true;
            this.ButtonResult.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ButtonResult.Location = new System.Drawing.Point(18, 119);
            this.ButtonResult.Name = "ButtonResult";
            this.ButtonResult.Size = new System.Drawing.Size(64, 29);
            this.ButtonResult.TabIndex = 2;
            this.ButtonResult.Text = "Начать";
            this.ButtonResult.UseVisualStyleBackColor = true;
            this.ButtonResult.Click += new System.EventHandler(this.ButtonResult_Click);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(161, 23);
            this.Label1.Margin = new System.Windows.Forms.Padding(3, 8, 3, 8);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(0, 19);
            this.Label1.TabIndex = 3;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(161, 58);
            this.Label2.Margin = new System.Windows.Forms.Padding(3, 8, 3, 8);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(0, 19);
            this.Label2.TabIndex = 4;
            // 
            // LabelResult
            // 
            this.LabelResult.AutoSize = true;
            this.LabelResult.Location = new System.Drawing.Point(161, 124);
            this.LabelResult.Margin = new System.Windows.Forms.Padding(3, 8, 3, 8);
            this.LabelResult.Name = "LabelResult";
            this.LabelResult.Size = new System.Drawing.Size(0, 19);
            this.LabelResult.TabIndex = 5;
            // 
            // tlp
            // 
            this.tlp.AutoSize = true;
            this.tlp.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tlp.ColumnCount = 2;
            this.tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlp.Controls.Add(this.Label2, 1, 1);
            this.tlp.Controls.Add(this.Label1, 1, 0);
            this.tlp.Controls.Add(this.Button1, 0, 0);
            this.tlp.Controls.Add(this.LabelResult, 1, 3);
            this.tlp.Controls.Add(this.ButtonResult, 0, 3);
            this.tlp.Controls.Add(this.Button2, 0, 1);
            this.tlp.Controls.Add(this.TextBoxMinSize, 0, 2);
            this.tlp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tlp.Location = new System.Drawing.Point(0, 0);
            this.tlp.Margin = new System.Windows.Forms.Padding(0);
            this.tlp.Name = "tlp";
            this.tlp.Padding = new System.Windows.Forms.Padding(15);
            this.tlp.RowCount = 4;
            this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlp.Size = new System.Drawing.Size(784, 561);
            this.tlp.TabIndex = 6;
            // 
            // TextBoxMinSize
            // 
            this.tlp.SetColumnSpan(this.TextBoxMinSize, 2);
            this.TextBoxMinSize.Location = new System.Drawing.Point(18, 88);
            this.TextBoxMinSize.Name = "TextBoxMinSize";
            this.TextBoxMinSize.Size = new System.Drawing.Size(275, 25);
            this.TextBoxMinSize.TabIndex = 6;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.tlp);
            this.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tlp.ResumeLayout(false);
            this.tlp.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button Button1;
        private Button Button2;
        private FolderBrowserDialog fbd;
        private Button ButtonResult;
        private Label Label1;
        private Label Label2;
        private Label LabelResult;
        private TableLayoutPanel tlp;
        private TextBox TextBoxMinSize;
    }
}