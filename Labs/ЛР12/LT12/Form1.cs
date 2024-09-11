namespace LT12
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            Form1.ActiveForm.Text = $"X: {e.X}, Y: {e.Y}";
            label1.Text = $"{e.X + e.Y}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var R = numericUpDown1.Value;
            label2.Text = $"{Math.PI*(double)R*(Double)R}";
        }
    }
}
