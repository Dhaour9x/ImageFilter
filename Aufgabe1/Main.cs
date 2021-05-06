using System;
using System.Collections.Generic;
using System.Linq;

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

        enum PaddedType
        {
            PaddedConstant,
            PaddedReplicat,
            PaddedMirror,
        }

        static void Main(string[] args)
        {
            IPadding padder = Run(PaddedType.PaddedMirror);
            var mean2F = new Filter(padder);
            var result = mean2F.MeanFilter2D(A, 5, 3, 3);
            //Console.WriteLine(result.ToString());
            for (int i = 0; i < result.Length; i++)
            {
                Console.Write(result[i] +" ");
            }
        }

        private static IPadding Run(PaddedType paddType)
        {
            switch (paddType)
            {
                case PaddedType.PaddedConstant:
                    return new ConstantPadding(0);

                case PaddedType.PaddedReplicat:
                    return new ReplicatePadding();

                case PaddedType.PaddedMirror:
                    return new MirorPadding();

                default:
                    throw new ArgumentException($"'{paddType}' is not a valid logger selection");
            }
        }
    }
}
