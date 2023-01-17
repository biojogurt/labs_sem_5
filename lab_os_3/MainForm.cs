namespace lab_os_3
{
    internal delegate void UpdateLabel(string s);

    internal partial class MainForm : Form
    {
        internal MainForm()
        {
            InitializeComponent();
            ListsLabel.MinimumSize = HeapsLabel.Size;
        }

        private void MainButton_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(ListsTextBox.Text, out int maxLists) || maxLists <= 0
                || !int.TryParse(HeapsTextBox.Text, out int maxHeaps) || maxHeaps <= 0)
            {
                UpdateLabel("¬водите только положительные целые числа");
                return;
            }

            ResultThread resultThread = new ResultThread(UpdateLabel, maxLists, maxHeaps);
        }

        private void UpdateLabel(string s)
        {
            Monitor.Enter(MainLabel);
            MainLabel.Invoke(() => MainLabel.Text = s);
            Monitor.Exit(MainLabel);
        }
    }
}