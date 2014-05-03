using SimplexNoise;
using System;
using System.Drawing;
using DwarvenRealms.Properties;

namespace DwarvenRealms
{
    class DwarfWorldMap
    {
        int[,] biomeMap;
        int[,] elevationMap;
        int[,] smoothedElevationMap;
        int[,] waterMap;
        int[,] riverHeightMap;

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
            smoothedElevationMap = Blur.gaussianBlur(elevationMap, 8);
            Console.WriteLine("Loaded elevation map sized {0}x{1}", elevationMap.GetUpperBound(0), elevationMap.GetUpperBound(1));
        }
        public void loadWaterMap(string path)
        {
            Bitmap waterBitMap = (Bitmap)Bitmap.FromFile(path);
            waterMap = new int[waterBitMap.Width, waterBitMap.Height];
            riverHeightMap = new int[waterBitMap.Width, waterBitMap.Height];
            for (int y = 0; y < waterBitMap.Height; y++)
            {
                for (int x = 0; x < waterBitMap.Width; x++)
                {
                    Color point = waterBitMap.GetPixel(x, y);
                    if (point.R == 0 && point.G == 0)
                    {
                        waterMap[x, y] = point.B + 25;
                        riverHeightMap[x, y] = -1;
                    }
                    else if (point.R == 0)
                    {
                        waterMap[x, y] = -1;
                        riverHeightMap[x, y] = point.B;
                    }
                    else
                    {
                        waterMap[x, y] = -1;
                        riverHeightMap[x, y] = -1;
                    }
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

        public enum InterpolationChoice
        {
            linear,
            cosine,
            cubic,
            catmulRom,
            hermite,
            fritschCarlson
        }
        InterpolationChoice interpolationChoice = InterpolationChoice.fritschCarlson;

        public int getElevation(int x, int y)
        {
            return getClampedCoord(elevationMap, x, y);
        }

        public double getElevation(double x, double y)
        {
            return getInterpolatedValue(elevationMap, interpolationChoice, x, y);
        }

        public static double getInterpolatedValue(int[,] array, InterpolationChoice type, double x, double y)
        {
            int x1, y1;
            x1 = (int)Math.Floor(x);
            y1 = (int)Math.Floor(y);

            double z11 = getClampedCoord(array, x1, y1);
            double z12 = getClampedCoord(array, x1, y1 + 1);
            double z21 = getClampedCoord(array, x1 + 1, y1);
            double z22 = getClampedCoord(array, x1 + 1, y1 + 1);

            double z00 = getClampedCoord(array, x1 - 1, y1 - 1);
            double z01 = getClampedCoord(array, x1 - 1, y1);
            double z02 = getClampedCoord(array, x1 - 1, y1 + 1);
            double z03 = getClampedCoord(array, x1 - 1, y1 + 2);
            double z10 = getClampedCoord(array, x1, y1 - 1);
            double z13 = getClampedCoord(array, x1, y1 + 2);
            double z20 = getClampedCoord(array, x1 + 1, y1 - 1);
            double z23 = getClampedCoord(array, x1 + 1, y1 + 2);
            double z30 = getClampedCoord(array, x1 + 2, y1 - 1);
            double z31 = getClampedCoord(array, x1 + 2, y1);
            double z32 = getClampedCoord(array, x1 + 2, y1 + 1);
            double z33 = getClampedCoord(array, x1 + 2, y1 + 2);

            double muy = x - x1;
            double mux = y - y1;

            //flat land sometimes gives trouble, so a slight increase can help that.
            double roundingCorrection = 0.5;

            switch (type)
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
                case InterpolationChoice.fritschCarlson:
                    return Interpolate.BiFritschCarlsonInterpolate(z00, z01, z02, z03, z10, z11, z12, z13, z20, z21, z22, z23, z30, z31, z32, z33, mux, muy) + roundingCorrection;

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
            return getClampedCoord(waterMap, x, y);
        }
        public int getRiverLevel(int x, int y)
        {
            return getClampedCoord(riverHeightMap, x, y);
        }

        public int getBiome(int x, int y)
        {
            return getClampedCoord(biomeMap, x, y);
        }
        public int getBiome(double x, double y)
        {
            return getBiome((int)Math.Floor(x), (int)Math.Floor(y));
        }

        /// <summary>
        /// Safely reads the value from an index grid.
        /// </summary>
        /// <param name="grid">A two dimensional array of ints to read from</param>
        /// <param name="x">X coord</param>
        /// <param name="y">Y coord</param>
        /// <returns>The value stored at the nearest valid grid cell, or MinValue if the grid is invalid entirely.</returns>
        public static int getClampedCoord(int[,] grid, int x, int y)
        {
            if (grid == null || grid.Length == 0)
                return int.MinValue;
            if (x < grid.GetLowerBound(0))
                x = grid.GetLowerBound(0);
            if (x > grid.GetUpperBound(0))
                x = grid.GetUpperBound(0);
            if (y < grid.GetLowerBound(1))
                y = grid.GetLowerBound(1);
            if (y > grid.GetUpperBound(1))
                y = grid.GetUpperBound(1);
            return grid[x, y];
        }
        public static double getClampedCoord(double[,] grid, int x, int y)
        {
            if (grid == null || grid.Length == 0)
                return double.MinValue;
            if (x < grid.GetLowerBound(0))
                x = grid.GetLowerBound(0);
            if (x > grid.GetUpperBound(0))
                x = grid.GetUpperBound(0);
            if (y < grid.GetLowerBound(1))
                y = grid.GetLowerBound(1);
            if (y > grid.GetUpperBound(1))
                y = grid.GetUpperBound(1);
            return grid[x, y];
        }

        double getCaveness(double x, double y)
        {
            double caveness = Noise.Generate((float)(x / Settings.Default.caveScale), (float)(y / Settings.Default.caveScale));
            caveness = ((caveness + 1.0) / 2) * 100;
            caveness -= (100 - Settings.Default.cavePercentage);
            caveness /= Settings.Default.cavePercentage;
            if (caveness < 0)
                caveness = 0;
            return caveness;
        }

        public int getCaveCeiling(double x, double y)
        {
            double height = getCaveness(x, y);
            height *= Settings.Default.caveHeight;
            height *= 2.0 / 3.0;
            height += (getInterpolatedValue(smoothedElevationMap, interpolationChoice, x, y) * 0.6);
            return (int)(height + 0.5);
        }
        public int getCaveFloor(double x, double y)
        {
            double height = getCaveness(x, y);
            height *= Settings.Default.caveHeight;
            height *= -1.0 / 3.0;
            height += (getInterpolatedValue(smoothedElevationMap, interpolationChoice, x, y) * 0.6);
            return (int)(height + 0.5);
        }

        int getFuzzyCoords(int[,] grid, double x, double y)
        {

            return int.MinValue;
        }

    }
}
