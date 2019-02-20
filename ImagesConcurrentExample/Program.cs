using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Namespace for get some statistics 
using System.Diagnostics;
// Allow us to access into HD/SSD
using System.IO;
// For image management
using System.Drawing;



namespace ImagesConcurrentExample
{
    class Program
    {
        #region Global variables
        //The arroba at the beginning is for indicate to .NET that backslash character belongs to string
        static string imagePath = @"E:\Images";
        // Path for "filtering" result (new images)
        static string newImagePath = @"E:\NewImages";
        //For get the execution time
        static Stopwatch stopWatch = new Stopwatch();
        #endregion Global variables

        static void Main(string[] args)
        {
            SecuencialMethod();            
            ParallelMethod();
            Console.Read();
        }

        /// <summary>
        /// Apply the gray scale filter in secuencial way
        /// </summary>
        static void SecuencialMethod()
        {
            //Start to count time
            stopWatch.Start();

            //Secuencial method that apply grayscale filter to whole folder (images)
            foreach (string file in Directory.GetFiles(imagePath))
            {
                Bitmap bitmap = (Bitmap)Image.FromFile(file);
                bitmap = Filters.Filters.GrayScale(bitmap);
                bitmap.Save(newImagePath + "\\" + Path.GetFileNameWithoutExtension(file) + Guid.NewGuid().ToString() + ".jpg");
            }
            Console.WriteLine("Secuencial Foreah - execution time = {0} seconds\n", stopWatch.Elapsed.TotalSeconds);
            stopWatch.Reset();
        }

        /// <summary>
        /// Apply the gray scale filter in secuencial way
        /// </summary>
        static void ParallelMethod()
        {
            stopWatch.Start();

            //Secuencial method that apply grayscale filter to whole folder (images)
            Parallel.ForEach(Directory.GetFiles(imagePath), file =>
            {
                Bitmap bitmap = (Bitmap)Image.FromFile(file);
                bitmap = Filters.Filters.GrayScale(bitmap);
                bitmap.Save(newImagePath + "\\" + Path.GetFileNameWithoutExtension(file) + Guid.NewGuid().ToString() + ".jpg");
            });
            Console.WriteLine("Parallel Foraech - execution time = {0} seconds\n", stopWatch.Elapsed.TotalSeconds);
            stopWatch.Reset();
        }
    }
}
