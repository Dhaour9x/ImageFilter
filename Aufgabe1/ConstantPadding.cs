using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;

namespace ImageProcessing
{
    public class ConstantPadding : IPadding
    {
        public int Constant { get; set; }

        public ConstantPadding(int _Constant)
        {
            Constant = _Constant;
        }
        public float[] CreatePadding(float[] data_in, int width_in, int height_in, int filterSize)
        {
            int N = width_in + filterSize - 1;
            int M = height_in + filterSize - 1;

            float[] padding = new float[M * N];
            for (int i = 0; i < padding.Length; i++)
            {
                padding[i] = Constant;
            }

            int size = filterSize / 2;
            for (int j = size; j < M - size; j++)
            {
                int rowIndex = j * N;
                for (int i = size; i < N - size; i++)
                {
                    padding[(i) + rowIndex] = data_in[(i - size) + (j - size) * width_in];
                }
            }
            return padding;
        }
    }
}
