using System;
using System.Drawing;
using System.Windows.Forms;
using Mandelbrot_Set;

namespace Mandelbrot_Set {
    class scherm : Form {

        #region Properties
        
        //Declaraties voor de interface
        TextBox invoerMiddenX, invoerMiddenY, invoerSchaal, invoerMax;
        Label labelMiddenX, labelMiddenY, labelSchaal, labelMax;
        Button knopGaan;
        Panel tekenVeld;

        //Classes references
        MandleBrot mandel;
        Draw draw;

        //Points list

        #endregion

        public scherm () {

            //de volgede methode zorgt voor de algemene opbouw van de interface(labels, textboxes en buttons)
            maakInterface();

            //vul tekenscherm
            vulTekenScherm();

            draw = new Draw(mandel);

        }
        private void maakInterface () {
            //maak scherm waar alles op geplaatst wordt
            this.ClientSize = new Size(450, 600);
            
            #region labels

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

            #endregion

            #region Textboxes

            //textbox invoermiddenx
            invoerMiddenX = new TextBox();
            invoerMiddenX.Location = new Point(90, 25);
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

            #endregion

            #region Button

            //button knopGaan
            knopGaan = new Button();
            knopGaan.Location = new Point(375, 25);
            knopGaan.Size = new Size(50, 35);
            knopGaan.Text = "gaan";
            this.Controls.Add(knopGaan);

            #endregion

            #region TekenVeld
            
            //Panel tekenVeld
            tekenVeld = new Panel();
            tekenVeld.Location = new Point(25, 175);
            tekenVeld.Size = new Size(400, 400);
            this.Controls.Add(tekenVeld);
            mandel = new MandleBrot(tekenVeld.Size);

            #endregion

        }

        private void vulTekenScherm () {
            tekenVeld.Paint += new PaintEventHandler(Paint_tekenVeld);
        }

        private void Paint_tekenVeld (object o, PaintEventArgs pea) {

            draw.Drawing(pea.Graphics, mandel.Points);

        }

        #region String converters
        //Usefull methods library

        public static Boolean isInt (String s) {
            try {
                int.Parse(s);
                return true;
            } catch (FormatException) {
                return false;
            }
        }

        public static int getInt (String s) {
            return int.Parse(s);
        }

        public static Boolean isDouble (String s) {
            try {
                double.Parse(s);
                return true;
            } catch (FormatException) {
                return false;
            }

        }

        public static double getDouble (String s) {
            return double.Parse(s);
        }

        #endregion

    }
}
