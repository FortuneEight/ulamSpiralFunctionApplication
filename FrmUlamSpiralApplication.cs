using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ulamSpiralFunctionApplication
{
    public partial class FrmUlamSpiralApplication : Form
    {
        static int LENGTH = 7;
        static Button[] btnRC = new Button[LENGTH * LENGTH];
        static int BUTTONW;
        int WIDTH;

        Panel PnlThings;
        public FrmUlamSpiralApplication()
        {
            InitializeComponent();
        }

        private void FrmUlamSpiralApplication_Load(object sender, EventArgs e)
        {
            this.ClientSize = new Size(600, 600);

            PnlThings = new Panel()
            {
                Dock = DockStyle.Fill
            };

            this.Controls.Add(PnlThings);

            WIDTH = Convert.ToInt32(PnlThings.Width);
            BUTTONW = WIDTH / LENGTH;

            DrawButtons();
        }

        public void DrawButtons()
        {
            //displays the ulam spiral

            for (int i = 0; i < (LENGTH * LENGTH); i++)
            {
                //x and y
                //int x = Convert.ToInt32((UlamSpiral(i).X * 30) + (600));
                //int y = Convert.ToInt32((UlamSpiral(i).Y * 30) + (600));



                //makes a new instance of a Button
                //btnTest = new Button
                int upperLC = (WIDTH - BUTTONW) / 2;

                btnRC[i] = new Button
                {
                    //sets correct parameters
                    Location = new Point(Convert.ToInt32((UlamSpiral(i).X * BUTTONW) + upperLC), Convert.ToInt32((UlamSpiral(i).Y * BUTTONW) + upperLC)),
                    Size = new Size(BUTTONW, BUTTONW),
                    Text = i.ToString(),
                    BackColor = Color.Green,
                    

                    //Location = new Point(100, 100),
                    //Size = new Size(55, 55),
                    //BackColor = Color.Red,
                    //Text = 1.ToString()
                };

                //MessageBox.Show($"{btnRC[i].Location}");
                //adds button
                PnlThings.Controls.Add(btnRC[i]);
                //PnlThings.Controls.Add(btnTest);
            }
        }

        public Point UlamSpiral(int index)
        {
            //gives a point according to formulas

            double p = Math.Floor(Math.Sqrt(4 * index + 1));
            double q = index - Math.Floor((p * p) / 4);

            int A;
            int B;
            int C;

            //setting A, B, and C
            A = Convert.ToInt32(q);
            B = Convert.ToInt32(Math.Floor((p + 2) / 4));
            C = Convert.ToInt32(Math.Floor((p + 1) / 4));

            //Point called coordinate
            Point coordinate = new Point();

            int zX; int zY;
            int P = Convert.ToInt32(p);

            switch (P % 4)
            {
                case 0:
                    zX = A - C;
                    zY = -B;
                    //sets coordinates
                    coordinate.X = zX;
                    coordinate.Y = zY;
                    //breaks into next switch statement
                    break;
                case 1:
                    zX = B;
                    zY = A - C;
                    //sets coordinates
                    coordinate.X = zX;
                    coordinate.Y = zY;
                    //breaks into next switch statement
                    break;
                case 2:
                    zX = C - A;
                    zY = B;
                    //sets coordinates
                    coordinate.X = zX;
                    coordinate.Y = zY;
                    //breaks into next switch statement
                    break;
                case 3:
                    zX = B * -1;
                    zY = C - A;
                    //sets coordinates
                    coordinate.X = zX;
                    coordinate.Y = zY;
                    //breaks into next switch statement
                    break;
            }

            return coordinate;
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            //displays the ulam spiral

            for (int i = 0; i < (LENGTH * LENGTH); i++)
            {
                //x and y
                //int x = Convert.ToInt32((UlamSpiral(i).X * 30) + (600));
                //int y = Convert.ToInt32((UlamSpiral(i).Y * 30) + (600));

                int WIDTH = Convert.ToInt32(PnlThings.Width);

                //makes a new instance of a Button
                //btnTest = new Button
                btnRC[i] = new Button
                {
                    //sets correct parameters
                    Location = new Point(Convert.ToInt32((UlamSpiral(i).X * BUTTONW) + (WIDTH / 2)), Convert.ToInt32((UlamSpiral(i).Y * BUTTONW) + (WIDTH / 2))),
                    Size = new Size(BUTTONW, BUTTONW),
                    Text = i.ToString(),
                    BackColor = Color.Green,

                    //Location = new Point(100, 100),
                    //Size = new Size(55, 55),
                    //BackColor = Color.Red,
                    //Text = 1.ToString()
                };

                //MessageBox.Show($"{btnRC[i].Location}");
                //adds button
                PnlThings.Controls.Add(btnRC[i]);
                //PnlThings.Controls.Add(btnTest);
            }
        }
    }
}
