using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using static MouseGesture.MouseHook;

namespace MouseGesture
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //DesktopDrawクラスのインスタンス化
            DesktopDraw DDraw = new DesktopDraw();
            DDraw = new DesktopDraw();
            AddEvent(DDraw.Drawline);
            Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var path = new GraphicsPath();
            path.StartFigure();
            path.AddEllipse(0, 0, 20, 20);
            path.CloseFigure();
            this.Region = new Region(path);
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.Green;
        }
    }
}
