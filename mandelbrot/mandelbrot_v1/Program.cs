using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;


namespace Mandelbrot
{
    class Program
    {
        static void Main(string[] args)
        {

            System.Windows.Forms.Application.Run(new scherm());
        }
        class scherm : Form
        {
            //declaraties voor de interface
            TextBox invoerMiddenX, invoerMiddenY, invoerSchaal, invoerMax;
            Label   labelMiddenX, labelMiddenY, labelSchaal, labelMax;
            Button  knopGaan;
            Panel   tekenVeld;
            

            public scherm()
            {
                //de volgede methode zorgt voor de algemene opbouw van de interface(labels, textboxes en buttons)
                maakInterface();

                //vul tekenscherm
                vulTekenScherm();            
               





            }
            public void maakInterface()
            {
                //maak scherm waar alles op geplaatst wordt
                this.ClientSize = new Size(450, 600);

                //labelMiddenX
                labelMiddenX = new Label();
                labelMiddenX.Location = new Point(20, 30);
                labelMiddenX.Size = new Size(60, 20);
                labelMiddenX.Text = "midden X:";
                this.Controls.Add(labelMiddenX);

                //labelMiddeny
                labelMiddenY = new Label();
                labelMiddenY.Location = new Point(20, 60);
                labelMiddenY.Size = new Size(60, 20);
                labelMiddenY.Text = "midden Y:";
                this.Controls.Add(labelMiddenY);

                //labelSchaal
                labelSchaal = new Label();
                labelSchaal.Location = new Point(200, 30);
                labelSchaal.Size = new Size(50, 20);
                labelSchaal.Text = "schaal :";
                this.Controls.Add(labelSchaal);

                //labelMax
                labelMax = new Label();
                labelMax.Location = new Point(200, 60);
                labelMax.Size = new Size(50, 20);
                labelMax.Text = "max :";
                this.Controls.Add(labelMax);

                //textbox invoermiddenx
                invoerMiddenX= new TextBox();
                invoerMiddenX.Location = new Point(90,25);
                invoerMiddenX.Size = new Size(100, 30);
                invoerMiddenX.Text = "0";
                this.Controls.Add(invoerMiddenX);

                //textbox invoermiddenY
                invoerMiddenY = new TextBox();
                invoerMiddenY.Location = new Point(90, 55);
                invoerMiddenY.Size = new Size(100, 30);
                invoerMiddenY.Text = "0";
                this.Controls.Add(invoerMiddenY);

                //textbox invoerSchaal
                invoerSchaal = new TextBox();
                invoerSchaal.Location = new Point(250, 25);
                invoerSchaal.Size = new Size(100, 30);
                invoerSchaal.Text = "1";
                this.Controls.Add(invoerSchaal);

                //textbox invoerMax
                invoerMax = new TextBox();
                invoerMax.Location = new Point(250, 55);
                invoerMax.Size = new Size(100, 30);
                invoerMax.Text = "0";
                this.Controls.Add(invoerMax);

                //button knopGaan
                knopGaan = new Button();
                knopGaan.Location = new Point(375, 25);
                knopGaan.Size = new Size(50, 35);
                knopGaan.Text = "gaan";
                this.Controls.Add(knopGaan);

                //Panel tekenVeld
                tekenVeld = new Panel();
                tekenVeld.Location = new Point(25, 175);
                tekenVeld.Size = new Size(400,400);
                this.Controls.Add(tekenVeld);

            }

            public void vulTekenScherm()
            {
                tekenVeld.Paint += new PaintEventHandler(Paint_tekenVeld);
            }

            private void Paint_tekenVeld(object o, PaintEventArgs pea)
            {
                Graphics gr = pea.Graphics;
                gr.DrawLine(Pens.Black, 0,0, 0, 399);
                gr.DrawLine(Pens.Black, 0, 0, 399, 0);
                gr.DrawLine(Pens.Black, 0, 399, 399, 399);
                gr.DrawLine(Pens.Black, 399, 0, 399, 399);
                gr.DrawString("Hier komt de mandelbrot", new Font("Tahoma", 20), Brushes.Black, 10, 20 );
                    }


            private void bereken(object o, System.EventArgs e)
            {
            }
        }
    }
}
