using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DwarvenRealms.Properties;
using SimplexNoise;

namespace DwarvenRealms
{
    class CaveThing
    {
        DwarfWorldMap map;
        double scale;
        double percentage;
        double height;

        public CaveThing(DwarfWorldMap parent)
        {
            map = parent;
            scale = Settings.Default.caveScale;
            percentage = Settings.Default.cavePercentage;
            height = Settings.Default.caveHeight;
        }

        public int getCaveBlock(float x, float y, float z)
        {
            int caveInteriorMat = Substrate.BlockType.AIR;
            int caveFloorMat = Substrate.BlockType.MYCELIUM;
            int caveCeilingMat = Substrate.BlockType.STONE;
            int caveExteriorMat = Substrate.BlockType.AIR;

            int caveTopHeight = getCaveCeiling(x, z);
            int caveBottomHeight = getCaveFloor(x, z);

            if (caveTopHeight < caveBottomHeight)
                return caveExteriorMat;
            else if (y == caveTopHeight)
                return caveCeilingMat;
            else if (y == caveBottomHeight)
                return caveFloorMat;
            else if (y > caveBottomHeight && y < caveTopHeight)
                return caveInteriorMat;
            else return caveExteriorMat;
        }

        double getOpenCave(double x, double y, double scale, double percentage)
        {
            double caveness = Noise.Generate((float)(x / scale), (float)(y / scale));
            caveness = ((caveness + 1.0) / 2) * 100;
            caveness -= (100 - percentage);
            caveness /= percentage;
            if (caveness < 0)
                caveness = 0;
            return caveness;
        }

        public int getCaveCeiling(double x, double y)
        {
            double height = getOpenCave(x, y, Settings.Default.caveScale, Settings.Default.cavePercentage);
            height *= Settings.Default.caveHeight;
            height *= 2.0 / 3.0;
            height += (map.getSmoothedElevation(x, y) * 0.6);
            return (int)(height + 0.5);
        }
        public int getCaveFloor(double x, double y)
        {
            double height = getOpenCave(x, y, Settings.Default.caveScale, Settings.Default.cavePercentage);
            height *= Settings.Default.caveHeight;
            height *= -1.0 / 3.0;
            height += (map.getSmoothedElevation(x, y) * 0.6);
            return (int)(height + 0.5);
        }
    }
}
