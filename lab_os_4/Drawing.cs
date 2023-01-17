namespace lab_os_4
{
    public class Drawing
    {
        public static Brush IdleBrush { get; } = Brushes.Blue;
        public static Brush RequestingBrush { get; } = Brushes.Red;
        public static Brush WaitingBrush { get; } = Brushes.Yellow;
        public static Brush WorkingBrush { get; } = Brushes.Green;
        public static int EllipseDiameter { get; } = 30;

        public static void MakeEllipse(Graphics graphics, Brush brush, int x, int y, int diameter)
        {
            graphics.FillEllipse(brush, new Rectangle(x, y, diameter, diameter));
        }
    }
}