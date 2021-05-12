using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessing
{
    public class MeanFilter : FilterBase
    {
        public MeanFilter(IPadding _Padder) : base(_Padder)
        {
        }

        public float[] MeanFilter2D(float[] data_in, int width_in, int height_in, int filtersize)
        {
            Stopwatch time = new Stopwatch();
            time.Start();
            int size = filtersize / 2;
            int N = width_in + size * 2;
            int M = height_in + size * 2; 

            float[] padding = myPadder.CreatePadding(data_in, width_in, height_in);

            float[] result = new float[width_in * height_in];

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
            time.Stop();
            TimeSpan ts = time.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);
            Console.WriteLine("RunTime " + elapsedTime);
            return result;
        }
    }
}
