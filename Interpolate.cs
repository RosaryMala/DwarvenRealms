using System;

namespace DwarvenRealms
{
    static class Interpolate
    {
        // Copied from http://paulbourke.net/miscellaneous/interpolation/

        /// <summary>
        /// Makes a straight line between two points
        /// </summary>
        /// <param name="y1">First Point</param>
        /// <param name="y2">Second Point</param>
        /// <param name="mu">Desired location between the two points.</param>
        /// <returns>The height at location mu</returns>
        public static double LinearInterpolate(double y1, double y2, double mu)
        {
            return (y1 * (1 - mu) + y2 * mu);
        }

        public static double CosineInterpolate(double y1, double y2, double mu)
        {
            double mu2;

            mu2 = (1 - Math.Cos(mu * Math.PI)) / 2;
            return (y1 * (1 - mu2) + y2 * mu2);
        }

        public static double CubicInterpolate(double y0, double y1, double y2, double y3, double mu)
        {
            double a0, a1, a2, a3, mu2;

            mu2 = mu * mu;
            a0 = y3 - y2 - y0 + y1;
            a1 = y0 - y1 - a0;
            a2 = y2 - y0;
            a3 = y1;

            return (a0 * mu * mu2 + a1 * mu2 + a2 * mu + a3);
        }

        public static double CatmullRomInterpolate(double y0, double y1, double y2, double y3, double mu)
        {
            double a0, a1, a2, a3, mu2;

            mu2 = mu * mu;
            a0 = -0.5 * y0 + 1.5 * y1 - 1.5 * y2 + 0.5 * y3;
            a1 = y0 - 2.5 * y1 + 2 * y2 - 0.5 * y3;
            a2 = -0.5 * y0 + 0.5 * y2;
            a3 = y1;

            return (a0 * mu * mu2 + a1 * mu2 + a2 * mu + a3);
        }


        /// <summary>
        /// Much like cubic interpolation, but has control over sharpness, using tention and bias controls.
        /// </summary>
        /// <param name="y0">point before the first, for normals.</param>
        /// <param name="y1">first point</param>
        /// <param name="y2">second point</param>
        /// <param name="y3">point after the second, for normals.</param>
        /// <param name="mu">Desired location between the two points.</param>
        /// <param name="tension">1 is high, 0 normal, -1 is low</param>
        /// <param name="bias">Bias: 0 is even, positive is towards first segment, negative towards the other</param>
        /// <returns>The height at location mu</returns>
        public static double HermiteInterpolate(double y0, double y1, double y2, double y3, double mu, double tension = 0, double bias = 0)
        {
            double m0, m1, mu2, mu3;
            double a0, a1, a2, a3;

            mu2 = mu * mu;
            mu3 = mu2 * mu;
            m0 = (y1 - y0) * (1 + bias) * (1 - tension) / 2;
            m0 += (y2 - y1) * (1 - bias) * (1 - tension) / 2;
            m1 = (y2 - y1) * (1 + bias) * (1 - tension) / 2;
            m1 += (y3 - y2) * (1 - bias) * (1 - tension) / 2;
            a0 = 2 * mu3 - 3 * mu2 + 1;
            a1 = mu3 - 2 * mu2 + mu;
            a2 = mu3 - mu2;
            a3 = -2 * mu3 + 3 * mu2;

            return (a0 * y1 + a1 * m0 + a2 * m1 + a3 * y2);
        }

        public static double FritschCarlsonInterpolate(double y0, double y1, double y2, double y3, double mu)
        {
            // Get Slopes
            double m0, m1, m2;
            m0 = y1 - y0;
            m1 = y2 - y1;
            m2 = y3 - y2;

            // Get degree-1 coefficients
            double c10, c11, c12;
            c10 = m0;
            if (m0 * m1 <= 0)
            {
                c11 = 0;
            }
            else
            {
                c11 = 2 / (1 / m0 + 1 / m1);
            }
            if (m1 * m2 <= 0)
            {
                c12 = 0;
            }
            else
            {
                c12 = 2 / (1 / m1 + 1 / m2);
            }

            // Get second and third degree coefficients
            double c20, c30;
            c20 = (3 * m0) - (2 * c10) - c11;
            c30 = c10 + c11 - (2 * m0); 
            double c21, c31;
            c21 = (3 * m1) - (2 * c11) - c12;
            c31 = c11 + c12 - (2 * m1);

            double mu2 = mu * mu;
            double mu3 = mu2 * mu;


            return y1 + c11 * mu + c21 * mu2 + c31 * mu3;

        }

        public static double BiLinearInterpolate(double z00, double z01, double z10, double z11, double mux, double muy)
        {
            double a0, a1;

            a0 = LinearInterpolate(z00, z01, mux);
            a1 = LinearInterpolate(z10, z11, mux);
            return LinearInterpolate(a0, a1, muy);
        }

        public static double BiCosineInterpolate(double z00, double z01, double z10, double z11, double mux, double muy)
        {
            double a0, a1;

            a0 = CosineInterpolate(z00, z01, mux);
            a1 = CosineInterpolate(z10, z11, mux);
            return CosineInterpolate(a0, a1, muy);
        }

        public static double BiCubicInterpolate(
            double z00, double z01, double z02, double z03,
            double z10, double z11, double z12, double z13,
            double z20, double z21, double z22, double z23,
            double z30, double z31, double z32, double z33,
            double mux, double muy)
        {
            double a0, a1, a2, a3;

            a0 = CubicInterpolate(z00, z01, z02, z03, mux);
            a1 = CubicInterpolate(z10, z11, z12, z13, mux);
            a2 = CubicInterpolate(z20, z21, z22, z23, mux);
            a3 = CubicInterpolate(z30, z31, z32, z33, mux);

            return CubicInterpolate(a0, a1, a2, a3, muy);
        }

        public static double BiCatmullRomInterpolate(
            double z00, double z01, double z02, double z03,
            double z10, double z11, double z12, double z13,
            double z20, double z21, double z22, double z23,
            double z30, double z31, double z32, double z33,
            double mux, double muy)
        {
            double a0, a1, a2, a3;

            a0 = CatmullRomInterpolate(z00, z01, z02, z03, mux);
            a1 = CatmullRomInterpolate(z10, z11, z12, z13, mux);
            a2 = CatmullRomInterpolate(z20, z21, z22, z23, mux);
            a3 = CatmullRomInterpolate(z30, z31, z32, z33, mux);

            return CatmullRomInterpolate(a0, a1, a2, a3, muy);
        }

        public static double BiHermiteInterpolate(
            double z00, double z01, double z02, double z03,
            double z10, double z11, double z12, double z13,
            double z20, double z21, double z22, double z23,
            double z30, double z31, double z32, double z33,
            double mux, double muy,
            double tension = 0.0, double bias = 0.0)
        {
            double a0, a1, a2, a3;

            a0 = HermiteInterpolate(z00, z01, z02, z03, mux, tension, bias);
            a1 = HermiteInterpolate(z10, z11, z12, z13, mux, tension, bias);
            a2 = HermiteInterpolate(z20, z21, z22, z23, mux, tension, bias);
            a3 = HermiteInterpolate(z30, z31, z32, z33, mux, tension, bias);

            return HermiteInterpolate(a0, a1, a2, a3, muy, tension, bias);
        }
        public static double BiFritschCarlsonInterpolate(
    double z00, double z01, double z02, double z03,
    double z10, double z11, double z12, double z13,
    double z20, double z21, double z22, double z23,
    double z30, double z31, double z32, double z33,
    double mux, double muy)
        {
            double a0, a1, a2, a3;

            a0 = FritschCarlsonInterpolate(z00, z01, z02, z03, mux);
            a1 = FritschCarlsonInterpolate(z10, z11, z12, z13, mux);
            a2 = FritschCarlsonInterpolate(z20, z21, z22, z23, mux);
            a3 = FritschCarlsonInterpolate(z30, z31, z32, z33, mux);

            return FritschCarlsonInterpolate(a0, a1, a2, a3, muy);
        }
    }

}
