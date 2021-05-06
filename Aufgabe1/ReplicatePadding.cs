using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessing
{
    public class ReplicatePadding : IPadding
    {
        public float[] CreatePadding(float[] data_in, int width_in, int height_in, int filterSize)
        {
            int N = width_in + 2;
            int M = height_in + 2;
            float[] padding = new float[M * N];

            for (int j = 0; j < M; j++)
            {
                int rowIndex = j * N;
                for (int i = 0; i < N; i++)
                {
                    int x = i - 1;
                    int y = j - 1;

                    // falls oberhalbs des Bilds
                    if (i < 1)
                    {
                        x += 1;
                    }
                    // links vom Bild
                    if (j < 1)
                    {
                        y += 1;
                    }
                    // rechte Border vom Bild
                    if (j == M - 1)
                    {
                        y = height_in - 1;
                    }
                    // untere Border vom Bild
                    if (i == N - 1)
                    {
                        x = width_in - 1;
                    }

                    padding[(i) + rowIndex] = data_in[x + y * width_in];

                }
            }

            return padding;
        }
    }
}
