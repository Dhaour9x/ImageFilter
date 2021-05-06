using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessing
{
    public class MirorPadding : IPadding
    {
        public float[] CreatePadding(float[] data_in, int width_in, int height_in, int filterSize)
        {
            int size = filterSize / 2;
            int N = width_in + size*2;
            int M = height_in + size*2;
            float[] padding = new float[N * M];
            for (int j = size; j < M-size; ++j)
            {
                int rowIndex = j * N;
                for (int i = size; i < N - size; ++i)
                {
                    int x = i - 1;
                    int y = j - 1;
                    // left
                    if (j < 1)
                    {
                        y = -j - y - 1;
                    }
                    //Top
                    if (i < 1)
                    {
                        x = -i - x - 1;
                    }
                    // right
                    if (j == M - 1)
                    {
                        y = height_in - 1;
                    }
                    //buttom
                    if (i == N - 1)
                    {
                        x = width_in - 1;
                    }
                    padding[i + rowIndex] = data_in[x + y * width_in];
                }
            }
            return padding;
        }
    }
}
