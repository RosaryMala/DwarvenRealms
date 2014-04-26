using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DwarvenRealms
{
    class DwarfWorldMap
    {
        int[,] biomeMap;
        int[,] elevationMap;
        int[,] waterMap;
        Bitmap hydrosphere;

        public void loadElevationMap(string path)
        {
            Bitmap elevationBitmap = (Bitmap)Bitmap.FromFile(path);
            elevationMap = new int[elevationBitmap.Width, elevationBitmap.Height];
            for (int y = 0; y < elevationBitmap.Height; y++)
            {
                for (int x = 0; x < elevationBitmap.Width; x++)
                {
                    Color point = elevationBitmap.GetPixel(x, y);
                    int height;
                    if (point.R == 0)
                        height = point.B;
                    else
                        height = point.B + 25;
                    elevationMap[x, y] = height;
                }
            }
            Console.WriteLine("Loaded elevation map sized {0}x{1}", elevationMap.GetUpperBound(0), elevationMap.GetUpperBound(1));
        }
        public void loadWaterMap(string path)
        {
            Bitmap waterBitMap = (Bitmap)Bitmap.FromFile(path);
            waterMap = new int[waterBitMap.Width, waterBitMap.Height];
            for (int y = 0; y < waterBitMap.Height; y++)
            {
                for (int x = 0; x < waterBitMap.Width; x++)
                {
                    Color point = waterBitMap.GetPixel(x, y);
                    if (point.R == 0 && point.G == 0)
                    {
                        waterMap[x, y] = point.B + 25;
                    }
                    else
                        waterMap[x, y] = -1;
                }
            }
            Console.WriteLine("Loaded ocean map sized {0}x{1}", waterMap.GetUpperBound(0), waterMap.GetUpperBound(1));
        }
        public void loadBiomeMap(string path)
        {
            Bitmap tempBiomeMap = (Bitmap)Bitmap.FromFile(path);
            biomeMap = new int[tempBiomeMap.Width, tempBiomeMap.Height];
            for (int y = 0; y < tempBiomeMap.Height; y++)
            {
                for (int x = 0; x < tempBiomeMap.Width; x++)
                {
                    biomeMap[x, y] = BiomeList.GetBiomeIndex(tempBiomeMap.GetPixel(x, y));
                }
            }
            Console.WriteLine("Loaded biome map sized {0}x{1}", biomeMap.GetUpperBound(0), biomeMap.GetUpperBound(1));
        }

        enum InterpolationChoice
        {
            linear,
            cosine,
            cubic,
            catmulRom,
            hermite
        }
        InterpolationChoice interpolationChoice = InterpolationChoice.linear;
        /// <summary>
        /// This function assumes that the loaded heightmap image follows the DF2012 convention of having the lowest elevations shaded blue.
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        /// <returns>The elevation at the specified coordinate, or -1 if an error occurs.</returns>
        public int getElevation(int x, int y)
        {
            if (x < elevationMap.GetLowerBound(0))
                x = elevationMap.GetLowerBound(0);
            if (x > elevationMap.GetUpperBound(0))
                x = elevationMap.GetUpperBound(0);
            if (y < elevationMap.GetLowerBound(1))
                y = elevationMap.GetLowerBound(1);
            if (y > elevationMap.GetUpperBound(1))
                y = elevationMap.GetUpperBound(1);
            return elevationMap[x, y];
        }

        public double getElevation(double x, double y)
        {
            int x1, y1;
            x1 = (int)Math.Floor(x);
            y1 = (int)Math.Floor(y);

            double z11 = getElevation(x1, y1);
            double z12 = getElevation(x1, y1 + 1);
            double z21 = getElevation(x1 + 1, y1);
            double z22 = getElevation(x1 + 1, y1 + 1);

            double z00 = getElevation(x1 - 1, y1 - 1);
            double z01 = getElevation(x1 - 1, y1);
            double z02 = getElevation(x1 - 1, y1 + 1);
            double z03 = getElevation(x1 - 1, y1 + 2);
            double z10 = getElevation(x1, y1 - 1);
            double z13 = getElevation(x1, y1 + 2);
            double z20 = getElevation(x1 + 1, y1 - 1);
            double z23 = getElevation(x1 + 1, y1 + 2);
            double z30 = getElevation(x1 + 2, y1 - 1);
            double z31 = getElevation(x1 + 2, y1);
            double z32 = getElevation(x1 + 2, y1 + 1);
            double z33 = getElevation(x1 + 2, y1 + 2);

            double muy = x - x1;
            double mux = y - y1;

            //flat land sometimes gives trouble, so a slight increase can help that.
            double roundingCorrection = 0.001;

            switch (interpolationChoice)
            {
                case InterpolationChoice.linear:
                    return Interpolate.BiLinearInterpolate(z11, z12, z21, z22, mux, muy) + roundingCorrection;
                case InterpolationChoice.cosine:
                    return Interpolate.BiCosineInterpolate(z11, z12, z21, z22, mux, muy) + roundingCorrection;
                case InterpolationChoice.cubic:
                    return Interpolate.BiCubicInterpolate(z00, z01, z02, z03, z10, z11, z12, z13, z20, z21, z22, z23, z30, z31, z32, z33, mux, muy) + roundingCorrection;
                case InterpolationChoice.catmulRom:
                    return Interpolate.BiCatmullRomInterpolate(z00, z01, z02, z03, z10, z11, z12, z13, z20, z21, z22, z23, z30, z31, z32, z33, mux, muy) + roundingCorrection;
                case InterpolationChoice.hermite:
                    return Interpolate.BiHermiteInterpolate(z00, z01, z02, z03, z10, z11, z12, z13, z20, z21, z22, z23, z30, z31, z32, z33, mux, muy, 0.75) + roundingCorrection;
            }
            return -1.0;
        }

        /// <summary>
        /// Returns the water level at the specified location, excluding rivers.
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        /// <returns>Water level, if available, or -1</returns>
        public int getWaterbodyLevel(int x, int y)
        {
            if (x < waterMap.GetLowerBound(0))
                x = waterMap.GetLowerBound(0);
            if (x > waterMap.GetUpperBound(0))
                x = waterMap.GetUpperBound(0);
            if (y < waterMap.GetLowerBound(1))
                y = waterMap.GetLowerBound(1);
            if (y > waterMap.GetUpperBound(1))
                y = waterMap.GetUpperBound(1);
            return waterMap[x, y];
        }

        public int getBiome(int x, int y)
        {
            if (x < biomeMap.GetLowerBound(0))
                x = biomeMap.GetLowerBound(0);
            if (x > biomeMap.GetUpperBound(0))
                x = biomeMap.GetUpperBound(0);
            if (y < biomeMap.GetLowerBound(1))
                y = biomeMap.GetLowerBound(1);
            if (y > biomeMap.GetUpperBound(1))
                y = biomeMap.GetUpperBound(1);
            return biomeMap[x, y];
        }
        public int getBiome(double x, double y)
        {
            return getBiome((int)Math.Floor(x), (int)Math.Floor(y));
        }
    }
}
