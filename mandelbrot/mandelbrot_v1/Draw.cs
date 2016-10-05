using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Mandelbrot_Set {
    class Draw {

        #region Properties

        public enum ColorTypes { BLACKANDWHITE, RED, BLUE, GREEN, SPECTRUM };
        static ColorTypes currentType = ColorTypes.BLACKANDWHITE;

        MandleBrot plugin;

        #endregion

        #region Constructor Methods

        public Draw (MandleBrot plugin) {
            this.plugin = plugin;
        }

        #endregion

        #region Drawing Methods

        public void Drawing (PaintEventArgs e, List<PointCalculator> points) {

            switch (currentType) {
                case (ColorTypes.BLACKANDWHITE):
                    BaW(e, points);
                    break;
                case (ColorTypes.RED):
                    Red(e, points);
                    break;
                case (ColorTypes.BLUE):
                    Blue(e, points);
                    break;
                case (ColorTypes.GREEN):
                    Green(e, points);
                    break;
                case (ColorTypes.SPECTRUM):
                    Spectrum(e, points);
                    break;
                default:
                    BaW(e, points);
                    break;
            }

        }

        private void BaW (PaintEventArgs e, List<PointCalculator> points) {

            Graphics graf = e.Graphics;
            foreach (PointCalculator point in points) {
                Pen pen = Pens.White;
                if (point.times % 2 == 0)
                    pen = Pens.Black;
                Point(graf, pen, point);
            }
        }

        private void Red (PaintEventArgs e, List<PointCalculator> points) {

            Graphics graf = e.Graphics;
            foreach (PointCalculator point in points) {
                Point(graf,
                    new Pen(Color.FromArgb(255 * point.times / point.max, 255 - 255 * point.times / point.max, 0)),
                    point);
            }

        }

        private void Blue (PaintEventArgs e, List<PointCalculator> points) {

            Graphics graf = e.Graphics;
            foreach (PointCalculator point in points) {
                Point(graf,
                    new Pen(Color.FromArgb(0, 255 - 255 * point.times / point.max, 255 * point.times / point.max)),
                    point);
            }

        }

        private void Green (PaintEventArgs e, List<PointCalculator> points) {

            Graphics graf = e.Graphics;
            foreach (PointCalculator point in points) {
                Point(graf,
                    new Pen(Color.FromArgb(0, 0, 0)),
                    point);
            }

        }

        private void Spectrum (PaintEventArgs e, List<PointCalculator> points) {
            Graphics graf = e.Graphics;
            foreach (PointCalculator point in points) {
                Point(graf,
                    new Pen(Color.FromArgb(255 - 255 * point.times / point.max, 0, 255 * point.times / point.max)),
                    point);
            }
        }

        private void Point (Graphics graf, Pen pen, PointCalculator point) {
            graf.DrawLine(pen,
                    (float) (plugin.originX + MandleBrot.PointChange(point.x, true, false)),
                    (float) (plugin.originY + MandleBrot.PointChange(point.y, false, false)),
                    (float) (plugin.originX + MandleBrot.PointChange(point.x, true, false)),
                    (float) (plugin.originY + MandleBrot.PointChange(point.x, false, false)));
        }

        #endregion

        #region Property Calls

        public ColorTypes Type {
            get {
                return currentType;
            }
            set {
                currentType = value;
            }
        }

        #endregion
        
    }
}
