using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Drawing.Drawing2D;

namespace Графические_примитивы
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Graphics grLine;
        Graphics grMain;
        Graphics grEllips;
        Graphics grRect;
        Graphics grPie;
        Random rand = new Random();
        Bitmap[] arrayPic;


        private void drawLine (int N)
        {
            N *= 2;
            Point[] coords;
            coords = new Point[N];
            for (int i = 0; i < coords.Length; i++)
            {
                coords[i].X = rand.Next(pictureBoxMain.Width-10);
                coords[i].Y = rand.Next(pictureBoxMain.Height-10);
            }
            for (int i = 0; i < coords.Length; i += 2)
            {
                Color color = Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255));
                Pen pen = new Pen(color, 1);
                grMain.DrawLine(pen, coords[i], coords[i + 1]);
                grLine.DrawLine(pen, coords[i].X/2, coords[i].Y / 2, coords[i + 1].X/2, coords[i + 1].Y/2);
            }
        }

        private void drawEllipse(int N)
        {
            Point[] coordsEllips;
            coordsEllips = new Point[N];
            float w = rand.Next(20, 200);
            float h = rand.Next(20, 200);
            for (int i = 0; i < coordsEllips.Length; i++)
            {
                coordsEllips[i].X = rand.Next(pictureBoxMain.Width-Convert.ToInt16(w));
                coordsEllips[i].Y = rand.Next(pictureBoxMain.Height- Convert.ToInt16(h));
            }

            for (int i = 0; i < coordsEllips.Length; i += 1)
            {
                Color color = Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255));
                Color newcl = Color.FromArgb(rand.Next(10, 90), color);
                Color color1 = Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255));
                Color newcl1 = Color.FromArgb(rand.Next(10, 90), color1);

                if (radioButtonOneColor.Checked == true)
                {
                    SolidBrush brush = new SolidBrush(newcl);

                    grMain.FillEllipse(brush, coordsEllips[i].X, coordsEllips[i].Y, w, h);

                    Pen pen = new Pen(color, 1);
                    grEllips.DrawEllipse(pen, coordsEllips[i].X / 2, coordsEllips[i].Y / 2, w / 2, h / 2);
                }
                if(radioButtonHatchBrush.Checked == true) 
                {
                    int num = rand.Next(1, 40);
                    HatchBrush hb = new HatchBrush((HatchStyle)num, newcl, color1);
                    grMain.FillEllipse(hb, coordsEllips[i].X, coordsEllips[i].Y, w, h);
                    Pen pen = new Pen(color, 1);
                    grEllips.DrawEllipse(pen, coordsEllips[i].X / 2, coordsEllips[i].Y / 2, w / 2, h / 2);
                }
                if(radioButtonGradientBrush.Checked==true)
                {
                    int gradMode = rand.Next(0, 3);
                    Rectangle rectangle = new Rectangle(coordsEllips[i].X, coordsEllips[i].Y, Convert.ToInt32(w), Convert.ToInt32(h));
                    LinearGradientBrush grad = new LinearGradientBrush(rectangle, newcl, newcl1, (LinearGradientMode)gradMode);
                    grMain.FillEllipse(grad, coordsEllips[i].X, coordsEllips[i].Y, w, h);
                    Pen pen = new Pen(color, 1);
                    grEllips.DrawEllipse(pen, coordsEllips[i].X / 2, coordsEllips[i].Y / 2, w / 2, h / 2);

                }
                if (radioButtonTextureBrush.Checked==true)
                {
                    Rectangle rectangle = new Rectangle(coordsEllips[i].X, coordsEllips[i].Y, Convert.ToInt32(w), Convert.ToInt32(h));

                    TextureBrush myTextureBrush = new TextureBrush(arrayPic[rand.Next(0,5)], WrapMode.Clamp) ; 
                    grMain.FillEllipse(myTextureBrush, coordsEllips[i].X, coordsEllips[i].Y, w, h);
                    Pen pen = new Pen(color, 1);
                    grEllips.DrawEllipse(pen, coordsEllips[i].X / 2, coordsEllips[i].Y / 2, w / 2, h / 2);

                }
                labelR.Text = "R: " +Convert.ToString(newcl.R);
                labelG.Text = "G: " + Convert.ToString(newcl.G);
                labelB.Text = "B: " + Convert.ToString(newcl.B);
                labelX.Text = "X: " + coordsEllips[i].X;
                labelY.Text = "Y: " + coordsEllips[i].Y;
                labelW.Text = "W: " + w;
                labelH.Text = "H: " + h;
            }
        }

        private void drawRectangle(int N)
        {
            Point[] coordsRect;
            coordsRect = new Point[N];
            float w = rand.Next(20, 200);
            float h = rand.Next(20, 200);
            for (int i = 0; i < coordsRect.Length; i++)
            {
                coordsRect[i].X = rand.Next(pictureBoxMain.Width-Convert.ToInt16(w));
                coordsRect[i].Y = rand.Next(pictureBoxMain.Height- Convert.ToInt16(h));
            }

            for (int i = 0; i < coordsRect.Length; i += 1)
            {
                Color color = Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255));
                Color newcl = Color.FromArgb(rand.Next(10, 90), color);
                Color color1 = Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255));
                Color newcl1 = Color.FromArgb(rand.Next(10, 90), color1);


                if (radioButtonOneColor.Checked == true)
                {
                    SolidBrush brush = new SolidBrush(newcl);
                    grMain.FillRectangle(brush, coordsRect[i].X, coordsRect[i].Y, w, h);

                    Pen pen = new Pen(color, 1);
                    grRect.DrawRectangle(pen, coordsRect[i].X / 2, coordsRect[i].Y / 2, w / 2, h / 2);
                }
                if (radioButtonHatchBrush.Checked == true)
                {
                    int num = rand.Next(1, 40);
                    HatchBrush hb = new HatchBrush((HatchStyle)num, newcl, color1);
                    grMain.FillRectangle(hb, coordsRect[i].X, coordsRect[i].Y, w, h);
                    Pen pen = new Pen(color, 1);
                    grRect.DrawRectangle(pen, coordsRect[i].X / 2, coordsRect[i].Y / 2, w / 2, h / 2);
                }
                if (radioButtonGradientBrush.Checked == true)
                {
                    int gradMode = rand.Next(0, 3);
                    Rectangle rectangle = new Rectangle(coordsRect[i].X, coordsRect[i].Y, Convert.ToInt32(w), Convert.ToInt32(h));
                    LinearGradientBrush grad = new LinearGradientBrush(rectangle, newcl, newcl1, (LinearGradientMode)gradMode);
                    Pen pen = new Pen(color, 1);
                    grRect.DrawRectangle(pen, coordsRect[i].X / 2, coordsRect[i].Y / 2, w / 2, h / 2);
                    grMain.FillRectangle(grad, coordsRect[i].X, coordsRect[i].Y, w, h);

                }
                if (radioButtonTextureBrush.Checked == true)
                {
                    Rectangle rectangle = new Rectangle(coordsRect[i].X, coordsRect[i].Y, Convert.ToInt32(w), Convert.ToInt32(h));

                    TextureBrush myTextureBrush = new TextureBrush(arrayPic[rand.Next(0, 5)], WrapMode.Clamp);
                    grMain.FillRectangle(myTextureBrush, coordsRect[i].X, coordsRect[i].Y, w, h);
                    Pen pen = new Pen(color, 1);
                    grRect.DrawRectangle(pen, coordsRect[i].X / 2, coordsRect[i].Y / 2, w / 2, h / 2);

                }

            }

        }

        private void drawPie(int N)
        {
            Point[] coordsPie;
            coordsPie = new Point[N];
            float w = rand.Next(20, 200);
            float h = rand.Next(20, 200);
            for (int i = 0; i < coordsPie.Length; i++)
            {
                coordsPie[i].X = rand.Next(pictureBoxMain.Width-Convert.ToInt16(w));
                coordsPie[i].Y = rand.Next(pictureBoxMain.Height- Convert.ToInt16(h));

            }

            for (int i = 0; i < coordsPie.Length; i += 1)
            {
                Color color = Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255));
                Color newcl = Color.FromArgb(rand.Next(10, 90), color);
                Color color1 = Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255));
                Color newcl1 = Color.FromArgb(rand.Next(10, 90), color1);
                float startAngle = rand.Next(30, 90);
                float sweepAngle = rand.Next(30, 90);
                if (radioButtonOneColor.Checked==true)
                { 
                    SolidBrush brush = new SolidBrush(newcl);
                    grMain.FillPie(brush, coordsPie[i].X, coordsPie[i].Y, w, h, startAngle, sweepAngle);

                    Pen pen = new Pen(color, 1);
                    grPie.DrawPie(pen, coordsPie[i].X/2, coordsPie[i].Y/2, w/2, h/2, startAngle, sweepAngle);
                }
                if (radioButtonHatchBrush.Checked == true)
                {
                    int num = rand.Next(1, 40);
                    HatchBrush hb = new HatchBrush((HatchStyle)num, newcl, color1);
                    grMain.FillPie(hb, coordsPie[i].X / 2, coordsPie[i].Y / 2, w / 2, h / 2, startAngle, sweepAngle);
                    Pen pen = new Pen(color, 1);
                    grPie.DrawPie(pen, coordsPie[i].X / 2, coordsPie[i].Y / 2, w / 2, h / 2, startAngle, sweepAngle);

                }
                if (radioButtonGradientBrush.Checked == true)
                {
                    int gradMode = rand.Next(0, 3);
                    Rectangle rectangle = new Rectangle(coordsPie[i].X, coordsPie[i].Y, Convert.ToInt32(w), Convert.ToInt32(h));
                    LinearGradientBrush grad = new LinearGradientBrush(rectangle, newcl, newcl1, (LinearGradientMode)gradMode);
                    grMain.FillPie(grad, coordsPie[i].X / 2, coordsPie[i].Y / 2, w / 2, h / 2, startAngle, sweepAngle);
                    Pen pen = new Pen(color, 1);
                    grPie.DrawPie(pen, coordsPie[i].X / 2, coordsPie[i].Y / 2, w / 2, h / 2, startAngle, sweepAngle);
                }
                if (radioButtonTextureBrush.Checked == true)
                {
                    Rectangle rectangle = new Rectangle(coordsPie[i].X, coordsPie[i].Y, Convert.ToInt32(w), Convert.ToInt32(h));

                    TextureBrush myTextureBrush = new TextureBrush(arrayPic[rand.Next(0, 5)], WrapMode.Clamp);
                    grMain.FillPie(myTextureBrush, coordsPie[i].X / 2, coordsPie[i].Y / 2, w / 2, h / 2, startAngle, sweepAngle);
                    Pen pen = new Pen(color, 1);
                    grPie.DrawPie(pen, coordsPie[i].X / 2, coordsPie[i].Y / 2, w / 2, h / 2, startAngle, sweepAngle);
                }
            }

        }


         private void buttonStart_Click(object sender, EventArgs e)//в функции рисования эллипса пример узорной кисти
         {
            if  (radioButtonEver.Checked)
            {
               timerSpeed.Start();
            }
            if (radioButtonOne.Checked)
            {
                drawLine(1);
                drawEllipse(1);
                drawRectangle(1);
                drawPie(1);
            }
            else if (radioButtonCount.Checked)
            {
                int count = (int)numericUpDown1.Value;
                for (int i = 0; i < count; i++)
                {
                    drawLine(1);
                    drawEllipse(1);
                    drawRectangle(1);
                    drawPie(1);
                }
            }
                
        }




        private void buttonClear_Click(object sender, EventArgs e)
        {
            if (buttonClear.Enabled == true)
            {
                pictureBoxMain.Image = null;
                pictureBoxLine.Image = null;
                pictureBoxEllips.Image = null;
                pictureBoxSquare.Image = null;
                pictureBoxPie.Image = null;
            }
        }

        private void buttonCl1_Click(object sender, EventArgs e)
        {
            switch ((sender as Button).Tag)
            {
                case "1": pictureBoxLine.Image = null; break;
                case "2": pictureBoxEllips.Image = null; break;
                case "3": pictureBoxSquare.Image = null; break;
                case "4": pictureBoxPie.Image = null; break;
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            timerSpeed.Interval = trackBar1.Value;  //задание скорости
        }

        private void timerSpeed_Tick(object sender, EventArgs e)
        {
            drawLine(1);
            drawEllipse(1);
            drawRectangle(1);
            drawPie(1);
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            timerSpeed.Stop();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            grMain = pictureBoxMain.CreateGraphics();
            grLine = pictureBoxLine.CreateGraphics();
            grEllips = pictureBoxEllips.CreateGraphics();
            grRect = pictureBoxSquare.CreateGraphics();
            grPie = pictureBoxPie.CreateGraphics();
            Bitmap pic1 = Properties.Resources.flowers;
            Bitmap pic2 = Properties.Resources.marble;
            Bitmap pic3 = Properties.Resources.moon;
            Bitmap pic4 = Properties.Resources.titles;
            Bitmap pic5 = Properties.Resources.wave;
            List<Bitmap> imageList = new List<Bitmap>();
            imageList.Add(pic1);
            imageList.Add(pic2);
            imageList.Add(pic3);
            imageList.Add(pic4);
            imageList.Add(pic5);
            arrayPic = imageList.ToArray();
        }
    }
}











