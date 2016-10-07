using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Mandelbrot_Set {
    class Draw {

        #region Properties

        /// <summary>
        /// Special Enumerate to describe the current color pattern that will be used for the drawing.
        /// </summary>
        public enum ColorTypes { BLACKANDWHITE, RED, BLUE, GREEN, SPECTRUM };

        static ColorTypes currentType = ColorTypes.RED;

        MandleBrot plugin;
        
        #endregion

        #region Constructor Methods

        public Draw (MandleBrot plugin) {
            this.plugin = plugin;
        }

        #endregion

        #region Drawing Methods

        public void Drawing (Graphics graf, List<PointCalculator> points) {

            switch (currentType) {
                case (ColorTypes.BLACKANDWHITE):
                    BaW(graf, points);
                    break;
                case (ColorTypes.RED):
                    Red(graf, points);
                    break;
                case (ColorTypes.BLUE):
                    Blue(graf, points);
                    break;
                case (ColorTypes.GREEN):
                    Green(graf, points);
                    break;
                case (ColorTypes.SPECTRUM):
                    Spectrum(graf, points);
                    break;
                default:
                    BaW(graf, points);
                    break;
            }
        }

        private void BaW (Graphics graf, List<PointCalculator> points) {

            foreach (PointCalculator point in points) {
                Pen pen = Pens.White;
                if (point.times % 2 == 0)
                    pen = Pens.Black;
                Point(graf, pen, point);
            }
        }

        private void Red (Graphics graf, List<PointCalculator> points) {

            foreach (PointCalculator point in points) {
                Point(graf,
                    new Pen(Color.FromArgb(255 * point.times / point.max, 255 - 255 * point.times / point.max, 0)),
                    point);
            }

        }

        private void Blue (Graphics graf, List<PointCalculator> points) {

            foreach (PointCalculator point in points) {
                Point(graf,
                    new Pen(Color.FromArgb(0, 255 - 255 * point.times / point.max, 255 * point.times / point.max)),
                    point);
            }

        }

        private void Green (Graphics graf, List<PointCalculator> points) {

            foreach (PointCalculator point in points) {
                Point(graf,
                    new Pen(Color.FromArgb(0, 0, 0)),
                    point);
            }

        }

        private void Spectrum (Graphics graf, List<PointCalculator> points) {

            foreach (PointCalculator point in points) {
                Point(graf,
                    new Pen(Color.FromArgb(255 - 255 * point.times / point.max, 0, 255 * point.times / point.max)),
                    point);
            }

        }

        private void Point (Graphics graf, Pen pen, PointCalculator point) {
            graf.DrawLine(pen,
                    (float) MandleBrot.PointChange(point.x, true, false),
                    (float) MandleBrot.PointChange(point.y, false, false),
                    (float) MandleBrot.PointChange(point.x, true, false),
                    (float) plugin.sizeHeight + 1);
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
