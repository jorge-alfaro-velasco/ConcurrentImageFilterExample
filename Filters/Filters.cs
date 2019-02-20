using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// For image management
using System.Drawing;

namespace Filters
{
    /// <summary>
    /// Gray scale methods
    /// </summary>
    public class Filters
    {
        /// <summary>
        /// Apply gray scale filter
        /// </summary>
        /// <param name="source">image location</param>
        /// <returns>Image in gray scale</returns>
        public static Bitmap GrayScale(Bitmap source)
        {
            Bitmap bm = new Bitmap(source.Width, source.Height);
            for (int y = 0; y < bm.Height; y++)
            {
                for (int x = 0; x < bm.Width; x++)
                {
                    Color c = source.GetPixel(x, y);
                    int average = (Convert.ToInt32(c.R) + Convert.ToInt32(c.G) + Convert.ToInt32(c.B)) / 3;
                    bm.SetPixel(x, y, Color.FromArgb(average, average, average));
                }
            }
            return bm;
        }
    }
}
