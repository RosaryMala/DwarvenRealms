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
        Bitmap biomeMap;
        Bitmap elevationMap;
        Bitmap waterMap;

        /// <summary>
        /// This function assumes that the loaded heightmap image follows the DF2012 convention of having the lowest elevations shaded blue.
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        /// <returns>The elevation at the specified coordinate, or -1 if an error occurs.</returns>
        int getElevation(int x, int y)
        {
            if (elevationMap == null)
                return - 1;
            Color point = elevationMap.GetPixel(x, y);
            if(point.R == 0)
                return point.B;
            else
                return point.B + 25;
        }

        /// <summary>
        /// Returns the water level at the specified location, excluding rivers.
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        /// <returns>Water level, if available, or -1</returns>
        int getWaterbodyLevel(int x, int y)
        {
            if (waterMap == null)
                return -1;
            Color point = waterMap.GetPixel(x, y);
            if (point.R == 0 && point.G == 0)
            {
                return point.B + 25;
            }
            else
                return -1;
        }

        int getBiome(int x, int y)
        {
            return -1;
        }
    }
}
