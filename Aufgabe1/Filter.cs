using System;
using System.Collections.Generic;

namespace ImageProcessing
{
    public class Filter   
    {
        private readonly IPadding myPadder;

        public Filter(IPadding padder)
        {
            myPadder = padder;

        }

        public int FilterSize { get; set; }

        public float[] MeanFilter2D(float[] data_in, int width_in, int height_in, int filtersize)
        {
            int size = filtersize / 2;
            int N = width_in + size * 2; // + FilterSizes.X -1 statt size*2
            int M = height_in + size * 2; // + FilterSizes[1] -1 statt size*2
            // int D = depth_in + FilterSites[2] -1;
            float[] padding = myPadder.CreatePadding(data_in, width_in, height_in, filtersize);

            float[] result = new float[width_in * height_in];
            // for (int k = size; k < D -size -1; k++) Iteration über slice/ z 
            for (int j = size; j < M - size; j++)
            {
                for (int i = size; i < N - size; i++)
                {
                    float summedupValues = 0f;
                    for (int y = -size; y < size + 1; y++)
                    {
                        for (int x = -size; x < size + 1; x++)
                        {
                            summedupValues += padding[(j + y) * N + (i + x)];
                        }
                    }
                    result[(i - size) + (j - size) * width_in] = summedupValues / (filtersize * filtersize);
                }
            }
            return result;
        }

        public float[] MedianFilter(float[] data_in, int width_in, int height_in, int filtersize)
        {
            int size = filtersize / 2;

            int N = width_in + size * 2;
            int M = height_in + size * 2;

            float[] padding = myPadder.CreatePadding(data_in, width_in, height_in, filtersize);
            float[] result = new float[width_in * height_in];

            List<float> filter = new();

            for (int j = size; j < M - size; ++j)
            {
                for (int i = size; i < N - size; ++i)
                {
                    var middelIndex = 0;
                    var middelValue = 0f;
                    for (int y = -size; y < size + 1; ++y)
                    {
                        for (int x = -size; x < size + 1; ++x)
                        {
                            filter.Add(padding[(j + y) * N + (i + x)]);
                        }
                    }
                    filter.Reverse();

                    middelIndex = (int)Math.Ceiling((decimal)filtersize / 2);
                    middelValue = filter[middelIndex];

                    result[(i - size) + (j - size) * width_in] = middelValue;
                    filter.Clear();
                }
            }
            return result;
        }
    }
}