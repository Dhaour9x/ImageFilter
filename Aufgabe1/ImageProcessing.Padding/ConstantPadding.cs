using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;

namespace ImageProcessing
{
    public class ConstantPadding : IPadding
    {
        public int Constant { get; private set; }

        public int FilterSize { get; private set; }

        public ConstantPadding(int filterSize, int _Constant)
        {
            Constant = _Constant;
            FilterSize = filterSize;
        }

        public float[] CreatePadding(float[] data_in, int width_in, int height_in)
        {
            int N = width_in + 2;
            int M = height_in + 2;

            float[] padding = new float[M * N];
            for (int i = 0; i < padding.Length; i++)
            {
                padding[i] = Constant;
            }

            int size = FilterSize / 2;
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
