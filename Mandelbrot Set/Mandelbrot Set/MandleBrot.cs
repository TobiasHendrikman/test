using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Mandelbrot_Set;

namespace Mandelbrot_Set {
    class MandleBrot : Panel {

        #region Properties

        List<PointCalculator> points;

        double CenterX = 200;
        double CenterY = 200;
        double Amplifier = 1;
        static double SizeWidth = 400;
        static double SizeHeight = 400;
        int Max = 100;

        #endregion

        #region Constructor Methods

        public MandleBrot (Size size) {

            points = new List<PointCalculator>();
            PointCalc(0,0, size.Width, size.Height);

        }
        
        #endregion
        
        #region PointCalculator Creator
        /* --- Point Calculator Settings --- */
        
        /// <summary>
        /// Creates all the new points in the given window.
        /// </summary>
        public void PointCalc () {
            for (double y = 0; y <= SizeHeight; y++) {
                for (double x = 0; x <= SizeWidth; x++) {

                    PointCalculator p = new PointCalculator(PointChange(x, true, true), PointChange(y, false, true), Max);
                    points.Add(p);

                }
            }

            this.Invalidate();

        }

        /// <summary>
        /// Creates all the new points in the given window
        /// </summary>
        /// <param name="x"> The center X position of the window. </param>
        /// <param name="y"> The center Y position of the window. </param>
        public void PointCalc (double x, double y) {
            CenterX = x;
            CenterY = y;
            PointCalc();
        }

        /// <summary>
        /// Creates all the new points in the given window
        /// </summary>
        /// <param name="x"> The center X position of the window. </param>
        /// <param name="y"> The center Y position of the window. </param>
        /// <param name="width"> The width of the window. </param>
        /// <param name="height">The height of the window. </param>
        public void PointCalc (double x, double y, double width, double height) {
            SizeWidth = width;
            SizeHeight = height;
            PointCalc(x, y);
        }

        /// <summary>
        /// Creates all the new points in the given window
        /// </summary>
        /// <param name="r"> The rectangle which will represent the window. </param>
        public void PointCalc (Rectangle r) {
            PointCalc(r.X, r.Y, r.Width, r.Height);
        }

        /* --- Point Calculator Ending --- */
        #endregion

        #region Static Methods

        /// <summary>
        /// Changes the given value to either fit the Mandlebrot window (convert = true)
        /// or to fit the application window (convert = false)
        /// </summary>
        /// <param name="x"> The value that will be recalculated. </param>
        /// <param name="width"> If the value represents and x or y coördinate (width = true if the point is an x-value) </param>
        /// <param name="convert"> If the value needs to fit the mandlebrot window (true) or the application window (false) </param>
        /// <returns></returns>
        public static double PointChange (double x, Boolean width, Boolean convert) {
            if (convert) {
                if (width)
                    return x / SizeWidth * 4 /* * Amplifier*/- 2;
                return x / SizeHeight * 4 - 2;
            }

            if (width)
                return (x + 2) / 4 * SizeWidth;
            return (x + 2) / 4 * SizeHeight;

        }

        /// <summary>
        /// Creates a picture of the Mandelbrot Screen.
        /// </summary>
        /// <param name="plugin"></param>
        public static void Screenshot (MandleBrot plugin) {

            Form form = Form.ActiveForm;
            using (Bitmap map = new Bitmap((int) SizeWidth, (int) SizeHeight)) {
                form.DrawToBitmap(map, new Rectangle(0, 0, (int) SizeWidth, (int) SizeHeight));
                //map.Save(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\MandleBrot\Picture.png");
                SaveFileDialog save = new SaveFileDialog();
                save.ShowDialog();
                map.Save(save.FileName);
            }

        }

        #endregion
        
        #region Property Calls

        /// <summary>
        /// Sets the new center X position of the MandleBrot picture.
        /// </summary>
        public double centerX {
            get {
                return this.CenterX;
            }
            set {
                this.CenterX += (Math.Abs(value - CenterX) * Amplifier);
            }
        }

        /// <summary>
        /// Sets the new center Y position of the MandleBrot picture.
        /// </summary>
        public double centerY {
            get {
                return this.CenterY;
            }
            set {
                this.CenterY += (Math.Abs(value - CenterY) * Amplifier);
            }
        }

        /// <summary>
        /// Sets the new center position of the MandleBrot picture.
        /// </summary>
        public Point center {
            get {
                return new Point((int) CenterX, (int) CenterY);
            }
            set {
                this.centerX = value.X;
                this.centerY = value.Y;
            }
        }

        /// <summary>
        /// Sets the new Width of the current MandleBrot screen.
        /// </summary>
        public double sizeWidth {
            get {
                return SizeWidth;
            }
            set {
                SizeWidth = value;
            }
        }

        /// <summary>
        /// Sets the new Height of the current MandleBrot screen.
        /// </summary>
        public double sizeHeight {
            get {
                return SizeHeight;
            }
            set {
                SizeHeight = value;
            }
        }

        /// <summary>
        /// Sets the maximum amount of times that a number may repeat itself.
        /// </summary>
        public int max {
            get {
                return this.Max;
            }
            set {
                this.Max = value;
                foreach (PointCalculator point in points) {
                    point.max = value;
                    point.MainFormula();
                }
            }
        }

        /// <summary>
        /// Gives a list with all the points in the current form.
        /// </summary>
        public List<PointCalculator> Points {
            get {
                return this.points;
            }
        }

        #endregion
        
    }
}