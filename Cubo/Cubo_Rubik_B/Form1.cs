using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using AForge;
using AForge.Imaging;
using AForge.Imaging.Filters;
using AForge.Math.Geometry;
using AForge.Video;
using AForge.Video.DirectShow;
using Point = AForge.Point;
using CubeXdotNET;
using System.IO.Ports;

namespace Cubo_Rubik
{
    public partial class Form1 : Form
    {
        private FilterInfoCollection VideoCapTureDevices;
        private VideoCaptureDevice Video;
        public Bitmap image;
        public int R;
        public int R1;
        public int R2;
        public int G = 0;
        public bool C1 = false;
        public string S;

        public Form1()
        {
            InitializeComponent();
            Tabla_Color.Rows.Add(8);
        }



        #region Mover Arrastrar Formulario
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void lblform_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        #endregion


        #region Botones de Ventana
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            if(Video != null)
            {
                Video.Stop();
            }
            Application.Exit();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        #endregion



        private void Form1_Load(object sender, EventArgs e)
        {
            VideoCapTureDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo VideoCaptureDevice in VideoCapTureDevices)
            {

                comboBox1.Items.Add(VideoCaptureDevice.Name);

            }

            comboBox1.SelectedIndex = 0;
        }


        private void BtnGrabar_Click(object sender, EventArgs e)
        {
            Video = new VideoCaptureDevice(VideoCapTureDevices[comboBox1.SelectedIndex].MonikerString);
            Video.NewFrame += new NewFrameEventHandler(Grabar);
            Video.Start();
        }

        void Grabar(object sender, NewFrameEventArgs eventArgs)
        {
            image = (Bitmap)eventArgs.Frame.Clone();


            pictureBox1.Image = image;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Color ColorCubo;

            ColorCubo = image.GetPixel(170, 75);

            Tabla_Color.Rows[0].Cells[0].Value = 1;
            Tabla_Color.Rows[0].Cells[1].Style.BackColor = ColorCubo;
            Tabla_Color.Rows[0].Cells[3].Value = ColorCubo.R.ToString() + "," + ColorCubo.G.ToString() + "," + ColorCubo.B.ToString();

            R = ColorCubo.R - ColorCubo.G;
            R1 = ColorCubo.R - ColorCubo.B;
            R2 = ColorCubo.G - ColorCubo.B;

            if (ColorCubo.R <= 255 && ColorCubo.R >= 100 && ColorCubo.G <= 255 && ColorCubo.G >= 100 && ColorCubo.B <= 255 && ColorCubo.B >= 100 && R <= 40 && R >= -55 && R1 <= 20 && R1 >= -80 && R2 <= 20 && R2 >= -50)
            {
                C1 = true;
                Tabla_Color.Rows[0].Cells[2].Value = "White";
                S = S + 'w';
            }

            R = ColorCubo.G - ColorCubo.B;

            R1 = ColorCubo.R - ColorCubo.G;

            if (ColorCubo.R >= ColorCubo.G && ColorCubo.R >= ColorCubo.B && ColorCubo.R <= 255 && ColorCubo.R >= 100 && ColorCubo.G <= 150 && ColorCubo.G >= 0 && ColorCubo.B <= 210 && ColorCubo.B >= 0 && R >= -80 && R <= 12 && C1 == false)
            {
                C1 = true;
                Tabla_Color.Rows[0].Cells[2].Value = "Red";
                S = S + 'r';
            }

            if (ColorCubo.R >= ColorCubo.G && ColorCubo.R >= ColorCubo.B && ColorCubo.R <= 255 && ColorCubo.R >= 100 && ColorCubo.G <= 220 && ColorCubo.G >= 0 && ColorCubo.B <= 230 && ColorCubo.B >= 0 && R >= -50 && R <= 90 && R1 >= 15 && C1 == false)
            {
                C1 = true;
                Tabla_Color.Rows[0].Cells[2].Value = "Orange";
                S = S + 'o';
            }

            R = ColorCubo.R - ColorCubo.B;

            if (ColorCubo.G >= ColorCubo.R && ColorCubo.G >= ColorCubo.B && ColorCubo.G <= 255 && ColorCubo.G >= 80 && ColorCubo.R <= 170 && ColorCubo.R >= 0 && ColorCubo.B <= 220 && ColorCubo.B >= 0 && R >= -140 && R <= 70 && C1 == false)
            {
                C1 = true;
                Tabla_Color.Rows[0].Cells[2].Value = "Green";
                S = S + 'g';
            }

            R = ColorCubo.R - ColorCubo.G;

            if (ColorCubo.B >= ColorCubo.G && ColorCubo.B >= ColorCubo.R && ColorCubo.B <= 255 && ColorCubo.B >= 20 && ColorCubo.R <= 180 && ColorCubo.R >= 0 && ColorCubo.G <= 200 && ColorCubo.G >= 0 && R >= -200 && R <= 30 && C1 == false)
            {
                C1 = true;
                Tabla_Color.Rows[0].Cells[2].Value = "Blue";
                S = S + 'b';
            }

            else
            if (C1 == false)
            {
                Tabla_Color.Rows[0].Cells[2].Value = "Yellow";
                S = S + 'y';
            }

            C1 = false;

            ColorCubo = image.GetPixel(325, 78);
            Tabla_Color.Rows[1].Cells[0].Value = 2;
            Tabla_Color.Rows[1].Cells[1].Style.BackColor = ColorCubo;
            Tabla_Color.Rows[1].Cells[3].Value = ColorCubo.R.ToString() + "," + ColorCubo.G.ToString() + "," + ColorCubo.B.ToString();

            R = ColorCubo.R - ColorCubo.G;
            R1 = ColorCubo.R - ColorCubo.B;
            R2 = ColorCubo.G - ColorCubo.B;


            if (ColorCubo.R <= 255 && ColorCubo.R >= 100 && ColorCubo.G <= 255 && ColorCubo.G >= 100 && ColorCubo.B <= 255 && ColorCubo.B >= 100 && R <= 40 && R >= -55 && R1 <= 20 && R1 >= -80 && R2 <= 20 && R2 >= -50)
            {
                C1 = true;
                Tabla_Color.Rows[1].Cells[2].Value = "White";
                S = S + 'w';
            }

            R = ColorCubo.G - ColorCubo.B;

            R1 = ColorCubo.R - ColorCubo.G;

            if (ColorCubo.R >= ColorCubo.G && ColorCubo.R >= ColorCubo.B && ColorCubo.R <= 255 && ColorCubo.R >= 100 && ColorCubo.G <= 150 && ColorCubo.G >= 0 && ColorCubo.B <= 210 && ColorCubo.B >= 0 && R >= -80 && R <= 12 && C1 == false)
            {
                C1 = true;
                Tabla_Color.Rows[1].Cells[2].Value = "Red";
                S = S + 'r';
            }

            if (ColorCubo.R >= ColorCubo.G && ColorCubo.R >= ColorCubo.B && ColorCubo.R <= 255 && ColorCubo.R >= 100 && ColorCubo.G <= 220 && ColorCubo.G >= 0 && ColorCubo.B <= 230 && ColorCubo.B >= 0 && R >= -50 && R <= 90 && R1 >= 15 && C1 == false)
            {
                C1 = true;
                Tabla_Color.Rows[1].Cells[2].Value = "Orange";
                S = S + 'o';
            }

            R = ColorCubo.R - ColorCubo.B;

            if (ColorCubo.G >= ColorCubo.R && ColorCubo.G >= ColorCubo.B && ColorCubo.G <= 255 && ColorCubo.G >= 80 && ColorCubo.R <= 170 && ColorCubo.R >= 0 && ColorCubo.B <= 220 && ColorCubo.B >= 0 && R >= -140 && R <= 70 && C1 == false)
            {
                C1 = true;
                Tabla_Color.Rows[1].Cells[2].Value = "Green";
                S = S + 'g';
            }

            R = ColorCubo.R - ColorCubo.G;

            if (ColorCubo.B >= ColorCubo.G && ColorCubo.B >= ColorCubo.R && ColorCubo.B <= 255 && ColorCubo.B >= 20 && ColorCubo.R <= 180 && ColorCubo.R >= 0 && ColorCubo.G <= 200 && ColorCubo.G >= 0 && R >= -200 && R <= 30 && C1 == false)
            {
                C1 = true;
                Tabla_Color.Rows[1].Cells[2].Value = "Blue";
                S = S + 'b';
            }

            else
            if (C1 == false)
            {
                Tabla_Color.Rows[1].Cells[2].Value = "Yellow";
                S = S + 'y';
            }

            C1 = false;

            ColorCubo = image.GetPixel(460, 75);

            Tabla_Color.Rows[2].Cells[0].Value = 3;
            Tabla_Color.Rows[2].Cells[1].Style.BackColor = ColorCubo;
            Tabla_Color.Rows[2].Cells[3].Value = ColorCubo.R.ToString() + "," + ColorCubo.G.ToString() + "," + ColorCubo.B.ToString();

            R = ColorCubo.R - ColorCubo.G;
            R1 = ColorCubo.R - ColorCubo.B;
            R2 = ColorCubo.G - ColorCubo.B;


            if (ColorCubo.R <= 255 && ColorCubo.R >= 100 && ColorCubo.G <= 255 && ColorCubo.G >= 100 && ColorCubo.B <= 255 && ColorCubo.B >= 100 && R <= 40 && R >= -55 && R1 <= 20 && R1 >= -80 && R2 <= 20 && R2 >= -50)
            {
                C1 = true;
                Tabla_Color.Rows[2].Cells[2].Value = "White";
                S = S + 'w';
            }

            R = ColorCubo.G - ColorCubo.B;

            R1 = ColorCubo.R - ColorCubo.G;

            if (ColorCubo.R >= ColorCubo.G && ColorCubo.R >= ColorCubo.B && ColorCubo.R <= 255 && ColorCubo.R >= 100 && ColorCubo.G <= 150 && ColorCubo.G >= 0 && ColorCubo.B <= 210 && ColorCubo.B >= 0 && R >= -80 && R <= 12 && C1 == false)
            {
                C1 = true;
                Tabla_Color.Rows[2].Cells[2].Value = "Red";
                S = S + 'r';
            }

            if (ColorCubo.R >= ColorCubo.G && ColorCubo.R >= ColorCubo.B && ColorCubo.R <= 255 && ColorCubo.R >= 100 && ColorCubo.G <= 220 && ColorCubo.G >= 0 && ColorCubo.B <= 230 && ColorCubo.B >= 0 && R >= -50 && R <= 90 && R1 >= 15 && C1 == false)
            {
                C1 = true;
                Tabla_Color.Rows[2].Cells[2].Value = "Orange";
                S = S + 'o';
            }

            R = ColorCubo.R - ColorCubo.B;

            if (ColorCubo.G >= ColorCubo.R && ColorCubo.G >= ColorCubo.B && ColorCubo.G <= 255 && ColorCubo.G >= 80 && ColorCubo.R <= 170 && ColorCubo.R >= 0 && ColorCubo.B <= 220 && ColorCubo.B >= 0 && R >= -140 && R <= 70 && C1 == false)
            {
                C1 = true;
                Tabla_Color.Rows[2].Cells[2].Value = "Green";
                S = S + 'g';
            }

            R = ColorCubo.R - ColorCubo.G;

            if (ColorCubo.B >= ColorCubo.G && ColorCubo.B >= ColorCubo.R && ColorCubo.B <= 255 && ColorCubo.B >= 20 && ColorCubo.R <= 180 && ColorCubo.R >= 0 && ColorCubo.G <= 200 && ColorCubo.G >= 0 && R >= -200 && R <= 30 && C1 == false)
            {
                C1 = true;
                Tabla_Color.Rows[2].Cells[2].Value = "Blue";
                S = S + 'b';
            }

            else
            if (C1 == false)
            {
                Tabla_Color.Rows[2].Cells[2].Value = "Yellow";
                S = S + 'y';
            }

            C1 = false;

            ColorCubo = image.GetPixel(168, 197);

            Tabla_Color.Rows[3].Cells[0].Value = 4;
            Tabla_Color.Rows[3].Cells[1].Style.BackColor = ColorCubo;
            Tabla_Color.Rows[3].Cells[3].Value = ColorCubo.R.ToString() + "," + ColorCubo.G.ToString() + "," + ColorCubo.B.ToString();

            R = ColorCubo.R - ColorCubo.G;
            R1 = ColorCubo.R - ColorCubo.B;
            R2 = ColorCubo.G - ColorCubo.B;


            if ( ColorCubo.R <= 255 && ColorCubo.R >= 100 && ColorCubo.G <= 255 && ColorCubo.G >= 100 && ColorCubo.B <= 255 && ColorCubo.B >= 100 && R <= 40 && R >= -55 && R1 <= 20 && R1 >= -80 && R2 <= 20 && R2 >= -50)
            {
                C1 = true;
                Tabla_Color.Rows[3].Cells[2].Value = "White";
                S = S + 'w';
            }

            R = ColorCubo.G - ColorCubo.B;

            R1 = ColorCubo.R - ColorCubo.G;

            if (ColorCubo.R >= ColorCubo.G && ColorCubo.R >= ColorCubo.B && ColorCubo.R <= 255 && ColorCubo.R >= 100 && ColorCubo.G <= 150 && ColorCubo.G >= 0 && ColorCubo.B <= 210 && ColorCubo.B >= 0 && R >= -80 && R <= 12 && C1 == false)
            {
                C1 = true;
                Tabla_Color.Rows[3].Cells[2].Value = "Red";
                S = S + 'r';
            }

            if (ColorCubo.R >= ColorCubo.G && ColorCubo.R >= ColorCubo.B && ColorCubo.R <= 255 && ColorCubo.R >= 100 && ColorCubo.G <= 220 && ColorCubo.G >= 0 && ColorCubo.B <= 230 && ColorCubo.B >= 0 && R >= -50 && R <= 90 && R1 >= 15 && C1 == false)
            {
                C1 = true;
                Tabla_Color.Rows[3].Cells[2].Value = "Orange";
                S = S + 'o';
            }

            R = ColorCubo.R - ColorCubo.B;

            if (ColorCubo.G >= ColorCubo.R && ColorCubo.G >= ColorCubo.B && ColorCubo.G <= 255 && ColorCubo.G >= 80 && ColorCubo.R <= 170 && ColorCubo.R >= 0 && ColorCubo.B <= 220 && ColorCubo.B >= 0 && R >= -140 && R <= 70 && C1 == false)
            {
                C1 = true;
                Tabla_Color.Rows[3].Cells[2].Value = "Green";
                S = S + 'g';
            }

            R = ColorCubo.R - ColorCubo.G;

            if (ColorCubo.B >= ColorCubo.G && ColorCubo.B >= ColorCubo.R && ColorCubo.B <= 255 && ColorCubo.B >= 20 && ColorCubo.R <= 180 && ColorCubo.R >= 0 && ColorCubo.G <= 200 && ColorCubo.G >= 0 && R >= -200 && R <= 30 && C1 == false)
            {
                C1 = true;
                Tabla_Color.Rows[3].Cells[2].Value = "Blue";
                S = S + 'b';
            }

            else
            if (C1 == false)
            {
                Tabla_Color.Rows[3].Cells[2].Value = "Yellow";
                S = S + 'y';
            }

            C1 = false;

            ColorCubo = image.GetPixel(315, 207);

            Tabla_Color.Rows[4].Cells[0].Value = 5;
            Tabla_Color.Rows[4].Cells[1].Style.BackColor = ColorCubo;
            Tabla_Color.Rows[4].Cells[3].Value = ColorCubo.R.ToString() + "," + ColorCubo.G.ToString() + "," + ColorCubo.B.ToString();

            R = ColorCubo.R - ColorCubo.G;
            R1 = ColorCubo.R - ColorCubo.B;
            R2 = ColorCubo.G - ColorCubo.B;


            if (ColorCubo.R <= 255 && ColorCubo.R >= 100 && ColorCubo.G <= 255 && ColorCubo.G >= 100 && ColorCubo.B <= 255 && ColorCubo.B >= 100 && R <= 40 && R >= -55 && R1 <= 20 && R1 >= -80 && R2 <= 20 && R2 >= -50)
            {
                C1 = true;
                Tabla_Color.Rows[4].Cells[2].Value = "White";
                S = S + 'w';
            }

            R = ColorCubo.G - ColorCubo.B;

            R1 = ColorCubo.R - ColorCubo.G;

            if (ColorCubo.R >= ColorCubo.G && ColorCubo.R >= ColorCubo.B && ColorCubo.R <= 255 && ColorCubo.R >= 100 && ColorCubo.G <= 150 && ColorCubo.G >= 0 && ColorCubo.B <= 210 && ColorCubo.B >= 0 && R >= -80 && R <= 12 && C1 == false)
            {
                C1 = true;
                Tabla_Color.Rows[4].Cells[2].Value = "Red";
                S = S + 'r';
            }

            if (ColorCubo.R >= ColorCubo.G && ColorCubo.R >= ColorCubo.B && ColorCubo.R <= 255 && ColorCubo.R >= 100 && ColorCubo.G <= 220 && ColorCubo.G >= 0 && ColorCubo.B <= 230 && ColorCubo.B >= 0 && R >= -50 && R <= 90 && R1 >= 15 && C1 == false)
            {
                C1 = true;
                Tabla_Color.Rows[4].Cells[2].Value = "Orange";
                S = S + 'o';
            }

            R = ColorCubo.R - ColorCubo.B;

            if (ColorCubo.G >= ColorCubo.R && ColorCubo.G >= ColorCubo.B && ColorCubo.G <= 255 && ColorCubo.G >= 80 && ColorCubo.R <= 170 && ColorCubo.R >= 0 && ColorCubo.B <= 220 && ColorCubo.B >= 0 && R >= -140 && R <= 70 && C1 == false)
            {
                C1 = true;
                Tabla_Color.Rows[4].Cells[2].Value = "Green";
                S = S + 'g';
            }

            R = ColorCubo.R - ColorCubo.G;

            if (ColorCubo.B >= ColorCubo.G && ColorCubo.B >= ColorCubo.R && ColorCubo.B <= 255 && ColorCubo.B >= 20 && ColorCubo.R <= 180 && ColorCubo.R >= 0 && ColorCubo.G <= 200 && ColorCubo.G >= 0 && R >= -200 && R <= 30 && C1 == false)
            {
                C1 = true;
                Tabla_Color.Rows[4].Cells[2].Value = "Blue";
                S = S + 'b';
            }

            else
            if (C1 == false)
            {
                Tabla_Color.Rows[4].Cells[2].Value = "Yellow";
                S = S + 'y';
            }

            C1 = false;

            ColorCubo = image.GetPixel(460, 207);

            Tabla_Color.Rows[5].Cells[0].Value = 6;
            Tabla_Color.Rows[5].Cells[1].Style.BackColor = ColorCubo;
            Tabla_Color.Rows[5].Cells[3].Value = ColorCubo.R.ToString() + "," + ColorCubo.G.ToString() + "," + ColorCubo.B.ToString();

            R = ColorCubo.R - ColorCubo.G;
            R1 = ColorCubo.R - ColorCubo.B;
            R2 = ColorCubo.G - ColorCubo.B;


            if (ColorCubo.R <= 255 && ColorCubo.R >= 100 && ColorCubo.G <= 255 && ColorCubo.G >= 100 && ColorCubo.B <= 255 && ColorCubo.B >= 100 && R <= 40 && R >= -55 && R1 <= 20 && R1 >= -80 && R2 <= 20 && R2 >= -50)
            {
                C1 = true;
                Tabla_Color.Rows[5].Cells[2].Value = "White";
                S = S + 'w';
            }

            R = ColorCubo.G - ColorCubo.B;

            R1 = ColorCubo.R - ColorCubo.G;

            if (ColorCubo.R >= ColorCubo.G && ColorCubo.R >= ColorCubo.B && ColorCubo.R <= 255 && ColorCubo.R >= 100 && ColorCubo.G <= 150 && ColorCubo.G >= 0 && ColorCubo.B <= 210 && ColorCubo.B >= 0 && R >= -80 && R <= 12 && C1 == false)
            {
                C1 = true;
                Tabla_Color.Rows[5].Cells[2].Value = "Red";
                S = S + 'r';
            }

            if (ColorCubo.R >= ColorCubo.G && ColorCubo.R >= ColorCubo.B && ColorCubo.R <= 255 && ColorCubo.R >= 100 && ColorCubo.G <= 220 && ColorCubo.G >= 0 && ColorCubo.B <= 230 && ColorCubo.B >= 0 && R >= -50 && R <= 90 && R1 >= 15 && C1 == false)
            {
                C1 = true;
                Tabla_Color.Rows[5].Cells[2].Value = "Orange";
                S = S + 'o';
            }

            R = ColorCubo.R - ColorCubo.B;

            if (ColorCubo.G >= ColorCubo.R && ColorCubo.G >= ColorCubo.B && ColorCubo.G <= 255 && ColorCubo.G >= 80 && ColorCubo.R <= 170 && ColorCubo.R >= 0 && ColorCubo.B <= 220 && ColorCubo.B >= 0 && R >= -140 && R <= 70 && C1 == false)
            {
                C1 = true;
                Tabla_Color.Rows[5].Cells[2].Value = "Green";
                S = S + 'g';
            }

            R = ColorCubo.R - ColorCubo.G;

            if (ColorCubo.B >= ColorCubo.G && ColorCubo.B >= ColorCubo.R && ColorCubo.B <= 255 && ColorCubo.B >= 20 && ColorCubo.R <= 180 && ColorCubo.R >= 0 && ColorCubo.G <= 200 && ColorCubo.G >= 0 && R >= -200 && R <= 30 && C1 == false)
            {
                C1 = true;
                Tabla_Color.Rows[5].Cells[2].Value = "Blue";
                S = S + 'b';
            }

            else
            if (C1 == false)
            {
                Tabla_Color.Rows[5].Cells[2].Value = "Yellow";
                S = S + 'y';
            }

            C1 = false;

            ColorCubo = image.GetPixel(170, 330);

            Tabla_Color.Rows[6].Cells[0].Value = 7;
            Tabla_Color.Rows[6].Cells[1].Style.BackColor = ColorCubo;
            Tabla_Color.Rows[6].Cells[3].Value = ColorCubo.R.ToString() + "," + ColorCubo.G.ToString() + "," + ColorCubo.B.ToString();

            R = ColorCubo.R - ColorCubo.G;
            R1 = ColorCubo.R - ColorCubo.B;
            R2 = ColorCubo.G - ColorCubo.B;


            if (ColorCubo.R <= 255 && ColorCubo.R >= 100 && ColorCubo.G <= 255 && ColorCubo.G >= 100 && ColorCubo.B <= 255 && ColorCubo.B >= 100 && R <= 40 && R >= -55 && R1 <= 20 && R1 >= -80 && R2 <= 20 && R2 >= -50)
            {
                C1 = true;
                Tabla_Color.Rows[6].Cells[2].Value = "White";
                S = S + 'w';
            }

            R = ColorCubo.G - ColorCubo.B;

            R1 = ColorCubo.R - ColorCubo.G;

            if (ColorCubo.R >= ColorCubo.G && ColorCubo.R >= ColorCubo.B && ColorCubo.R <= 255 && ColorCubo.R >= 100 && ColorCubo.G <= 150 && ColorCubo.G >= 0 && ColorCubo.B <= 210 && ColorCubo.B >= 0 && R >= -80 && R <= 12 && C1 == false)
            {
                C1 = true;
                Tabla_Color.Rows[6].Cells[2].Value = "Red";
                S = S + 'r';
            }

            if (ColorCubo.R >= ColorCubo.G && ColorCubo.R >= ColorCubo.B && ColorCubo.R <= 255 && ColorCubo.R >= 100 && ColorCubo.G <= 220 && ColorCubo.G >= 0 && ColorCubo.B <= 230 && ColorCubo.B >= 0 && R >= -50 && R <= 90 && R1 >= 15 && C1 == false)
            {
                C1 = true;
                Tabla_Color.Rows[6].Cells[2].Value = "Orange";
                S = S + 'o';
            }

            R = ColorCubo.R - ColorCubo.B;

            if (ColorCubo.G >= ColorCubo.R && ColorCubo.G >= ColorCubo.B && ColorCubo.G <= 255 && ColorCubo.G >= 80 && ColorCubo.R <= 170 && ColorCubo.R >= 0 && ColorCubo.B <= 220 && ColorCubo.B >= 0 && R >= -140 && R <= 70 && C1 == false)
            {
                C1 = true;
                Tabla_Color.Rows[6].Cells[2].Value = "Green";
                S = S + 'g';
            }

            R = ColorCubo.R - ColorCubo.G;

            if (ColorCubo.B >= ColorCubo.G && ColorCubo.B >= ColorCubo.R && ColorCubo.B <= 255 && ColorCubo.B >= 20 && ColorCubo.R <= 180 && ColorCubo.R >= 0 && ColorCubo.G <= 200 && ColorCubo.G >= 0 && R >= -200 && R <= 30 && C1 == false)
            {
                C1 = true;
                Tabla_Color.Rows[6].Cells[2].Value = "Blue";
                S = S + 'b';
            }

            else
            if (C1 == false)
            {
                Tabla_Color.Rows[6].Cells[2].Value = "Yellow";
                S = S + 'y';
            }

            C1 = false;

            ColorCubo = image.GetPixel(322, 340);

            Tabla_Color.Rows[7].Cells[0].Value = 8;
            Tabla_Color.Rows[7].Cells[1].Style.BackColor = ColorCubo;
            Tabla_Color.Rows[7].Cells[3].Value = ColorCubo.R.ToString() + "," + ColorCubo.G.ToString() + "," + ColorCubo.B.ToString();

            R = ColorCubo.R - ColorCubo.G;
            R1 = ColorCubo.R - ColorCubo.B;
            R2 = ColorCubo.G - ColorCubo.B;

            if ( ColorCubo.R <= 255 && ColorCubo.R >= 100 && ColorCubo.G <= 255 && ColorCubo.G >= 100 && ColorCubo.B <= 255 && ColorCubo.B >= 100 && R <= 40 && R >= -55 && R1 <= 20 && R1 >= -80 && R2 <= 20 && R2 >= -50)
            {
                C1 = true;
                Tabla_Color.Rows[7].Cells[2].Value = "White";
                S = S + 'w';
            }

            R = ColorCubo.G - ColorCubo.B;

            R1 = ColorCubo.R - ColorCubo.G;

            if (ColorCubo.R >= ColorCubo.G && ColorCubo.R >= ColorCubo.B && ColorCubo.R <= 255 && ColorCubo.R >= 100 && ColorCubo.G <= 150 && ColorCubo.G >= 0 && ColorCubo.B <= 210 && ColorCubo.B >= 0 && R >= -80 && R <= 12 && C1 == false)
            {
                C1 = true;
                Tabla_Color.Rows[7].Cells[2].Value = "Red";
                S = S + 'r';
            }

            if (ColorCubo.R >= ColorCubo.G && ColorCubo.R >= ColorCubo.B && ColorCubo.R <= 255 && ColorCubo.R >= 100 && ColorCubo.G <= 220 && ColorCubo.G >= 0 && ColorCubo.B <= 230 && ColorCubo.B >= 0 && R >= -50 && R <= 90 && R1 >= 15 && C1 == false)
            {
                C1 = true;
                Tabla_Color.Rows[7].Cells[2].Value = "Orange";
                S = S + 'o';
            }

            R = ColorCubo.R - ColorCubo.B;

            if (ColorCubo.G >= ColorCubo.R && ColorCubo.G >= ColorCubo.B && ColorCubo.G <= 255 && ColorCubo.G >= 80 && ColorCubo.R <= 170 && ColorCubo.R >= 0 && ColorCubo.B <= 220 && ColorCubo.B >= 0 && R >= -140 && R <= 70 && C1 == false)
            {
                C1 = true;
                Tabla_Color.Rows[7].Cells[2].Value = "Green";
                S = S + 'g';
            }

            R = ColorCubo.R - ColorCubo.G;

            if (ColorCubo.B >= ColorCubo.G && ColorCubo.B >= ColorCubo.R && ColorCubo.B <= 255 && ColorCubo.B >= 20 && ColorCubo.R <= 180 && ColorCubo.R >= 0 && ColorCubo.G <= 200 && ColorCubo.G >= 0 && R >= -200 && R <= 30 && C1 == false)
            {
                C1 = true;
                Tabla_Color.Rows[7].Cells[2].Value = "Blue";
                S = S + 'b';
            }

            else
            if (C1 == false)
            {
                Tabla_Color.Rows[7].Cells[2].Value = "Yellow";
                S = S + 'y';
            }

            C1 = false;

            ColorCubo = image.GetPixel(460, 330);

            Tabla_Color.Rows[8].Cells[0].Value = 9;
            Tabla_Color.Rows[8].Cells[1].Style.BackColor = ColorCubo;
            Tabla_Color.Rows[8].Cells[3].Value = ColorCubo.R.ToString() + "," + ColorCubo.G.ToString() + "," + ColorCubo.B.ToString();

            R = ColorCubo.R - ColorCubo.G;
            R1 = ColorCubo.R - ColorCubo.B;
            R2 = ColorCubo.G - ColorCubo.B;

            if (ColorCubo.R <= 255 && ColorCubo.R >= 100 && ColorCubo.G <= 255 && ColorCubo.G >= 100 && ColorCubo.B <= 255 && ColorCubo.B >= 100 && R <= 40 && R >= -55 && R1 <= 20 && R1 >= -80 && R2 <= 20 && R2 >= -50)
            {
                C1 = true;
                Tabla_Color.Rows[8].Cells[2].Value = "White";
                S = S + 'w';
            }

            R = ColorCubo.G - ColorCubo.B;

            R1 = ColorCubo.R - ColorCubo.G;

            if (ColorCubo.R >= ColorCubo.G && ColorCubo.R >= ColorCubo.B && ColorCubo.R <= 255 && ColorCubo.R >= 100 && ColorCubo.G <= 150 && ColorCubo.G >= 0 && ColorCubo.B <= 210 && ColorCubo.B >= 0 && R >= -80 && R <= 12 && C1 == false)
            {
                C1 = true;
                Tabla_Color.Rows[8].Cells[2].Value = "Red";
                S = S + 'r';
            }

            if (ColorCubo.R >= ColorCubo.G && ColorCubo.R >= ColorCubo.B && ColorCubo.R <= 255 && ColorCubo.R >= 100 && ColorCubo.G <= 220 && ColorCubo.G >= 0 && ColorCubo.B <= 230 && ColorCubo.B >= 0 && R >= -50 && R <= 90 && R1 >= 15 && C1 == false)
            {
                C1 = true;
                Tabla_Color.Rows[8].Cells[2].Value = "Orange";
                S = S + 'o';
            }

            R = ColorCubo.R - ColorCubo.B;

            if (ColorCubo.G >= ColorCubo.R && ColorCubo.G >= ColorCubo.B && ColorCubo.G <= 255 && ColorCubo.G >= 80 && ColorCubo.R <= 170 && ColorCubo.R >= 0 && ColorCubo.B <= 220 && ColorCubo.B >= 0 && R >= -140 && R <= 70 && C1 == false)
            {
                C1 = true;
                Tabla_Color.Rows[8].Cells[2].Value = "Green";
                S = S + 'g';
            }

            R = ColorCubo.R - ColorCubo.G;

            if (ColorCubo.B >= ColorCubo.G && ColorCubo.B >= ColorCubo.R && ColorCubo.B <= 255 && ColorCubo.B >= 20 && ColorCubo.R <= 180 && ColorCubo.R >= 0 && ColorCubo.G <= 200 && ColorCubo.G >= 0 && R >= -200 && R <= 30 && C1 == false)
            {
                C1 = true;
                Tabla_Color.Rows[8].Cells[2].Value = "Blue";
                S = S + 'b';
            }

            else
            if (C1 == false)
            {
                Tabla_Color.Rows[8].Cells[2].Value = "Yellow";
                S = S + 'y';
            }


            C1 = false;

            lblConvinacion.Text = S;
            CubeState.Text = S;


            /*if(G == 0)
            {
                using (SerialPort serialport = new SerialPort("COM6", 9600))
                {
                    serialport.Open();
                    serialport.Write("W");
                }
            }


            if (G == 1)
            {
                using (SerialPort serialport = new SerialPort("COM6", 9600))
                {
                    serialport.Open();
                    serialport.Write("W");
                }
            }

            if (G == 2)
            {
                using (SerialPort serialport = new SerialPort("COM6", 9600))
                {
                    serialport.Open();
                    serialport.Write("W");
                }
            }

            if (G == 3)
            {
                using (SerialPort serialport = new SerialPort("COM6", 9600))
                {
                    serialport.Open();
                    serialport.Write("X");
                }
            }

            if (G == 4)
            {
                using (SerialPort serialport = new SerialPort("COM6", 9600))
                {
                    serialport.Open();
                    serialport.Write("Y");
                }
            }

            if (G == 5)
            {
                using (SerialPort serialport = new SerialPort("COM6", 9600))
                {
                    serialport.Open();
                    serialport.Write("Z");
                }
            }*/

            G++;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {

            Pen Pluma = new Pen(Color.Lime, 4);
            SolidBrush pen = new SolidBrush(Color.Red);

            e.Graphics.DrawRectangle(Pluma, 150, 55, 50, 50);
            e.Graphics.FillEllipse(pen, 170, 75, 10, 10);
            e.Graphics.DrawRectangle(Pluma, 298, 55, 50, 50);
            e.Graphics.FillEllipse(pen, 325, 78, 2, 2);
            e.Graphics.DrawRectangle(Pluma, 440, 55, 50, 50);
            e.Graphics.FillEllipse(pen, 460, 75, 10, 10);

            e.Graphics.DrawRectangle(Pluma, 150, 177, 50, 50);
            e.Graphics.FillEllipse(pen, 168, 197, 10, 10);
            e.Graphics.DrawRectangle(Pluma, 295, 187, 50, 50);
            e.Graphics.FillEllipse(pen, 315, 207, 10, 10);
            e.Graphics.DrawRectangle(Pluma, 440, 187, 50, 50);
            e.Graphics.FillEllipse(pen, 460, 207, 10, 10);

            e.Graphics.DrawRectangle(Pluma, 150, 310, 50, 50);
            e.Graphics.FillEllipse(pen, 170, 330, 10, 10);
            e.Graphics.DrawRectangle(Pluma, 302, 320, 50, 50);
            e.Graphics.FillEllipse(pen, 322, 340, 10, 10);
            e.Graphics.DrawRectangle(Pluma, 440, 310, 50, 50);
            e.Graphics.FillEllipse(pen, 460, 330, 10, 10);
        }

        private void SolveButton_Click(object sender, EventArgs e)
        {
            if (CubeState.Text.Length != 54 || !CubeState.Text.All(c => "gobryw".Contains(c))) // Invalid entry if user didn't enter 54 colors or if the input string contains other characters.
            {
                MessageBox.Show("Invalid Entry");
                return;
            }

            FridrichSolver Solver = new FridrichSolver(CubeState.Text);

            Solver.Solve();

            //Status after solving
            Soln.Text = Solver.Solution;
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            string texto = Soln.Text;

            string[] palabras = texto.Split(' ');

           foreach (string palabra in palabras)
            {
                Thread.Sleep(2000);

                if (palabra.Contains("R"))
                {
                    if (palabra.Contains("R'"))
                    {
                        using (SerialPort serialPort = new SerialPort("COM6", 9600))
                        {
                            serialPort.Open();
                            serialPort.Write("C"); // Enviar el comando '2' a la placa ESP32
                        }
                    }
                    else if (palabra.Contains("R2"))
                    {
                        using (SerialPort serialPort = new SerialPort("COM6", 9600))
                        {
                            serialPort.Open();
                            serialPort.Write("B"); // Enviar el comando '2' a la placa ESP32
                        }
                    }
                    else
                    {
                        using (SerialPort serialPort = new SerialPort("COM6", 9600))
                        {
                            serialPort.Open();
                            serialPort.Write("A"); // Enviar el comando '1' a la placa ESP32
                        }
                    }
                    continue; // Pasar a la siguiente palabra sin ejecutar el resto del código dentro del bucle
                }
                if (palabra.Contains("L"))
                {
                    if (palabra.Contains("L'"))
                    {
                        using (SerialPort serialPort = new SerialPort("COM6", 9600))
                        {
                            serialPort.Open();
                            serialPort.Write("F"); // Enviar el comando '2' a la placa ESP32
                        }
                    }
                    else if (palabra.Contains("L2"))
                    {
                        using (SerialPort serialPort = new SerialPort("COM6", 9600))
                        {
                            serialPort.Open();
                            serialPort.Write("E"); // Enviar el comando '2' a la placa ESP32
                        }
                    }
                    else
                    {
                        using (SerialPort serialPort = new SerialPort("COM6", 9600))
                        {
                            serialPort.Open();
                            serialPort.Write("D"); // Enviar el comando '1' a la placa ESP32
                        }
                    }
                    continue; // Pasar a la siguiente palabra sin ejecutar el resto del código dentro del bucle
                }
                if (palabra.Contains("F"))
                {
                    if (palabra.Contains("F'"))
                    {
                        using (SerialPort serialPort = new SerialPort("COM6", 9600))
                        {
                            serialPort.Open();
                            serialPort.Write("I"); // Enviar el comando '2' a la placa ESP32
                        }
                    }
                    else if (palabra.Contains("F2"))
                    {
                        using (SerialPort serialPort = new SerialPort("COM6", 9600))
                        {
                            serialPort.Open();
                            serialPort.Write("H"); // Enviar el comando '2' a la placa ESP32
                        }
                    }
                    else
                    {
                        using (SerialPort serialPort = new SerialPort("COM6", 9600))
                        {
                            serialPort.Open();
                            serialPort.Write("G"); // Enviar el comando '1' a la placa ESP32
                        }
                    }
                    continue; // Pasar a la siguiente palabra sin ejecutar el resto del código dentro del bucle
                }
                if (palabra.Contains("B"))
                {
                    if (palabra.Contains("B'"))
                    {
                        using (SerialPort serialPort = new SerialPort("COM6", 9600))
                        {
                            serialPort.Open();
                            serialPort.Write("L"); // Enviar el comando '2' a la placa ESP32
                        }
                    }
                    else if (palabra.Contains("B2"))
                    {
                        using (SerialPort serialPort = new SerialPort("COM6", 9600))
                        {
                            serialPort.Open();
                            serialPort.Write("K"); // Enviar el comando '2' a la placa ESP32
                        }
                    }
                    else
                    {
                        using (SerialPort serialPort = new SerialPort("COM6", 9600))
                        {
                            serialPort.Open();
                            serialPort.Write("J"); // Enviar el comando '1' a la placa ESP32
                        }
                    }
                    continue; // Pasar a la siguiente palabra sin ejecutar el resto del código dentro del bucle
                }
                if (palabra.Contains("U"))
                {
                    if (palabra.Contains("U'"))
                    {
                        using (SerialPort serialPort = new SerialPort("COM6", 9600))
                        {
                            serialPort.Open();
                            serialPort.Write("O"); // Enviar el comando '2' a la placa ESP32
                        }
                    }
                    else if (palabra.Contains("U2"))
                    {
                        using (SerialPort serialPort = new SerialPort("COM6", 9600))
                        {
                            serialPort.Open();
                            serialPort.Write("N"); // Enviar el comando '2' a la placa ESP32
                        }
                    }
                    else
                    {
                        using (SerialPort serialPort = new SerialPort("COM6", 9600))
                        {
                            serialPort.Open();
                            serialPort.Write("M"); // Enviar el comando '1' a la placa ESP32
                        }
                    }
                    continue; // Pasar a la siguiente palabra sin ejecutar el resto del código dentro del bucle
                }
                if (palabra.Contains("D"))
                {
                    if (palabra.Contains("D'"))
                    {
                        using (SerialPort serialPort = new SerialPort("COM6", 9600))
                        {
                            serialPort.Open();
                            serialPort.Write("R"); // Enviar el comando '2' a la placa ESP32
                        }
                    }
                    else if (palabra.Contains("D2"))
                    {
                        using (SerialPort serialPort = new SerialPort("COM6", 9600))
                        {
                            serialPort.Open();
                            serialPort.Write("Q"); // Enviar el comando '2' a la placa ESP32
                        }
                    }
                    else
                    {
                        using (SerialPort serialPort = new SerialPort("COM6", 9600))
                        {
                            serialPort.Open();
                            serialPort.Write("P"); // Enviar el comando '1' a la placa ESP32
                        }
                    }
                    continue; // Pasar a la siguiente palabra sin ejecutar el resto del código dentro del bucle
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SerialPort serialport  = new SerialPort("COM6", 9600))
            {
                serialport.Open();
                serialport.Write("1");
            }
        }

        private void button3_Click(object sende
            , EventArgs e)
        {
            using (SerialPort serialport = new SerialPort("COM6", 9600))
            {
                serialport.Open();
                serialport.Write("2");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (SerialPort serialport = new SerialPort("COM6", 9600))
            {
                serialport.Open();
                serialport.Write("3");
            }
        }
    }
}
