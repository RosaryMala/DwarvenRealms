using System.Drawing;
using SimplexNoise;
using System;

namespace DwarvenRealms
{
    class BiomeConversion
    {
        Color colorKey;
        public int mineCraftBiome;
        int[] layer1ID;
        int layer1Thickness;
        int[] layer2ID;
        int layer2Thickness;
        int[] layer3ID;
        int layer3Thickness;
        int[] layer4ID;
        public BiomeConversion(Color color, int biome)
        {
            colorKey = color;
            mineCraftBiome = biome;
        }
        public BiomeConversion(int red, int green, int blue, int biome,
            int[] lay1ID = null, int lay1thick = 0,
            int[] lay2ID = null, int lay2thick = 0,
            int[] lay3ID = null, int lay3thick = 0,
            int[] lay4ID = null)
        {
            colorKey = Color.FromArgb(red, green, blue);
            mineCraftBiome = biome;
            if (lay1ID != null)
                layer1ID = lay1ID;
            else layer1ID = new int[] { 1 };
            layer1Thickness = lay1thick;
            if (lay2ID != null)
                layer2ID = lay2ID;
            else layer2ID = new int[] { 1 };
            layer2Thickness = lay1thick + lay2thick;
            if (lay3ID != null)
                layer3ID = lay3ID;
            else layer3ID = new int[] { 1 };
            layer3Thickness = lay1thick + lay2thick + lay3thick;
            if (lay4ID != null)
                layer4ID = lay4ID;
            else layer4ID = new int[] { 1 };
        }
        public int getBlockID(int depth, float x = 0, float y = 0)
        {
            x /= 8.0f;
            y /= 8.0f;
            if (depth <= layer1Thickness)
            {
                if (layer1ID.Length == 1)
                    return layer1ID[0];
                double rando = SimplexNoise.Noise.Generate(x, y, depth);
                rando += 1;
                rando /= 2;
                rando *= layer1ID.Length;
                return layer1ID[(int)Math.Floor(rando)];
            }
            else if (depth <= layer2Thickness)
            {
                if (layer2ID.Length == 1)
                    return layer2ID[0];
                double rando = SimplexNoise.Noise.Generate(x, y, depth);
                rando += 1;
                rando /= 2;
                rando *= layer2ID.Length;
                return layer2ID[(int)Math.Floor(rando)];
            }
            else if (depth <= layer3Thickness)
            {
                if (layer3ID.Length == 1)
                    return layer3ID[0];
                double rando = SimplexNoise.Noise.Generate(x, y, depth);
                rando += 1;
                rando /= 2;
                rando *= layer3ID.Length;
                return layer3ID[(int)Math.Floor(rando)];
            }
            else
            {
                if (layer4ID.Length == 1)
                    return layer4ID[0];
                double rando = SimplexNoise.Noise.Generate(x, y, depth);
                rando += 1;
                rando /= 2;
                rando *= layer4ID.Length;
                return layer4ID[(int)Math.Floor(rando)];
            }
        }
        public static bool operator ==(Color a, BiomeConversion b)
        {
            return a.R == b.colorKey.R && a.G == b.colorKey.G && a.B == b.colorKey.B;
        }
        public static bool operator ==(BiomeConversion b, Color a)
        {
            return a.R == b.colorKey.R && a.G == b.colorKey.G && a.B == b.colorKey.B;
        }
        public static bool operator !=(Color a, BiomeConversion b)
        {
            return a.R != b.colorKey.R || a.G != b.colorKey.G || a.B != b.colorKey.B;
        }
        public static bool operator !=(BiomeConversion b, Color a)
        {
            return a.R != b.colorKey.R || a.G != b.colorKey.G || a.B != b.colorKey.B;
        }
    }
}
