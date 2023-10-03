namespace Task_1
{
    public partial class Form1 : Form
    {
        static public int count { get; set; } = 1;
        public Point DownPoint { get; set; }
        public Point UpPoint { get; set; }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            DownPoint = e.Location;
        }
     
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Location.Y - DownPoint.Y < 10 && e.Location.Y > DownPoint.Y || DownPoint.Y - e.Location.Y < 10 && e.Location.Y < DownPoint.Y)
            {
                MessageBox.Show("it is too small", "Worning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Button button = new();
            button.Click += (s, e) =>
                button.Text = "Location: " + button.Location.ToString();
      
            button.AutoSize = true;
            button.Text = count++.ToString();
            button.Size = new Size(e.Location.Y - DownPoint.Y, e.Location.Y - DownPoint.Y);
            if (e.Location.X > DownPoint.X && e.Location.Y > DownPoint.Y)
                button.Location = DownPoint;

            else if (e.Location.X < DownPoint.X && e.Location.Y > DownPoint.Y)
                button.Location = new Point(DownPoint.X - (e.Location.Y - DownPoint.Y), DownPoint.Y);

            else if (e.Location.X > DownPoint.X && e.Location.Y < DownPoint.Y)
            {
                button.Location = new Point(DownPoint.X, e.Location.Y);
                button.Size = new Size(DownPoint.Y - e.Location.Y, DownPoint.Y - e.Location.Y);
            }

            else if (e.Location.X < DownPoint.X && e.Location.Y < DownPoint.Y)
            {
                button.Location = e.Location;
                button.Size = new Size(DownPoint.Y - e.Location.Y, DownPoint.Y - e.Location.Y);
            }
            Controls.Add(button);
        }
    }
}