using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using static MouseGesture.MouseHook;

namespace MouseGesture
{
    class DesktopDraw
    {
        //フィールド

        //クラスのインスタンス化
        Form nForm = new Form();
        PictureBox nPB = new PictureBox();
        GraphicsPath myPath;
        Bitmap bmp = new Bitmap(Screen.PrimaryScreen.Bounds.Width,Screen.PrimaryScreen.Bounds.Height);

        Point OldP;
        Graphics g,g2;

        //右ボタンdownのフラグ
        bool isRIGHTDOWN = false;

        //コンストラクタ
        public DesktopDraw()
        {
            //追加フォームの初期化
            nForm.TransparencyKey = Color.FromKnownColor(KnownColor.Control);
            nForm.FormBorderStyle = FormBorderStyle.None;
            nForm.Bounds = Screen.PrimaryScreen.Bounds;
            nForm.TopMost = true;

            //追加ピクチャボックスの初期化
            nPB.Bounds = Screen.PrimaryScreen.Bounds;
        }

        /// <summary>
        /// デスクトップへの直接描写
        /// </summary>
        /// <param name="stateMouse">マウスの状態の構造体</param>
        public void Drawline(ref StateMouse stateMouse)
        {
            switch (stateMouse.Stroke)
            {
                case Stroke.MOVE:

                    if (isRIGHTDOWN == true)
                    {
                        myPath.StartFigure();
                        myPath.AddLine(OldP.X, OldP.Y, State.X, State.Y);
                        Pen GreenPen = new Pen(Color.Green, 5);
                        g.DrawPath(GreenPen, myPath);
                        OldP.X = State.X;
                        OldP.Y = State.Y;
                    }

                    break;
                case Stroke.LEFT_DOWN:
                    break;
                case Stroke.LEFT_UP:
                    break;
                case Stroke.RIGHT_DOWN:

                    OldP = new Point(State.X, State.Y);
                    isRIGHTDOWN = true;

                    //追加フォームの表示
                    nForm.Show();
                    //追加フォームにピクチャボックスを追加する
                    nForm.Controls.Add(nPB);

                    //追加ピクチャボックスのグラフィクスオブジェクトの取得
                    g = nPB.CreateGraphics();
                    g2 = Graphics.FromImage(bmp);

                    g2.CopyFromScreen(new Point(0, 0), new Point(0, 0), bmp.Size);
                    nPB.Image = bmp;

                    //myPathクラスのインスタンス化
                    myPath = new GraphicsPath();

                    break;

                case Stroke.RIGHT_UP:

                    isRIGHTDOWN = false;
                    myPath.Dispose();
                    g.Dispose();
                    nPB.Image = null;
                    nForm.Controls.Remove(nPB);
                    nForm.Hide();

                    break;

                case Stroke.MIDDLE_DOWN:
                    break;
                case Stroke.MIDDLE_UP:
                    break;
                case Stroke.WHEEL_DOWN:
                    break;
                case Stroke.WHEEL_UP:
                    break;
                case Stroke.X1_DOWN:
                    break;
                case Stroke.X1_UP:
                    break;
                case Stroke.X2_DOWN:
                    break;
                case Stroke.X2_UP:
                    break;
                case Stroke.UNKNOWN:
                    break;
                default:
                    break;
            }
        }
    }
}
