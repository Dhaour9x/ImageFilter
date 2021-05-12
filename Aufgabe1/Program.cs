using System;
using System.Collections.Generic;
using System.Linq;
using ImageProcessing;

namespace ImageProcessing
{
    public class Program
    {
        public static float[] A = new[]
        {
            5.0000f, 7.0000f, 8.0000f, 46.0000f, 6.0000f,
            0.0000f, 1.0000f, 9.0000f, 37.0000f, 7.0000f,
            4.0000f, 3.0000f, 29.0000f, 6.0000f, 2.0000f
        };

        public static float[] TestSlice = new[]
       {
            5f,  7f,  8f, 46f,  6f,  0f,  1f,  9f, 37f, 7f,
            4f,  3f, 29f,  6f,  2f, 15f, 47f,  4f, 28f, 6f,
           40f, 19f,  1f,  9f, 37f, 44f, 38f,  5f, 16f, 2f,
            1f,  0f, 30f,  4f,  1f,  3f, 45f,  5f,  6f, 9f,
            9f, 49f,  8f,  7f,  6f, 21f,  3f, 10f,  4f, 41f,
           35f,  4f, 55f, 26f,  9f, 39f,  2f, 18f,  7f,  6f
        };

        enum PaddedType
        {
            PaddedConstant,
            PaddedReplicat,
            PaddedMirror,
        }

        static void Main(string[] args)
        {
           // IPadding padderOld = GetPaddingByType(PaddedType.PaddedConstant);
            //((ConstantPadding)padderOld).Constant = 5;
            IPadding padder = new ConstantPadding(3, 1);
            //IPadding padder2 = new ReplicatePadding();


            //var mean2F = new Filter(padder);
            var meanFilt = new MeanFilter(padder);
            var result1 = meanFilt.MeanFilter2D(A, 5, 3, 3);
            //Console.WriteLine(result.ToString());
            for (int i = 0; i < result1.Length; i++)
            {
                Console.Write(result1[i] + " ");
            }
            

            //var result2 = mean2F.SigmaFilter(A, 5, 3, 3);
            //for (int i = 0; i < result2.Length; i++)
            //{
            //    Console.Write(result2.ElementAt(i) + " ");
            //}

            //var result3 = mean2F.FogFilter(A, 5, 3, 3);
            //for (int i = 0; i < result3.Length; i++)
            //{
            //    Console.Write(result3.ElementAt(i) + " ");
            //}
        }

        //private static IPadding GetPaddingByType(PaddedType paddType)
        //{
        //    return paddType switch
        //    {
        //       // PaddedType.PaddedConstant => new ConstantPadding(3,0),
        //        PaddedType.PaddedReplicat => new ReplicatePadding(),
        //        PaddedType.PaddedMirror => new MirorPadding(3),
        //        _ => throw new ArgumentException($"'{paddType}' is not a valid logger selection"),
        //    };
        //}
    }
}
