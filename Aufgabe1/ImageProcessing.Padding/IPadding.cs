using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessing
{
    public interface IPadding
    {
       public int FilterSize { get; }

        float[] CreatePadding(float[] data_in, int width_in, int height_in);
    }
}
