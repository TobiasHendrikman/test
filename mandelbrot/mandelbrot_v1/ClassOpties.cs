using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;


namespace mandelbrot_v1
{
    class ClassOpties : Form
    {
        public ClassOpties( )
        {

       

            schrijven("midden x", 20, 20);
        }

        private void schrijven(string t, int x, int y)
        {
            Label n = new Label();
            n.Location = new System.Drawing.Point(65, 10);
            n.Size = new System.Drawing.Size(100, 20);
            n.Text = t;
            this.Controls.Add(n);
        }
    }
}
