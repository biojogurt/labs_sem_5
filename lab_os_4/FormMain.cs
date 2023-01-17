namespace lab_os_4
{
    public partial class FormMain : Form
    {
        private DoubleBufferedFlowLayoutPanel Legend { get; }
        private DoubleBufferedFlowLayoutPanel Workers { get; }
        private DistributedSystem? DistributedSystem { get; set; } = null;

        public FormMain()
        {
            InitializeComponent();
            DoubleBuffered = true;

            Legend = new DoubleBufferedFlowLayoutPanel
            {
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                BackColor = Color.Transparent,
                FlowDirection = FlowDirection.TopDown,
                Location = new Point(310, 20),
                Margin = Padding.Empty,
                Padding = Padding.Empty,
                Visible = false
            };
            Legend.Controls.Add(LabelExplanation);
            Legend.Controls.Add(LabelIdle);
            Legend.Controls.Add(LabelRequesting);
            Legend.Controls.Add(LabelWaiting);
            Legend.Controls.Add(LabelWorking);
            Controls.Add(Legend);

            Workers = new DoubleBufferedFlowLayoutPanel
            {
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                BackColor = Color.Transparent,
                FlowDirection = FlowDirection.TopDown,
                Location = new Point(30, 20),
                Margin = Padding.Empty,
                Padding = Padding.Empty,
                Visible = false
            };
            Workers.Controls.Add(LabelWorker1);
            Workers.Controls.Add(LabelWorker2);
            Workers.Controls.Add(LabelWorker3);
            Workers.Controls.Add(LabelWorker4);
            Workers.Controls.Add(LabelWorker5);
            Workers.Controls.Add(LabelWorker6);
            Workers.Controls.Add(LabelWorker7);
            Controls.Add(Workers);

            var timer = new System.Windows.Forms.Timer();
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Interval = 20;
            timer.Start();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            DistributedSystem = DistributedSystem.GetInstance();
            DistributedSystem.Thread?.Join();

            LabelWorker1.Text += DistributedSystem?.Writers?[0].ID;
            LabelWorker2.Text += DistributedSystem?.Writers?[1].ID;
            LabelWorker3.Text += DistributedSystem?.Writers?[2].ID;
            LabelWorker4.Text += DistributedSystem?.Writers?[3].ID;
            LabelWorker5.Text += DistributedSystem?.Writers?[4].ID;
            LabelWorker6.Text += DistributedSystem?.Writers?[5].ID;
            LabelWorker7.Text += DistributedSystem?.Writers?[6].ID;

            LabelWorker1.Visible = true;
            LabelWorker2.Visible = true;
            LabelWorker3.Visible = true;
            LabelWorker4.Visible = true;
            LabelWorker5.Visible = true;
            LabelWorker6.Visible = true;
            LabelWorker7.Visible = true;
            DataGridViewQueue.Visible = true;
            LabelExplanation.Visible = true;
            LabelIdle.Visible = true;
            LabelRequesting.Visible = true;
            LabelWaiting.Visible = true;
            LabelWorking.Visible = true;
            Legend.Visible = true;
            Workers.Visible = true;
            LabelQueue.Visible = true;

            StartButton.Enabled = false;
            ContinueButton.Enabled = false;
            PauseButton.Enabled = true;
        }

        private void PauseButton_Click(object sender, EventArgs e)
        {
            if (DistributedSystem != null)
            {
                if (DistributedSystem.Writers != null)
                {
                    foreach (Writer writer in DistributedSystem.Writers)
                    {
                        writer.Pause();
                    }
                }

                DistributedSystem.Manager?.Pause();

                StartButton.Enabled = false;
                ContinueButton.Enabled = true;
                PauseButton.Enabled = false;
            }
        }

        private void ContinueButton_Click(object sender, EventArgs e)
        {
            if (DistributedSystem != null)
            {
                if (DistributedSystem.Writers != null)
                {
                    foreach (Writer writer in DistributedSystem.Writers)
                    {
                        writer.Unpause();
                    }
                }

                DistributedSystem.Manager?.Unpause();

                StartButton.Enabled = false;
                ContinueButton.Enabled = false;
                PauseButton.Enabled = true;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (DistributedSystem != null)
            {
                Drawing.MakeEllipse(e.Graphics, Drawing.IdleBrush, 317, 70, Drawing.EllipseDiameter);
                Drawing.MakeEllipse(e.Graphics, Drawing.RequestingBrush, 317, 110, Drawing.EllipseDiameter);
                Drawing.MakeEllipse(e.Graphics, Drawing.WaitingBrush, 317, 150, Drawing.EllipseDiameter);
                Drawing.MakeEllipse(e.Graphics, Drawing.WorkingBrush, 317, 190, Drawing.EllipseDiameter);

                if (DistributedSystem.Writers != null)
                {
                    foreach (Writer writer in DistributedSystem.Writers)
                    {
                        Brush brush = writer.State == State.Idle
                            ? Drawing.IdleBrush
                            : writer.State == State.Requesting
                            ? Drawing.RequestingBrush
                            : writer.State == State.Waiting
                            ? Drawing.WaitingBrush
                            : Drawing.WorkingBrush;
                        Drawing.MakeEllipse(e.Graphics, brush, writer.X, writer.Y, Drawing.EllipseDiameter);
                    }
                }

                if (DistributedSystem.Manager != null)
                {
                    lock (DistributedSystem.Manager.Queue)
                    {
                        DataGridViewQueue.DataSource = new BindingSource(DistributedSystem.Manager.Queue.Select(x => new { name = "Writer " + x } ).ToList(), null);
                    }
                }
            }

        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            Invalidate();
        }
    }
}