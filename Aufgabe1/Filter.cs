using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessing
{
    public class Filter
    {
        private readonly IPadding myPadder;

        public Filter(IPadding padder)
        {
            myPadder = padder;

        }
        //public readonly float Constant = 0;
        public IPadding PaddType { get; set; }
        public int FilterSize { get; set; }
        //public float[] data_in { get; set; }
        //public int width_in { get; set; }
        //public int width_in { get; set; }

        //public Filter(IPadding _PaddType, int _FilterSize)
        //{
        //    // this.Constant = _constant;
        //    this.PaddType = _PaddType;
        //    this.FilterSize = _FilterSize;
        //}

        public float[] MeanFilter2D(float[] data_in, int width_in, int height_in, int filtersize)
        {
            int size = filtersize / 2;
            int N = width_in + size * 2; // + FilterSizes.X -1 statt size*2
            int M = height_in + size * 2; // + FilterSizes[1] -1 statt size*2
            // int D = depth_in + FilterSites[2] -1;
            float[] padding = myPadder.CreatePadding(data_in, width_in, height_in, filtersize);

            float[] result = new float[width_in * height_in];
            // for (int k = size; k < D -size -1; k++) Iteration über slice/ z 
            for (int j = size; j < M - size - 1; j++)
            {
                for (int i = size; i < N - size - 1; i++)
                {
                    float summedupValues = 0f;
                    for (int y = -size; y < size + 1; y++)
                    {
                        for (int x = -size; x < size + 1; x++)
                        {
                            summedupValues += padding[(j + y) * N + (i + x)];
                        }
                    }
                    result[(i - size) + (j - size) * width_in] = summedupValues / filtersize;
                }
            }
            return result;
        }

        public float[] MedianFilter(float[] data_in, int width_in, int height_in, int filterSize)
        {
            int size = FilterSize / 2;
            int N = width_in + size * 2; // + FilterSizes.X -1 statt size*2
            int M = height_in + size * 2; // + FilterSizes[1] -1 statt size*2
            // int D = depth_in + FilterSites[2] -1;
            float[] padding = new float[N * M];
            
            
            return padding;
        }
    }
}
