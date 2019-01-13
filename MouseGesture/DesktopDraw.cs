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
        Form nForm = new Form();
        PictureBox nPB = new PictureBox();
        public Bitmap nCanvas;
        Point OldP;
        Graphics g;

        //右クリック下押しのフラグ
        bool isRIGHTDOWN = false;

        //コンストラクタ
        public DesktopDraw()
        {
            //追加フォームの初期化
            nForm.TransparencyKey = Color.FromKnownColor(KnownColor.Control);
            nForm.FormBorderStyle = FormBorderStyle.None;
            nForm.Bounds = Screen.PrimaryScreen.Bounds;
            nForm.TopMost = true;
            //nCanvas = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            nForm.Bounds = Screen.PrimaryScreen.Bounds;

            //追加ピクチャボックスの初期化
            nPB.Bounds = Screen.PrimaryScreen.Bounds;
            //追加ピクチャボックスのグラフィクスオブジェクトの取得
            g = nPB.CreateGraphics();
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
                        g.DrawLine(Pens.Black, OldP.X, OldP.Y, State.X, State.Y);
                        OldP.X = State.X;
                        OldP.Y = State.Y;
                    }

                    break;
                case Stroke.LEFT_DOWN:
                    break;
                case Stroke.LEFT_UP:
                    break;
                case Stroke.RIGHT_DOWN:
                    //OldPの初期化
                    OldP = new Point(State.X, State.Y);
                    //追加フォームの表示
                    nForm.Show();
                    //追加ピクチャボックスの表示
                    nForm.Controls.Add(nPB);
                    isRIGHTDOWN = true;
                    break;
                case Stroke.RIGHT_UP:
                    //追加フォームを閉じる
                    nForm.Close();
                    isRIGHTDOWN = false;
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
