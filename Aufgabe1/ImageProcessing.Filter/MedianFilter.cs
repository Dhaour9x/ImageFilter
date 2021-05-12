using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessing
{
    public class MedianFilter : FilterBase
    {
        public MedianFilter(IPadding _Padder) : base(_Padder)
        {
        }

        public float[] MedianFilter2D(float[] data_in, int width_in, int height_in, int filtersize)
        {
            int size = filtersize / 2;

            int N = width_in + size * 2;
            int M = height_in + size * 2;

            float[] padding = myPadder.CreatePadding(data_in, width_in, height_in);
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
                    filter.Sort();

                    middelIndex = (int)Math.Floor((decimal)filter.Count / 2);
                    middelValue = filter[middelIndex];

                    result[(i - size) + (j - size) * width_in] = middelValue;
                    filter.Clear();
                }
            }
            return result;
        }
    }
}
