using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace itogovoe4pr_game_end
{
    public partial class Form1 : Form
    {
        private int rI, rJ; //для генерации функции
        private PictureBox fruit;
        private int dirx, diry; //движение котика
        private int width = 900; //размеры окошка
        private int height = 800;
        private int sizeofsides = 40; //размер игрока

        public Form1()
        {
            InitializeComponent();

            dirx = 1;
            diry = 0;
            fruit = new PictureBox();
            fruit.BackColor = Color.Yellow;
            fruit.Size = new Size(sizeofsides, sizeofsides);
            this.Width = width;//присвоение значений игровому окну
            this.Height = height;
            generateMap();
            timer.Tick += new EventHandler(update); //создание обработчика событий для таймера с интервалом
            timer.Interval = 500;
            timer.Start();
            this.KeyDown += new KeyEventHandler (OKP);
        }

        private void generateFruit()
        {
            Random.r = new Random();
            rI = rI.Next(0, width - sizeofsides);
            int tempI = rI % sizeofsides; //остаток от деления

        }

        private void generateMap() //генерация карты
        {
            for(int i=0; i<Width / sizeofsides; i++) //горизонталь
            {
                PictureBox pic = new PictureBox();
                pic.BackColor = Color.Black;
                pic.Location = new Point(0, sizeofsides * i);
                pic.Size = new Size(width - 100, 1);
                this.Controls.Add(pic);
            }

            for (int i = 0; i <= height / sizeofsides; i++) //горизонталь
            {
                PictureBox pic = new PictureBox();
                pic.BackColor = Color.Black;
                pic.Location = new Point(sizeofsides * i, 0);
                pic.Size = new Size(1,width);
                this.Controls.Add(pic);

            }
        }

        private void update (Object myObject, EventArgs eventArgs)
        {
            cube.Location = new Point(cube.Location.X + dirx * sizeofsides, cube.Location.Y + diry * sizeofsides);
        }

        private void OKP(object sender, KeyEventArgs e)
        {
            //обработчик нажатия клавиатуры
            switch (e.KeyCode.ToString())
            {
                case "Right":
                    //cube.Location = new Point(cube.Location.X + sizeofsides, cube.Location.Y);
                    dirx = 1;
                    diry = 0;
                    break;

                case "Left":
                    //cube.Location = new Point(cube.Location.X - sizeofsides, cube.Location.Y);
                    dirx = -1;
                    diry = 0;
                    break;

                case "Up":
                    //cube.Location = new Point(cube.Location.X, cube.Location.Y-sizeofsides);
                    diry = -1;
                    dirx = 0;
                    break;

                case "Down":
                    //cube.Location = new Point(cube.Location.X, cube.Location.Y+sizeofsides);
                    diry = 1;
                    dirx = 0;
                    break;
            }
        }






    }
}
