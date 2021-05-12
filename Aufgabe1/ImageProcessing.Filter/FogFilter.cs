using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessing
{
    public class FogFilter : FilterBase
    {
        public FogFilter(IPadding _Padder) : base(_Padder)
        {
        }

        public float[] FogFilter2D(float[] data_in, int width_in, int height_in, int filtersize)
        {
            var size = filtersize / 2;
            var N = width_in + size * 2;
            var M = height_in + size * 2;

            float[] padding = myPadder.CreatePadding(data_in, width_in, height_in);
            float[] result = new float[width_in * height_in];

            for (int j = size; j < M - size; ++j)
            {
                for (int i = size; i < N - size; ++i)
                {
                    var neighborcount = (filtersize * filtersize) - 1;
                    float summedupValues = 0f;
                    for (int y = -size; y < size + 1; y++)
                    {
                        for (int x = -size; x < size + 1; x++)
                        {
                            summedupValues += padding[(j + y) * N + (i + x)];
                        }
                    }
                    summedupValues -= data_in[i - 1 + j - 1];
                    float value = data_in[i - 1 + j - 1] * neighborcount;
                    summedupValues += value;
                    result[(i - size) + ((j - size) * width_in)] = (float)Math.Floor((decimal)summedupValues / (neighborcount + neighborcount));
                }
            }

            return result;
        }
    }
}
