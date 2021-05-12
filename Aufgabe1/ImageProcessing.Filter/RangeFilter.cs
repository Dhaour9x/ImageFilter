using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessing
{
    public class RangeFilter : FilterBase
    {
        public RangeFilter(IPadding _Padder) : base(_Padder)
        {
        }

        public float[] RangeFilter2D(float[] data_in, int width_in, int height_in, int filtersize)
        {
            int size = filtersize / 2;
            int N = width_in + size * 2; // + FilterSizes.X -1 statt size*2
            int M = height_in + size * 2; // + FilterSizes[1] -1 statt size*2
            // int D = depth_in + FilterSites[2] -1;
            float[] padding = myPadder.CreatePadding(data_in, width_in, height_in);

            float[] result = new float[width_in * height_in];
            List<float> filterList = new();
            for (int j = size; j < M - size; j++)
            {
                for (int i = size; i < N - size; i++)
                {
                    for (int y = -size; y < size + 1; y++)
                    {
                        for (int x = -size; x < size + 1; x++)
                        {
                            filterList.Add(padding[(j + y) * N + (i + x)]);
                            //summedupValues += padding[(j + y) * N + (i + x)];
                        }
                    }
                    filterList.Sort();
                    var maxIndex = filterList.Count;
                    var maximumValue = filterList[maxIndex];
                    var minimumValue = filterList.ElementAt(0);
                    var rangeValue = maximumValue - minimumValue;

                    result[(i - size) + (j - size) * width_in] = rangeValue;
                    //result[(i - size) + (j - size) * width_in] = summedupValues / (filtersize * filtersize);
                }
            }
            return result;
        }
    }
}
