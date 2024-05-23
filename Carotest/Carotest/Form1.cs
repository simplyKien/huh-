namespace Carotest
{
    public partial class Form1 : Form
    {
        private CaroChess caroChess;
        private Graphics grs;
        public int count;
        public int countmax = 25;
        public Form1()
        {
            InitializeComponent();
            button1.Click += new EventHandler(pvPToolStripMenuItem_Click);
            button2.Click += new EventHandler(pvEToolStripMenuItem_Click);
            caroChess = new CaroChess();
            caroChess.KhoiTaoMangOCo();
            grs = panel1.CreateGraphics();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Location = new Point(label1.Location.X, label1.Location.Y - 50);
            if (label1.Location.Y + label1.Height < 0)
            {
                label1.Location = new Point(label1.Location.X, panel2.Height);
            }
            count++;
            int remain = countmax - count;
            countdown.Text = remain.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = "Welcome to the game\nHope you guys enjoy this game!\nThe rule of this game:";
            timer1.Enabled = true;

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            caroChess.VeBanCo(grs);
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            count = 0;
            if (!caroChess.SanSang)
                return;
            if (caroChess.DanhCo(e.X, e.Y, grs))
            {
                if (caroChess.KiemTraChienThang())
                    caroChess.KetThucTroChoi();
                else
                {
                    if (caroChess.CheDoChoi == 2)
                    {
                        caroChess.KhoiDongComputer(grs);
                        if (caroChess.KiemTraChienThang())
                            caroChess.KetThucTroChoi();
                    }
                }
            }
        }

        private void pvPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            grs.Clear(panel1.BackColor);
            caroChess.StartPvP(grs);
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //grs.Clear(panel1.BackColor);
            caroChess.Undo(grs);
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            caroChess.Redo(grs);
        }

        private void pvEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            grs.Clear(panel1.BackColor);
            caroChess.StartPvE(grs);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Application.ExecutablePath); // to start new instance of application
            this.Close(); //to turn off current app
        }
    }
}
