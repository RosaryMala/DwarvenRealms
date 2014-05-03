using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DwarvenRealms
{
    static class Blur
    {
        public static int[,] gaussianBlur(int[,] inputImage, int radius)
        {
            double[,] pass1 = new double[inputImage.GetUpperBound(0), inputImage.GetUpperBound(1)];
            int[,] pass2 = new int[inputImage.GetUpperBound(0), inputImage.GetUpperBound(1)];
            double sigma = (float)radius / 3.0;
            double[] kernel = new double[radius];
            for (int i = 0; i < radius; i++)
            {
                kernel[i] = (1 / (Math.Sqrt(2 * Math.PI * sigma))) * Math.Pow(Math.E, -((i * i) / (2 * sigma * sigma)));
            }
            double total = 0.0;
            for (int i = 0; i < radius; i++)
            {
                total += kernel[i];
                if (i > 0)
                    total += kernel[i];
            }
            for (int i = 0; i < radius; i++)
            {
                kernel[i] /= total; //this ensures that it always adds up to 1
            }
            //First do horizontal smoothing.
            for (int xi = 0; xi < inputImage.GetUpperBound(0); xi++)
            {
                for (int yi = 0; yi < inputImage.GetUpperBound(1); yi++)
                {
                    pass1[xi, yi] = kernel[0] * inputImage[xi, yi];
                    for (int i = 1; i < radius; i++)
                    {
                        pass1[xi, yi] += DwarfWorldMap.getClampedCoord(inputImage, xi + i, yi) * kernel[i];
                    }
                }
            }            
            //Next do vertical. Also convert back to int.
            for (int xi = 0; xi < inputImage.GetUpperBound(0); xi++)
            {
                for (int yi = 0; yi < inputImage.GetUpperBound(1); yi++)
                {
                    double pixel = kernel[0] * inputImage[xi, yi];
                    for (int i = 1; i < radius; i++)
                    {
                        pixel += DwarfWorldMap.getClampedCoord(pass1, xi, yi + 1) * kernel[i];
                    }
                    pass2[xi, yi] = (int)Math.Floor(pixel + 0.5);
                }
            }
            return pass2;
        }
    }
}
