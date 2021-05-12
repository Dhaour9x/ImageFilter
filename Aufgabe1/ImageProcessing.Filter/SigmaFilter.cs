using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessing
{
    public class SigmaFilter : FilterBase
    {
        public SigmaFilter(IPadding _Padder) : base(_Padder)
        {
        }

        public float[] SigmaFilter2D(float[] data_in, int width_in, int height_in, int filtersize)
        {
            var size = filtersize / 2;
            var N = width_in + size * 2;
            var M = height_in + size * 2;

            float[] padding = myPadder.CreatePadding(data_in, width_in, height_in);
            float[] result = new float[width_in * height_in];
            var sigma = 0f;

            for (int j = size; j < M - size; ++j)
            {
                for (int i = size; i < N - size; ++i)
                {
                    for (int y = -size; y < size + 1; ++y)
                    {
                        for (int x = -size; x < size + 1; ++x)
                        {
                            sigma = (float)Math.Sqrt((Math.Abs(padding[((j + y) * N) + (i + x)] - data_in[(i - size) + (j - size) * width_in]) / (filtersize * filtersize)));
                            sigma += sigma;
                        }
                    }
                    result[(i - size) + (j - size) * width_in] = sigma;
                }
            }
            return result;
        }
    }
}
