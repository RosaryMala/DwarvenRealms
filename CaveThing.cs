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

        public int getCaveBlock(double x, int y, double z)
        {
            int caveInteriorMat = Substrate.BlockType.AIR;
            int caveFloorMat = Substrate.BlockType.MYCELIUM;
            int caveCeilingMat = Substrate.BlockType.STONE;

            int caveTopHeight = getCaveCeiling(x, z);
            int caveBottomHeight = getCaveFloor(x, z);

            if (caveTopHeight <= caveBottomHeight)
                return -2;
            else if (y == caveTopHeight+1)
                return caveCeilingMat;
            else if (y == caveBottomHeight)
                return caveFloorMat;
            else if (y > caveBottomHeight && y < caveTopHeight)
                return caveInteriorMat;
            else if (y > caveTopHeight)
                return -2;
            else return -1;
        }

        double getCaveness(double x, double y, double scale, double percentage)
        {
            double biome1 = Noise.Generate((float)(x / (scale * 4)), (float)(y / (scale * 4)));
            biome1 *= 2;
            biome1 += 0.5;
            if(biome1 < 0)
                return getPathyCave(x, y, scale, percentage);
            else if (biome1 > 1)
                return getWideCave(x, y, scale, percentage);
            else
            {
                double wide = getWideCave(x, y, scale, percentage);
                double path = getPathyCave(x, y, scale, percentage);
                return (biome1 * wide) + ((1 - biome1) * path);
            }
        }

        double getWideCave(double x, double y, double scale, double percentage)
        {
            double caveness = Noise.Generate((float)(x / scale), (float)(y / scale));
            caveness = ((caveness + 1.0) / 2) * 100;
            caveness -= (100 - percentage);
            caveness /= percentage;
            if (caveness < 0)
                caveness = 0;
            return caveness;
        }

        double getPathyCave(double x, double y, double scale, double percentage)
        {
            double caveness = Noise.Generate((float)(x / (scale / 4.0)), (float)(y / (scale / 4.0)));
            caveness = (-Math.Abs(caveness) + 1) * 100;
            caveness -= (100 - percentage);
            caveness /= percentage;
            caveness /= 2;
            if (caveness < 0)
                caveness = 0;
            return caveness;
        }

        public int getCaveCeiling(double x, double y)
        {
            double height = getCaveness(x, y, Settings.Default.caveScale, Settings.Default.cavePercentage);
            height *= Settings.Default.caveHeight;
            height *= 2.0 / 3.0;
            height += (map.getSmoothedElevation(x, y) * 0.6);
            return (int)(height + 0.5);
        }
        public int getCaveFloor(double x, double y)
        {
            double height = getCaveness(x, y, Settings.Default.caveScale, Settings.Default.cavePercentage);
            height *= Settings.Default.caveHeight;
            height *= -1.0 / 3.0;
            height += (map.getSmoothedElevation(x, y) * 0.6);
            return (int)(height + 0.5);
        }
    }
}
