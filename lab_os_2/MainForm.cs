using System.Runtime.InteropServices;

namespace lab_os_2
{
    internal delegate void UpdateLabel(string s);

    internal partial class MainForm : Form
    {
        private const int EM_SETCUEBANNER = 0x1501;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            _ = SendMessage(TextBoxMinSize.Handle, EM_SETCUEBANNER, 0, " ¬ведите минимальный размер подкаталога");
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            GetFoldelPath(Label1);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            GetFoldelPath(Label2);
        }

        private void GetFoldelPath(Label label)
        {
            DialogResult result = fbd.ShowDialog();

            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
            {
                label.Text = fbd.SelectedPath;
            }
        }

        private void ButtonResult_Click(object sender, EventArgs e)
        {
            ResultThread resultThread = new ResultThread(Label1.Text, Label2.Text, ulong.Parse(TextBoxMinSize.Text), UpdateResultLabel);
        }

        private void UpdateResultLabel(string s)
        {
            LabelResult.Invoke(() => LabelResult.Text = s);
        }
    }
}