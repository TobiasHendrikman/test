using System;

namespace Mandelbrot_Set {
    class PointCalculator {

        #region Properties

        double PosX = 0;
        double PosY = 0;
        int Times = 0;
        int Max = 100;

        #endregion

        #region Constructor Methods
        /* --- Constructor Methods --- */

        /// <summary>
        /// Uses the mandlebrot formula on a given point.
        /// </summary>
        /// <param name="x"> Point x-coördinate</param>
        /// <param name="y"> Point y-coördinate</param>
        public PointCalculator (double x, double y) {
            this.PosX = x;
            this.PosY = y;
            MainFormula();
        }

        /// <summary>
        /// Uses the mandlebrot formula on a given point.
        /// </summary>
        /// <param name="x"> Point x-coördinate</param>
        /// <param name="y"> Point y-coördinate</param>
        /// <param name="max"> The maximum amount of times this program may be executed. </param>
        public PointCalculator (double x, double y, int max) {
            this.PosX = x;
            this.PosY = y;
            this.Max = max;
            MainFormula();
        }

        /* --- Constructor Methods --- */
        #endregion

        /// <summary>
        /// The main method from the MandleBrot Set.
        /// </summary>
        public void MainFormula () {

            double a = 0;
            double b = 0;
            double olda = 0;
            double oldb = 0;

            for (int t = 0; t < Max; t++) {
                a = olda * olda - oldb * oldb + PosX;
                b = 2 * olda * oldb + PosY;
                if (Math.Sqrt(Math.Abs(a * a + b * b)) > 2d) {
                    Times = t;
                    return;
                }
                olda = a;
                oldb = b;
            }
            Times = Max;
            return;
        }

        #region Property Calls
        /* --- Property Calls --- */

        /// <summary>
        /// Gets the amount of time that this number has used the Mandlebrot formula without reaching the bounds.
        /// If the bounds have been reached then this will return the maximum number of tries.
        /// </summary>
        public int times {
            get {
                return this.Times;
            }
        }

        /// <summary>
        /// Gets the X coördinate of the current point
        /// </summary>
        public double x {
            get {
                return this.PosX;
            }
        }

        /// <summary>
        /// Gets the Y coördinate of the current point
        /// </summary>
        public double y {
            get {
                return this.PosY;
            }
        }

        /// <summary>
        /// Sets the maximum amount of times that this number may use the Mandlebrot formula.
        /// </summary>
        public int max {
            get{
                return this.Max;
            }
            set {
                this.Max = value;
            }
        }

        /* --- Property Calls --- */
        #endregion

    }
}
