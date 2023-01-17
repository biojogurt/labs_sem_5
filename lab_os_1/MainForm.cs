namespace lab_os_1
{
    internal delegate void ProgessUpdateDelegate(string progress);

    internal partial class MainForm : Form
    {
        ThreadManager threadManager { get; }

        public MainForm()
        {
            InitializeComponent();
            threadManager = new ThreadManager(UpdateActions, UpdateStartStop);
        }

        private void UpdateActions(string progress)
        {
            Monitor.Enter(StatusActionsTextBox);
            StatusActionsTextBox.Invoke(() =>
            {
                StatusActionsTextBox.AppendText(progress + "\r\n");
            });
            Monitor.Exit(StatusActionsTextBox);
        }

        private void UpdateStartStop(string progress)
        {
            Monitor.Enter(StatusStartStopTextBox);
            StatusStartStopTextBox.Invoke(() =>
            {
                StatusStartStopTextBox.AppendText(progress + "\r\n");
            });
            Monitor.Exit(StatusStartStopTextBox);
        }

        private void PauseButton_Click(object sender, EventArgs e)
        {
            threadManager.PauseAll();
        }

        private void ResumeButton_Click(object sender, EventArgs e)
        {
            threadManager.ResumeAll();
        }
    }
}